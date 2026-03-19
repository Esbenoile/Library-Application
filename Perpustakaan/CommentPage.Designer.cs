namespace Perpustakaan
{
    partial class CommentPage
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
            this.panelStars = new System.Windows.Forms.Panel();
            this.FifthRating = new System.Windows.Forms.PictureBox();
            this.FourthRating = new System.Windows.Forms.PictureBox();
            this.ThirdRating = new System.Windows.Forms.PictureBox();
            this.SecondRating = new System.Windows.Forms.PictureBox();
            this.FirstRating = new System.Windows.Forms.PictureBox();
            this.Comment = new System.Windows.Forms.TextBox();
            this.CommentButton = new Perpustakaan.RoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorLimit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelStars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FifthRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstRating)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStars
            // 
            this.panelStars.Controls.Add(this.FifthRating);
            this.panelStars.Controls.Add(this.FourthRating);
            this.panelStars.Controls.Add(this.ThirdRating);
            this.panelStars.Controls.Add(this.SecondRating);
            this.panelStars.Controls.Add(this.FirstRating);
            this.panelStars.Location = new System.Drawing.Point(21, 66);
            this.panelStars.Name = "panelStars";
            this.panelStars.Size = new System.Drawing.Size(494, 119);
            this.panelStars.TabIndex = 0;
            // 
            // FifthRating
            // 
            this.FifthRating.Image = global::Perpustakaan.Properties.Resources.empty_rating_star;
            this.FifthRating.Location = new System.Drawing.Point(376, 43);
            this.FifthRating.Name = "FifthRating";
            this.FifthRating.Size = new System.Drawing.Size(50, 50);
            this.FifthRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FifthRating.TabIndex = 4;
            this.FifthRating.TabStop = false;
            // 
            // FourthRating
            // 
            this.FourthRating.Image = global::Perpustakaan.Properties.Resources.empty_rating_star;
            this.FourthRating.Location = new System.Drawing.Point(302, 43);
            this.FourthRating.Name = "FourthRating";
            this.FourthRating.Size = new System.Drawing.Size(50, 50);
            this.FourthRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FourthRating.TabIndex = 3;
            this.FourthRating.TabStop = false;
            // 
            // ThirdRating
            // 
            this.ThirdRating.Image = global::Perpustakaan.Properties.Resources.empty_rating_star;
            this.ThirdRating.Location = new System.Drawing.Point(228, 43);
            this.ThirdRating.Name = "ThirdRating";
            this.ThirdRating.Size = new System.Drawing.Size(50, 50);
            this.ThirdRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThirdRating.TabIndex = 2;
            this.ThirdRating.TabStop = false;
            // 
            // SecondRating
            // 
            this.SecondRating.Image = global::Perpustakaan.Properties.Resources.empty_rating_star;
            this.SecondRating.Location = new System.Drawing.Point(154, 43);
            this.SecondRating.Name = "SecondRating";
            this.SecondRating.Size = new System.Drawing.Size(50, 50);
            this.SecondRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SecondRating.TabIndex = 1;
            this.SecondRating.TabStop = false;
            // 
            // FirstRating
            // 
            this.FirstRating.Image = global::Perpustakaan.Properties.Resources.empty_rating_star;
            this.FirstRating.Location = new System.Drawing.Point(80, 43);
            this.FirstRating.Name = "FirstRating";
            this.FirstRating.Size = new System.Drawing.Size(50, 50);
            this.FirstRating.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FirstRating.TabIndex = 0;
            this.FirstRating.TabStop = false;
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Comment.Location = new System.Drawing.Point(22, 284);
            this.Comment.Multiline = true;
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(493, 283);
            this.Comment.TabIndex = 1;
            // 
            // CommentButton
            // 
            this.CommentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(185)))));
            this.CommentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommentButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CommentButton.Location = new System.Drawing.Point(21, 615);
            this.CommentButton.Name = "CommentButton";
            this.CommentButton.Size = new System.Drawing.Size(494, 52);
            this.CommentButton.TabIndex = 2;
            this.CommentButton.Text = "Submit";
            this.CommentButton.UseVisualStyleBackColor = false;
            this.CommentButton.Click += new System.EventHandler(this.CommentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comments";
            // 
            // ErrorLimit
            // 
            this.ErrorLimit.AutoSize = true;
            this.ErrorLimit.BackColor = System.Drawing.Color.White;
            this.ErrorLimit.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLimit.ForeColor = System.Drawing.Color.Red;
            this.ErrorLimit.Location = new System.Drawing.Point(19, 570);
            this.ErrorLimit.Name = "ErrorLimit";
            this.ErrorLimit.Size = new System.Drawing.Size(49, 15);
            this.ErrorLimit.TabIndex = 5;
            this.ErrorLimit.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(499, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 27);
            this.label4.TabIndex = 27;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CommentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 715);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ErrorLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommentButton);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.panelStars);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommentPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommentPage";
            this.Load += new System.EventHandler(this.CommentPage_Load);
            this.panelStars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FifthRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelStars;
        private System.Windows.Forms.TextBox Comment;
        private RoundButton CommentButton;
        private System.Windows.Forms.PictureBox FirstRating;
        private System.Windows.Forms.PictureBox FifthRating;
        private System.Windows.Forms.PictureBox FourthRating;
        private System.Windows.Forms.PictureBox ThirdRating;
        private System.Windows.Forms.PictureBox SecondRating;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorLimit;
        private System.Windows.Forms.Label label4;
    }
}