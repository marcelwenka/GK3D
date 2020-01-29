namespace GK3D
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.movementSpeedSlider = new System.Windows.Forms.TrackBar();
            this.movementSpeedLabel = new System.Windows.Forms.Label();
            this.cameraGroupBox = new System.Windows.Forms.GroupBox();
            this.zCameraSlider = new System.Windows.Forms.TrackBar();
            this.zCameraLabel = new System.Windows.Forms.Label();
            this.yCameraSlider = new System.Windows.Forms.TrackBar();
            this.yCameraLabel = new System.Windows.Forms.Label();
            this.xCameraSlider = new System.Windows.Forms.TrackBar();
            this.xCameraLabel = new System.Windows.Forms.Label();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.fovSlider = new System.Windows.Forms.TrackBar();
            this.fovLabel = new System.Windows.Forms.Label();
            this.parallelCheckbox = new System.Windows.Forms.CheckBox();
            this.lightingGroupBox = new System.Windows.Forms.GroupBox();
            this.kdSlider = new System.Windows.Forms.TrackBar();
            this.pSlider = new System.Windows.Forms.TrackBar();
            this.pLabel = new System.Windows.Forms.Label();
            this.kaSlider = new System.Windows.Forms.TrackBar();
            this.kaLabel = new System.Windows.Forms.Label();
            this.mSlider = new System.Windows.Forms.TrackBar();
            this.mLabel = new System.Windows.Forms.Label();
            this.ksSlider = new System.Windows.Forms.TrackBar();
            this.ksLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.shaderLabel = new System.Windows.Forms.Label();
            this.shaderComboBox = new System.Windows.Forms.ComboBox();
            this.drawTriangleEdgesCheckbox = new System.Windows.Forms.CheckBox();
            this.fpsNameLabel = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movementSpeedSlider)).BeginInit();
            this.cameraGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zCameraSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCameraSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCameraSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovSlider)).BeginInit();
            this.lightingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainTableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.rightPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1184, 661);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(978, 655);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.movementSpeedSlider);
            this.rightPanel.Controls.Add(this.movementSpeedLabel);
            this.rightPanel.Controls.Add(this.cameraGroupBox);
            this.rightPanel.Controls.Add(this.parallelCheckbox);
            this.rightPanel.Controls.Add(this.lightingGroupBox);
            this.rightPanel.Controls.Add(this.drawTriangleEdgesCheckbox);
            this.rightPanel.Controls.Add(this.fpsNameLabel);
            this.rightPanel.Controls.Add(this.fpsLabel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(987, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(194, 655);
            this.rightPanel.TabIndex = 1;
            // 
            // movementSpeedSlider
            // 
            this.movementSpeedSlider.AutoSize = false;
            this.movementSpeedSlider.Location = new System.Drawing.Point(11, 475);
            this.movementSpeedSlider.Maximum = 200;
            this.movementSpeedSlider.Minimum = 1;
            this.movementSpeedSlider.Name = "movementSpeedSlider";
            this.movementSpeedSlider.Size = new System.Drawing.Size(175, 21);
            this.movementSpeedSlider.TabIndex = 19;
            this.movementSpeedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.movementSpeedSlider.Value = 100;
            this.movementSpeedSlider.ValueChanged += new System.EventHandler(this.movementSpeedSlider_ValueChanged);
            // 
            // movementSpeedLabel
            // 
            this.movementSpeedLabel.AutoSize = true;
            this.movementSpeedLabel.Location = new System.Drawing.Point(15, 458);
            this.movementSpeedLabel.Name = "movementSpeedLabel";
            this.movementSpeedLabel.Size = new System.Drawing.Size(110, 13);
            this.movementSpeedLabel.TabIndex = 18;
            this.movementSpeedLabel.Text = "Movement speed: 0.1";
            // 
            // cameraGroupBox
            // 
            this.cameraGroupBox.Controls.Add(this.zCameraSlider);
            this.cameraGroupBox.Controls.Add(this.zCameraLabel);
            this.cameraGroupBox.Controls.Add(this.yCameraSlider);
            this.cameraGroupBox.Controls.Add(this.yCameraLabel);
            this.cameraGroupBox.Controls.Add(this.xCameraSlider);
            this.cameraGroupBox.Controls.Add(this.xCameraLabel);
            this.cameraGroupBox.Controls.Add(this.cameraComboBox);
            this.cameraGroupBox.Controls.Add(this.cameraLabel);
            this.cameraGroupBox.Controls.Add(this.fovSlider);
            this.cameraGroupBox.Controls.Add(this.fovLabel);
            this.cameraGroupBox.Location = new System.Drawing.Point(6, 94);
            this.cameraGroupBox.Name = "cameraGroupBox";
            this.cameraGroupBox.Size = new System.Drawing.Size(185, 157);
            this.cameraGroupBox.TabIndex = 18;
            this.cameraGroupBox.TabStop = false;
            this.cameraGroupBox.Text = "Camera";
            // 
            // zCameraSlider
            // 
            this.zCameraSlider.AutoSize = false;
            this.zCameraSlider.Location = new System.Drawing.Point(60, 127);
            this.zCameraSlider.Maximum = 100;
            this.zCameraSlider.Minimum = -100;
            this.zCameraSlider.Name = "zCameraSlider";
            this.zCameraSlider.Size = new System.Drawing.Size(120, 21);
            this.zCameraSlider.TabIndex = 22;
            this.zCameraSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zCameraSlider.Value = 20;
            this.zCameraSlider.ValueChanged += new System.EventHandler(this.zCameraSlider_ValueChanged);
            // 
            // zCameraLabel
            // 
            this.zCameraLabel.AutoSize = true;
            this.zCameraLabel.Location = new System.Drawing.Point(11, 127);
            this.zCameraLabel.Name = "zCameraLabel";
            this.zCameraLabel.Size = new System.Drawing.Size(24, 13);
            this.zCameraLabel.TabIndex = 21;
            this.zCameraLabel.Text = "z: 2";
            // 
            // yCameraSlider
            // 
            this.yCameraSlider.AutoSize = false;
            this.yCameraSlider.Location = new System.Drawing.Point(60, 102);
            this.yCameraSlider.Maximum = 100;
            this.yCameraSlider.Minimum = -100;
            this.yCameraSlider.Name = "yCameraSlider";
            this.yCameraSlider.Size = new System.Drawing.Size(120, 21);
            this.yCameraSlider.TabIndex = 20;
            this.yCameraSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.yCameraSlider.ValueChanged += new System.EventHandler(this.yCameraSlider_ValueChanged);
            // 
            // yCameraLabel
            // 
            this.yCameraLabel.AutoSize = true;
            this.yCameraLabel.Location = new System.Drawing.Point(11, 102);
            this.yCameraLabel.Name = "yCameraLabel";
            this.yCameraLabel.Size = new System.Drawing.Size(24, 13);
            this.yCameraLabel.TabIndex = 19;
            this.yCameraLabel.Text = "y: 0";
            // 
            // xCameraSlider
            // 
            this.xCameraSlider.AutoSize = false;
            this.xCameraSlider.Location = new System.Drawing.Point(60, 77);
            this.xCameraSlider.Maximum = 100;
            this.xCameraSlider.Minimum = -100;
            this.xCameraSlider.Name = "xCameraSlider";
            this.xCameraSlider.Size = new System.Drawing.Size(120, 21);
            this.xCameraSlider.TabIndex = 18;
            this.xCameraSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.xCameraSlider.Value = 50;
            this.xCameraSlider.ValueChanged += new System.EventHandler(this.xCameraSlider_ValueChanged);
            // 
            // xCameraLabel
            // 
            this.xCameraLabel.AutoSize = true;
            this.xCameraLabel.Location = new System.Drawing.Point(11, 77);
            this.xCameraLabel.Name = "xCameraLabel";
            this.xCameraLabel.Size = new System.Drawing.Size(24, 13);
            this.xCameraLabel.TabIndex = 17;
            this.xCameraLabel.Text = "x: 5";
            // 
            // cameraComboBox
            // 
            this.cameraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(59, 23);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraComboBox.TabIndex = 1;
            this.cameraComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraComboBox_SelectedIndexChanged);
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(10, 26);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(31, 13);
            this.cameraLabel.TabIndex = 0;
            this.cameraLabel.Text = "Type";
            // 
            // fovSlider
            // 
            this.fovSlider.AutoSize = false;
            this.fovSlider.Location = new System.Drawing.Point(60, 53);
            this.fovSlider.Maximum = 100;
            this.fovSlider.Minimum = 1;
            this.fovSlider.Name = "fovSlider";
            this.fovSlider.Size = new System.Drawing.Size(120, 21);
            this.fovSlider.TabIndex = 16;
            this.fovSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fovSlider.Value = 55;
            this.fovSlider.ValueChanged += new System.EventHandler(this.fovSlider_ValueChanged);
            // 
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Location = new System.Drawing.Point(11, 53);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(40, 13);
            this.fovLabel.TabIndex = 15;
            this.fovLabel.Text = "fov: 55";
            // 
            // parallelCheckbox
            // 
            this.parallelCheckbox.AutoSize = true;
            this.parallelCheckbox.Checked = true;
            this.parallelCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.parallelCheckbox.Location = new System.Drawing.Point(19, 69);
            this.parallelCheckbox.Name = "parallelCheckbox";
            this.parallelCheckbox.Size = new System.Drawing.Size(66, 17);
            this.parallelCheckbox.TabIndex = 17;
            this.parallelCheckbox.Text = "Parallel?";
            this.parallelCheckbox.UseVisualStyleBackColor = true;
            this.parallelCheckbox.CheckedChanged += new System.EventHandler(this.parallelCheckbox_CheckedChanged);
            // 
            // lightingGroupBox
            // 
            this.lightingGroupBox.Controls.Add(this.kdSlider);
            this.lightingGroupBox.Controls.Add(this.pSlider);
            this.lightingGroupBox.Controls.Add(this.pLabel);
            this.lightingGroupBox.Controls.Add(this.kaSlider);
            this.lightingGroupBox.Controls.Add(this.kaLabel);
            this.lightingGroupBox.Controls.Add(this.mSlider);
            this.lightingGroupBox.Controls.Add(this.mLabel);
            this.lightingGroupBox.Controls.Add(this.ksSlider);
            this.lightingGroupBox.Controls.Add(this.ksLabel);
            this.lightingGroupBox.Controls.Add(this.kdLabel);
            this.lightingGroupBox.Controls.Add(this.shaderLabel);
            this.lightingGroupBox.Controls.Add(this.shaderComboBox);
            this.lightingGroupBox.Location = new System.Drawing.Point(6, 258);
            this.lightingGroupBox.Name = "lightingGroupBox";
            this.lightingGroupBox.Size = new System.Drawing.Size(185, 189);
            this.lightingGroupBox.TabIndex = 7;
            this.lightingGroupBox.TabStop = false;
            this.lightingGroupBox.Text = "Lighting";
            // 
            // kdSlider
            // 
            this.kdSlider.AutoSize = false;
            this.kdSlider.Location = new System.Drawing.Point(59, 78);
            this.kdSlider.Maximum = 100;
            this.kdSlider.Minimum = 1;
            this.kdSlider.Name = "kdSlider";
            this.kdSlider.Size = new System.Drawing.Size(120, 21);
            this.kdSlider.TabIndex = 17;
            this.kdSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kdSlider.Value = 70;
            this.kdSlider.ValueChanged += new System.EventHandler(this.kdSlider_ValueChanged);
            // 
            // pSlider
            // 
            this.pSlider.AutoSize = false;
            this.pSlider.Location = new System.Drawing.Point(59, 159);
            this.pSlider.Maximum = 100;
            this.pSlider.Minimum = 1;
            this.pSlider.Name = "pSlider";
            this.pSlider.Size = new System.Drawing.Size(120, 21);
            this.pSlider.TabIndex = 16;
            this.pSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.pSlider.Value = 30;
            this.pSlider.ValueChanged += new System.EventHandler(this.pSlider_ValueChanged);
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(10, 159);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(31, 13);
            this.pLabel.TabIndex = 15;
            this.pLabel.Text = "p: 30";
            // 
            // kaSlider
            // 
            this.kaSlider.AutoSize = false;
            this.kaSlider.Location = new System.Drawing.Point(59, 51);
            this.kaSlider.Maximum = 100;
            this.kaSlider.Minimum = 1;
            this.kaSlider.Name = "kaSlider";
            this.kaSlider.Size = new System.Drawing.Size(120, 21);
            this.kaSlider.TabIndex = 14;
            this.kaSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kaSlider.Value = 20;
            this.kaSlider.ValueChanged += new System.EventHandler(this.kaSlider_ValueChanged);
            // 
            // kaLabel
            // 
            this.kaLabel.AutoSize = true;
            this.kaLabel.Location = new System.Drawing.Point(10, 51);
            this.kaLabel.Name = "kaLabel";
            this.kaLabel.Size = new System.Drawing.Size(40, 13);
            this.kaLabel.TabIndex = 13;
            this.kaLabel.Text = "ka: 0.2";
            // 
            // mSlider
            // 
            this.mSlider.AutoSize = false;
            this.mSlider.Location = new System.Drawing.Point(59, 132);
            this.mSlider.Maximum = 100;
            this.mSlider.Minimum = 1;
            this.mSlider.Name = "mSlider";
            this.mSlider.Size = new System.Drawing.Size(120, 21);
            this.mSlider.TabIndex = 12;
            this.mSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mSlider.Value = 8;
            this.mSlider.ValueChanged += new System.EventHandler(this.mSlider_ValueChanged);
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(10, 132);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(27, 13);
            this.mLabel.TabIndex = 11;
            this.mLabel.Text = "m: 8";
            // 
            // ksSlider
            // 
            this.ksSlider.AutoSize = false;
            this.ksSlider.Location = new System.Drawing.Point(59, 105);
            this.ksSlider.Maximum = 100;
            this.ksSlider.Minimum = 1;
            this.ksSlider.Name = "ksSlider";
            this.ksSlider.Size = new System.Drawing.Size(120, 21);
            this.ksSlider.TabIndex = 10;
            this.ksSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ksSlider.Value = 100;
            this.ksSlider.ValueChanged += new System.EventHandler(this.ksSlider_ValueChanged);
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Location = new System.Drawing.Point(10, 105);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(30, 13);
            this.ksLabel.TabIndex = 9;
            this.ksLabel.Text = "ks: 1";
            // 
            // kdLabel
            // 
            this.kdLabel.AutoSize = true;
            this.kdLabel.Location = new System.Drawing.Point(10, 78);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(40, 13);
            this.kdLabel.TabIndex = 7;
            this.kdLabel.Text = "kd: 0.7";
            // 
            // shaderLabel
            // 
            this.shaderLabel.AutoSize = true;
            this.shaderLabel.Location = new System.Drawing.Point(9, 27);
            this.shaderLabel.Name = "shaderLabel";
            this.shaderLabel.Size = new System.Drawing.Size(41, 13);
            this.shaderLabel.TabIndex = 5;
            this.shaderLabel.Text = "Shader";
            // 
            // shaderComboBox
            // 
            this.shaderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shaderComboBox.FormattingEnabled = true;
            this.shaderComboBox.Location = new System.Drawing.Point(59, 24);
            this.shaderComboBox.Name = "shaderComboBox";
            this.shaderComboBox.Size = new System.Drawing.Size(121, 21);
            this.shaderComboBox.TabIndex = 6;
            this.shaderComboBox.SelectedIndexChanged += new System.EventHandler(this.shaderComboBox_SelectedIndexChanged);
            // 
            // drawTriangleEdgesCheckbox
            // 
            this.drawTriangleEdgesCheckbox.AutoSize = true;
            this.drawTriangleEdgesCheckbox.Location = new System.Drawing.Point(19, 43);
            this.drawTriangleEdgesCheckbox.Name = "drawTriangleEdgesCheckbox";
            this.drawTriangleEdgesCheckbox.Size = new System.Drawing.Size(126, 17);
            this.drawTriangleEdgesCheckbox.TabIndex = 4;
            this.drawTriangleEdgesCheckbox.Text = "Draw triangle edges?";
            this.drawTriangleEdgesCheckbox.UseVisualStyleBackColor = true;
            this.drawTriangleEdgesCheckbox.CheckedChanged += new System.EventHandler(this.drawTriangleEdgesCheckbox_CheckedChanged);
            // 
            // fpsNameLabel
            // 
            this.fpsNameLabel.AutoSize = true;
            this.fpsNameLabel.Location = new System.Drawing.Point(16, 17);
            this.fpsNameLabel.Name = "fpsNameLabel";
            this.fpsNameLabel.Size = new System.Drawing.Size(30, 13);
            this.fpsNameLabel.TabIndex = 3;
            this.fpsNameLabel.Text = "FPS:";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(62, 17);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(13, 13);
            this.fpsLabel.TabIndex = 2;
            this.fpsLabel.Text = "0";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "GK 3D";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.mainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movementSpeedSlider)).EndInit();
            this.cameraGroupBox.ResumeLayout(false);
            this.cameraGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zCameraSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCameraSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCameraSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovSlider)).EndInit();
            this.lightingGroupBox.ResumeLayout(false);
            this.lightingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.ComboBox cameraComboBox;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Label fpsNameLabel;
        private System.Windows.Forms.CheckBox drawTriangleEdgesCheckbox;
        private System.Windows.Forms.ComboBox shaderComboBox;
        private System.Windows.Forms.Label shaderLabel;
        private System.Windows.Forms.GroupBox lightingGroupBox;
        private System.Windows.Forms.Label kdLabel;
        private System.Windows.Forms.TrackBar mSlider;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.TrackBar ksSlider;
        private System.Windows.Forms.Label ksLabel;
        private System.Windows.Forms.TrackBar kaSlider;
        private System.Windows.Forms.Label kaLabel;
        private System.Windows.Forms.TrackBar fovSlider;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.TrackBar pSlider;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.TrackBar kdSlider;
        private System.Windows.Forms.CheckBox parallelCheckbox;
        private System.Windows.Forms.GroupBox cameraGroupBox;
        private System.Windows.Forms.TrackBar zCameraSlider;
        private System.Windows.Forms.Label zCameraLabel;
        private System.Windows.Forms.TrackBar yCameraSlider;
        private System.Windows.Forms.Label yCameraLabel;
        private System.Windows.Forms.TrackBar xCameraSlider;
        private System.Windows.Forms.Label xCameraLabel;
        private System.Windows.Forms.TrackBar movementSpeedSlider;
        private System.Windows.Forms.Label movementSpeedLabel;
    }
}

