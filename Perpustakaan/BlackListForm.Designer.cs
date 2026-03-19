namespace Perpustakaan
{
    partial class BlackListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelMod = new System.Windows.Forms.Panel();
            this.PanelBlackList = new System.Windows.Forms.Panel();
            this.roundButton1 = new Perpustakaan.RoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton2 = new Perpustakaan.RoundButton();
            this.StatusUserLoL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PanelMod.SuspendLayout();
            this.PanelBlackList.SuspendLayout();
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
            this.PageLayout.Size = new System.Drawing.Size(591, 654);
            this.PageLayout.TabIndex = 0;
            this.PageLayout.WrapContents = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(16, 30);
            this.Title.MaximumSize = new System.Drawing.Size(400, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(395, 92);
            this.Title.TabIndex = 1;
            this.Title.Text = "When it reach 3 level of streaks there gonna be blacklist which you can blacklist" +
    " the user that never return the book";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PageLayout);
            this.panel1.Controls.Add(this.PanelMod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 675);
            this.panel1.TabIndex = 7;
            // 
            // PanelMod
            // 
            this.PanelMod.Controls.Add(this.StatusUserLoL);
            this.PanelMod.Controls.Add(this.Title);
            this.PanelMod.Controls.Add(this.PanelBlackList);
            this.PanelMod.Location = new System.Drawing.Point(612, 93);
            this.PanelMod.Name = "PanelMod";
            this.PanelMod.Size = new System.Drawing.Size(510, 557);
            this.PanelMod.TabIndex = 7;
            this.PanelMod.Visible = false;
            // 
            // PanelBlackList
            // 
            this.PanelBlackList.Controls.Add(this.roundButton2);
            this.PanelBlackList.Controls.Add(this.roundButton1);
            this.PanelBlackList.Location = new System.Drawing.Point(20, 439);
            this.PanelBlackList.Name = "PanelBlackList";
            this.PanelBlackList.Size = new System.Drawing.Size(345, 100);
            this.PanelBlackList.TabIndex = 7;
            this.PanelBlackList.Visible = false;
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(185)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roundButton1.Location = new System.Drawing.Point(3, 26);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(164, 47);
            this.roundButton1.TabIndex = 6;
            this.roundButton1.Text = "Blacklist";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
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
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(185)))));
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roundButton2.Location = new System.Drawing.Point(172, 26);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(164, 47);
            this.roundButton2.TabIndex = 7;
            this.roundButton2.Text = "Whitelist";
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // StatusUserLoL
            // 
            this.StatusUserLoL.AutoSize = true;
            this.StatusUserLoL.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusUserLoL.Location = new System.Drawing.Point(19, 145);
            this.StatusUserLoL.MaximumSize = new System.Drawing.Size(400, 0);
            this.StatusUserLoL.Name = "StatusUserLoL";
            this.StatusUserLoL.Size = new System.Drawing.Size(32, 23);
            this.StatusUserLoL.TabIndex = 8;
            this.StatusUserLoL.Text = "1.";
            // 
            // BlackListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "BlackListForm";
            this.Load += new System.EventHandler(this.BlackListForm_Load);
            this.panel1.ResumeLayout(false);
            this.PanelMod.ResumeLayout(false);
            this.PanelMod.PerformLayout();
            this.PanelBlackList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PageLayout;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelMod;
        private RoundButton roundButton1;
        private System.Windows.Forms.Panel PanelBlackList;
        private RoundButton roundButton2;
        private System.Windows.Forms.Label StatusUserLoL;
    }
}