namespace Perpustakaan
{
    partial class CodeItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.VerificationCode = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.timerSession = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.PictureCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureCover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 600);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Time";
            // 
            // VerificationCode
            // 
            this.VerificationCode.AutoSize = true;
            this.VerificationCode.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerificationCode.Location = new System.Drawing.Point(284, 102);
            this.VerificationCode.Name = "VerificationCode";
            this.VerificationCode.Size = new System.Drawing.Size(125, 38);
            this.VerificationCode.TabIndex = 1;
            this.VerificationCode.Text = "label2";
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(284, 637);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(233, 38);
            this.Timer.TabIndex = 3;
            this.Timer.Text = "Session Time";
            // 
            // timerSession
            // 
            this.timerSession.Tick += new System.EventHandler(this.timerSession_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Your Token";
            // 
            // PictureCover
            // 
            this.PictureCover.Location = new System.Drawing.Point(291, 145);
            this.PictureCover.Name = "PictureCover";
            this.PictureCover.Size = new System.Drawing.Size(366, 438);
            this.PictureCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureCover.TabIndex = 2;
            this.PictureCover.TabStop = false;
            // 
            // CodeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 754);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.PictureCover);
            this.Controls.Add(this.VerificationCode);
            this.Controls.Add(this.label1);
            this.Name = "CodeItem";
            this.Text = "CodeItem";
            this.Load += new System.EventHandler(this.CodeItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VerificationCode;
        private System.Windows.Forms.PictureBox PictureCover;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Timer timerSession;
        private System.Windows.Forms.Label label2;
    }
}