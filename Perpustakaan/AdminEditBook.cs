using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class AdminEditBook : Form
    {
        public AdminEditBook()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbBookID.Text) ||
                string.IsNullOrWhiteSpace(TxtBookTitle.Text) ||
                string.IsNullOrWhiteSpace(TxtBookDescription.Text) ||
                string.IsNullOrWhiteSpace(TxtBookPublisher.Text) ||
                string.IsNullOrWhiteSpace(TxtBookWriter.Text) ||
                string.IsNullOrWhiteSpace(TxtBookGenre.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PictureBox.Image == null)
            {
                MessageBox.Show("Please select an image for the book cover.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DatabaseClass.BukaDB("book");
                DatabaseClass.AddNewBook(
                    CmbBookID.Text,
                    TxtBookTitle.Text,
                    TxtBookDescription.Text,
                    TxtBookPublisher.Text,
                    TxtBookWriter.Text,
                    TxtBookGenre.Text,
                    int.Parse(TxtBookQuantity.Text),
                    int.Parse(TxtBookQuantity.Text),
                    PictureBox.Image
                );
                reloadWhole();
                Program.FrmDiscover.allFunction();
                DatabaseClass.TutupDB("book");

                MessageBox.Show("Data berhasil disimpan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select a Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CmbBookID.Text) ||
                string.IsNullOrWhiteSpace(TxtBookTitle.Text) ||
                string.IsNullOrWhiteSpace(TxtBookDescription.Text) ||
                string.IsNullOrWhiteSpace(TxtBookPublisher.Text) ||
                string.IsNullOrWhiteSpace(TxtBookWriter.Text) ||
                string.IsNullOrWhiteSpace(TxtBookGenre.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PictureBox.Image == null)
            {
                MessageBox.Show("Please select an image for the book cover.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DatabaseClass.BukaDB("book");
                DatabaseClass.UpdateBook(
                    CmbBookID.Text,
                    TxtBookTitle.Text,
                    TxtBookDescription.Text,
                    TxtBookPublisher.Text,
                    TxtBookWriter.Text,
                    TxtBookGenre.Text,
                    int.Parse(TxtBookQuantity.Text),
                    int.Parse(TxtBookQuantity.Text),
                    PictureBox.Image
                );
                reloadWhole();
                Program.FrmDiscover.allFunction();
                DatabaseClass.TutupDB("book");

                MessageBox.Show("Data berhasil disimpan!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void reloadWhole()
        {
            DGV.Rows.Clear();

            if (DGV.Columns.Count == 0)
            {
                DGV.Columns.Add("BookId", "Book ID");
                DGV.Columns.Add("BookTitle", "Title");
                DGV.Columns.Add("BookDescription", "Description");
                DGV.Columns.Add("BookPublisher", "Publisher");
                DGV.Columns.Add("BookAuthor", "Author");
                DGV.Columns.Add("BookGenre", "Genre");
                DGV.Columns.Add("BookQuantity", "Quantity");
                DGV.Columns.Add("BookTotal", "Total");
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "BookImageCover";
                imgCol.HeaderText = "Cover Image";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                DGV.Columns.Add(imgCol);
            }

            string sqlCmd = "SELECT * FROM book";

            List<Book> books = DatabaseClass.BacaDataBuku(sqlCmd);

            foreach (var book in books)
            {
                DGV.Rows.Add(
                    book.BookId,
                    book.BookTitle,
                    book.BookDescription,
                    book.BookPublisher,
                    book.BookAuthor,
                    book.BookGenre,
                    book.BookQuantity,
                    book.BookTotal,
                    ConvertImageToBitmap(book.BookImageCover)
                );
            }
        }

        private Bitmap ConvertImageToBitmap(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                return new Bitmap(ms);
            }
        }

        private void AdminEditBook_Load(object sender, EventArgs e)
        {
            DatabaseClass.BukaDB("book");
            reloadWhole();
            DatabaseClass.TutupDB("book");
        }

        private void DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DGV.Rows.Count)
            {
                DataGridViewRow row = DGV.Rows[e.RowIndex];

                CmbBookID.Text = row.Cells["BookId"].Value.ToString();
                TxtBookTitle.Text = row.Cells["BookTitle"].Value.ToString();
                TxtBookDescription.Text = row.Cells["BookDescription"].Value.ToString();
                TxtBookPublisher.Text = row.Cells["BookPublisher"].Value.ToString();
                TxtBookWriter.Text = row.Cells["BookAuthor"].Value.ToString();
                TxtBookGenre.Text = row.Cells["BookGenre"].Value.ToString();
                TxtBookQuantity.Text = row.Cells["BookQuantity"].Value.ToString();

                if (row.Cells["BookImageCover"].Value is Bitmap bitmap)
                {
                    PictureBox.Image = bitmap;
                }
                else
                {
                    PictureBox.Image = null; 
                }
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CmbBookID.Text = "";
            TxtBookTitle.Text = "";
            TxtBookDescription.Text = "";
            TxtBookPublisher.Text = "";
            TxtBookWriter.Text = "";
            TxtBookGenre.Text = "";
            TxtBookQuantity.Text = "";
        }
    }
}
