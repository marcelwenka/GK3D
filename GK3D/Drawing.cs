using GK3D.Models;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public static class Drawing
    {
        public static double[,] zBuffor;
        public static bool drawLines = false;
        public static ShaderType shaderType = ShaderType.Phong;
        public static int width;
        public static int height;

        public static void ReinitializeZBuffor()
        {
            zBuffor = new double[width, height];
        }

        public static void Fill(this DirectBitmap bitmap, Triangle triangle, IModel model)
        {
            var indexes = triangle.GetSortedIndexes();
            var AET = new List<AETNode>();
            int k = 0;

            Vector<double> N = null;

            Color constantColor = Color.Empty;
            Color[] gouraudColors = null;

            if (model is Cuboid)
                N = (model as Cuboid).N(triangle);

            switch (shaderType)
            {
                case ShaderType.Constant:
                {
                    var coordinates = Vector<double>.Build.Dense(new double[3]
                    {
                        (triangle.points[0].worldX + triangle.points[1].worldX + triangle.points[2].worldX) / 3.0,
                        (triangle.points[0].worldY + triangle.points[1].worldY + triangle.points[2].worldY) / 3.0,
                        (triangle.points[0].worldZ + triangle.points[1].worldZ + triangle.points[2].worldZ) / 3.0
                    });
                    
                    N = triangle.interpolateN(0.333, 0.333, 0.333);
                    constantColor = ColorCalculation.Phong(coordinates, N, model.Color);
                    
                    break;
                }
                case ShaderType.Gouraud:
                {
                    gouraudColors = new Color[3]
                    {
                        ColorCalculation.Phong(triangle.points[0], model.Color),
                        ColorCalculation.Phong(triangle.points[1], model.Color),
                        ColorCalculation.Phong(triangle.points[2], model.Color)
                    };
                    break;
                }
            }

            int lowerBound = triangle.points[indexes[0]].projectionY;
            int upperBound = triangle.points[indexes[2]].projectionY >= bitmap.Height ? bitmap.Height - 1 : triangle.points[indexes[2]].projectionY;

            if (lowerBound < 0)
            {
                if (upperBound < 0)
                    return;

                lowerBound = 0;

                AET.Add(new AETNode(triangle.points[indexes[2]], triangle.points[indexes[0]]));
                if (triangle.points[indexes[1]].projectionY < 0)
                {
                    AET.Add(new AETNode(triangle.points[indexes[1]], triangle.points[indexes[2]]));
                    k = 2;
                }
                else
                {
                    AET.Add(new AETNode(triangle.points[indexes[0]], triangle.points[indexes[1]]));
                    k = 1;
                }

                foreach (var aetNode in AET)
                    aetNode.x += aetNode.xd * -aetNode.p1.projectionY;

                AET.Sort((p1, p2) => (int)(p1.x - p2.x));
            }

            for (int y = lowerBound; y <= upperBound; y++)
            {
                while (triangle.points[indexes[k]].projectionY == y - 1)
                {
                    var prev = triangle.points[Triangle.prev(indexes[k])];
                    var current = triangle.points[indexes[k]];
                    var next = triangle.points[Triangle.next(indexes[k])];

                    if (prev.projectionY > current.projectionY)
                        AET.Add(new AETNode(prev, current));
                    else
                        AET.RemoveAll(aetn => aetn.p2.projectionY == current.projectionY);

                    if (next.projectionY > current.projectionY)
                        AET.Add(new AETNode(current, next));
                    else
                        AET.RemoveAll(aetn => aetn.p2.projectionY == current.projectionY);

                    k++;
                }

                if (AET.Count > 0 && AET[1].x < AET[0].x)
                {
                    AET.Add(AET[0]);
                    AET.RemoveAt(0);
                }

                for (int i = 0; i < AET.Count; i += 2)
                {
                    int xLowerBound = (int)AET[i].x >= 0 ? (int)AET[i].x : 0;
                    int xUpperBound = (int)Math.Round(AET[i + 1].x) < bitmap.Width ? (int)Math.Round(AET[i + 1].x) : bitmap.Width;
                    for (int x = xLowerBound; x < xUpperBound; x++)
                    {
                        double w0, w1, w2;
                        (w0, w1, w2) = triangle.GetWeights(x, y);
                        double z = triangle.Z(w0, w1, w2);
                        if (z >= zBuffor[x, y])
                        {
                            zBuffor[x, y] = z;

                            switch (shaderType)
                            {
                                case ShaderType.Constant:
                                    bitmap.SetPixel(x, y, constantColor);
                                    break;
                                case ShaderType.Gouraud:
                                    Color gouraudColor = ColorCalculation.Gouraud(gouraudColors, w0, w1, w2);
                                    bitmap.SetPixel(x, y, gouraudColor);
                                    break;
                                case ShaderType.Phong:

                                    N = triangle.interpolateN(w0, w1, w2);
                                    Color phongColor = ColorCalculation.Phong(triangle.interpolateXYZ(w0, w1, w2), N, model.Color);
                                    bitmap.SetPixel(x, y, phongColor);
                                    break;
                            }
                        }
                    }
                }
                foreach (var aetn in AET)
                {
                    aetn.x += aetn.xd;
                }
            }

            if (drawLines)
            {
                bitmap.DrawLine(triangle, triangle.points[0], triangle.points[1]);
                bitmap.DrawLine(triangle, triangle.points[0], triangle.points[2]);
                bitmap.DrawLine(triangle, triangle.points[1], triangle.points[2]);
            }
        }

        public static void DrawLine(this DirectBitmap bitmap, Triangle triangle, Vertex from, Vertex to)
        {
            Color lineColor = Color.RoyalBlue;
            // Bresenham's line algorithm
            // zmienne pomocnicze
            int d, dx, dy, ai, bi, xi, yi;
            int x1 = from.projectionX, y1 = from.projectionY, x2 = to.projectionX, y2 = to.projectionY;
            int x = x1, y = y1;
            // ustalenie kierunku rysowania
            dx = Math.Abs(x2 - x1);
            xi = Math.Sign(x2 - x1);
            dy = Math.Abs(y2 - y1);
            yi = Math.Sign(y2 - y1);
            // pierwszy piksel
            if (0 <= x && x < bitmap.Width && 0 <= y && y < bitmap.Height)
            {
                double w0, w1, w2;
                (w0, w1, w2) = triangle.GetWeights(x, y);
                double z = triangle.Z(w0, w1, w2);
                if (z >= zBuffor[x, y])
                {
                    zBuffor[x, y] = z;
                    bitmap.SetPixel(x, y, lineColor);
                }
            }
            // oś wiodąca OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // pętla po kolejnych x
                while (x != x2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    if (0 <= x && x < bitmap.Width && 0 <= y && y < bitmap.Height)
                    {
                        double w0, w1, w2;
                        (w0, w1, w2) = triangle.GetWeights(x, y);
                        double z = triangle.Z(w0, w1, w2);
                        if (z >= zBuffor[x, y])
                        {
                            zBuffor[x, y] = z;
                            bitmap.SetPixel(x, y, lineColor);
                        }
                    }
                }
            }
            // oś wiodąca OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // pętla po kolejnych y
                while (y != y2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    if (0 <= x && x < bitmap.Width && 0 <= y && y < bitmap.Height)
                    {
                        double w0, w1, w2;
                        (w0, w1, w2) = triangle.GetWeights(x, y);
                        double z = triangle.Z(w0, w1, w2);
                        if (z >= zBuffor[x, y])
                        {
                            zBuffor[x, y] = z;
                            bitmap.SetPixel(x, y, lineColor);
                        }
                    }
                }
            }
        }
    }
}
