using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class SessionActivityForm : Form
    {
        public SessionActivityForm()
        {
            InitializeComponent();
        }

        public void globalFunction(string userId)
        {
            DatabaseClass.BukaDB("Rental");
            List<Rental> userRentals = BacaDataRentalByUserId(userId);

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
                    //Console.WriteLine(rental.StatusRental);

                    if (!rental.StatusRental)
                    {
                        foreach (var book in bookList)
                        {

                            Panel comicPanel = new Panel();
                            comicPanel.Size = new Size(400, 80);
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


                            detailsButton.Click += (s, e) =>
                            {
                                label2.Text = "Your Token";
                                label3.Text = "Session Time";
                                StopAllTimers();

                                Timer countdownTimer = new Timer { Interval = 1000 };
                                countdownTimer.Tick += (a, b) =>
                                {
                                    TimeSpan remainingTimeClock = DateTime.Today.AddDays(1).AddHours(0) - DateTime.Now;

                                    if (remainingTimeClock.TotalSeconds <= 0)
                                    {
                                        countdownTimer.Stop();
                                        CountDown.Text = "Rental period has expired!";
                                    } else
                                    {
                                        string formattedTime = remainingTimeClock.ToString(@"hh\:mm\:ss");
                                        CountDown.Text = formattedTime;
                                    }
                                };

                                activeTimers1.Add(countdownTimer);
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


        private List<Timer> activeTimers1 = new List<Timer>();

        private void SessionActivityForm_Load(object sender, EventArgs e)
        {
            VerificationCode.Text = "";
            CountDown.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        public void generateInbox(string book_id, string user_id, string book_name)
        {
            PageLayout.Controls.Clear();
            globalFunction(user_id);
        }


        public void StopAllTimers()
        {
            foreach (var timer in activeTimers1)
            {
                timer.Stop();
            }
            activeTimers1.Clear();
        }

        public void loadInbox(string userId)
        {
            PageLayout.Controls.Clear();
            globalFunction(userId);
        }

        public void reloadInbox()
        {
            VerificationCode.Text = "";
            CountDown.Text = "";
            label2.Text = "";
            label3.Text = "";
            PictureCover.Image = null;
            StopAllTimers();
        }

        private void pictureImage_Click(object sender, EventArgs e)
        {

        }

        private void VerificationCode_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
