using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class RentPage : Form
    {
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> multiDict = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

        public RentPage()
        {
            InitializeComponent();
        }


        private List<Panel> comicPanels = new List<Panel>();
        int increment = 1;
        private int publicUserId = -1;

        public void AddComicDatabase(string bookTitle, string bookCodeParam, int indexPosition, string genreNovel, byte[] pictureBook, string Publisher, string author, string bookDescription, int bookQuantity, int bookTotal, int paramInventoryId)
        {
            Panel comicPanel = new Panel
            {
                Size = new Size(160, 330),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(
                    (((indexPosition - 1) % 7) * 200) + 50,
                    ((indexPosition - 1) / 7 * 320) + 30
                )
            };

            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Top,
                Size = new Size(150, 200),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = pictureBook != null && pictureBook.Length > 0
                    ? Image.FromStream(new MemoryStream(pictureBook))
                    : null
            };

            RoundButton button = new RoundButton
            {
                Text = "Read Book",
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(7, 190, 185),
                ForeColor = Color.White,
                Font = new Font("Roboto", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 25)
            };

            Label titleLabel = new Label
            {
                Text = bookTitle,
                Dock = DockStyle.Bottom,
                Font = new Font("Consolas", 10, FontStyle.Bold),
                MaximumSize = new Size(200, 100)
            };

            DatabaseClass.BukaDB("Comments");

            List<int> ratingAmount = Enumerable.Range(1, 5)
                .Select(i =>
                {
                    string query = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating ORDER BY timestamp DESC";
                    var parameters = new Dictionary<string, object>
                    {
                { "@BookId", bookCodeParam },
                { "@Rating", i }
                    };

                    return DatabaseClass.BacaDataComment(query, parameters).Count;
                })
                .ToList();

            DatabaseClass.TutupDB("Comments");

            float ratingScore = ratingAmount.Sum() > 0
                ? ratingAmount.Select((count, i) => count * (i + 1)).Sum() / (float)ratingAmount.Sum()
                : 0f;

            string formattedRating = ratingScore.ToString("0.0");

            Label genreRatingLabel = new Label
            {
                Text = $"{genreNovel}      {formattedRating}",
                Dock = DockStyle.Bottom,
                ForeColor = Color.FromArgb(175, 175, 175),
                Font = new Font("Consolas", 10)
            };

            Panel ratingPanel = new Panel
            {
                Size = new Size(150, 20),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Dock = DockStyle.Bottom
            };

            for (int i = 0; i < 5; i++)
            {
                ratingPanel.Controls.Add(new PictureBox
                {
                    Image = i < (int)ratingScore
                        ? Properties.Resources.full_rating_star
                        : i == (int)ratingScore && ratingScore % 1 != 0
                            ? Properties.Resources.half_rating_star
                            : Properties.Resources.empty_rating_star,
                    Location = new Point(i * 22, 0),
                    Size = new Size(20, 20),
                    SizeMode = PictureBoxSizeMode.StretchImage
                });
            }


            RoundButton buttonDelete = new RoundButton
            {
                Text = "Delete",
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(255,0, 0),
                ForeColor = Color.White,
                Font = new Font("Roboto", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(150, 25)
            };

            buttonDelete.Click += (s, e) =>
            {
                DatabaseClass.BukaDB("inventory");
                DatabaseClass.DeleteInventory(bookCodeParam, publicUserId.ToString(), paramInventoryId);
                DatabaseClass.TutupDB("inventory");
                Reload(publicUserId);
            };

            button.Click += (s, e) =>
            {
                Menu collt = Program.FrmMenu;
                collt.Hide();

                Page page = Program.FrmPage;
                page.UpdateTitleBook(
                    bookTitle,
                    Publisher,
                    author,
                    bookDescription,
                    pictureBook,
                    genreNovel,
                    bookCodeParam,
                    bookQuantity,
                    bookTotal
                );
                page.GlobalBookFetch(bookCodeParam);

                page.Show();
                page.WindowState = FormWindowState.Maximized;
                page.BringToFront();
            };

            comicPanel.Controls.Add(pictureBox);
            comicPanel.Controls.Add(button);
            comicPanel.Controls.Add(buttonDelete);
            comicPanel.Controls.Add(titleLabel);
            comicPanel.Controls.Add(ratingPanel);
            comicPanel.Controls.Add(genreRatingLabel);

            GenreLayout.Controls.Add(comicPanel);
            comicPanels.Add(comicPanel);
        }

        public void Reload(int fetchId)
        {
            publicUserId = fetchId;
            GenreLayout.Controls.Clear();

            DatabaseClass.BukaDB("inventory");
            List<Inventory> inventories = DatabaseClass.GetInventoryByBookIdAndUser(fetchId);
            DatabaseClass.TutupDB("inventory");

            int allIndex = 1;
            foreach (var inventory in inventories)
            {
                Console.WriteLine(inventory.InventoryId);
                DatabaseClass.BukaDB("book");

                List<Book> bookList = DatabaseClass.BacaDataBuku(
                    $"SELECT * FROM book WHERE book_id = '{inventory.InventoryBookId}' ORDER BY book_id"
                );

                foreach (var book in bookList)
                {
                    AddComicDatabase(
                        book.BookTitle,
                        book.BookId,
                        allIndex,
                        book.BookGenre,
                        book.BookImageCover,
                        book.BookPublisher,
                        book.BookAuthor,
                        book.BookDescription,
                        book.BookQuantity,
                        book.BookTotal,
                        inventory.InventoryId
                    );
                }

                allIndex++;

                DatabaseClass.TutupDB("book");
            }

        }

        public void AddComic(int text1, string genre, string publicBookCode)
        {
            Reload(text1);
        }
        

        public void LogOut()
        {
            GenreLayout.Controls.Clear();
            publicUserId = -1;
        }

        private void RentPage_Load(object sender, EventArgs e)
        {

        }

        private void GenreLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
