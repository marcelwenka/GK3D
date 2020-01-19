using System;

namespace GK3D
{
    partial class Form
    {
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraType = (CameraType)cameraComboBox.SelectedItem;
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
    }
}
