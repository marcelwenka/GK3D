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
        int currentfps = 0;
        readonly ProjectionMatrix projectionMatrix;
        readonly ViewMatrix viewMatrix;
        DirectBitmap canvas;
        readonly List<IModel> models;
        bool parallel = true;
        readonly Timer fpsTimer;
        CameraType cameraType = CameraType.Fixed;

        public Form()
        {
            InitializeComponent();

            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);

            cameraComboBox.DataSource = Enum.GetValues(typeof(CameraType));
            shaderComboBox.DataSource = Enum.GetValues(typeof(ShaderType));
            shaderComboBox.SelectedIndex = 1;

            width = pictureBox.Width;
            height = pictureBox.Height;
            ReinitializeZBuffor();

            projectionMatrix = new ProjectionMatrix((double)pictureBox.Height / pictureBox.Width);
            viewMatrix = new ViewMatrix();

            models = Initializers.InitializeModels();
            ColorCalculation.lights = Initializers.InitializeLights();
            ColorCalculation.cameraPosition = viewMatrix.CameraPosition;

            _ = InitializeAnimation();

            fpsTimer = new Timer() { Interval = 1000 };
            fpsTimer.Tick += (object sender, EventArgs eventArgs) => { fpsLabel.Text = $"{currentfps}"; currentfps = 0; };
            fpsTimer.Start();
        }

        public async Task InitializeAnimation()
        {
            await Task.Run(() => RunAnimation()).ContinueWith(task => InitializeAnimation());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            fpsTimer.Dispose();
            canvas.Dispose();
            base.Dispose(disposing);
        }
    }
}
