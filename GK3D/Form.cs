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
        ViewMatrix viewMatrix;
        DirectBitmap canvas;
        List<Shape> objects;
        List<Vector<double>> points;
        Vector<double> defaultCameraPosition = Vector<double>.Build.DenseOfArray(new double[3] { 4, 0.5, 0.5 });
        Timer timer;
        CameraType cameraType = CameraType.Fixed;
        double i = 0;
        double[,] zBuffor;


        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            cameraComboBox.DataSource = Enum.GetValues(typeof(CameraType));

            ReinitializeZBuffor();
            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / pictureBox.Width);

            objects = new List<Shape>();

            objects.Add(new Shape());
            objects.Add(new Shape());

            objects[0].modelMatrix = InitializeModelMatrix1();
            objects[1].modelMatrix = InitializeModelMatrix2();

            InitializeFixedViewMatrix();

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

        private void InitializeFixedViewMatrix()
        {
            viewMatrix = new ViewMatrix(
                defaultCameraPosition,
                Vector<double>.Build.DenseOfArray(new double[3] { 0, 0.5, 0.5 }),
                Vector<double>.Build.DenseOfArray(new double[3] { 0, 0, 1 })
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
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { -0.5, -0.5, -0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { 0.5, -0.5, -0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { 0.5, 0.5, -0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { -0.5, 0.5, -0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { -0.5, -0.5, 0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { 0.5, -0.5, 0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { 0.5, 0.5, 0.5, 0.5 }));
            points.Add(Vector<double>.Build.DenseOfArray(new double[4] { -0.5, 0.5, 0.5, 0.5 }));

            Random random = new Random();
            foreach (var ob in objects)
            {
                var color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                ob.triangles = new List<Triangle>();
                for (int i = 0; i < 6; i++)
                {
                    ob.triangles.Add(new Triangle(new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), color));
                    ob.triangles.Add(new Triangle(new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), color));
                }
            }
        }

        private void Animation(object sender, EventArgs eventArgs)
        {
            i += 0.02;
            i %= 2*Math.PI;

            if (i < Math.PI)
                objects[1].modelMatrix[1, 3] = i;
            else
                objects[1].modelMatrix[1, 3] = 2 * Math.PI - i;

            switch (cameraType)
            {
                case CameraType.Fixed:
                    break;
                case CameraType.Following:
                    viewMatrix.CameraPosition = defaultCameraPosition + Vector<double>.Build.DenseOfArray(new double[3] { objects[1].modelMatrix[0, 3], objects[1].modelMatrix[1, 3], objects[1].modelMatrix[2, 3] });
                    viewMatrix.CameraTarget = Vector<double>.Build.DenseOfArray(new double[3] { objects[1].modelMatrix[0, 3], objects[1].modelMatrix[1, 3], objects[1].modelMatrix[2, 3] });
                    break;
                case CameraType.FixedFollowing:
                    viewMatrix.CameraPosition = defaultCameraPosition;
                    viewMatrix.CameraTarget = Vector<double>.Build.DenseOfArray(new double[3] { objects[1].modelMatrix[0, 3], objects[1].modelMatrix[1, 3], objects[1].modelMatrix[2, 3] });
                    break;
            }

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
                graphics.Clear(Color.Black);
            }

            foreach (var ob in objects)
            {
                var matrix = projectionMatrix.Matrix * viewMatrix.Matrix * ob.modelMatrix;
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

                //Parallel.ForEach(ob.triangles, triangle =>
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

            projectionMatrix.a = (double)pictureBox.Height / pictureBox.Width;
            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);
        }

        private void Fill(Triangle triangle)
        {
            var indexes = triangle.GetSortedIndexes();
            var AET = new List<AETNode>();
            int k = 0;

            int lowerBound = triangle.points[indexes[0]].Y;
            int upperBound = triangle.points[indexes[2]].Y >= pictureBox.Height ? pictureBox.Height - 1 : triangle.points[indexes[2]].Y;
            
            if (lowerBound < 0)
            {
                if (upperBound < 0)
                    return;

                lowerBound = 0;

                AET.Add(new AETNode(triangle.points[indexes[2]], triangle.points[indexes[0]]));
                if (triangle.points[indexes[1]].Y < 0)
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
                    aetNode.x += aetNode.xd * -aetNode.p1.Y;

                AET.Sort((p1, p2) => (int)(p1.x - p2.x));
            }

            for (int y = lowerBound; y <= upperBound; y++)
            {
                while (triangle.points[indexes[k]].Y == y - 1)
                {
                    var prev = triangle.points[Triangle.prev(indexes[k])];
                    var current = triangle.points[indexes[k]];
                    var next = triangle.points[Triangle.next(indexes[k])];

                    if (prev.Y >= current.Y)
                        AET.Add(new AETNode(prev, current));
                    else
                        AET.RemoveAll(aetn => aetn.p2.Y == current.Y);

                    if (next.Y >= current.Y)
                        AET.Add(new AETNode(current, next));
                    else
                        AET.RemoveAll(aetn => aetn.p2.Y == current.Y);

                    k++;
                }

                AET.Sort((p1, p2) => (int)(p1.x - p2.x));
                for (int i = 0; i < AET.Count; i += 2)
                {
                    int xLowerBound = (int)AET[i].x >= 0 ? (int)AET[i].x : 0;
                    int xUpperBound = (int)Math.Round(AET[i + 1].x) < pictureBox.Width ? (int)Math.Round(AET[i + 1].x) : pictureBox.Width;
                    for (int x = xLowerBound; x < xUpperBound; x++)
                    {
                        double z = triangle.Z(x, y);
                        if (z < zBuffor[x, y])
                        {
                            zBuffor[x, y] = z;
                            canvas.SetPixel(x, y, triangle.color);
                        }
                    }
                }
                foreach (var aetn in AET)
                {
                    aetn.x += aetn.xd;
                }
            }
        }

        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraType = (CameraType)cameraComboBox.SelectedItem;
        }
    }
}
