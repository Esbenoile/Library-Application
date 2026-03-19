namespace Perpustakaan
{
    partial class VerificationEmail
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.DateLabelCountdown = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HelloLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KodeVerification = new System.Windows.Forms.TextBox();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.BtnRegister = new Perpustakaan.RoundButton();
            this.RetryLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(185)))));
            this.panel2.Controls.Add(this.RetryLabel);
            this.panel2.Controls.Add(this.DateLabelCountdown);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 206);
            this.panel2.TabIndex = 24;
            // 
            // DateLabelCountdown
            // 
            this.DateLabelCountdown.AutoSize = true;
            this.DateLabelCountdown.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabelCountdown.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DateLabelCountdown.Location = new System.Drawing.Point(340, 124);
            this.DateLabelCountdown.Name = "DateLabelCountdown";
            this.DateLabelCountdown.Size = new System.Drawing.Size(130, 47);
            this.DateLabelCountdown.TabIndex = 1;
            this.DateLabelCountdown.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(126, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verify Your E-mail Adress";
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelloLabel.Location = new System.Drawing.Point(27, 249);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(87, 23);
            this.HelloLabel.TabIndex = 25;
            this.HelloLabel.Text = "Hello, ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Thank you for register";
            // 
            // KodeVerification
            // 
            this.KodeVerification.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KodeVerification.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KodeVerification.Location = new System.Drawing.Point(31, 329);
            this.KodeVerification.MaxLength = 6;
            this.KodeVerification.Name = "KodeVerification";
            this.KodeVerification.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KodeVerification.Size = new System.Drawing.Size(248, 36);
            this.KodeVerification.TabIndex = 27;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ErrorMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(27, 380);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(21, 23);
            this.ErrorMessage.TabIndex = 34;
            this.ErrorMessage.Text = "w";
            // 
            // BtnRegister
            // 
            this.BtnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(110)))), ((int)(((byte)(185)))));
            this.BtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegister.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.BtnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnRegister.Location = new System.Drawing.Point(31, 443);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(171, 40);
            this.BtnRegister.TabIndex = 33;
            this.BtnRegister.Text = "Verify Email";
            this.BtnRegister.UseVisualStyleBackColor = false;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // RetryLabel
            // 
            this.RetryLabel.AutoSize = true;
            this.RetryLabel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetryLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RetryLabel.Location = new System.Drawing.Point(366, 171);
            this.RetryLabel.Name = "RetryLabel";
            this.RetryLabel.Size = new System.Drawing.Size(77, 27);
            this.RetryLabel.TabIndex = 36;
            this.RetryLabel.Text = "Retry";
            this.RetryLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // VerificationEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(794, 519);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.KodeVerification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HelloLabel);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerificationEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerificationEmail";
            this.Load += new System.EventHandler(this.VerificationEmail_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HelloLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KodeVerification;
        private RoundButton BtnRegister;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label DateLabelCountdown;
        private System.Windows.Forms.Label RetryLabel;
    }
}