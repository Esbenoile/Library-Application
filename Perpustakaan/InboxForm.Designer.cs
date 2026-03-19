namespace Perpustakaan
{
    partial class InboxForm
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
            this.PageLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.Title = new System.Windows.Forms.Label();
            this.Text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CountDown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PageLayout
            // 
            this.PageLayout.AutoScroll = true;
            this.PageLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PageLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.PageLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PageLayout.Location = new System.Drawing.Point(0, 0);
            this.PageLayout.Name = "PageLayout";
            this.PageLayout.Size = new System.Drawing.Size(591, 708);
            this.PageLayout.TabIndex = 0;
            this.PageLayout.WrapContents = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(608, 116);
            this.Title.MaximumSize = new System.Drawing.Size(900, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(63, 20);
            this.Title.TabIndex = 1;
            this.Title.Text = "label1";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text.Location = new System.Drawing.Point(608, 258);
            this.Text.MaximumSize = new System.Drawing.Size(900, 0);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(63, 20);
            this.Text.TabIndex = 2;
            this.Text.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inbox";
            // 
            // pictureImage
            // 
            this.pictureImage.Location = new System.Drawing.Point(612, 457);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(326, 128);
            this.pictureImage.TabIndex = 4;
            this.pictureImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureImage);
            this.panel1.Controls.Add(this.PageLayout);
            this.panel1.Controls.Add(this.CountDown);
            this.panel1.Controls.Add(this.Text);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 708);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDown.Location = new System.Drawing.Point(607, 399);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(90, 27);
            this.CountDown.TabIndex = 5;
            this.CountDown.Text = "label2";
            // 
            // InboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 708);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "InboxForm";
            this.Load += new System.EventHandler(this.InboxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PageLayout;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CountDown;
    }
}