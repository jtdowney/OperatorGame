namespace OperatorGame
{
    partial class MainForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.controllerDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enumerateButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(418, 644);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // controllerDropDown
            // 
            this.controllerDropDown.FormattingEnabled = true;
            this.controllerDropDown.Location = new System.Drawing.Point(324, 617);
            this.controllerDropDown.Name = "controllerDropDown";
            this.controllerDropDown.Size = new System.Drawing.Size(233, 21);
            this.controllerDropDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 620);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Controller:";
            // 
            // enumerateButton
            // 
            this.enumerateButton.Location = new System.Drawing.Point(563, 615);
            this.enumerateButton.Name = "enumerateButton";
            this.enumerateButton.Size = new System.Drawing.Size(75, 23);
            this.enumerateButton.TabIndex = 4;
            this.enumerateButton.Text = "Enumerate";
            this.enumerateButton.UseVisualStyleBackColor = true;
            this.enumerateButton.Click += new System.EventHandler(this.EnumerateButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OperatorGame.Properties.Resources.gamepad;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(883, 598);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(898, 676);
            this.Controls.Add(this.enumerateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controllerDropDown);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "I\'m Training Operators Asbestos I Can";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox controllerDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enumerateButton;
    }
}