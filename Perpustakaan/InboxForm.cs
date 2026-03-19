using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class InboxForm : Form
    {

        public void globalFunction(string userId)
        {
            DatabaseClass.BukaDB("Rental");
            List<Rental> userRentals = BacaDataRentalByUserId(userId);

            var groupedRentals = userRentals.GroupBy(r => r.RentalDate.Date)
                                             .OrderBy(g => g.Key);

            foreach (var group in groupedRentals)
            {
                if (group.All(rental => !rental.StatusRental))
                {
                    continue;
                }

                FlowLayoutPanel datePanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Margin = new Padding(10)
                };
                PageLayout.Controls.Add(datePanel);

                //Console.WriteLine(group.Key.ToString());

                Label dateHeader = new Label
                {
                    Text = group.Key == DateTime.Today ? "Today" :
                   group.Key == DateTime.Today.AddDays(-1) ? "Yesterday" :
                   $"{(DateTime.Today - group.Key).Days} days ago",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                datePanel.Controls.Add(dateHeader);

                FlowLayoutPanel timelinePanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Padding = new Padding(0, 10, 0, 0)
                };

                datePanel.Controls.Add(timelinePanel);

                foreach (var rental in group)
                {
                    string query = "SELECT * FROM book WHERE book_id = " + rental.RentalBookId;
                    List<Book> bookList = DatabaseClass.BacaDataBuku(query);

                    if (rental.StatusRental)
                    {
                        foreach (var book in bookList)
                        {

                            Panel comicPanel = new Panel();
                            comicPanel.Size = new Size(400, 250);
                            comicPanel.BorderStyle = BorderStyle.None;
                            comicPanel.BackColor = Color.White;
                            comicPanel.Margin = new Padding(0, 0, 0, 10);

                            //timelinePanel.Controls.Add(coverBook);

                            Panel topPanel = new Panel();
                            topPanel.Size = new Size(140, 30);
                            topPanel.BorderStyle = BorderStyle.None;
                            topPanel.BackColor = Color.White;
                            topPanel.Dock = DockStyle.Top;

                            Panel timelineMarker1 = new Panel
                            {
                                Size = new Size(30, 30),
                                Dock = DockStyle.Left,
                                BorderStyle = BorderStyle.None
                            };


                            Label timelineMarker = new Label
                            {
                                Size = new Size(25, 25),
                                Location = new Point(2, 2),
                                BackColor = Color.Blue,
                                BorderStyle = BorderStyle.None
                            };

                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(0, 0, timelineMarker.Width, timelineMarker.Height);
                            timelineMarker.Region = new Region(path);

                            Label titleBook = new Label();
                            titleBook.Text = book.BookTitle;
                            titleBook.Dock = DockStyle.Left;
                            titleBook.ForeColor = Color.FromArgb(0, 0, 0);
                            titleBook.Font = new Font("Consolas", 10);

                            topPanel.Controls.Add(titleBook);
                            topPanel.Controls.Add(timelineMarker1);
                            timelineMarker1.Controls.Add(timelineMarker);

                            DateTime rentalEndDate = rental.EndDate;
                            TimeSpan timeRemaining = rentalEndDate - DateTime.Now;
                            if (timeRemaining.TotalSeconds <= 0)
                                timelineMarker.BackColor = Color.Red;
                            else if (timeRemaining.TotalDays <= (rental.EndDate - rental.RentalDate).TotalDays / 2)
                                timelineMarker.BackColor = Color.Yellow;
                            else
                                timelineMarker.BackColor = Color.Green;


                            Panel pictureBoxPanel = new Panel();
                            pictureBoxPanel.Size = new Size(160, 90);
                            pictureBoxPanel.BorderStyle = BorderStyle.None;
                            pictureBoxPanel.BackColor = Color.White;
                            pictureBoxPanel.Dock = DockStyle.Left;


                            PictureBox pictureBox = new PictureBox();
                            if (book.BookImageCover != null && book.BookImageCover.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(book.BookImageCover))
                                {
                                    pictureBox.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pictureBox.Image = null; // Clear the PictureBox if no image is found
                            }


                            pictureBox.Dock = DockStyle.Left;
                            pictureBox.Size = new Size(150, 90);
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                            //Label label = new Label();
                            //label.Text = bookTitle;
                            //label.Dock = DockStyle.Bottom;
                            //label.Font = new Font("Consolas", 12);


                            List<int> RatingAmount = new List<int>();

                            for (int i = 1; i <= 5; i++)
                            {
                                var parameters = new Dictionary<string, object>();

                                string query1 = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating";
                                parameters = new Dictionary<string, object>
                            {
                                { "@BookId", book.BookId },
                                { "@Rating", i}
                            };

                                query1 += " ORDER BY timestamp DESC";

                                List<DatabaseClass.Comment> commentList = DatabaseClass.BacaDataComment(query1, parameters);
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

                            string formattedRating = float.IsNaN(RatingScore) ? "0.0" : RatingScore.ToString("0.0");

                            //Label label2 = new Label();
                            //label2.Text = genreNovel;
                            //label2.Dock = DockStyle.Left;
                            //label2.ForeColor = Color.FromArgb(175, 175, 175);
                            //label2.Font = new Font("Consolas", 10);

                            Panel fillPanel = new Panel();
                            fillPanel.Size = new Size(200, 100);
                            fillPanel.BorderStyle = BorderStyle.None;
                            fillPanel.BackColor = Color.White;
                            fillPanel.Dock = DockStyle.Left;


                            Image filledStar = Properties.Resources.full_rating_star;
                            Image emptyStar = Properties.Resources.empty_rating_star;
                            Image halfStar = Properties.Resources.half_rating_star;

                            Panel ratingPanel = new Panel();
                            ratingPanel.Size = new Size(150, 20);
                            ratingPanel.BorderStyle = BorderStyle.None;
                            ratingPanel.BackColor = Color.White;
                            ratingPanel.Dock = DockStyle.Top;

                            for (int i = 0; i < 5; i++)
                            {
                                Image starImage;

                                if (i < (int)RatingScore)
                                {
                                    starImage = filledStar;
                                }
                                else if (i == (int)RatingScore && RatingScore % 1 != 0)
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

                            DateTime rentalStartDate = rental.RentalDate;

                            Label formatRatingLabel = new Label();
                            formatRatingLabel.Text = formattedRating;
                            formatRatingLabel.Location = new Point(110, 0);
                            formatRatingLabel.ForeColor = Color.FromArgb(175, 175, 175);
                            formatRatingLabel.Font = new Font("Consolas", 10);

                            string formattedReturnDate = rentalEndDate.ToString("dd MMMM yyyy");
                            string formattedRentDate = rentalStartDate.ToString("dd MMMM yyyy");

                            Label ReturnDate = new Label();
                            ReturnDate.Text = "Return-Date: " + formattedReturnDate;
                            ReturnDate.Dock = DockStyle.Top;
                            ReturnDate.ForeColor = Color.FromArgb(175, 175, 175);
                            ReturnDate.Font = new Font("Consolas", 10);

                            Label RentDate = new Label();
                            RentDate.Text = "Rent-Date: " + formattedRentDate;
                            RentDate.Dock = DockStyle.Top;
                            RentDate.ForeColor = Color.FromArgb(175, 175, 175);
                            RentDate.Font = new Font("Consolas", 10);


                            Label timerRemaining = new Label
                            {
                                AutoSize = true,
                                Font = new Font("Consolas", 12),
                                ForeColor = Color.Gray,
                                Dock = DockStyle.Fill,
                            };

                            if (timeRemaining.TotalSeconds <= 0)
                            {
                                timerRemaining.Text = $"Expired!!!!";
                                timerRemaining.ForeColor = Color.Red;
                            }
                            else
                            {
                                timerRemaining.Text = $"{timeRemaining.Days}d {timeRemaining.Hours}h remaining";
                                timerRemaining.ForeColor = Color.Gray;
                            }

                            //entryPanel.Controls.Add(description);
                            fillPanel.Controls.Add(timerRemaining);


                            fillPanel.Controls.Add(ReturnDate);
                            fillPanel.Controls.Add(RentDate);


                            ratingPanel.Controls.Add(formatRatingLabel);


                            fillPanel.Controls.Add(ratingPanel);

                            //Panel entryPanel = new Panel
                            //{
                            //    AutoSize = true,
                            //    Size = new Size(20, 50)
                            //};

                            //timelinePanel.Controls.Add(entryPanel);

                            //PictureBox coverBook = new PictureBox();
                            //coverBook.Dock = DockStyle.Left;
                            //coverBook.Size = new Size(2, 40);
                            //coverBook.Image = (Image)Properties.Resources.ResourceManager.GetObject(book.BookImageCover);
                            //coverBook.SizeMode = PictureBoxSizeMode.StretchImage;
                            //Label description = new Label
                            //{
                            //    AutoSize = true,
                            //    Text = $"{book.BookTitle}",
                            //    Font = new Font("Arial", 10),
                            //    ForeColor = Color.Black,
                            //    Dock = DockStyle.Top,
                            //};

                            Panel otherFillPanel = new Panel();
                            otherFillPanel.Size = new Size(150, 20);
                            otherFillPanel.BorderStyle = BorderStyle.None;
                            otherFillPanel.BackColor = Color.White;
                            otherFillPanel.Dock = DockStyle.Bottom;

                            RoundButton detailsButton = new RoundButton();
                            detailsButton.Text = "View Details";
                            detailsButton.Dock = DockStyle.Bottom;
                            detailsButton.BackColor = Color.FromArgb(7, 190, 185);
                            detailsButton.ForeColor = Color.White;
                            detailsButton.Font = new Font("Consolas", 8, FontStyle.Bold);
                            detailsButton.FlatStyle = FlatStyle.Flat;
                            detailsButton.Size = new Size(150, 25);

                            fillPanel.Controls.Add(detailsButton);
                            fillPanel.Controls.Add(otherFillPanel);

                            detailsButton.Click += (s, e) =>
                            {
                                StopAllTimers();

                                Timer countdownTimer = new Timer { Interval = 1000 };
                                countdownTimer.Tick += (a, b) =>
                                {
                                    TimeSpan updatedTimeRemaining = rentalEndDate - DateTime.Now;

                                    if (updatedTimeRemaining.TotalSeconds <= 0)
                                    {
                                        CountDown.Text = "Rental period has expired!";
                                        countdownTimer.Stop();
                                    }
                                    else
                                    {
                                        CountDown.Text = $"{updatedTimeRemaining.Days} days, " +
                                                         $"{updatedTimeRemaining.Hours} hours, " +
                                                         $"{updatedTimeRemaining.Minutes} minutes, " +
                                                         $"{updatedTimeRemaining.Seconds} seconds remaining.";
                                    }
                                };

                                activeTimers.Add(countdownTimer);
                                countdownTimer.Start();

                                DatabaseClass.BukaDB("users");
                                List<Register> usernameById = DatabaseClass.GetUsernameById(rental.RentalUserId);
                                DatabaseClass.TutupDB("users");


                                foreach (var user in usernameById)
                                {

                                    Title.Text = $"Thank you, \"{user.Username}\", for borrowing \"{book.BookTitle}\" from our library. We hope this book brings you valuable insights, knowledge, or simply the joy of a good story. As part of our commitment to serving all our readers, we kindly remind you that the due date for this book is [Due Date]. Returning it on time ensures that others can also enjoy it without delay.";
                                    Text.Text = $"If you have any questions, need help with renewing the book, or wish to explore our collection further, please feel free to contact us. Your satisfaction is important to us, and we’re here to assist you. Happy reading, and we look forward to welcoming you back to the library soon!";
                                }


                            };


                            comicPanel.Controls.Add(fillPanel);

                            comicPanel.Controls.Add(pictureBoxPanel);
                            pictureBoxPanel.Controls.Add(pictureBox);

                            comicPanel.Controls.Add(topPanel);

                            //comicPanel.Controls.Add(button);

                            timelinePanel.Controls.Add(comicPanel);

                        }
                    }



                }
            }

            DatabaseClass.TutupDB("Rental");
        }

        public InboxForm()
        {
            InitializeComponent();
        }

        private List<Timer> activeTimers = new List<Timer>();

        public void generateInbox(string book_id, string user_id, string book_name)
        {
            PageLayout.Controls.Clear();
            globalFunction(user_id);
        }

        public void StopAllTimers()
        {
            foreach (var timer in activeTimers)
            {
                timer.Stop();
            }
            activeTimers.Clear();
        }

        public void loadInbox(string userId)
        {
            PageLayout.Controls.Clear();
            globalFunction(userId);
        }

        public void reloadInbox()
        {
            Title.Text = "";
            Text.Text = "";
            CountDown.Text = "";
        }

        private void InboxForm_Load(object sender, EventArgs e)
        {
            reloadInbox();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }
    }
}
