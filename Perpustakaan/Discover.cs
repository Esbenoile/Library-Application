using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Net.Http;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static Perpustakaan.DatabaseClass;
using System.Web;
using System.IO;

namespace Perpustakaan
{
    public partial class Discover : Form
    {
        RoundButton originalButton = null;

        Dictionary<string, Dictionary<string, Dictionary<string, string>>> multiDict = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();


        private List<Panel> comicPanels = new List<Panel>();
        string genre = "fasfasfasfasfasfa";
        string oldGenre;
        int allIndex;

        public class SearchResult
        {
            public string BookId { get; set; }
            public string BookTitle { get; set; }
            public string BookDescription { get; set; }
            public string BookPublisher { get; set; }
            public byte[] BookImageCover { get; set; }
            public string BookGenre { get; set; }
            public string BookAuthor { get; set; }
        }

        int indexItterate = 1;
        private void DisplayResults(List<SearchResult> results)
        {
            int itemsPerPage = 10;
            int currentPage = 1;

            int totalBooks = results.Count;
            int totalPages = (int)Math.Ceiling(totalBooks / (double)itemsPerPage);

            void PageNumber()
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    RoundButton nextPageButton = new RoundButton();
                    nextPageButton.Text = i.ToString();
                    nextPageButton.Size = new Size(30, 30);
                    nextPageButton.Location = new Point(50 + (i - 1) * 40, 670);
                    int pageNumber = i;
                    nextPageButton.Click += (s, e) =>
                    {
                        currentPage = pageNumber;
                        DisplayBooksForCurrentPage(currentPage);
                    };

                    GenreLayout.Controls.Add(nextPageButton);
                }
            }

            void DisplayBooksForCurrentPage(int pageNumber)
            {
                GenreLayout.Controls.Clear();

                List<Book> paginatedBooks = results
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .Select(result => new Book
                    {
                        BookId = result.BookId,
                        BookTitle = result.BookTitle,
                        BookDescription = result.BookDescription,
                        BookPublisher = result.BookPublisher,
                        BookImageCover = result.BookImageCover,
                        BookGenre = result.BookGenre,
                        BookAuthor = result.BookAuthor,
                    })
                    .ToList();

                int indexItterate = 1;

                foreach (var result in paginatedBooks)
                {
                    AddComicDatabase(
                        result.BookTitle,
                        result.BookId,
                        indexItterate,
                        result.BookGenre,
                        result.BookImageCover,
                        result.BookPublisher,
                        result.BookAuthor,
                        result.BookDescription,
                        result.BookQuantity,
                        result.BookTotal
                    );
                    indexItterate++;
                }

                PageNumber();
            }

