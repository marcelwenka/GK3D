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
        double n = 1;
        double f = 100;
        double fov = 33.333;
        double a;
        double e = 2.414214;
        Matrix<double> projectionMatrix;
        Matrix<double> viewMatrix;
        Matrix<double> modelMatrix;
        DirectBitmap canvas;
        List<Vector<double>> points;
        List<(int, int)> edges;
        Timer timer;
        double i = 0;

        public Form()
        {
            InitializeComponent();

            a = (double)pictureBox.Height / (double)pictureBox.Width;
            e = 1 / Math.Tan(fov / 2);
            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            points = new List<Vector<double>>();
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 0, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 0, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 1, 0, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 1, 0, 1 }));

            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 0, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 0, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 1, 1, 1, 1 }));
            points.Add(Vector<double>.Build.Dense(new double[4] { 0, 1, 1, 1 }));

            edges = new List<(int, int)>() { (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 7), (1, 2), (1, 5), (2, 3), (2, 5), (2, 6), (2, 7), (3, 7), (4, 5), (4, 7), (5, 6), (5, 7), (6, 7) };

            projectionMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { e, 0, 0, 0 },
                    { 0, e/a, 0, 0 },
                    { 0, 0, -(f+n)/(f-n), -2*f*n/(f-n) },
                    { 0, 0, -1, 0 }
                }
            );

            viewMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 0, 1, 0, -0.5 },
                    { 0, 0, 1, -0.5 },
                    { 1, 0, 0, -3 },
                    { 0, 0, 0, 1 }
                }
            );

            modelMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0.5 },
                    { 0, 1, 0, 0.4 },
                    { 0, 0, 1, 0.3 },
                    { 0, 0, 0, 1 }
                }
            );

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Animation;
            timer.Start();
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
            var matrix = projectionMatrix * viewMatrix * modelMatrix;
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
                //canvas.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Navy);
            }

            using (var graphics = Graphics.FromImage(canvas.Bitmap))
            {
                graphics.Clear(Color.White);
                foreach (var e in edges)
                {
                    graphics.DrawLine(Pens.Black, calculatedPoints[e.Item1], calculatedPoints[e.Item2]);
                }
            }

            pictureBox.Image = canvas.Bitmap;
        }

        private void Form_Resize(object sender, EventArgs eventArgs)
        {
            a = (double)pictureBox.Height / (double)pictureBox.Width;
            projectionMatrix[1, 1] = e / a;
            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);
        }
    }
}
