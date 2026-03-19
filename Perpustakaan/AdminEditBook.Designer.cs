namespace Perpustakaan
{
    partial class AdminEditBook
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TxtBookQuantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.CmbBookID = new System.Windows.Forms.ComboBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.TxtBookGenre = new System.Windows.Forms.TextBox();
            this.TxtBookWriter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBookPublisher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBookDescription = new System.Windows.Forms.TextBox();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnFind = new System.Windows.Forms.Button();
            this.TxtBookTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.DGV);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1331, 598);
            this.panel5.TabIndex = 1;
            // 
            // DGV
            // 
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 281);
            this.DGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 62;
            this.DGV.RowTemplate.Height = 28;
            this.DGV.Size = new System.Drawing.Size(1310, 351);
            this.DGV.TabIndex = 6;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            this.DGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentDoubleClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel6.Controls.Add(this.TxtBookQuantity);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.BtnInsert);
            this.panel6.Controls.Add(this.CmbBookID);
            this.panel6.Controls.Add(this.PictureBox);
            this.panel6.Controls.Add(this.TxtBookGenre);
            this.panel6.Controls.Add(this.TxtBookWriter);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.TxtBookPublisher);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.TxtBookDescription);
            this.panel6.Controls.Add(this.BtnNew);
            this.panel6.Controls.Add(this.BtnDelete);
            this.panel6.Controls.Add(this.BtnChange);
            this.panel6.Controls.Add(this.BtnAdd);
            this.panel6.Controls.Add(this.BtnFind);
            this.panel6.Controls.Add(this.TxtBookTitle);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1310, 231);
            this.panel6.TabIndex = 6;
            // 
            // TxtBookQuantity
            // 
            this.TxtBookQuantity.Location = new System.Drawing.Point(170, 135);
            this.TxtBookQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookQuantity.Name = "TxtBookQuantity";
            this.TxtBookQuantity.Size = new System.Drawing.Size(152, 22);
            this.TxtBookQuantity.TabIndex = 82;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 81;
            this.label7.Text = "Book_Quantity";
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(543, 18);
            this.BtnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(151, 21);
            this.BtnInsert.TabIndex = 80;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // CmbBookID
            // 
            this.CmbBookID.FormattingEnabled = true;
            this.CmbBookID.Location = new System.Drawing.Point(170, 14);
            this.CmbBookID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbBookID.Name = "CmbBookID";
            this.CmbBookID.Size = new System.Drawing.Size(152, 24);
            this.CmbBookID.TabIndex = 79;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(728, 5);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(187, 216);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 78;
            this.PictureBox.TabStop = false;
            // 
            // TxtBookGenre
            // 
            this.TxtBookGenre.Location = new System.Drawing.Point(543, 97);
            this.TxtBookGenre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookGenre.Name = "TxtBookGenre";
            this.TxtBookGenre.Size = new System.Drawing.Size(152, 22);
            this.TxtBookGenre.TabIndex = 77;
            // 
            // TxtBookWriter
            // 
            this.TxtBookWriter.Location = new System.Drawing.Point(543, 60);
            this.TxtBookWriter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookWriter.Name = "TxtBookWriter";
            this.TxtBookWriter.Size = new System.Drawing.Size(152, 22);
            this.TxtBookWriter.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(392, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 74;
            this.label6.Text = "Book_Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(392, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 73;
            this.label5.Text = "Book_Writer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(392, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Book_Image_Cover";
            // 
            // TxtBookPublisher
            // 
            this.TxtBookPublisher.Location = new System.Drawing.Point(170, 97);
            this.TxtBookPublisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookPublisher.Name = "TxtBookPublisher";
            this.TxtBookPublisher.Size = new System.Drawing.Size(152, 22);
            this.TxtBookPublisher.TabIndex = 71;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 70;
            this.label9.Text = "Book_Publisher";
            // 
            // TxtBookDescription
            // 
            this.TxtBookDescription.Location = new System.Drawing.Point(1061, 11);
            this.TxtBookDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookDescription.Multiline = true;
            this.TxtBookDescription.Name = "TxtBookDescription";
            this.TxtBookDescription.Size = new System.Drawing.Size(232, 210);
            this.TxtBookDescription.TabIndex = 69;
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(468, 170);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(67, 24);
            this.BtnNew.TabIndex = 68;
            this.BtnNew.Text = "&New";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(396, 170);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(67, 24);
            this.BtnDelete.TabIndex = 67;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(468, 134);
            this.BtnChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(67, 24);
            this.BtnChange.TabIndex = 66;
            this.BtnChange.Text = "&Change";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(396, 134);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(67, 24);
            this.BtnAdd.TabIndex = 65;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.BackColor = System.Drawing.Color.Transparent;
            this.BtnFind.Location = new System.Drawing.Point(562, 149);
            this.BtnFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(92, 24);
            this.BtnFind.TabIndex = 57;
            this.BtnFind.Text = "Find";
            this.BtnFind.UseVisualStyleBackColor = false;
            // 
            // TxtBookTitle
            // 
            this.TxtBookTitle.Location = new System.Drawing.Point(170, 58);
            this.TxtBookTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBookTitle.Name = "TxtBookTitle";
            this.TxtBookTitle.Size = new System.Drawing.Size(152, 22);
            this.TxtBookTitle.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(941, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Book_Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Book_Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 46;
            this.label8.Text = "Book_ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1310, 50);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1778, 3);
            this.panel4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Library Manage System | Main Form";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(284, 614);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 18);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1331, 598);
            this.panel3.TabIndex = 4;
            // 
            // AdminEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 598);
            this.Controls.Add(this.panel3);
            this.Name = "AdminEditBook";
            this.Text = "AdminEditBook";
            this.Load += new System.EventHandler(this.AdminEditBook_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.ComboBox CmbBookID;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox TxtBookGenre;
        private System.Windows.Forms.TextBox TxtBookWriter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBookPublisher;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtBookDescription;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.TextBox TxtBookTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtBookQuantity;
        private System.Windows.Forms.Label label7;
    }
}