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
    partial class Form
    {
        double[,] zBuffor;
        bool drawTriangleEdges = false;
        ShaderType shaderType = ShaderType.Phong;
        int width;
        int height;

        public void Draw()
        {
            ReinitializeZBuffor();

            canvas.Clear(Color.Black);

            if (parallel)
                Parallel.ForEach(models, model => DrawModel(model));
            else
                foreach (var model in models)
                    DrawModel(model);

            pictureBox.Image = canvas.Bitmap;
        }

        public void DrawModel(IModel model)
        {
            var matrix = projectionMatrix.Matrix * viewMatrix.Matrix;
            var projectionPoints = new List<Vertex>();

            foreach (var point in model.Points)
            {
                var worldPoint = model.Matrix * point;

                var projectionPoint = matrix * worldPoint;

                if (projectionPoint[3] != 0)
                    for (int i = 0; i < 3; i++)
                        projectionPoint[i] /= projectionPoint[3];
                projectionPoint[3] = 1;

                double x = (projectionPoint[0] + 1) * pictureBox.Width / 2;
                double y = (projectionPoint[1] + 1) * pictureBox.Height / 2;

                Vector<double> N = null;

                if (model is Sphere)
                    N = (model as Sphere).N(worldPoint[0], worldPoint[1], worldPoint[2]);

                projectionPoints.Add(new Vertex()
                {
                    projectionX = (int)Math.Round(x),
                    projectionY = (int)Math.Round(y),
                    projectionZ = -(projectionPoint[2] - 1) * 1000,
                    worldX = worldPoint[0],
                    worldY = worldPoint[1],
                    worldZ = worldPoint[2],
                    N = N
                });
            }

            model.Triangles = model.TriangleIndexes.Select(indexes =>
                new Triangle(
                    projectionPoints[indexes.Item1].Clone(),
                    projectionPoints[indexes.Item2].Clone(),
                    projectionPoints[indexes.Item3].Clone())
                ).ToList();

            if (model is Cuboid)
            {
                foreach (Triangle triangle in model.Triangles)
                {
                    triangle.points[0].N = (model as Cuboid).N(triangle);
                    triangle.points[1].N = (model as Cuboid).N(triangle);
                    triangle.points[2].N = (model as Cuboid).N(triangle);
                }
            }

            foreach (var triangle in model.Triangles)
            {
                try // when resizing the window or changing from Phong to Gouraud some calculations are interrupted in the middle, needed structures are non-existent and an exception is thrown
                {
                    Fill(model, triangle);
                }
                catch { }
            }
        }

        public void ReinitializeZBuffor()
        {
            zBuffor = new double[width, height];
        }

        public void Fill(IModel model, Triangle triangle)
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
                    
                    N = triangle.InterpolateN(0.333, 0.333, 0.333);
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
            int upperBound = triangle.points[indexes[2]].projectionY >= canvas.Height ? canvas.Height - 1 : triangle.points[indexes[2]].projectionY;

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
                    var prev = triangle.points[Triangle.Prev(indexes[k])];
                    var current = triangle.points[indexes[k]];
                    var next = triangle.points[Triangle.Next(indexes[k])];

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
                    int xUpperBound = (int)Math.Round(AET[i + 1].x) < canvas.Width ? (int)Math.Round(AET[i + 1].x) : canvas.Width;
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
                                    canvas.SetPixel(x, y, constantColor);
                                    break;
                                case ShaderType.Gouraud:
                                    Color gouraudColor = ColorCalculation.Gouraud(gouraudColors, w0, w1, w2);
                                    canvas.SetPixel(x, y, gouraudColor);
                                    break;
                                case ShaderType.Phong:

                                    N = triangle.InterpolateN(w0, w1, w2);
                                    Color phongColor = ColorCalculation.Phong(triangle.InterpolateXYZ(w0, w1, w2), N, model.Color);
                                    canvas.SetPixel(x, y, phongColor);
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

            if (drawTriangleEdges)
            {
                DrawLine(triangle, triangle.points[0], triangle.points[1]);
                DrawLine(triangle, triangle.points[0], triangle.points[2]);
                DrawLine(triangle, triangle.points[1], triangle.points[2]);
            }
        }

        private void SetPixel(Triangle triangle, int x, int y, Color color)
        {
            if (0 <= x && x < canvas.Width && 0 <= y && y < canvas.Height)
            {
                double w0, w1, w2;
                (w0, w1, w2) = triangle.GetWeights(x, y);
                double z = triangle.Z(w0, w1, w2);
                if (z >= zBuffor[x, y])
                {
                    zBuffor[x, y] = z;
                    canvas.SetPixel(x, y, color);
                }
            }
        }

        // Bresenham's line algorithm
        public void DrawLine(Triangle triangle, Vertex from, Vertex to)
        {
            Color lineColor = Color.RoyalBlue;

            int d, dx, dy, ai, bi, xi, yi;
            int x1 = from.projectionX, y1 = from.projectionY, x2 = to.projectionX, y2 = to.projectionY;
            int x = x1, y = y1;

            // ustalenie kierunku rysowania
            dx = Math.Abs(x2 - x1);
            xi = Math.Sign(x2 - x1);
            dy = Math.Abs(y2 - y1);
            yi = Math.Sign(y2 - y1);

            // pierwszy piksel
            SetPixel(triangle, x, y, lineColor);

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
                    SetPixel(triangle, x, y, lineColor);
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
                    SetPixel(triangle, x, y, lineColor);
                }
            }
        }
    }
}
