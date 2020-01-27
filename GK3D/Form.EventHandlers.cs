using System;

namespace GK3D
{
    partial class Form
    {
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraType = (CameraType)cameraComboBox.SelectedItem;
        }

        private void shaderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drawing.shaderType = (ShaderType)shaderComboBox.SelectedItem;
        }

        private void Form_Resize(object sender, EventArgs eventArgs)
        {
            Drawing.width = pictureBox.Width;
            Drawing.height = pictureBox.Height;
            Drawing.ReinitializeZBuffor();

            projectionMatrix.a = (double)pictureBox.Height / pictureBox.Width;
            canvas = new DirectBitmap(pictureBox.Width, pictureBox.Height);
        }

        private void drawLinesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Drawing.drawLines = drawLinesCheckbox.Checked;
        }

        private void parallelCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            parallel = parallelCheckbox.Checked;
        }

        private void kaSlider_ValueChanged(object sender, EventArgs e)
        {
            ColorCalculation.ka = kaSlider.Value / 100.0;
            kaLabel.Text = "ka: " + ColorCalculation.ka;
        }

        private void kdSlider_ValueChanged(object sender, EventArgs e)
        {
            ColorCalculation.kd = kdSlider.Value / 100.0;
            kdLabel.Text = "kd: " + ColorCalculation.kd;
        }

        private void ksSlider_ValueChanged(object sender, EventArgs e)
        {
            ColorCalculation.ks = ksSlider.Value / 100.0;
            ksLabel.Text = "ks: " + ColorCalculation.ks;

        }

        private void mSlider_ValueChanged(object sender, EventArgs e)
        {
            ColorCalculation.m = mSlider.Value;
            mLabel.Text = "m: " + ColorCalculation.m;
        }

        private void pSlider_ValueChanged(object sender, EventArgs e)
        {
            ColorCalculation.p = pSlider.Value;
            pLabel.Text = "p: " + ColorCalculation.p;
        }

        private void fovSlider_ValueChanged(object sender, EventArgs e)
        {
            projectionMatrix.fov = fovSlider.Value / 100.0 * Math.PI;
            fovLabel.Text = "fov: " + fovSlider.Value;
        }

        private void xCameraSlider_ValueChanged(object sender, EventArgs e)
        {
            ViewMatrix.DefaultCameraPosition[0] = xCameraSlider.Value / 10.0;
            xCameraLabel.Text = "x: " + xCameraSlider.Value / 10.0;
        }

        private void yCameraSlider_ValueChanged(object sender, EventArgs e)
        {
            ViewMatrix.DefaultCameraPosition[1] = yCameraSlider.Value / 10.0;
            yCameraLabel.Text = "y: " + yCameraSlider.Value / 10.0;
        }

        private void zCameraSlider_ValueChanged(object sender, EventArgs e)
        {
            ViewMatrix.DefaultCameraPosition[2] = zCameraSlider.Value / -10.0;
            zCameraLabel.Text = "z: " + zCameraSlider.Value / 10.0;
        }

        private void movementSpeedSlider_ValueChanged(object sender, EventArgs e)
        {
            movementSpeed = movementSpeedSlider.Value / 1000.0;
            movementSpeedLabel.Text = "Movement speed: " + movementSpeed;
        }
    }
}
