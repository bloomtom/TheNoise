﻿namespace Lab_7_Finial_Project
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.newUserNameLabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newUserNameBox = new System.Windows.Forms.TextBox();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.confrimPWordlabel = new System.Windows.Forms.Label();
            this.newCPWBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // newUserNameLabel
            // 
            this.newUserNameLabel.AutoSize = true;
            this.newUserNameLabel.ForeColor = System.Drawing.Color.Black;
            this.newUserNameLabel.Location = new System.Drawing.Point(43, 36);
            this.newUserNameLabel.Name = "newUserNameLabel";
            this.newUserNameLabel.Size = new System.Drawing.Size(63, 13);
            this.newUserNameLabel.TabIndex = 0;
            this.newUserNameLabel.Text = "User Name:";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(50, 66);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.newPasswordLabel.TabIndex = 1;
            this.newPasswordLabel.Text = "Password:";
            // 
            // newUserNameBox
            // 
            this.newUserNameBox.Location = new System.Drawing.Point(112, 33);
            this.newUserNameBox.Name = "newUserNameBox";
            this.newUserNameBox.Size = new System.Drawing.Size(100, 20);
            this.newUserNameBox.TabIndex = 2;
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Location = new System.Drawing.Point(112, 63);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.PasswordChar = '?';
            this.NewPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.NewPasswordBox.TabIndex = 3;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(34, 128);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(160, 23);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // confrimPWordlabel
            // 
            this.confrimPWordlabel.AutoSize = true;
            this.confrimPWordlabel.Location = new System.Drawing.Point(12, 96);
            this.confrimPWordlabel.Name = "confrimPWordlabel";
            this.confrimPWordlabel.Size = new System.Drawing.Size(94, 13);
            this.confrimPWordlabel.TabIndex = 5;
            this.confrimPWordlabel.Text = "Confirm Password:";
            // 
            // newCPWBox
            // 
            this.newCPWBox.Location = new System.Drawing.Point(112, 93);
            this.newCPWBox.Name = "newCPWBox";
            this.newCPWBox.Size = new System.Drawing.Size(100, 20);
            this.newCPWBox.TabIndex = 6;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(234, 170);
            this.Controls.Add(this.newCPWBox);
            this.Controls.Add(this.confrimPWordlabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.NewPasswordBox);
            this.Controls.Add(this.newUserNameBox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.newUserNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newUserNameLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox newUserNameBox;
        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label confrimPWordlabel;
        private System.Windows.Forms.TextBox newCPWBox;
    }
}