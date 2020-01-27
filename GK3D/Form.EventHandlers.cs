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
    }
}
