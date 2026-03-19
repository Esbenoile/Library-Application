namespace Perpustakaan
{
    partial class SessionActivityForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CountDown = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureCover = new System.Windows.Forms.PictureBox();
            this.PageLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.VerificationCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSession = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.CountDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PictureCover);
            this.panel1.Controls.Add(this.PageLayout);
            this.panel1.Controls.Add(this.VerificationCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 688);
            this.panel1.TabIndex = 7;
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDown.Location = new System.Drawing.Point(605, 646);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(233, 38);
            this.CountDown.TabIndex = 12;
            this.CountDown.Text = "Session Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(608, 609);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Session Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(608, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Your Token";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PictureCover
            // 
            this.PictureCover.Location = new System.Drawing.Point(612, 168);
            this.PictureCover.Name = "PictureCover";
            this.PictureCover.Size = new System.Drawing.Size(366, 438);
            this.PictureCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureCover.TabIndex = 9;
            this.PictureCover.TabStop = false;
            this.PictureCover.Click += new System.EventHandler(this.pictureImage_Click);
            // 
            // PageLayout
            // 
            this.PageLayout.AutoScroll = true;
            this.PageLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PageLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.PageLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PageLayout.Location = new System.Drawing.Point(0, 0);
            this.PageLayout.Name = "PageLayout";
            this.PageLayout.Size = new System.Drawing.Size(591, 688);
            this.PageLayout.TabIndex = 0;
            this.PageLayout.WrapContents = false;
            // 
            // VerificationCode
            // 
            this.VerificationCode.AutoSize = true;
            this.VerificationCode.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationCode.Location = new System.Drawing.Point(605, 125);
            this.VerificationCode.Name = "VerificationCode";
            this.VerificationCode.Size = new System.Drawing.Size(125, 38);
            this.VerificationCode.TabIndex = 8;
            this.VerificationCode.Text = "label2";
            this.VerificationCode.Click += new System.EventHandler(this.VerificationCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inbox";
            // 
            // SessionActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "SessionActivityForm";
            this.Load += new System.EventHandler(this.SessionActivityForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel PageLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer activeTimers;
        private System.Windows.Forms.Timer timerSession;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PictureCover;
        private System.Windows.Forms.Label VerificationCode;
        private System.Windows.Forms.Label CountDown;
        private System.Windows.Forms.Label label3;
    }
}