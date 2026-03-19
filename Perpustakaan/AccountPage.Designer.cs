namespace Perpustakaan
{
    partial class AccountPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.FinancialAccountButton = new Perpustakaan.RoundButton();
            this.MyAccountButton = new Perpustakaan.RoundButton();
            this.AccountPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NameStuffDisplay = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DateCreated = new System.Windows.Forms.Label();
            this.GmailProfile = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameProfile = new System.Windows.Forms.Label();
            this.roundButton2 = new Perpustakaan.RoundButton();
            this.FinancialPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.roundButton1 = new Perpustakaan.RoundButton();
            this.Balance = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.LanguageCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.AccountPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.FinancialPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.AccountPanel);
            this.panel1.Controls.Add(this.FinancialPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1890, 1022);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Controls.Add(this.FinancialAccountButton);
            this.panel7.Controls.Add(this.MyAccountButton);
            this.panel7.Location = new System.Drawing.Point(38, 82);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(247, 773);
            this.panel7.TabIndex = 16;
            // 
            // FinancialAccountButton
            // 
            this.FinancialAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FinancialAccountButton.FlatAppearance.BorderSize = 0;
            this.FinancialAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinancialAccountButton.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialAccountButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FinancialAccountButton.Location = new System.Drawing.Point(7, 49);
            this.FinancialAccountButton.Name = "FinancialAccountButton";
            this.FinancialAccountButton.Size = new System.Drawing.Size(237, 48);
            this.FinancialAccountButton.TabIndex = 5;
            this.FinancialAccountButton.Text = "Financial && Payment";
            this.FinancialAccountButton.UseVisualStyleBackColor = false;
            this.FinancialAccountButton.Click += new System.EventHandler(this.FinancialAccountButton_Click);
            // 
            // MyAccountButton
            // 
            this.MyAccountButton.BackColor = System.Drawing.Color.Silver;
            this.MyAccountButton.FlatAppearance.BorderSize = 0;
            this.MyAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyAccountButton.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyAccountButton.ForeColor = System.Drawing.Color.Black;
            this.MyAccountButton.Location = new System.Drawing.Point(7, 6);
            this.MyAccountButton.Name = "MyAccountButton";
            this.MyAccountButton.Size = new System.Drawing.Size(237, 44);
            this.MyAccountButton.TabIndex = 4;
            this.MyAccountButton.Text = "My Account";
            this.MyAccountButton.UseVisualStyleBackColor = false;
            this.MyAccountButton.Click += new System.EventHandler(this.roundButton3_Click);
            // 
            // AccountPanel
            // 
            this.AccountPanel.Controls.Add(this.panel3);
            this.AccountPanel.Controls.Add(this.panel4);
            this.AccountPanel.Location = new System.Drawing.Point(291, 70);
            this.AccountPanel.Name = "AccountPanel";
            this.AccountPanel.Size = new System.Drawing.Size(1444, 807);
            this.AccountPanel.TabIndex = 15;
            this.AccountPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.NameStuffDisplay);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DateCreated);
            this.panel3.Controls.Add(this.GmailProfile);
            this.panel3.Location = new System.Drawing.Point(5, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1336, 498);
            this.panel3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 28);
            this.label1.TabIndex = 16;
            this.label1.Text = "Display Name";
            // 
            // NameStuffDisplay
            // 
            this.NameStuffDisplay.AutoSize = true;
            this.NameStuffDisplay.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameStuffDisplay.ForeColor = System.Drawing.Color.Black;
            this.NameStuffDisplay.Location = new System.Drawing.Point(12, 133);
            this.NameStuffDisplay.Name = "NameStuffDisplay";
            this.NameStuffDisplay.Size = new System.Drawing.Size(76, 25);
            this.NameStuffDisplay.TabIndex = 15;
            this.NameStuffDisplay.Text = "Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(0, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1336, 4);
            this.panel5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(12, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 34);
            this.label2.TabIndex = 9;
            this.label2.Text = "Personal Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(12, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date Created";
            // 
            // DateCreated
            // 
            this.DateCreated.AutoSize = true;
            this.DateCreated.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateCreated.ForeColor = System.Drawing.Color.Black;
            this.DateCreated.Location = new System.Drawing.Point(12, 331);
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.Size = new System.Drawing.Size(64, 25);
            this.DateCreated.TabIndex = 8;
            this.DateCreated.Text = "Date";
            // 
            // GmailProfile
            // 
            this.GmailProfile.AutoSize = true;
            this.GmailProfile.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GmailProfile.ForeColor = System.Drawing.Color.Black;
            this.GmailProfile.Location = new System.Drawing.Point(12, 239);
            this.GmailProfile.Name = "GmailProfile";
            this.GmailProfile.Size = new System.Drawing.Size(76, 25);
            this.GmailProfile.TabIndex = 1;
            this.GmailProfile.Text = "Gmail";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.UsernameProfile);
            this.panel4.Controls.Add(this.roundButton2);
            this.panel4.Location = new System.Drawing.Point(5, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1336, 257);
            this.panel4.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Perpustakaan.Properties.Resources.Profile_Picture_White;
            this.pictureBox1.Location = new System.Drawing.Point(9, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameProfile
            // 
            this.UsernameProfile.AutoSize = true;
            this.UsernameProfile.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameProfile.Location = new System.Drawing.Point(226, 4);
            this.UsernameProfile.Name = "UsernameProfile";
            this.UsernameProfile.Size = new System.Drawing.Size(113, 34);
            this.UsernameProfile.TabIndex = 0;
            this.UsernameProfile.Text = "label1";
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(185)))));
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.roundButton2.Location = new System.Drawing.Point(232, 167);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(205, 37);
            this.roundButton2.TabIndex = 2;
            this.roundButton2.Text = "Upload New photo";
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // FinancialPanel
            // 
            this.FinancialPanel.BackColor = System.Drawing.Color.White;
            this.FinancialPanel.Controls.Add(this.panel6);
            this.FinancialPanel.Location = new System.Drawing.Point(291, 70);
            this.FinancialPanel.Name = "FinancialPanel";
            this.FinancialPanel.Size = new System.Drawing.Size(1444, 807);
            this.FinancialPanel.TabIndex = 0;
            this.FinancialPanel.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.roundButton1);
            this.panel6.Controls.Add(this.Balance);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.LanguageCurrency);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(5, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1336, 773);
            this.panel6.TabIndex = 4;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint_1);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.roundButton1.Location = new System.Drawing.Point(9, 154);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(134, 39);
            this.roundButton1.TabIndex = 6;
            this.roundButton1.Text = "Pay";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balance.ForeColor = System.Drawing.Color.Black;
            this.Balance.Location = new System.Drawing.Point(12, 110);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(99, 25);
            this.Balance.TabIndex = 4;
            this.Balance.Text = "Balance";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(0, 49);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1336, 8);
            this.panel8.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total balance";
            // 
            // LanguageCurrency
            // 
            this.LanguageCurrency.FormattingEnabled = true;
            this.LanguageCurrency.Location = new System.Drawing.Point(154, 69);
            this.LanguageCurrency.Name = "LanguageCurrency";
            this.LanguageCurrency.Size = new System.Drawing.Size(134, 24);
            this.LanguageCurrency.TabIndex = 7;
            this.LanguageCurrency.SelectedIndexChanged += new System.EventHandler(this.LanguageCurrency_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Balance";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1890, 54);
            this.panel2.TabIndex = 1;
            // 
            // AccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1890, 1022);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountPage";
            this.Text = "AccountPage";
            this.Load += new System.EventHandler(this.AccountPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.AccountPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.FinancialPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label UsernameProfile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label GmailProfile;
        private RoundButton roundButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Balance;
        private RoundButton roundButton1;
        private System.Windows.Forms.ComboBox LanguageCurrency;
        private System.Windows.Forms.Label DateCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel AccountPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameStuffDisplay;
        private System.Windows.Forms.Panel panel7;
        private RoundButton MyAccountButton;
        private RoundButton FinancialAccountButton;
        private System.Windows.Forms.Panel FinancialPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
    }
}