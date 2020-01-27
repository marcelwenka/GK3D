namespace GK3D
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.fovSlider = new System.Windows.Forms.TrackBar();
            this.lightingGroupBox = new System.Windows.Forms.GroupBox();
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
            this.fovLabel = new System.Windows.Forms.Label();
            this.drawLinesCheckbox = new System.Windows.Forms.CheckBox();
            this.fpsNameLabel = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.cameraComboBox = new System.Windows.Forms.ComboBox();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.kdSlider = new System.Windows.Forms.TrackBar();
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fovSlider)).BeginInit();
            this.lightingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).BeginInit();
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
            this.rightPanel.Controls.Add(this.fovSlider);
            this.rightPanel.Controls.Add(this.lightingGroupBox);
            this.rightPanel.Controls.Add(this.fovLabel);
            this.rightPanel.Controls.Add(this.drawLinesCheckbox);
            this.rightPanel.Controls.Add(this.fpsNameLabel);
            this.rightPanel.Controls.Add(this.fpsLabel);
            this.rightPanel.Controls.Add(this.cameraComboBox);
            this.rightPanel.Controls.Add(this.cameraLabel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(987, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(194, 655);
            this.rightPanel.TabIndex = 1;
            // 
            // fovSlider
            // 
            this.fovSlider.AutoSize = false;
            this.fovSlider.Location = new System.Drawing.Point(65, 103);
            this.fovSlider.Maximum = 100;
            this.fovSlider.Minimum = 1;
            this.fovSlider.Name = "fovSlider";
            this.fovSlider.Size = new System.Drawing.Size(120, 21);
            this.fovSlider.TabIndex = 16;
            this.fovSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.fovSlider.Value = 55;
            this.fovSlider.ValueChanged += new System.EventHandler(this.fovSlider_ValueChanged);
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
            this.lightingGroupBox.Location = new System.Drawing.Point(6, 130);
            this.lightingGroupBox.Name = "lightingGroupBox";
            this.lightingGroupBox.Size = new System.Drawing.Size(185, 189);
            this.lightingGroupBox.TabIndex = 7;
            this.lightingGroupBox.TabStop = false;
            this.lightingGroupBox.Text = "Lighting";
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
            this.pSlider.Value = 5;
            this.pSlider.ValueChanged += new System.EventHandler(this.pSlider_ValueChanged);
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(10, 159);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(25, 13);
            this.pLabel.TabIndex = 15;
            this.pLabel.Text = "p: 5";
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
            this.shaderLabel.Location = new System.Drawing.Point(10, 27);
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
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Location = new System.Drawing.Point(16, 103);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(40, 13);
            this.fovLabel.TabIndex = 15;
            this.fovLabel.Text = "fov: 55";
            // 
            // drawLinesCheckbox
            // 
            this.drawLinesCheckbox.AutoSize = true;
            this.drawLinesCheckbox.Location = new System.Drawing.Point(19, 43);
            this.drawLinesCheckbox.Name = "drawLinesCheckbox";
            this.drawLinesCheckbox.Size = new System.Drawing.Size(126, 17);
            this.drawLinesCheckbox.TabIndex = 4;
            this.drawLinesCheckbox.Text = "Draw triangle edges?";
            this.drawLinesCheckbox.UseVisualStyleBackColor = true;
            this.drawLinesCheckbox.CheckedChanged += new System.EventHandler(this.drawLinesCheckbox_CheckedChanged);
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
            // cameraComboBox
            // 
            this.cameraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraComboBox.FormattingEnabled = true;
            this.cameraComboBox.Location = new System.Drawing.Point(64, 71);
            this.cameraComboBox.Name = "cameraComboBox";
            this.cameraComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraComboBox.TabIndex = 1;
            this.cameraComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraComboBox_SelectedIndexChanged);
            // 
            // cameraLabel
            // 
            this.cameraLabel.AutoSize = true;
            this.cameraLabel.Location = new System.Drawing.Point(16, 74);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(43, 13);
            this.cameraLabel.TabIndex = 0;
            this.cameraLabel.Text = "Camera";
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
            ((System.ComponentModel.ISupportInitialize)(this.fovSlider)).EndInit();
            this.lightingGroupBox.ResumeLayout(false);
            this.lightingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).EndInit();
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
        private System.Windows.Forms.CheckBox drawLinesCheckbox;
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
    }
}

