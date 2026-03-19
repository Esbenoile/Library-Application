using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        public void globalFunction()
        {
            DatabaseClass.BukaDB("Rental");
            List<Rental> userRentals = BacaDataRentalByUserId();

            var groupedRentals = userRentals.GroupBy(r => r.RentalDate.Date)
                                             .OrderBy(g => g.Key);

            foreach (var group in groupedRentals)
            {
                if (group.All(rental => rental.StatusRental))
                {
                    continue;
                }

                FlowLayoutPanel datePanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Margin = new Padding(10)
                };
                PageLayout1.Controls.Add(datePanel);

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
                    Padding = new Padding(20, 0, 0, 0)
                };

                datePanel.Controls.Add(timelinePanel);

                foreach (var rental in group)
                {
                    string query = "SELECT * FROM book WHERE book_id = " + rental.RentalBookId;
                    List<Book> bookList = DatabaseClass.BacaDataBuku(query);
                    //Console.WriteLine(rental.StatusRental);

                    if (!rental.StatusRental)
                    {
                        foreach (var book in bookList)
                        {

                            Panel comicPanel = new Panel();
                            comicPanel.Size = new Size(300, 80);
                            comicPanel.BorderStyle = BorderStyle.None;
                            comicPanel.BackColor = Color.White;

                            //timelinePanel.Controls.Add(coverBook);

                            Panel topPanel = new Panel();
                            topPanel.Size = new Size(140, 25);
                            topPanel.BorderStyle = BorderStyle.None;
                            topPanel.BackColor = Color.White;
                            topPanel.Dock = DockStyle.Top;

                            Label titleBook = new Label();
                            titleBook.Text = rental.CodeGeneration;
                            titleBook.Dock = DockStyle.Left;
                            titleBook.ForeColor = Color.FromArgb(175, 175, 175);
                            titleBook.Font = new Font("Consolas", 10);

                            topPanel.Controls.Add(titleBook);


                            Panel fillPanel = new Panel();
                            fillPanel.Size = new Size(200, 100);
                            fillPanel.BorderStyle = BorderStyle.None;
                            fillPanel.BackColor = Color.White;
                            fillPanel.Dock = DockStyle.Left;


                            Label ReturnDate = new Label();
                            ReturnDate.Dock = DockStyle.Top;
                            ReturnDate.ForeColor = Color.FromArgb(175, 175, 175);
                            ReturnDate.Font = new Font("Consolas", 10);


                            DateTime rentalStartDate = rental.RentalDate;
                            TimeSpan remainingTime = DateTime.Today.AddDays(1).AddHours(0) - DateTime.Now;

                            if (remainingTime.TotalSeconds <= 0)
                            {
                                timerSession.Stop();
                                ReturnDate.Text = "Session Time: 0 hours";
                            }
                            else
                            {
                                string formattedTime = $"{remainingTime.Hours} hours";
                                ReturnDate.Text = "Session Time: " + formattedTime;
                            }

                            fillPanel.Controls.Add(ReturnDate);


                            RoundButton detailsButton = new RoundButton();
                            detailsButton.Text = "View Details";
                            detailsButton.Dock = DockStyle.Bottom;
                            detailsButton.BackColor = Color.FromArgb(7, 190, 185);
                            detailsButton.ForeColor = Color.White;
                            detailsButton.Font = new Font("Consolas", 8, FontStyle.Bold);
                            detailsButton.FlatStyle = FlatStyle.Flat;
                            detailsButton.Size = new Size(150, 25);

                            fillPanel.Controls.Add(detailsButton);

                            //PanelButtonShow.Visible = true;
                            detailsButton.Click += (s, e) =>
                            {
                                label4.Text = "Token To Redeem";
                                label3.Text = "Session Time";

                                StopAllTimers();
                                fetchRentalId = rental.RentalId;
                                globalFetchUser = rental.RentalUserId;
                                globalBookId = rental.RentalBookId;

                                PanelButtonShow.Visible = true;

                                Timer countdownTimer = new Timer { Interval = 1000 };
                                countdownTimer.Tick += (a, b) =>
                                {
                                    TimeSpan remainingTimeClock = DateTime.Today.AddDays(1).AddHours(0) - DateTime.Now;

                                    if (remainingTimeClock.TotalSeconds <= 0)
                                    {
                                        countdownTimer.Stop();
                                        CountDown1.Text = "Rental period has expired!";
                                    }
                                    else
                                    {
                                        string formattedTime = remainingTimeClock.ToString(@"hh\:mm\:ss");
                                        CountDown1.Text = formattedTime;
                                    }
                                };

                                activeTimers.Add(countdownTimer);
                                countdownTimer.Start();

                                if (book.BookImageCover != null && book.BookImageCover.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(book.BookImageCover))
                                    {
                                        PictureCover.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    PictureCover.Image = null; 
                                }

                                VerificationCode.Text = rental.CodeGeneration;
                            };


                            comicPanel.Controls.Add(fillPanel);

                            comicPanel.Controls.Add(topPanel);

                            //comicPanel.Controls.Add(button);

                            timelinePanel.Controls.Add(comicPanel);

                        }

                    }

                }
            }

            DatabaseClass.TutupDB("Rental");
        }

        private int fetchRentalId;
        private int globalFetchUser;
        private string globalBookId;


        private int globalRentalFetchUser;
        private string globalRentalBookId;
        private int globalRentalId;

        public void globalFunction1()
        {
            DatabaseClass.BukaDB("Rental");
            List<Rental> userRentals = BacaDataRentalByUserId();

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
                    Padding = new Padding(20, 0, 0, 0)
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

                            //timelinePanel.Controls.Add(coverBook);

                            Panel topPanel = new Panel();
                            topPanel.Size = new Size(140, 25);
                            topPanel.BorderStyle = BorderStyle.None;
                            topPanel.BackColor = Color.White;
                            topPanel.Dock = DockStyle.Top;

                            Label timelineMarker = new Label
                            {
                                Size = new Size(25, 25),
                                Dock = DockStyle.Left,
                                BackColor = Color.Blue,
                                BorderStyle = BorderStyle.None
                            };

                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(0, 0, timelineMarker.Width, timelineMarker.Height);
                            timelineMarker.Region = new Region(path);

                            Label titleBook = new Label();
                            titleBook.Text = book.BookTitle;
                            titleBook.Dock = DockStyle.Left;
                            titleBook.ForeColor = Color.FromArgb(175, 175, 175);
                            titleBook.Font = new Font("Consolas", 10);

                            topPanel.Controls.Add(titleBook);
                            topPanel.Controls.Add(timelineMarker);

                            DateTime rentalEndDate = rental.EndDate;
                            TimeSpan timeRemaining = rentalEndDate - DateTime.Now;
                            if (timeRemaining.TotalSeconds <= 0)
                                timelineMarker.BackColor = Color.Red;
                            else if (timeRemaining.TotalDays <= (rental.EndDate - rental.RentalDate).TotalDays / 2)
                                timelineMarker.BackColor = Color.Yellow;
                            else
                                timelineMarker.BackColor = Color.Green;

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
                                pictureBox.Image = null;
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


                            RoundButton detailsButton = new RoundButton();
                            detailsButton.Text = "View Details";
                            detailsButton.Dock = DockStyle.Bottom;
                            detailsButton.BackColor = Color.FromArgb(7, 190, 185);
                            detailsButton.ForeColor = Color.White;
                            detailsButton.Font = new Font("Consolas", 8, FontStyle.Bold);
                            detailsButton.FlatStyle = FlatStyle.Flat;
                            detailsButton.Size = new Size(150, 25);

                            fillPanel.Controls.Add(detailsButton);


                            detailsButton.Click += (s, e) =>
                            {
                                StopAllTimers();
                                PanelBoxMod.Visible = true;
                                globalRentalFetchUser = rental.RentalUserId;
                                globalRentalBookId = rental.RentalBookId;
                                globalRentalId = rental.RentalId;

                                DatabaseClass.BukaDB("users");
                                List<Register> usernameById = DatabaseClass.GetUsernameById(rental.RentalUserId);
                                DatabaseClass.TutupDB("users");

                                foreach (var user in usernameById)
                                {
                                    UsernameRental.Text = user.Username;
                                    EmailRental.Text = user.Email;
                                    BalanceUserRental.Text = user.Balance.ToString();
                                }

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

                                if (book.BookImageCover != null && book.BookImageCover.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(book.BookImageCover))
                                    {
                                        pictureImage.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pictureImage.Image = null;
                                }

                            };


                            comicPanel.Controls.Add(fillPanel);

                            comicPanel.Controls.Add(pictureBox);
                            comicPanel.Controls.Add(topPanel);

                            //comicPanel.Controls.Add(button);

                            timelinePanel.Controls.Add(comicPanel);

                        }
                    }



                }
            }

            DatabaseClass.TutupDB("Rental");
        }

        private List<Timer> activeTimers = new List<Timer>();

        public void StopAllTimers()
        {
            foreach (var timer in activeTimers)
            {
                timer.Stop();
            }
            activeTimers.Clear();
        }

        private string publicParamUser;
        public void reload(string paramUserReload)
        {
            publicParamUser = paramUserReload;
            PageLayout.Controls.Clear();
            PageLayout1.Controls.Clear();
            Program.FrmSessionActivityForm.loadInbox(publicParamUser);
            Program.FrmSessionActivityForm.reloadInbox();
            Program.FrmInbox.loadInbox(publicParamUser);
            globalFunction();
            globalFunction1();
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {
            PageLayout.HorizontalScroll.Enabled = false;
            PageLayout.HorizontalScroll.Visible = false;


            label4.Text = "";
            VerificationCode.Text = "";
            PictureCover.Image = null;
            label3.Text = "";
            CountDown1.Text = "";
            PanelButtonShow.Visible = false;
            PanelBoxMod.Visible = false;
        }

        private void RedeemButton_Click(object sender, EventArgs e)
        {
            StopAllTimers();
            label4.Text = "";
            VerificationCode.Text = "";
            PictureCover.Image = null;
            label3.Text = "";
            CountDown1.Text = "";
            PanelButtonShow.Visible = false;

            Program.FrmDiscover.reload();
            DatabaseClass.BukaDB("Rental");
            DatabaseClass.RedeemCode(fetchRentalId);
            DatabaseClass.DecreaseBookQuantity(globalBookId, 1);
            DatabaseClass.TutupDB("Rental");

            reload(publicParamUser);
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            Program.FrmInbox.reloadInbox();
            PanelBoxMod.Visible = false;

            Program.FrmDiscover.reload();
            Program.FrmPage.reload();

            DatabaseClass.BukaDB("Rental");
            Console.WriteLine(globalRentalBookId);
            Console.WriteLine(globalRentalFetchUser);
            Console.WriteLine(globalRentalId);

            DatabaseClass.DecreaseBookQuantity(globalRentalBookId, -1);
            DatabaseClass.DeleteRental(globalRentalBookId, globalRentalFetchUser.ToString(), globalRentalId);
            DatabaseClass.TutupDB("Rental");
            Console.WriteLine("AAAAAAAaaaaaaaa");

            reload(publicParamUser);
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            DatabaseClass.BukaDB("users");

            long balance = DatabaseClass.GetUserBalance(globalFetchUser);
            balance -= 50;

            DatabaseClass.UpdateUserBalance(globalFetchUser, balance);
            //, fetchRentalId globalBookId,
            Program.FrmAccount.UpdateBalanceLabel();
            DatabaseClass.TutupDB("users");
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            StopAllTimers();
            label4.Text = "";
            VerificationCode.Text = "";
            PictureCover.Image = null;
            label3.Text = "";
            CountDown1.Text = "";
            PanelButtonShow.Visible = false;

            Program.FrmDiscover.reload();

            DatabaseClass.BukaDB("Rental");
            DatabaseClass.DeleteRental(globalBookId, globalFetchUser.ToString(), fetchRentalId); 
            DatabaseClass.TutupDB("Rental");

            reload(publicParamUser);
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            Program.FrmInbox.reloadInbox();
            PanelBoxMod.Visible = false;

            Program.FrmDiscover.reload();
            Program.FrmPage.reload();

            DatabaseClass.BukaDB("Rental");

            DatabaseClass.DeleteRental(globalRentalBookId, globalRentalFetchUser.ToString(), globalRentalId);
            DatabaseClass.TutupDB("Rental");

            reload(publicParamUser);
        }
    }
}
