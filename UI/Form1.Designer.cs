namespace AlarmUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rotateCWButton = new System.Windows.Forms.Button();
            this.rotateCCWButton = new System.Windows.Forms.Button();
            this.captureImageButton = new System.Windows.Forms.Button();
            this.controllModeLabel = new System.Windows.Forms.Label();
            this.cameraPosLabel = new System.Windows.Forms.Label();
            this.controllModeTextBox = new System.Windows.Forms.TextBox();
            this.camPosTextBox = new System.Windows.Forms.TextBox();
            this.motionDetectionCheckBox = new System.Windows.Forms.CheckBox();
            this.motionDetectOnImage = new System.Windows.Forms.PictureBox();
            this.motionDetectOffImage = new System.Windows.Forms.PictureBox();
            this.turnedOffByLabel = new System.Windows.Forms.Label();
            this.turnedOnByLabel = new System.Windows.Forms.Label();
            this.turnedOnByTextBox = new System.Windows.Forms.TextBox();
            this.turnedOffByTextBox = new System.Windows.Forms.TextBox();
            this.receivedMessageTextBox = new System.Windows.Forms.TextBox();
            this.triggeredAlarmImage = new System.Windows.Forms.PictureBox();
            this.sensLabel1 = new System.Windows.Forms.Label();
            this.sensLabel2 = new System.Windows.Forms.Label();
            this.setSensButton = new System.Windows.Forms.Button();
            this.sensTextBox = new System.Windows.Forms.TextBox();
            this.invalidSensValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.motionDetectOnImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDetectOffImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggeredAlarmImage)).BeginInit();
            this.SuspendLayout();
            // 
            // rotateCWButton
            // 
            this.rotateCWButton.Location = new System.Drawing.Point(10, 206);
            this.rotateCWButton.Name = "rotateCWButton";
            this.rotateCWButton.Size = new System.Drawing.Size(190, 23);
            this.rotateCWButton.TabIndex = 0;
            this.rotateCWButton.Text = "Rotate clockwise";
            this.rotateCWButton.UseVisualStyleBackColor = true;
            this.rotateCWButton.Click += new System.EventHandler(this.rotateCWButton_Click);
            // 
            // rotateCCWButton
            // 
            this.rotateCCWButton.Location = new System.Drawing.Point(402, 206);
            this.rotateCCWButton.Name = "rotateCCWButton";
            this.rotateCCWButton.Size = new System.Drawing.Size(190, 23);
            this.rotateCCWButton.TabIndex = 1;
            this.rotateCCWButton.Text = "Rotate counter-clockwise";
            this.rotateCCWButton.UseVisualStyleBackColor = true;
            this.rotateCCWButton.Click += new System.EventHandler(this.rotateCCWButton_Click);
            // 
            // captureImageButton
            // 
            this.captureImageButton.Location = new System.Drawing.Point(206, 206);
            this.captureImageButton.Name = "captureImageButton";
            this.captureImageButton.Size = new System.Drawing.Size(190, 23);
            this.captureImageButton.TabIndex = 2;
            this.captureImageButton.Text = "Capture image";
            this.captureImageButton.UseVisualStyleBackColor = true;
            this.captureImageButton.Click += new System.EventHandler(this.captureImageButton_Click);
            // 
            // controllModeLabel
            // 
            this.controllModeLabel.AutoSize = true;
            this.controllModeLabel.Location = new System.Drawing.Point(14, 15);
            this.controllModeLabel.Name = "controllModeLabel";
            this.controllModeLabel.Size = new System.Drawing.Size(71, 13);
            this.controllModeLabel.TabIndex = 3;
            this.controllModeLabel.Text = "Controll mode";
            // 
            // cameraPosLabel
            // 
            this.cameraPosLabel.AutoSize = true;
            this.cameraPosLabel.Location = new System.Drawing.Point(14, 45);
            this.cameraPosLabel.Name = "cameraPosLabel";
            this.cameraPosLabel.Size = new System.Drawing.Size(82, 13);
            this.cameraPosLabel.TabIndex = 4;
            this.cameraPosLabel.Text = "Camera position";
            // 
            // controllModeTextBox
            // 
            this.controllModeTextBox.Location = new System.Drawing.Point(102, 12);
            this.controllModeTextBox.Name = "controllModeTextBox";
            this.controllModeTextBox.Size = new System.Drawing.Size(100, 20);
            this.controllModeTextBox.TabIndex = 5;
            this.controllModeTextBox.Text = "Local";
            // 
            // camPosTextBox
            // 
            this.camPosTextBox.Location = new System.Drawing.Point(102, 42);
            this.camPosTextBox.Name = "camPosTextBox";
            this.camPosTextBox.Size = new System.Drawing.Size(100, 20);
            this.camPosTextBox.TabIndex = 6;
            this.camPosTextBox.Text = "Undefined";
            // 
            // motionDetectionCheckBox
            // 
            this.motionDetectionCheckBox.AutoSize = true;
            this.motionDetectionCheckBox.Location = new System.Drawing.Point(231, 14);
            this.motionDetectionCheckBox.Name = "motionDetectionCheckBox";
            this.motionDetectionCheckBox.Size = new System.Drawing.Size(105, 17);
            this.motionDetectionCheckBox.TabIndex = 7;
            this.motionDetectionCheckBox.Text = "Motion detection";
            this.motionDetectionCheckBox.UseVisualStyleBackColor = true;
            this.motionDetectionCheckBox.CheckedChanged += new System.EventHandler(this.motionDetectionCheckBox_CheckedChanged);
            this.motionDetectionCheckBox.Click += new System.EventHandler(this.motionDetectionCheckBox_Click);
            // 
            // motionDetectOnImage
            // 
            this.motionDetectOnImage.Image = ((System.Drawing.Image)(resources.GetObject("motionDetectOnImage.Image")));
            this.motionDetectOnImage.Location = new System.Drawing.Point(342, 11);
            this.motionDetectOnImage.Name = "motionDetectOnImage";
            this.motionDetectOnImage.Size = new System.Drawing.Size(40, 20);
            this.motionDetectOnImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.motionDetectOnImage.TabIndex = 8;
            this.motionDetectOnImage.TabStop = false;
            // 
            // motionDetectOffImage
            // 
            this.motionDetectOffImage.Image = ((System.Drawing.Image)(resources.GetObject("motionDetectOffImage.Image")));
            this.motionDetectOffImage.Location = new System.Drawing.Point(342, 11);
            this.motionDetectOffImage.Name = "motionDetectOffImage";
            this.motionDetectOffImage.Size = new System.Drawing.Size(40, 20);
            this.motionDetectOffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.motionDetectOffImage.TabIndex = 9;
            this.motionDetectOffImage.TabStop = false;
            // 
            // turnedOffByLabel
            // 
            this.turnedOffByLabel.AutoSize = true;
            this.turnedOffByLabel.Location = new System.Drawing.Point(232, 117);
            this.turnedOffByLabel.Name = "turnedOffByLabel";
            this.turnedOffByLabel.Size = new System.Drawing.Size(73, 13);
            this.turnedOffByLabel.TabIndex = 10;
            this.turnedOffByLabel.Text = "Turned on by:";
            // 
            // turnedOnByLabel
            // 
            this.turnedOnByLabel.AutoSize = true;
            this.turnedOnByLabel.Location = new System.Drawing.Point(232, 149);
            this.turnedOnByLabel.Name = "turnedOnByLabel";
            this.turnedOnByLabel.Size = new System.Drawing.Size(73, 13);
            this.turnedOnByLabel.TabIndex = 11;
            this.turnedOnByLabel.Text = "Turned off by:";
            // 
            // turnedOnByTextBox
            // 
            this.turnedOnByTextBox.Location = new System.Drawing.Point(312, 114);
            this.turnedOnByTextBox.Name = "turnedOnByTextBox";
            this.turnedOnByTextBox.Size = new System.Drawing.Size(100, 20);
            this.turnedOnByTextBox.TabIndex = 12;
            // 
            // turnedOffByTextBox
            // 
            this.turnedOffByTextBox.Location = new System.Drawing.Point(312, 146);
            this.turnedOffByTextBox.Name = "turnedOffByTextBox";
            this.turnedOffByTextBox.Size = new System.Drawing.Size(100, 20);
            this.turnedOffByTextBox.TabIndex = 13;
            // 
            // receivedMessageTextBox
            // 
            this.receivedMessageTextBox.Location = new System.Drawing.Point(17, 273);
            this.receivedMessageTextBox.Name = "receivedMessageTextBox";
            this.receivedMessageTextBox.Size = new System.Drawing.Size(575, 20);
            this.receivedMessageTextBox.TabIndex = 14;
            // 
            // triggeredAlarmImage
            // 
            this.triggeredAlarmImage.Image = ((System.Drawing.Image)(resources.GetObject("triggeredAlarmImage.Image")));
            this.triggeredAlarmImage.Location = new System.Drawing.Point(492, 6);
            this.triggeredAlarmImage.Name = "triggeredAlarmImage";
            this.triggeredAlarmImage.Size = new System.Drawing.Size(100, 100);
            this.triggeredAlarmImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.triggeredAlarmImage.TabIndex = 15;
            this.triggeredAlarmImage.TabStop = false;
            // 
            // sensLabel1
            // 
            this.sensLabel1.AutoSize = true;
            this.sensLabel1.Location = new System.Drawing.Point(228, 42);
            this.sensLabel1.Name = "sensLabel1";
            this.sensLabel1.Size = new System.Drawing.Size(142, 13);
            this.sensLabel1.TabIndex = 16;
            this.sensLabel1.Text = "Set motion detect sensitivty :";
            this.sensLabel1.Click += new System.EventHandler(this.captureImageButton_Click);
            // 
            // sensLabel2
            // 
            this.sensLabel2.AutoSize = true;
            this.sensLabel2.Location = new System.Drawing.Point(228, 55);
            this.sensLabel2.Name = "sensLabel2";
            this.sensLabel2.Size = new System.Drawing.Size(126, 13);
            this.sensLabel2.TabIndex = 17;
            this.sensLabel2.Text = "1000 (min) - 10000 (max) ";
            // 
            // setSensButton
            // 
            this.setSensButton.Location = new System.Drawing.Point(231, 82);
            this.setSensButton.Name = "setSensButton";
            this.setSensButton.Size = new System.Drawing.Size(75, 20);
            this.setSensButton.TabIndex = 18;
            this.setSensButton.Text = "Set";
            this.setSensButton.UseVisualStyleBackColor = true;
            this.setSensButton.Click += new System.EventHandler(this.setSensButton_Click);
            // 
            // sensTextBox
            // 
            this.sensTextBox.Location = new System.Drawing.Point(312, 82);
            this.sensTextBox.Name = "sensTextBox";
            this.sensTextBox.Size = new System.Drawing.Size(100, 20);
            this.sensTextBox.TabIndex = 19;
            // 
            // invalidSensValueLabel
            // 
            this.invalidSensValueLabel.AutoSize = true;
            this.invalidSensValueLabel.Location = new System.Drawing.Point(14, 82);
            this.invalidSensValueLabel.Name = "invalidSensValueLabel";
            this.invalidSensValueLabel.Size = new System.Drawing.Size(0, 13);
            this.invalidSensValueLabel.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 321);
            this.Controls.Add(this.invalidSensValueLabel);
            this.Controls.Add(this.sensTextBox);
            this.Controls.Add(this.setSensButton);
            this.Controls.Add(this.sensLabel2);
            this.Controls.Add(this.sensLabel1);
            this.Controls.Add(this.triggeredAlarmImage);
            this.Controls.Add(this.receivedMessageTextBox);
            this.Controls.Add(this.turnedOffByTextBox);
            this.Controls.Add(this.turnedOnByTextBox);
            this.Controls.Add(this.turnedOnByLabel);
            this.Controls.Add(this.turnedOffByLabel);
            this.Controls.Add(this.motionDetectOffImage);
            this.Controls.Add(this.motionDetectOnImage);
            this.Controls.Add(this.motionDetectionCheckBox);
            this.Controls.Add(this.camPosTextBox);
            this.Controls.Add(this.controllModeTextBox);
            this.Controls.Add(this.cameraPosLabel);
            this.Controls.Add(this.controllModeLabel);
            this.Controls.Add(this.captureImageButton);
            this.Controls.Add(this.rotateCCWButton);
            this.Controls.Add(this.rotateCWButton);
            this.Name = "Form1";
            this.Text = "Alarm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.motionDetectOnImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDetectOffImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggeredAlarmImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rotateCWButton;
        private System.Windows.Forms.Button rotateCCWButton;
        private System.Windows.Forms.Button captureImageButton;
        private System.Windows.Forms.Label controllModeLabel;
        private System.Windows.Forms.Label cameraPosLabel;
        private System.Windows.Forms.TextBox controllModeTextBox;
        private System.Windows.Forms.TextBox camPosTextBox;
        private System.Windows.Forms.CheckBox motionDetectionCheckBox;
        private System.Windows.Forms.PictureBox motionDetectOnImage;
        private System.Windows.Forms.PictureBox motionDetectOffImage;
        private System.Windows.Forms.Label turnedOffByLabel;
        private System.Windows.Forms.Label turnedOnByLabel;
        private System.Windows.Forms.TextBox turnedOnByTextBox;
        private System.Windows.Forms.TextBox turnedOffByTextBox;
        private System.Windows.Forms.TextBox receivedMessageTextBox;
        private System.Windows.Forms.PictureBox triggeredAlarmImage;
        private System.Windows.Forms.Label sensLabel1;
        private System.Windows.Forms.Label sensLabel2;
        private System.Windows.Forms.Button setSensButton;
        private System.Windows.Forms.TextBox sensTextBox;
        private System.Windows.Forms.Label invalidSensValueLabel;
    }
}