            DisplayBooksForCurrentPage(currentPage);
            PageNumber();
        }

        public void SearchBarFunc(string searchText)
        {
            //Console.WriteLine(genre);
            string sqlCmd = @"
        SELECT book_id, book_title, book_description, book_publisher, book_genre, book_writer, book_quantity, book_total, book_image_cover
        FROM book
        WHERE book_title COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + @searchText + '%'";

            searchText = searchText.Trim();

            searchText = System.Text.RegularExpressions.Regex.Replace(searchText, @"[^a-zA-Z0-9\s]", "");

            if (!string.IsNullOrEmpty(genre) && genre != "allGenre")
            {
                sqlCmd += " AND CAST(book_genre AS varchar(MAX)) COLLATE SQL_Latin1_General_CP1_CI_AS = @genre";
            }

            DatabaseClass.BukaDB("book");
            string formattedSearchCmd = sqlCmd
                .Replace("@searchText", $"'{searchText}'")
                .Replace("@genre", genre != null ? $"'{genre}'" : "NULL");

            var bookResults = DatabaseClass.BacaDataBuku(formattedSearchCmd);

            DatabaseClass.TutupDB("book");

            if (bookResults != null && bookResults.Count > 0)
            {
                List<SearchResult> searchResults = bookResults.Select(book => new SearchResult
                {
                    BookId = book.BookId,
                    BookTitle = book.BookTitle,
                    BookDescription = book.BookDescription,
                    BookPublisher = book.BookPublisher,
                    BookImageCover = book.BookImageCover,
                    BookGenre = book.BookGenre,
                    BookAuthor = book.BookAuthor
                }).ToList();

                DisplayResults(searchResults);
            }
        }



        public void RefreshComic(string genreParam, RoundButton buttonParam)
        {
            //Home frmHome = Program.FrmUtama;
            //string text = frmHome.textDetector();
            GenreLayout.Controls.Clear();
            originalButton = buttonParam;
            int itemsPerPage = 10;
            int currentPage = 1;
            int totalBooks = DatabaseClass.GetTotalBooks("book_genre", "book", genreParam);
            int totalPages = (int)Math.Ceiling(totalBooks / (double)itemsPerPage);

            void DisplayBooksForCurrentPage(int pageNumber)
            {
                GenreLayout.Controls.Clear();

                DatabaseClass.BukaDB("book");

                string query = "SELECT * FROM book";
                if (!string.IsNullOrEmpty(genreParam))
                {
                    query += $" WHERE CAST(book_genre AS VARCHAR(MAX)) = '{genreParam}'";
                }

                query += $" ORDER BY book_id OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

                List<DatabaseClass.Book> bookList = DatabaseClass.BacaDataBuku(query);

                int allIndex = 1;
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
                        book.BookTotal
                    );
                    allIndex++;
                }

                DatabaseClass.TutupDB("book");
                if (totalPages > 1)
                {
                    PageNumber();
                }
            }


            void PageNumber()
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    RoundButton nextPageButton = new RoundButton();
                    nextPageButton.Text = i.ToString();
                    nextPageButton.Size = new Size(30, 30);
                    nextPageButton.Location = new Point(50 + (i - 1) * 40, 670);
                    int pageNumber = i;
                    nextPageButton.Click += (s, e) =>
                    {
                        currentPage = pageNumber;
                        DisplayBooksForCurrentPage(currentPage);
                    };

                    GenreLayout.Controls.Add(nextPageButton);
                }
            }

            DisplayBooksForCurrentPage(currentPage);
        }

        public void AddComicDatabase(string bookTitle, string bookCodeParam, int indexPosition, string genreNovel, byte[] pictureBook, string Publisher, string author, string bookDescription, int bookQuantity, int bookTotal)
        {
            Panel comicPanel = new Panel
            {
                Size = new Size(160, 320),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(
                    (((indexPosition - 1) % 5) * 200) + 50,
                    ((indexPosition - 1) / 5 * 310) + 30
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
            comicPanel.Controls.Add(titleLabel);
            comicPanel.Controls.Add(ratingPanel);
            comicPanel.Controls.Add(genreRatingLabel);

            GenreLayout.Controls.Add(comicPanel);
            comicPanels.Add(comicPanel);
        }



        SqlDataReader TabelBuku;
        SqlCommand CmdCari;

        public void allFunction()
        {
            genre = "allGenre";
            int itemsPerPage = 10;
            int currentPage = 1;

            int totalBooks = DatabaseClass.GetTotalBooks("book_genre", "book");
            int totalPages = (int)Math.Ceiling(totalBooks / (double)itemsPerPage);

            void PageNumber()
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    RoundButton nextPageButton = new RoundButton();
                    nextPageButton.Text = i.ToString();
                    nextPageButton.Size = new Size(30, 30);
                    nextPageButton.Location = new Point(50 + (i - 1) * 40, 670);
                    int pageNumber = i;
                    nextPageButton.Click += (s, e) =>
                    {
                        currentPage = pageNumber;
                        DisplayBooksForCurrentPage(currentPage);
                    };

                    GenreLayout.Controls.Add(nextPageButton);
                }
            }


            void DisplayBooksForCurrentPage(int pageNumber)
            {
                GenreLayout.Controls.Clear();

                DatabaseClass.BukaDB("book");
                //Console.WriteLine((pageNumber - 1) * itemsPerPage);
                //Console.WriteLine(itemsPerPage);
                List<Book> bookList = DatabaseClass.BacaDataBuku(
                    $"SELECT * FROM book ORDER BY book_id OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY"
                );
                int allIndex = 1;

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
                        book.BookTotal
                    );
                    allIndex++;
                }

                DatabaseClass.TutupDB("book");
                if (totalPages > 1)
                {
                    PageNumber();
                }
            }

            DisplayBooksForCurrentPage(currentPage);

        }

        public Discover()
        {
            InitializeComponent();

            originalButton = roundButton7;
            //Console.Write("AAAAAAAAAa");
            allFunction();
        }

        public void reload()
        {
            allFunction();
        }

        private void Discover_Load(object sender, EventArgs e)
        {
            
        }

        private void roundButton1_MouseHover(object sender, EventArgs e)
        {

        }

        
        Color turqoiseBackColor = Color.FromArgb(7, 190, 185);
        Color grayBackColor = Color.FromArgb(224, 224, 224);
        Color whiteForeColor = Color.FromArgb(255, 255, 255);
        Color brownForeColor = Color.FromArgb(124, 112, 106);
        private void roundButton2_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton2.BackColor = turqoiseBackColor;
            roundButton2.ForeColor = whiteForeColor;
            RefreshComic("Sci-fi", roundButton2);
            genre = "Sci-fi";
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton3.BackColor = turqoiseBackColor;
            roundButton3.ForeColor = whiteForeColor;
            RefreshComic("Mystery", roundButton3);
            genre = "Mystery";
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton4.BackColor = turqoiseBackColor;
            roundButton4.ForeColor = whiteForeColor;
            RefreshComic("Romance", roundButton4);
            genre = "Romance";
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton5.BackColor = turqoiseBackColor;
            roundButton5.ForeColor = whiteForeColor;
            RefreshComic("Horror", roundButton5);
            genre = "Horror";
        }

        private void roundButton6_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton6.BackColor = turqoiseBackColor;
            roundButton6.ForeColor = whiteForeColor;
            RefreshComic("Biography", roundButton6);
            genre = "Biography";
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton1.BackColor = turqoiseBackColor;
            roundButton1.ForeColor = whiteForeColor;
            RefreshComic("Fantasy", roundButton1);
            genre = "Fantasy";
        }

        private void roundButton7_Click(object sender, EventArgs e)
        {
            originalButton.BackColor = grayBackColor;
            originalButton.ForeColor = brownForeColor;
            roundButton7.BackColor = turqoiseBackColor;
            roundButton7.ForeColor = whiteForeColor;
            originalButton = roundButton7;

            allFunction();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenreLayout_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
