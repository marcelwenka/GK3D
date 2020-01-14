using System;

namespace GK3D
{
    public partial class Form
    {
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraType = (CameraType)cameraComboBox.SelectedItem;
        }
    }
}
