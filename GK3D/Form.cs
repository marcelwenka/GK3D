using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK3D
{
    public partial class Form : System.Windows.Forms.Form
    {
        DirectBitmap canvas;
        List<Object> objects;
        List<Vector<double>> points;
        Timer timer;
        double i = 0;
        double[,] zBuffor;

        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            ReinitializeZBuffor();

            objects = new List<Object>();

            objects.Add(new Object((double)pictureBox.Height / pictureBox.Width));
            objects.Add(new Object((double)pictureBox.Height / pictureBox.Width));

            objects[0].viewMatrix = InitializeViewMatrix();
            objects[0].modelMatrix = InitializeModelMatrix1();

            objects[1].viewMatrix = InitializeViewMatrix();
            objects[1].modelMatrix = InitializeModelMatrix2();

            InitializeTriangles();

            timer = new Timer();
            timer.Interval = 33;
            timer.Tick += Animation;
            timer.Start();
        }

        private void ReinitializeZBuffor()
        {
            zBuffor = new double[pictureBox.Width, pictureBox.Height];
            ClearZBuffor();
        }
       
        private void ClearZBuffor()
        {
            for (int i = 0; i < pictureBox.Width; i++)
            {
                for (int j = 0; j < pictureBox.Height; j++)
                {
                    zBuffor[i, j] = 1;
                }
            }
        }

        private Matrix<double> InitializeViewMatrix()
        {
            return DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 0, 1, 0, -0.5 },
                    { 0, 0, 1, -0.5 },
                    { 1, 0, 0, -3 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        private Matrix<double> InitializeModelMatrix1()
        {
            return DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0.5 },
                    { 0, 1, 0, 0.4 },
                    { 0, 0, 1, 0.3 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        private Matrix<double> InitializeModelMatrix2()
        {
            return DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        private void InitializeTriangles()
        {
            points = new List<Vector<double>>();
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 0, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 0, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 1, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 1, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 0, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 0, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 1, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 1, 1, 1 }));

            Random random = new Random();
            foreach (var ob in objects)
            {
                ob.triangles = new List<Triangle>();
                for (int i = 0; i < 6; i++)
                {
                    var color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    ob.triangles.Add(new Triangle(new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), color));
                    ob.triangles.Add(new Triangle(new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), color));
                }
            }
        }

        private void Animation(object sender, EventArgs eventArgs)
        {
            i += 0.05;
            i %= 100;

            objects[0].modelMatrix[0, 0] = Math.Cos(i);
            objects[0].modelMatrix[0, 1] = Math.Sin(i);
            objects[0].modelMatrix[1, 0] = -Math.Sin(i);
            objects[0].modelMatrix[1, 1] = Math.Cos(i);

            objects[1].modelMatrix[1, 1] = Math.Cos(3 * i);
            objects[1].modelMatrix[1, 2] = Math.Sin(3 * i);
            objects[1].modelMatrix[2, 1] = -Math.Sin(3 * i);
            objects[1].modelMatrix[2, 2] = Math.Cos(3 * i);

            Draw();
        }

        public void Draw()
        {
            ClearZBuffor();

            using (var graphics = Graphics.FromImage(canvas.Bitmap))
            {
                graphics.Clear(Color.White);
            }

            foreach (var ob in objects)
            {
                var matrix = ob.projectionMatrix.Matrix * ob.viewMatrix * ob.modelMatrix;
                var calculatedPoints = new List<Vertex>();

                foreach (var p in points)
                {
                    var calculatedPoint = matrix * p;

                    for (int i = 0; i < 4; i++)
                    {
                        calculatedPoint[i] /= calculatedPoint[3];
                    }

                    double x = (calculatedPoint[0] + 1) * pictureBox.Width / 2;
                    double y = (calculatedPoint[1] + 1) * pictureBox.Height / 2;

                    calculatedPoints.Add(new Vertex((int)Math.Round(x), (int)Math.Round(y), calculatedPoint[2]));
                }

                ob.triangles[0].points = new Vertex[3] { calculatedPoints[0], calculatedPoints[1], calculatedPoints[2] };
                ob.triangles[1].points = new Vertex[3] { calculatedPoints[0], calculatedPoints[3], calculatedPoints[2] };

                ob.triangles[2].points = new Vertex[3] { calculatedPoints[1], calculatedPoints[2], calculatedPoints[6] };
                ob.triangles[3].points = new Vertex[3] { calculatedPoints[1], calculatedPoints[5], calculatedPoints[6] };

                ob.triangles[4].points = new Vertex[3] { calculatedPoints[0], calculatedPoints[1], calculatedPoints[5] };
                ob.triangles[5].points = new Vertex[3] { calculatedPoints[0], calculatedPoints[4], calculatedPoints[5] };

                ob.triangles[6].points = new Vertex[3] { calculatedPoints[2], calculatedPoints[3], calculatedPoints[7] };
                ob.triangles[7].points = new Vertex[3] { calculatedPoints[2], calculatedPoints[6], calculatedPoints[7] };

                ob.triangles[8].points = new Vertex[3] { calculatedPoints[3], calculatedPoints[0], calculatedPoints[4] };
                ob.triangles[9].points = new Vertex[3] { calculatedPoints[3], calculatedPoints[7], calculatedPoints[4] };

                ob.triangles[10].points = new Vertex[3] { calculatedPoints[5], calculatedPoints[4], calculatedPoints[7] };
                ob.triangles[11].points = new Vertex[3] { calculatedPoints[5], calculatedPoints[6], calculatedPoints[7] };

                foreach (var triangle in ob.triangles)
                {
                    Fill(triangle);
                }
            }

            pictureBox.Image = canvas.Bitmap;
        }

        private void Form_Resize(object sender, EventArgs eventArgs)
        {
            ReinitializeZBuffor();

            foreach (var ob in objects)
            {
                ob.projectionMatrix.a = (double)pictureBox.Height / (double)pictureBox.Width;
                ob.projectionMatrix.Matrix[1, 1] = ob.projectionMatrix.e / ob.projectionMatrix.a;
            }
            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);
        }

        private void Fill(Triangle triangle)
        {
            var indexes = triangle.GetSortedIndexes();
            var AET = new List<AETNode>();
            int k = 0;

            for (double y = triangle.points[indexes[0]].Y; y <= triangle.points[indexes[2]].Y; y++)
            {
                while (triangle.points[indexes[k]].Y == y - 1)
                {
                    var prev = triangle.points[Triangle.prev(indexes[k])];
                    var current = triangle.points[indexes[k]];
                    var next = triangle.points[Triangle.next(indexes[k])];

                    if (prev.Y >= current.Y)
                        AET.Add(new AETNode(prev, current));
                    else
                        AET.RemoveAll(aetn => aetn.p1 == prev && aetn.p2 == current);

                    if (next.Y >= current.Y)
                        AET.Add(new AETNode(current, next));
                    else
                        AET.RemoveAll(aetn => aetn.p1 == current && aetn.p2 == next);

                    k++;
                }

                AET.Sort((p1, p2) => (int)(p1.x - p2.x));
                for (int i = 0; i < AET.Count; i += 2)
                {
                    for (int x = (int)AET[i].x; x < AET[i + 1].x; x++)
                    {
                        int yint = (int)Math.Round(y);
                        double z = triangle.Z(x, yint);
                        if (x >= 0 && x < pictureBox.Width && y >= 0 && y < pictureBox.Height && z <= zBuffor[x, yint])
                        {
                            zBuffor[x, yint] = z;
                            canvas.SetPixel(x, yint, triangle.color);
                        }
                    }
                }
                foreach (var aetn in AET)
                {
                    aetn.x += aetn.xd;
                }
            }
        }
    }
}
