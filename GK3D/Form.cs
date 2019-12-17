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
        ProjectionMatrix projectionMatrix;
        Matrix<double> viewMatrix;
        Matrix<double> modelMatrix;
        DirectBitmap canvas;
        List<Vector<double>> points;
        List<Triangle> triangles;
        Timer timer;
        double i = 0;

        public Form()
        {
            InitializeComponent();

            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / (double)pictureBox.Width);

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            InitializeTriangles();

            InitializeViewMatrix();
            InitializeModelMatrix();

            timer = new Timer();
            timer.Interval = 33;
            timer.Tick += Animation;
            timer.Start();
        }

        private void InitializeViewMatrix()
        {
            viewMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 0, 1, 0, -0.5 },
                    { 0, 0, 1, -0.5 },
                    { 1, 0, 0, -3 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        private void InitializeModelMatrix()
        {
            modelMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0.5 },
                    { 0, 1, 0, 0.4 },
                    { 0, 0, 1, 0.3 },
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
        }

        private void Animation(object sender, EventArgs eventArgs)
        {
            i += 0.1;
            i %= 100;

            modelMatrix[0, 0] = Math.Cos(i);
            modelMatrix[0, 1] = -Math.Sin(i);
            modelMatrix[1, 0] = Math.Sin(i);
            modelMatrix[1, 1] = Math.Cos(i);

            Draw();
        }

        public void Draw()
        {
            var matrix = projectionMatrix.Matrix * viewMatrix * modelMatrix;
            var calculatedPoints = new List<Point>();

            foreach (var p in points)
            {
                var calculatedPoint = matrix * p;

                for (int i = 0; i < 4; i++)
                {
                    calculatedPoint[i] /= calculatedPoint[3];
                }

                double x = (calculatedPoint[0] + 1) * pictureBox.Width / 2;
                double y = (calculatedPoint[1] + 1) * pictureBox.Height / 2;

                calculatedPoints.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            }

            triangles = new List<Triangle>();

            triangles.Add(new Triangle(calculatedPoints[0], calculatedPoints[1], calculatedPoints[2]));
            triangles.Add(new Triangle(calculatedPoints[0], calculatedPoints[3], calculatedPoints[2]));

            triangles.Add(new Triangle(calculatedPoints[1], calculatedPoints[2], calculatedPoints[6]));
            triangles.Add(new Triangle(calculatedPoints[1], calculatedPoints[5], calculatedPoints[6]));

            triangles.Add(new Triangle(calculatedPoints[0], calculatedPoints[1], calculatedPoints[5]));
            triangles.Add(new Triangle(calculatedPoints[0], calculatedPoints[4], calculatedPoints[5]));

            triangles.Add(new Triangle(calculatedPoints[2], calculatedPoints[3], calculatedPoints[7]));
            triangles.Add(new Triangle(calculatedPoints[2], calculatedPoints[6], calculatedPoints[7]));

            triangles.Add(new Triangle(calculatedPoints[3], calculatedPoints[0], calculatedPoints[4]));
            triangles.Add(new Triangle(calculatedPoints[3], calculatedPoints[7], calculatedPoints[4]));

            triangles.Add(new Triangle(calculatedPoints[5], calculatedPoints[4], calculatedPoints[7]));
            triangles.Add(new Triangle(calculatedPoints[5], calculatedPoints[6], calculatedPoints[7]));

            using (var graphics = Graphics.FromImage(canvas.Bitmap))
            {
                graphics.Clear(Color.White);
                foreach (var triangle in triangles)
                {
                    Fill(triangle);
                }
            }

            pictureBox.Image = canvas.Bitmap;
        }

        private void Form_Resize(object sender, EventArgs eventArgs)
        {
            projectionMatrix.a = (double)pictureBox.Height / (double)pictureBox.Width;
            projectionMatrix.Matrix[1, 1] = projectionMatrix.e / projectionMatrix.a;
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
                        Color c = Color.Navy;
                        canvas.SetPixel(x, (int)Math.Round(y), c);
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
