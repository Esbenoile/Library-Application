using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class Menu : Form
    {
        private string[] comicNames = { "The Cool Book", "Red Dead", "Levitius Cornwall" };
        private string[] publisherNames = { "Leo", "Jifri", "Priscilla" };
        private string[] writerNames = { "Justin", "Selvy, devi", "Gari" };
        private string[] Description = { "Cool Book", "Legendary Gunslinger name arthur", "Mafia Life" };

        private List<Panel> comicPanels = new List<Panel>();

        private void AddComic(string imagePath, string comicTitle, int index)
        {
            Panel comicPanel = new Panel();
            comicPanel.Size = new Size(150, 200);
            comicPanel.BorderStyle = BorderStyle.FixedSingle;

            int panelWidth = comicPanel.Width;
            int panelHeight = comicPanel.Height;
            int padding = 15; 

            int x = (index % 9) * (panelWidth + padding); 
            int y = (index / 9) * (panelHeight + padding); 

            comicPanel.Location = new Point(x, y);

            PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = Image.FromFile(imagePath);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Top;

            Button button = new Button();
            button.Text = comicTitle;
            button.Dock = DockStyle.Bottom;

            button.Click += (s, e) =>
            {
                Menu collt = Program.FrmMenu;
                collt.Hide();
                
                Page page = Program.FrmPage;
                //page.UpdateTitleBook(comicNames[index], publisherNames[index], writerNames[index], Description[index]);
                page.Show();
                page.WindowState = FormWindowState.Maximized;
                page.BringToFront();


                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form != Program.FrmUtama && form != page)
                    {
                        form.Hide();
                    }
                }


            };

            comicPanel.Controls.Add(pictureBox);
            comicPanel.Controls.Add(button);

            ScrollPanel.Controls.Add(comicPanel); 
            comicPanels.Add(comicPanel);
        }


        public Menu()
        {
            InitializeComponent();
            //string[] comicImages = { "path/to/image1.jpg", "path/to/image2.jpg", "path/to/image3.jpg" };
            //string[] comicTitles = { "Co", "Comic Title 2", "Comic Title 3" };

            //for (int i = 0; i < 3; i++)
            //{
            //    AddComic("2", "check comic", i);
            //}

            //TitleHome.Parent = GradientBoxTop;
            //TitleHome.BackColor = Color.Transparent;

        }

        private void Collection_Load(object sender, EventArgs e)
        {
            List<byte[]> stringImageCover = new List<byte[]>(); 
            List<float> floatRating = new List<float>();
            List<int> amountReview = new List<int>();

            DatabaseClass.BukaDB("book");

            string query = "SELECT * FROM book";
            query += $" ORDER BY book_id";

            List<DatabaseClass.Book> bookList = DatabaseClass.BacaDataBuku(query);

            int allIndex = 1;

            foreach (var book in bookList)
            {
                stringImageCover.Add(book.BookImageCover);
                DatabaseClass.BukaDB("Comments");

                List<int> RatingAmount = new List<int>();

                for (int i = 1; i <= 5; i++)
                {
                    var parameters = new Dictionary<string, object>();

                    string queryComment = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating";
                    parameters = new Dictionary<string, object>
                    {
                        { "@BookId", book.BookId },
                        { "@Rating", i}
                    };

                    queryComment += " ORDER BY timestamp DESC";

                    List<DatabaseClass.Comment> commentList = DatabaseClass.BacaDataComment(queryComment, parameters);
                    int indexAmount = 0;
                    foreach (var comment in commentList)
                    {
                        indexAmount++;
                    }
                    RatingAmount.Add(indexAmount);
                }

                int halfSum = 0;

                for (int i = 1; i <= 5; i++)
                {
                    halfSum += RatingAmount[i - 1] * i;
                }


                float RatingScore = ((float)halfSum / RatingAmount.Sum());
                floatRating.Add(RatingScore);

                amountReview.Add(RatingAmount.Sum());
                DatabaseClass.TutupDB("Comments");
                allIndex++;
            }

            DatabaseClass.TutupDB("book");

            //float maxRating = float.MinValue;
            //int k = 0;
            //for (int i = 0; i < floatRating.Count; i++)
            //{
            //    if (floatRating[i] > maxRating)
            //    {
            //        maxRating = floatRating[i];
            //        k = i;
            //    }
            //}


            List<int> rankingIndices = new List<int>();
            List<float> weightedRatings = floatRating
                .Select((rating, index) => new { WeightedRating = rating * amountReview[index], Index = index })
                .OrderByDescending(item => item.WeightedRating)
                .Take(3)
                .ToList()
                .Select(item =>
                {
                    rankingIndices.Add(item.Index);
                    return item.WeightedRating;
                })
                .ToList();

            List<string> rankedBookIds = rankingIndices
                .Select(index => bookList[index].BookId)
                .ToList();


            List<PictureBox> imageList = new List<PictureBox>();
            imageList.Add(pictureBox12);
            imageList.Add(pictureBox2);
            imageList.Add(pictureBox3);

            for (int rank = 0; rank < rankingIndices.Count; rank++)
            {
                if (stringImageCover[rankingIndices[rank]] != null && stringImageCover[rankingIndices[rank]].Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(stringImageCover[rankingIndices[rank]]))
                    {
                        imageList[rank].Image = Image.FromStream(ms);

                        Image filledStar = Properties.Resources.full_rating_star;
                        Image emptyStar = Properties.Resources.empty_rating_star;
                        Image halfStar = Properties.Resources.half_rating_star;

                        Panel ratingPanel = new Panel();
                        ratingPanel.Size = new Size(150, 20);
                        ratingPanel.BorderStyle = BorderStyle.None;
                        ratingPanel.BackColor = Color.White;

                        for (int i = 0; i < 5; i++)
                        {
                            Image starImage;
                            
                            if (i < (int)floatRating[rankingIndices[rank]])
                            {
                                starImage = filledStar;
                            }
                            else if (i == (int)floatRating[rankingIndices[rank]] && floatRating[rankingIndices[rank]] % 1 != 0)
                            {
                                starImage = halfStar;
                            }
                            else
                            {
                                starImage = emptyStar; // Empty stars
                            }

                            PictureBox ratingPicture = new PictureBox
                            {
                                Image = starImage,
                                Location = new Point(i * 22, 0),
                                Size = new Size(20, 20),
                                SizeMode = PictureBoxSizeMode.StretchImage
                            };

                            ratingPanel.Controls.Add(ratingPicture);
                        }

                        ScrollPanel.Controls.Add(ratingPanel);
                        ratingPanel.BringToFront();

                        ratingPanel.Location = new Point(imageList[rank].Location.X + imageList[rank].Size.Width + 10, imageList[rank].Location.Y + 100);

                        Label ratingScoreLabel = new Label();
                        ratingScoreLabel.Text = double.IsNaN(floatRating[rankingIndices[rank]]) ? "0.0" : floatRating[rankingIndices[rank]].ToString("0.0", CultureInfo.InvariantCulture);
                        ratingScoreLabel.Location = new Point(imageList[rank].Location.X + imageList[rank].Size.Width + 140, imageList[rank].Location.Y + 100);
                        ratingScoreLabel.BringToFront();
                        ScrollPanel.Controls.Add(ratingScoreLabel);

                        RoundButton button = new RoundButton();
                        button.Text = "Read Book";
                        button.BackColor = Color.FromArgb(7, 190, 185);
                        button.ForeColor = Color.White;
                        button.Font = new Font("Roboto", 9, FontStyle.Bold);
                        button.FlatStyle = FlatStyle.Flat;
                        button.Size = new Size(150, 25);
                        ScrollPanel.Controls.Add(button);
                        button.Location = new Point(imageList[rank].Location.X + imageList[rank].Size.Width + 20, imageList[rank].Location.Y + imageList[rank].Size.Height - 40);
                        button.BringToFront();

                        DatabaseClass.BukaDB("book");
                        List<Book> rankedBooks = DatabaseClass.BacaDataBuku(
                            $"SELECT * FROM book WHERE book_id = {rankedBookIds[rank]}"
                        );

                        DatabaseClass.TutupDB("book");

                        button.Click += (s, eventArgs) =>
                        {
                            Menu collt = Program.FrmMenu;
                            collt.Hide();

                            Page page = Program.FrmPage;


                            foreach (var book in rankedBooks)
                            {
                                Console.WriteLine(book.BookTitle);
                                page.UpdateTitleBook(
                                    book.BookTitle,
                                    book.BookPublisher,
                                    book.BookAuthor,
                                    book.BookDescription,
                                    book.BookImageCover,
                                    book.BookGenre,
                                    book.BookId,
                                    book.BookQuantity,
                                    book.BookTotal
                                );

                                page.GlobalBookFetch(book.BookId);

                                page.Show();
                                page.WindowState = FormWindowState.Maximized;
                                page.BringToFront();
                            }
                        };

                    }
                }
                else
                {
                    pictureBox12.Image = null;
                }
            }


            //List<int> rankingIndices = new List<int>();
            //List<float> sortedRatings = floatRating
            //    .Select((rating, index) => new { Rating = rating, Index = index })
            //    .OrderByDescending(item => item.Rating)
            //    .Take(3)
            //    .ToList()
            //    .Select(item =>
            //    {
            //        rankingIndices.Add(item.Index);
            //        return item.Rating;
            //    })
            //    .ToList();



            //List<PictureBox> imageList = new List<PictureBox>();
            //imageList.Add(pictureBox12);
            //imageList.Add(pictureBox2);
            //imageList.Add(pictureBox3);


            //for (int rank = 0; rank < rankingIndices.Count; rank++)
            //{
            //    if (stringImageCover[rankingIndices[rank]] != null && stringImageCover[rankingIndices[rank]].Length > 0)
            //    {
            //        using (MemoryStream ms = new MemoryStream(stringImageCover[rankingIndices[rank]]))
            //        {
            //            imageList[rank].Image = Image.FromStream(ms);


            //            Image filledStar = Properties.Resources.full_rating_star;
            //            Image emptyStar = Properties.Resources.empty_rating_star;
            //            Image halfStar = Properties.Resources.half_rating_star;

            //            Panel ratingPanel = new Panel();
            //            ratingPanel.Size = new Size(150, 20);
            //            ratingPanel.BorderStyle = BorderStyle.None;
            //            ratingPanel.BackColor = Color.White;

            //            for (int i = 0; i < 5; i++)
            //            {
            //                Image starImage;

            //                if (i < (int)sortedRatings[rank])
            //                {
            //                    starImage = filledStar;
            //                }
            //                else if (i == (int)sortedRatings[rank] && sortedRatings[rank] % 1 != 0)
            //                {
            //                    starImage = halfStar;
            //                }
            //                else
            //                {
            //                    starImage = emptyStar; // Empty stars
            //                }

            //                PictureBox ratingPicture = new PictureBox
            //                {
            //                    Image = starImage,
            //                    Location = new Point(i * 22, 0),
            //                    Size = new Size(20, 20),
            //                    SizeMode = PictureBoxSizeMode.StretchImage
            //                };

            //                ratingPanel.Controls.Add(ratingPicture);
            //            }

            //            ScrollPanel.Controls.Add(ratingPanel);
            //            ratingPanel.BringToFront();

            //            ratingPanel.Location = new Point(imageList[rank].Location.X + imageList[rank].Size.Width + 10, imageList[rank].Location.Y + 100);

            //            Label ratingScoreLabel = new Label();
            //            ratingScoreLabel.Text = double.IsNaN(sortedRatings[rank]) ? "0.0" : sortedRatings[rank].ToString("0.0", CultureInfo.InvariantCulture);
            //            ratingScoreLabel.Location = new Point(imageList[rank].Location.X + imageList[rank].Size.Width + 140, imageList[rank].Location.Y + 100);
            //            ratingScoreLabel.BringToFront();
            //            ScrollPanel.Controls.Add(ratingScoreLabel);
            //        }
            //    }
            //    else
            //    {
            //        pictureBox12.Image = null;
            //    }
            //}


            //Console.WriteLine("The largest rating is: " + maxRating);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void TitleHome_Click(object sender, EventArgs e)
        {

        }

        private void ScrollPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
