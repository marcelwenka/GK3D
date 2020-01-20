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
        bool isIdle = true;
        int actualfps = 0;
        ProjectionMatrix projectionMatrix;
        ViewMatrix viewMatrix;
        DirectBitmap canvas;
        List<IModel> models;
        //Timer animationTimer;
        Timer fpsTimer;
        CameraType cameraType = CameraType.Fixed;
        double i = 0;

        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            cameraComboBox.DataSource = Enum.GetValues(typeof(CameraType));

            Drawing.width = pictureBox.Width;
            Drawing.height = pictureBox.Height;
            Drawing.ReinitializeZBuffor();

            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / pictureBox.Width);
            viewMatrix = new ViewMatrix();

            models = Initializers.InitializeModels();
            Lighting.lights = Initializers.InitializeLights();
            Lighting.cameraPosition = viewMatrix.CameraPosition;

            //animationTimer = new Timer() { Interval = 500 };
            //animationTimer.Tick += Animation;
            //animationTimer.Start();

            _ = Animation();

            fpsTimer = new Timer() { Interval = 1000 };
            fpsTimer.Tick += (object sender, EventArgs eventArgs) => { fpsLabel.Text = $"{actualfps}"; actualfps = 0; };
            fpsTimer.Start();
        }

        public async Task Animation()
        {
            while (true)
                if (isIdle)
                    await Task.Run(() => Animation(new object(), new EventArgs())).ContinueWith(task => isIdle = true);
        }

        public void Draw()
        {
            Drawing.ReinitializeZBuffor();

            //try
            //{
            //    using (var graphics = Graphics.FromImage(canvas.Bitmap))
            //    {
            //        graphics.Clear(Color.Black);
            //    }
            //}
            //catch
            //{
            //    return;
            //}

            canvas.Clear(Color.Black);

            Parallel.ForEach(models, model => DrawModel(model));

            //foreach (var model in models)
            //    DrawModel(model);

            //var tasks = models.Select(model => Task.Run(() => DrawModel(model)));
            //Task.WhenAll(tasks).Wait();

            pictureBox.Image = canvas.Bitmap;
        }

        public void DrawModel(IModel model)
        {
            var matrix = projectionMatrix.Matrix * viewMatrix.Matrix * model.Matrix;
            var calculatedPoints = new List<Vertex>();

            foreach (var p in model.Points)
            {
                var calculatedPoint = matrix * p;

                if (calculatedPoint[3] != 0)
                    for (int i = 0; i < 3; i++)
                        calculatedPoint[i] /= calculatedPoint[3];
                calculatedPoint[3] = 1;

                double x = (calculatedPoint[0] + 1) * pictureBox.Width / 2;
                double y = (calculatedPoint[1] + 1) * pictureBox.Height / 2;

                calculatedPoints.Add(new Vertex((int)Math.Round(x), (int)Math.Round(y), -(calculatedPoint[2] - 1) * 1000));
            }

            foreach (var light in Lighting.lights)
            {
                var calculatedPosition = matrix * light.nominalPosition;
                if (calculatedPosition[3] != 0)
                    for (int i = 0; i < 3; i++)
                        calculatedPosition[i] /= calculatedPosition[3];

                light.actualPosition = Vector<double>.Build.Dense(new double[3]
                {
                    (calculatedPosition[0] + 1) * pictureBox.Width / 2,
                    (calculatedPosition[1] + 1) * pictureBox.Height / 2,
                    -(calculatedPosition[2] - 1) * 1000
                });
            }

            model.Center = Vector<double>.Build.Dense(new double[3]
            {
                (calculatedPoints[0].X + calculatedPoints[5].X) / 2,
                (calculatedPoints[0].Y + calculatedPoints[5].Y) / 2,
                (calculatedPoints[0].Z + calculatedPoints[5].Z) / 2
            });
            model.Triangles = model.TriangleIndexes.Select(indexes =>
                new Triangle(
                    calculatedPoints[indexes.Item1],
                    calculatedPoints[indexes.Item2],
                    calculatedPoints[indexes.Item3])
                ).ToList();

            //Parallel.ForEach(model.Triangles, triangle => canvas.Fill(triangle, model));

            foreach (var triangle in model.Triangles)
                canvas.Fill(triangle, model);

            //var tasks = model.Triangles.Select(triangle => Task.Run(() => canvas.Fill(triangle, model)));
            //Task.WhenAll(tasks).Wait();
        }
    }
}
