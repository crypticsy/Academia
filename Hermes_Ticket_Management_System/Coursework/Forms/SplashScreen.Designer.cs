
namespace Hermes
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarBackground = new System.Windows.Forms.Panel();
            this.progressBarStatus = new System.Windows.Forms.Panel();
            this.randomTextLabel = new System.Windows.Forms.Label();
            this.loadingTextLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 8;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarBackground
            // 
            this.progressBarBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBarBackground.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarBackground.Location = new System.Drawing.Point(0, 385);
            this.progressBarBackground.Name = "progressBarBackground";
            this.progressBarBackground.Size = new System.Drawing.Size(700, 15);
            this.progressBarBackground.TabIndex = 0;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(161)))), ((int)(((byte)(217)))));
            this.progressBarStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.progressBarStatus.Location = new System.Drawing.Point(0, 385);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(0, 100);
            this.progressBarStatus.TabIndex = 1;
            // 
            // randomTextLabel
            // 
            this.randomTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.randomTextLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.randomTextLabel.Location = new System.Drawing.Point(586, 21);
            this.randomTextLabel.Name = "randomTextLabel";
            this.randomTextLabel.Size = new System.Drawing.Size(91, 15);
            this.randomTextLabel.TabIndex = 2;
            this.randomTextLabel.Text = "Initializing";
            this.randomTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loadingTextLabel
            // 
            this.loadingTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingTextLabel.ForeColor = System.Drawing.Color.White;
            this.loadingTextLabel.Location = new System.Drawing.Point(293, 358);
            this.loadingTextLabel.Name = "loadingTextLabel";
            this.loadingTextLabel.Size = new System.Drawing.Size(101, 15);
            this.loadingTextLabel.TabIndex = 3;
            this.loadingTextLabel.Text = "Loading";
            this.loadingTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.versionLabel.Location = new System.Drawing.Point(21, 358);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(123, 15);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Version : 0.1.3";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 309);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.loadingTextLabel);
            this.Controls.Add(this.randomTextLabel);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this.progressBarBackground);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel progressBarBackground;
        private System.Windows.Forms.Panel progressBarStatus;
        private System.Windows.Forms.Label randomTextLabel;
        private System.Windows.Forms.Label loadingTextLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}