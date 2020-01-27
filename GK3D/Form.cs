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
        readonly ProjectionMatrix projectionMatrix;
        readonly ViewMatrix viewMatrix;
        DirectBitmap canvas;
        readonly List<IModel> models;
        //Timer animationTimer;
        readonly Timer fpsTimer;
        CameraType cameraType = CameraType.Fixed;

        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            cameraComboBox.DataSource = Enum.GetValues(typeof(CameraType));
            shaderComboBox.DataSource = Enum.GetValues(typeof(ShaderType));
            shaderComboBox.SelectedIndex = 1;

            Drawing.width = pictureBox.Width;
            Drawing.height = pictureBox.Height;
            Drawing.ReinitializeZBuffor();

            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / pictureBox.Width);
            viewMatrix = new ViewMatrix();

            models = Initializers.InitializeModels();
            ColorCalculation.lights = Initializers.InitializeLights();
            ColorCalculation.cameraPosition = viewMatrix.CameraPosition;

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

            canvas.Clear(Color.Black);

            Parallel.ForEach(models, model => DrawModel(model));

            //foreach (var model in models)
            //{
            //    DrawModel(model);
            //}

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

            //Parallel.ForEach(model.Triangles, triangle => canvas.Fill(triangle, model));

            foreach (var triangle in model.Triangles)
            {
                //canvas.Fill(triangle, model);
                try { canvas.Fill(triangle, model); }
                catch { }
            }
        }
    }
}
