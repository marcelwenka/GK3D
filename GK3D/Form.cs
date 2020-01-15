using GK3D.Models;
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
        int desiredfps = 22;
        int actualfps = 0;
        ProjectionMatrix projectionMatrix;
        ViewMatrix viewMatrix;
        DirectBitmap canvas;
        List<Model> models;
        Timer animationTimer;
        Timer fpsTimer;
        CameraType cameraType = CameraType.Fixed;
        double i = 0;


        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            cameraComboBox.DataSource = Enum.GetValues(typeof(CameraType));

            Drawing.ReinitializeZBuffor(pictureBox.Width, pictureBox.Height);

            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / pictureBox.Width);
            viewMatrix = new ViewMatrix();

            models = Initializers.InitializeModels();

            animationTimer = new Timer() { Interval = 1000 / desiredfps };
            animationTimer.Tick += Animation;
            animationTimer.Start();

            fpsTimer = new Timer() { Interval = 1000 };
            fpsTimer.Tick += (object sender, EventArgs eventArgs) => { fpsLabel.Text = $"{actualfps}"; actualfps = 0; };
            fpsTimer.Start();
        }

        public void Draw()
        {
            Drawing.ClearZBuffor();

            using (var graphics = Graphics.FromImage(canvas.Bitmap))
            {
                graphics.Clear(Color.Black);
            }

            Parallel.ForEach(models, model => DrawModel(model));

            pictureBox.Image = canvas.Bitmap;
        }

        public void DrawModel(Model model)
        {
            var matrix = projectionMatrix.Matrix * viewMatrix.Matrix * model.Matrix;
            var calculatedPoints = new List<Vertex>();

            foreach (var p in model.Points)
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

            model.Triangles = new List<Triangle>();
            foreach (var indexes in model.TriangleIndexes)
            {
                model.Triangles.Add(new Triangle(calculatedPoints[indexes.Item1], calculatedPoints[indexes.Item2], calculatedPoints[indexes.Item3], model.Color));
            }

            Parallel.ForEach(model.Triangles, triangle => canvas.Fill(triangle));
        }
    }
}
