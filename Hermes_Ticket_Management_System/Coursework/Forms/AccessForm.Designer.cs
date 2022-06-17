
namespace Hermes
{
    partial class AccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessForm));
            this.closeButtonPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.accessButton = new System.Windows.Forms.Button();
            this.switchAccessLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.loginErrorLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.accessPageControl = new global::Hermes.TablessControl();
            this.loginPage = new System.Windows.Forms.TabPage();
            this.signupPage = new System.Windows.Forms.TabPage();
            this.signupRepasswordLabel = new System.Windows.Forms.Label();
            this.signupLabel = new System.Windows.Forms.Label();
            this.signupRepasswordTextBox = new System.Windows.Forms.TextBox();
            this.signupPasswordTextBox = new System.Windows.Forms.TextBox();
            this.signupUsernameTextBox = new System.Windows.Forms.TextBox();
            this.signupErrorLabel = new System.Windows.Forms.Label();
            this.signupPasswordLabel = new System.Windows.Forms.Label();
            this.signupUsernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.accessPageControl.SuspendLayout();
            this.loginPage.SuspendLayout();
            this.signupPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButtonPicture
            // 
            this.closeButtonPicture.Image = ((System.Drawing.Image)(resources.GetObject("closeButtonPicture.Image")));
            this.closeButtonPicture.Location = new System.Drawing.Point(531, 18);
            this.closeButtonPicture.Name = "closeButtonPicture";
            this.closeButtonPicture.Size = new System.Drawing.Size(25, 25);
            this.closeButtonPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.closeButtonPicture.TabIndex = 0;
            this.closeButtonPicture.TabStop = false;
            this.closeButtonPicture.Click += new System.EventHandler(this.closeButtonPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-94, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.ForeColor = System.Drawing.Color.White;
            this.loginLabel.Location = new System.Drawing.Point(122, 20);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(32, 13);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "log in";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.ForeColor = System.Drawing.Color.White;
            this.loginUsernameLabel.Location = new System.Drawing.Point(56, 89);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(64, 13);
            this.loginUsernameLabel.TabIndex = 3;
            this.loginUsernameLabel.Text = "Username : ";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.loginPasswordLabel.Location = new System.Drawing.Point(56, 139);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(62, 13);
            this.loginPasswordLabel.TabIndex = 4;
            this.loginPasswordLabel.Text = "Password : ";
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.loginUsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginUsernameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loginUsernameTextBox.Location = new System.Drawing.Point(152, 87);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(170, 20);
            this.loginUsernameTextBox.TabIndex = 5;
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.loginPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loginPasswordTextBox.Location = new System.Drawing.Point(152, 137);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.PasswordChar = '*';
            this.loginPasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.loginPasswordTextBox.TabIndex = 6;
            this.loginPasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // accessButton
            // 
            this.accessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(161)))), ((int)(((byte)(217)))));
            this.accessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accessButton.ForeColor = System.Drawing.Color.White;
            this.accessButton.Location = new System.Drawing.Point(246, 455);
            this.accessButton.Margin = new System.Windows.Forms.Padding(0);
            this.accessButton.Name = "accessButton";
            this.accessButton.Size = new System.Drawing.Size(80, 26);
            this.accessButton.TabIndex = 7;
            this.accessButton.Text = "Log in";
            this.accessButton.UseVisualStyleBackColor = false;
            this.accessButton.Click += new System.EventHandler(this.accessButton_Click);
            // 
            // switchAccessLabel
            // 
            this.switchAccessLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.switchAccessLabel.AutoSize = true;
            this.switchAccessLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(161)))), ((int)(((byte)(217)))));
            this.switchAccessLabel.Location = new System.Drawing.Point(184, 506);
            this.switchAccessLabel.Name = "switchAccessLabel";
            this.switchAccessLabel.Size = new System.Drawing.Size(171, 13);
            this.switchAccessLabel.TabIndex = 8;
            this.switchAccessLabel.Text = "Not Registered Yet? Register Here";
            this.switchAccessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.switchAccessLabel.Click += new System.EventHandler(this.switchAccessLabel_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.copyrightLabel.ForeColor = System.Drawing.Color.White;
            this.copyrightLabel.Location = new System.Drawing.Point(249, 609);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(91, 13);
            this.copyrightLabel.TabIndex = 9;
            this.copyrightLabel.Text = " © 2022 Crypticsy";
            // 
            // loginErrorLabel
            // 
            this.loginErrorLabel.AutoSize = true;
            this.loginErrorLabel.ForeColor = System.Drawing.Color.Salmon;
            this.loginErrorLabel.Location = new System.Drawing.Point(91, 227);
            this.loginErrorLabel.Name = "loginErrorLabel";
            this.loginErrorLabel.Size = new System.Drawing.Size(29, 13);
            this.loginErrorLabel.TabIndex = 10;
            this.loginErrorLabel.Text = "Error";
            this.loginErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(163, -35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // accessPageControl
            // 
            this.accessPageControl.Controls.Add(this.loginPage);
            this.accessPageControl.Controls.Add(this.signupPage);
            this.accessPageControl.Location = new System.Drawing.Point(94, 173);
            this.accessPageControl.Name = "accessPageControl";
            this.accessPageControl.SelectedIndex = 0;
            this.accessPageControl.Size = new System.Drawing.Size(387, 279);
            this.accessPageControl.TabIndex = 14;
            // 
            // loginPage
            // 
            this.loginPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.loginPage.Controls.Add(this.loginLabel);
            this.loginPage.Controls.Add(this.loginErrorLabel);
            this.loginPage.Controls.Add(this.loginPasswordTextBox);
            this.loginPage.Controls.Add(this.loginUsernameLabel);
            this.loginPage.Controls.Add(this.loginUsernameTextBox);
            this.loginPage.Controls.Add(this.loginPasswordLabel);
            this.loginPage.Location = new System.Drawing.Point(4, 22);
            this.loginPage.Name = "loginPage";
            this.loginPage.Padding = new System.Windows.Forms.Padding(3);
            this.loginPage.Size = new System.Drawing.Size(379, 253);
            this.loginPage.TabIndex = 0;
            this.loginPage.Text = "Login";
            // 
            // signupPage
            // 
            this.signupPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.signupPage.Controls.Add(this.signupRepasswordLabel);
            this.signupPage.Controls.Add(this.signupLabel);
            this.signupPage.Controls.Add(this.signupRepasswordTextBox);
            this.signupPage.Controls.Add(this.signupPasswordTextBox);
            this.signupPage.Controls.Add(this.signupUsernameTextBox);
            this.signupPage.Controls.Add(this.signupErrorLabel);
            this.signupPage.Controls.Add(this.signupPasswordLabel);
            this.signupPage.Controls.Add(this.signupUsernameLabel);
            this.signupPage.Location = new System.Drawing.Point(4, 22);
            this.signupPage.Name = "signupPage";
            this.signupPage.Padding = new System.Windows.Forms.Padding(3);
            this.signupPage.Size = new System.Drawing.Size(379, 253);
            this.signupPage.TabIndex = 1;
            this.signupPage.Text = "Sign up";
            // 
            // signupRepasswordLabel
            // 
            this.signupRepasswordLabel.AutoSize = true;
            this.signupRepasswordLabel.ForeColor = System.Drawing.Color.White;
            this.signupRepasswordLabel.Location = new System.Drawing.Point(56, 189);
            this.signupRepasswordLabel.Name = "signupRepasswordLabel";
            this.signupRepasswordLabel.Size = new System.Drawing.Size(75, 13);
            this.signupRepasswordLabel.TabIndex = 27;
            this.signupRepasswordLabel.Text = "Repassword : ";
            // 
            // signupLabel
            // 
            this.signupLabel.AutoSize = true;
            this.signupLabel.ForeColor = System.Drawing.Color.White;
            this.signupLabel.Location = new System.Drawing.Point(122, 20);
            this.signupLabel.Name = "signupLabel";
            this.signupLabel.Size = new System.Drawing.Size(41, 13);
            this.signupLabel.TabIndex = 21;
            this.signupLabel.Text = "sign up";
            this.signupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signupRepasswordTextBox
            // 
            this.signupRepasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.signupRepasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signupRepasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.signupRepasswordTextBox.Location = new System.Drawing.Point(152, 187);
            this.signupRepasswordTextBox.Name = "signupRepasswordTextBox";
            this.signupRepasswordTextBox.PasswordChar = '*';
            this.signupRepasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.signupRepasswordTextBox.TabIndex = 28;
            this.signupRepasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // signupPasswordTextBox
            // 
            this.signupPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.signupPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signupPasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.signupPasswordTextBox.Location = new System.Drawing.Point(152, 137);
            this.signupPasswordTextBox.Name = "signupPasswordTextBox";
            this.signupPasswordTextBox.PasswordChar = '*';
            this.signupPasswordTextBox.Size = new System.Drawing.Size(170, 20);
            this.signupPasswordTextBox.TabIndex = 25;
            // 
            // signupUsernameTextBox
            // 
            this.signupUsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.signupUsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signupUsernameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.signupUsernameTextBox.Location = new System.Drawing.Point(152, 87);
            this.signupUsernameTextBox.Name = "signupUsernameTextBox";
            this.signupUsernameTextBox.Size = new System.Drawing.Size(170, 20);
            this.signupUsernameTextBox.TabIndex = 24;
            // 
            // signupErrorLabel
            // 
            this.signupErrorLabel.AutoSize = true;
            this.signupErrorLabel.ForeColor = System.Drawing.Color.Salmon;
            this.signupErrorLabel.Location = new System.Drawing.Point(91, 227);
            this.signupErrorLabel.Name = "signupErrorLabel";
            this.signupErrorLabel.Size = new System.Drawing.Size(29, 13);
            this.signupErrorLabel.TabIndex = 26;
            this.signupErrorLabel.Text = "Error";
            this.signupErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signupPasswordLabel
            // 
            this.signupPasswordLabel.AutoSize = true;
            this.signupPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.signupPasswordLabel.Location = new System.Drawing.Point(56, 139);
            this.signupPasswordLabel.Name = "signupPasswordLabel";
            this.signupPasswordLabel.Size = new System.Drawing.Size(62, 13);
            this.signupPasswordLabel.TabIndex = 23;
            this.signupPasswordLabel.Text = "Password : ";
            // 
            // signupUsernameLabel
            // 
            this.signupUsernameLabel.AutoSize = true;
            this.signupUsernameLabel.ForeColor = System.Drawing.Color.White;
            this.signupUsernameLabel.Location = new System.Drawing.Point(56, 89);
            this.signupUsernameLabel.Name = "signupUsernameLabel";
            this.signupUsernameLabel.Size = new System.Drawing.Size(64, 13);
            this.signupUsernameLabel.TabIndex = 22;
            this.signupUsernameLabel.Text = "Username : ";
            // 
            // AccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(575, 650);
            this.Controls.Add(this.accessPageControl);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.switchAccessLabel);
            this.Controls.Add(this.closeButtonPicture);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.accessButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hermes";
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.accessPageControl.ResumeLayout(false);
            this.loginPage.ResumeLayout(false);
            this.loginPage.PerformLayout();
            this.signupPage.ResumeLayout(false);
            this.signupPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeButtonPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginUsernameTextBox;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Button accessButton;
        private System.Windows.Forms.Label switchAccessLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label loginErrorLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private TablessControl accessPageControl;
        private System.Windows.Forms.TabPage loginPage;
        private System.Windows.Forms.TabPage signupPage;
        private System.Windows.Forms.Label signupRepasswordLabel;
        private System.Windows.Forms.Label signupLabel;
        private System.Windows.Forms.TextBox signupRepasswordTextBox;
        private System.Windows.Forms.TextBox signupPasswordTextBox;
        private System.Windows.Forms.TextBox signupUsernameTextBox;
        private System.Windows.Forms.Label signupErrorLabel;
        private System.Windows.Forms.Label signupPasswordLabel;
        private System.Windows.Forms.Label signupUsernameLabel;
    }
}

