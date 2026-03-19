using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class Page : Form
    {
        public Page()
        {
            InitializeComponent();
        }


        string publicGenre;
        string publicBookCode;
        int SizeCommentX = 625;
        int globalId = -1;

        public void CommentDisplay(string publicCodeParam, int ratingSort)
        {
            int allIndex = 1;

            int itemsPerPage = 10;
            int currentPage = 1;
            int totalComment = DatabaseClass.GetTotalBooks("book_id", "Comments", publicBookCode);

            int totalPages = (int)Math.Ceiling(totalComment / (double)itemsPerPage);


            void DisplayRating(Panel RatingPanel, int rating)
            {
                RatingPanel.Controls.Clear();

                Image filledStar = Properties.Resources.full_rating_star;
                Image emptyStar = Properties.Resources.empty_rating_star;

                for (int i = 0; i < 5; i++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = (i < rating) ? filledStar : emptyStar,
                        Location = new Point(i * 22, 0), 
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    RatingPanel.Controls.Add(pictureBox);
                }
            }



            void DisplayCommentForCurrentPage(int pageNumber)
            {
                CommentPanel.Controls.Clear();
                CommentPanelProfile.Controls.Clear();
                FlowPage.Controls.Clear();

                DatabaseClass.BukaDB("Comments");

                //string query = "SELECT book_id * FROM Comments";
                //query += $" ORDER BY timestamp ASC, comment_id OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
                //string query = "SELECT * FROM Comments WHERE book_id = @BookId";

                //query += $" ORDER BY comment_id OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
                //var parameters = new Dictionary<string, object>
                //{
                //    { "@BookId", publicCodeParam }
                //};

                string query;

                var parameters = new Dictionary<string, object>();
                if (ratingSort == -1)
                {
                    query = "SELECT * FROM Comments WHERE book_id = @BookId";
                    parameters = new Dictionary<string, object>
                    {
                        { "@BookId", publicCodeParam }
                    };
                }
                else
                {
                    query = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating";
                    parameters = new Dictionary<string, object>
                    {
                        { "@BookId", publicCodeParam },
                        { "@Rating", ratingSort }
                    };
                }

                query += " ORDER BY timestamp DESC";
                query += $" OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

                List<DatabaseClass.Comment> commentList = DatabaseClass.BacaDataComment(query, parameters);

                foreach (var comment in commentList)
                {
                    DatabaseClass.BukaDB("users");
                    List<Register> usernameById = DatabaseClass.GetUsernameById(comment.UserId);
                    DatabaseClass.TutupDB("users");

                    FlowLayoutPanel mainPanel = new FlowLayoutPanel();
                    mainPanel.Size = new Size(SizeCommentX, 150);
                    mainPanel.BorderStyle = BorderStyle.None;
                    mainPanel.FlowDirection = FlowDirection.LeftToRight;
                    mainPanel.WrapContents = false;
                    mainPanel.AutoSize = true;

                    Panel comentarPanel = new Panel();
                    comentarPanel.Size = new Size(SizeCommentX, 150);
                    comentarPanel.BorderStyle = BorderStyle.None;
                    comentarPanel.BackColor = Color.LightGray;

                    //comentarPanel.Dock = DockStyle.Top;

                    comentarPanel.BackColor = Color.White;
                    //int x = (((allIndex - 1) % 5) * 180) + 50;
                    int y = (int)(Math.Floor((double)(allIndex - 1) / 1) * 100) + 0;

                    comentarPanel.Location = new Point(0, y);

                    string targetDateString = comment.Timestamp.ToString();
                    //Console.WriteLine(targetDateString);

                    DateTime targetDate = DateTime.ParseExact(targetDateString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime currentDate = DateTime.Now;

                    TimeSpan difference = currentDate - targetDate;

                    string readableDifference = GetReadableTimeDifference(difference);

                    Panel Rating = new Panel();
                    Rating.Size = new Size(SizeCommentX, 20);
                    Rating.BorderStyle = BorderStyle.None;
                    Rating.BackColor = Color.White;
                    Rating.Dock = DockStyle.Top;

                    DisplayRating(Rating, comment.Rating);

                    Panel usernamePanel = new Panel();
                    usernamePanel.Size = new Size(SizeCommentX, 20);
                    usernamePanel.BorderStyle = BorderStyle.None;
                    usernamePanel.Dock = DockStyle.Top;

                    Panel panelToUse = CommentPanel;
                    if (globalId != -1 && comment.UserId == globalId)
                    {
                        panelToUse = CommentPanelProfile;
                        Label ThreeDot = new Label();
                        ThreeDot.Text = "...";
                        ThreeDot.Font = new Font("Consolas", 14);
                        ThreeDot.Dock = DockStyle.Right;
                        usernamePanel.Controls.Add(ThreeDot);
                        //leonardoalexyoung11@gmail.com

                        ThreeDot.Click += (sender, e) =>
                        {
                            Label clickedLabel = sender as Label;
                            if (clickedLabel != null)
                            {
                                Panel parentPanel = clickedLabel.Parent as Panel;
                                if (parentPanel != null)
                                {
                                    Panel existingShowPanel = parentPanel.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "ShowPanel");
                                    if (existingShowPanel != null)
                                    {
                                        parentPanel.Controls.Remove(existingShowPanel);
                                    }

                                    Panel Show = new Panel
                                    {
                                        Name = "ShowPanel",
                                        Size = new Size(30, 30),
                                        BorderStyle = BorderStyle.None,
                                        BackColor = Color.Black,
                                        Location = new Point(parentPanel.Width - 50, clickedLabel.Height + 5) // Adjust position relative to the clicked label
                                    };

                                    parentPanel.Controls.Add(Show);

                                    Show.Click += (s, ev) =>
                                    {
                                        MessageBox.Show("Show panel clicked!");
                                    };

                                    Show.BringToFront();
                                }
                            }
                        };

                    }

                    panelToUse.Controls.Add(mainPanel);

                    Label nameUser = new Label();
                    nameUser.Dock = DockStyle.Left;
                    nameUser.AutoSize = true;
                    nameUser.Font = new Font("Consolas", 12);

                    Label dateTime = new Label();
                    dateTime.Dock = DockStyle.Left;
                    dateTime.AutoSize = true;
                    dateTime.Text = readableDifference;
                    dateTime.Font = new Font("Consolas", 12);
                    dateTime.ForeColor = Color.Gray;

                    Panel profilePanel = new Panel();
                    profilePanel.Size = new Size(SizeCommentX, 40);
                    profilePanel.BorderStyle = BorderStyle.None;
                    profilePanel.BackColor = Color.White;
                    profilePanel.Dock = DockStyle.Left;

                    Image defaultProfilePicture = Properties.Resources.Profile_Picture_White;
                    PictureBox imageProfile = new PictureBox();

                    imageProfile.Location = new Point(comentarPanel.Location.X - 10, comentarPanel.Location.Y);
                    imageProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageProfile.Size = new Size(40, 40);
                    imageProfile.BringToFront();

                    imageProfile.Click += (sender, e) =>
                    {
                        ProfilePictureOther profilePictureOther = Program.FrmProfilePictureOther;
                        profilePictureOther.Show();
                        profilePictureOther.WindowState = FormWindowState.Maximized;
                        profilePictureOther.BringToFront();
                        profilePictureOther.LoadInformation(comment.UserId, globalUserId);
                    };

                    foreach (var user in usernameById)
                    {
                        nameUser.Text = user.Username;
                        DatabaseClass.BukaDB("users");

                        if (user.Username != "-1")
                        {
                            Image profilePic = DatabaseClass.GetProfilePicture(comment.UserId);

                            if (profilePic != null)
                            {
                                imageProfile.Image = profilePic;
                            }
                            else
                            {
                                imageProfile.Image = defaultProfilePicture;
                            }
                        }
                        DatabaseClass.TutupDB("users");
                    }
                    mainPanel.Controls.Add(imageProfile);
                    mainPanel.Controls.Add(comentarPanel);

                    bool isExpanded = false;
                    int maxLength = 100;

                    if (comment.CommentText.Length >= maxLength)
                    {
                        string truncatedText = comment.CommentText.Substring(0, maxLength) + "...";

                        Label commentLabel = new Label();
                        commentLabel.Dock = DockStyle.Fill;
                        commentLabel.Text = truncatedText;
                        commentLabel.Font = new Font("Consolas", 10);

                        //using (Graphics g = commentLabel.CreateGraphics())
                        //{
                        //    SizeF textSize = g.MeasureString(commentLabel.Text, commentLabel.Font, commentLabel.Width);
                        //    int calculatedHeight = (int)Math.Ceiling(textSize.Height);

                        //    comentarPanel.Size = new Size(comentarPanel.Width, calculatedHeight + 100);
                        //}

                        Label buttonRead = new Label();
                        buttonRead.Text = "Read More";
                        buttonRead.ForeColor = Color.Gray;
                        buttonRead.Font = new Font("Consolas", 10);
                        buttonRead.Dock = DockStyle.Bottom;

                        buttonRead.Click += (sender, e) =>
                        {
                            isExpanded = !isExpanded;
                            if (isExpanded)
                            {
                                commentLabel.Text = comment.CommentText;
                                buttonRead.Text = "Read Less";
                                //comentarPanel.Size = new Size(SizeCommentX, 300);
                                using (Graphics g = commentLabel.CreateGraphics())
                                {
                                    SizeF textSize = g.MeasureString(commentLabel.Text, commentLabel.Font, commentLabel.Width);
                                    int calculatedHeight = (int)Math.Ceiling(textSize.Height);

                                    comentarPanel.Size = new Size(comentarPanel.Width, calculatedHeight + 150);
                                }
                            }
                            else
                            {
                                commentLabel.Text = truncatedText;
                                buttonRead.Text = "Read More";
                                comentarPanel.Size = new Size(SizeCommentX, 100);
                            }
                        };

                        comentarPanel.Controls.Add(buttonRead);
                        comentarPanel.Controls.Add(commentLabel);
                    }
                    else
                    {
                        Label stuff = new Label();
                        stuff.Dock = DockStyle.Fill;
                        stuff.Text = comment.CommentText;
                        stuff.Font = new Font("Consolas", 10);

                        using (Graphics g = stuff.CreateGraphics())
                        {
                            SizeF textSize = g.MeasureString(stuff.Text, stuff.Font, stuff.Width);
                            int calculatedHeight = (int)Math.Ceiling(textSize.Height);

                            comentarPanel.Size = new Size(comentarPanel.Width, calculatedHeight + 40);
                        }
                        comentarPanel.Controls.Add(stuff);
                    }


                    comentarPanel.Controls.Add(Rating);
                    usernamePanel.Controls.Add(dateTime);
                    usernamePanel.Controls.Add(nameUser);
                    comentarPanel.Controls.Add(usernamePanel);

                    allIndex++;
                }

                DatabaseClass.TutupDB("Comments");

                if (totalPages > 1)
                {
                    PageNumber();
                }

                if (globalId != -1)
                {
                    Panel mover = new Panel();
                    mover.Size = new Size(SizeCommentX, 100);
                    mover.BorderStyle = BorderStyle.None;
                    mover.BackColor = Color.FromArgb(224, 224, 224);
                    CommentPanel.Controls.Add(mover);
                    mover.SendToBack();
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
                        DisplayCommentForCurrentPage(currentPage);
                    };

                    FlowPage.Controls.Add(nextPageButton);
                }
            }

            DisplayCommentForCurrentPage(currentPage);
        }

        public int totalBook;
        

        public void reload()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            List<Label> descLabel = new List<Label>();
            List<PictureBox> progressBarList = new List<PictureBox>();

            DatabaseClass.BukaDB("Comments");

            List<int> RatingAmount = new List<int>();

            for (int i = 1; i <= 5; i++)
            {
                var parameters = new Dictionary<string, object>();

                string query = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating";
                parameters = new Dictionary<string, object>
                {
                    { "@BookId", publicBookCode },
                    { "@Rating", i}
                };

                query += " ORDER BY timestamp DESC";
                //query += $" OFFSET {(pageNumber - 1) * itemsPerPage} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

                List<DatabaseClass.Comment> commentList = DatabaseClass.BacaDataComment(query, parameters);
                int indexAmount = 0;
                foreach (var comment in commentList)
                {
                    indexAmount++;
                }
                RatingAmount.Add(indexAmount);
            }

            int biggest = RatingAmount[0];
            int biggestIndex = 0;
            for (int i = 0; i < RatingAmount.Count; i++)
            {
                if (biggest < RatingAmount[i])
                {
                    biggest = RatingAmount[i];
                    biggestIndex = i;
                }
            }

            pictureBoxes.Add(FirstBar);
            pictureBoxes.Add(SecondBar);
            pictureBoxes.Add(ThreeBar);
            pictureBoxes.Add(FourBar);
            pictureBoxes.Add(FiveBar);

            descLabel.Add(DescFirst);
            descLabel.Add(DescTwo);
            descLabel.Add(DescThree);
            descLabel.Add(DescFour);
            descLabel.Add(DescFive);

            progressBarList.Add(FirstProgress);
            progressBarList.Add(SecondProgress);
            progressBarList.Add(ThirdProgress);
            progressBarList.Add(FourthProgress);
            progressBarList.Add(FifthProgress);

            int halfSum = 0;

            for (int i = 1; i <= 5; i++)
            {
                halfSum += RatingAmount[i - 1] * i;
            }
            float ratingScore1 = ((float)halfSum / RatingAmount.Sum());
            RatingScore.Text = double.IsNaN(ratingScore1) ? "0.0" : ratingScore1.ToString("0.0", CultureInfo.InvariantCulture);
            AmountPeople.Text = "Based on " + (RatingAmount.Sum()).ToString() + " Reviews";

            Image filledStar = Properties.Resources.full_rating_star;
            Image emptyStar = Properties.Resources.empty_rating_star;
            Image halfStar = Properties.Resources.half_rating_star;

            float a = 1;

            RatingShowcase.Controls.Clear();
            for (int i = 0; i < 5; i++)
            {
                Image starImage;

                if (i < (int)ratingScore1)
                {
                    starImage = filledStar;
                }
                else if (i == (int)ratingScore1 && ratingScore1 % 1 != 0)
                {
                    starImage = halfStar;
                }
                else
                {
                    starImage = emptyStar;
                }

                //Console.WriteLine(ratingScore1);

                PictureBox ratingPicture = new PictureBox
                {
                    Image = starImage,
                    Location = new Point(i * 22, 0),
                    Size = new Size(20, 20),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                RatingShowcase.Controls.Add(ratingPicture);
            }

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                float percentage = RatingAmount[i] / (float)RatingAmount.Sum();
                int newHeight = (int)(210 * percentage);

                progressBarList[i].Size = new Size(newHeight, 24);

                pictureBoxes[i].Location = new Point(newHeight + progressBarList[i].Location.X, progressBarList[i].Location.Y);
                pictureBoxes[i].Image = (Image)Properties.Resources.ResourceManager.GetObject("Left_Half_Progress");
                if (newHeight >= 210)
                {
                    pictureBoxes[i].Image = (Image)Properties.Resources.ResourceManager.GetObject("White_Left_Half_Progress");
                }

                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                descLabel[i].Text = (i + 1).ToString();
            }

            pictureBoxes.Clear();
            descLabel.Clear();

            DatabaseClass.TutupDB("Comments");
        }

        public void UpdateTitleBook(string text1, string text2, string text3, string text4, byte[] text5, string genre, string publicCode, int bookQuantity, int bookTotal)
        {
            ErrorMes.Text = "";
            roundButton1.Enabled = true;
            roundButton2.Enabled = true;
            if (text5 != null && text5.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(text5))
                {
                    pictureCover.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureCover.Image = null;
            }
            PageNameBook.Text = text1;
            PublishNameBook.Text = text2;
            PenulisNameBook.Text = text3;
            DescriptionNameBook.Text = text4;
            pictureCover.SizeMode = PictureBoxSizeMode.StretchImage;
            publicGenre = genre;
            GenreLabel.Text = genre;
            TitleLabel.Text = text1;
            publicBookCode = publicCode;
            BookQuantity.Text = bookQuantity.ToString();
            totalBook = bookTotal;

            if (bookQuantity <= 0)
            {
                roundButton1.Enabled = false;
                roundButton2.Enabled = false;
            }

            //Console.WriteLine(100);

            CommentDisplay(publicCode, -1);
            //132, 737

            CommentPage cmdPage = Program.FrmCommentPage;
            cmdPage.Hide();

            reload();
        }

        string globalBookId = "";

        public void GlobalUserFetch(int fetchId)
        {
            globalId = fetchId;

            CommentPanelProfile.Size = new Size(938, 152);
            CommentPanel.Size = new Size(938, 372);

            CommentPanelProfile.BackColor = Color.FromArgb(224, 224, 224);
            
            label9.Text = "Your Comment";
            label11.Text = "Comment";
            CommentDisplay(publicBookCode, -1);
        }

        public void GlobalLoginId()
        {
            label9.Text = "Comment";

            globalId = -1;
            globalUserId = -1;
            CommentPanelProfile.Size = new Size(938, 10);
            CommentPanel.Size = new Size(938, 533);
            CommentDisplay(publicBookCode, -1);
        }


        public void GlobalBookFetch(string fetchBookId)
        {
            globalBookId = fetchBookId;
            //CommentPanel.Controls.Clear();
        }

        int x = 2;
        public void CommentPage(string textComment, int rating)
        {
            //Console.WriteLine(rating);
            if (globalId != -1 && globalBookId != "")
            {
                DatabaseClass.BukaDB("comment");
                DatabaseClass.AddNewComment(globalId.ToString(), globalBookId, textComment, rating.ToString(), "0", "0");
                DatabaseClass.TutupDB("comment");
                CommentDisplay(publicBookCode, -1);
                reload();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (globalUserId != -1)
            {
                DatabaseClass.BukaDB("Rental");
                bool canRent = DatabaseClass.CanAddRent(globalUserId, globalBookId);

                if (canRent)
                {
                    ErrorMes.Text = "";
                    RentingViewPage rentingPage = Program.FrmRentingView;
                    rentingPage.Show();
                    rentingPage.rentingInfo(publicBookCode, globalId.ToString(), TitleLabel.Text, int.Parse(BookQuantity.Text), pictureCover.Image);
                    rentingPage.WindowState = FormWindowState.Maximized;
                    rentingPage.BringToFront();
                }
                else
                {
                    ErrorMes.Text = "You already have rented this book";
                }
                DatabaseClass.TutupDB("Rental");

            } else
            {
                LoginPage loginForm = Program.FrmLogin;
                loginForm.Show();
            }
            //RentingViewPage rentingPage = Program.FrmRentingView;
            //rentingPage.Show();
            //rentingPage.rentingInfo(publicBookCode, globalId.ToString(), TitleLabel.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Discover discover = Program.FrmDiscover;
            discover.Show();
            discover.WindowState = FormWindowState.Maximized;
            discover.BringToFront();


            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != Program.FrmUtama && form != discover)
                {
                    form.Hide();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Discover discover = Program.FrmDiscover;
            discover.Show();
            discover.WindowState = FormWindowState.Maximized;
            discover.BringToFront();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            //Panel panel = new Panel();
            //panel.Dock = DockStyle.Top;
            //panel.BackColor = Color.Orange;
            //panel.Size = new Size(150, 40);
            //panel1.Controls.Add(panel);

            //Panel panel2 = new Panel();
            //panel2.Dock = DockStyle.Top;
            //panel2.BackColor = Color.Orange;
            //panel2.Size = new Size(150, 40);
            //panel1.Controls.Add(panel2);

            //Label label = new Label();
            //label.Dock = DockStyle.Fill;
            //label.Font = new Font("Consolas", 12, FontStyle.Bold);
            //panel.Controls.Add(label);

            if (globalUserId != -1)
            {
                ErrorMes.Text = "";
                DatabaseClass.BukaDB("inventory");

                bool rentInventory = DatabaseClass.CanAddInventory(globalUserId, globalBookId);

                if (rentInventory)
                {
                    ErrorMes.Text = "";
                    MessageBox.Show("This book added to the inventory.", "Inventory Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RentPage rent = Program.FrmRent;
                    DatabaseClass.AddNewInventory(publicBookCode, globalUserId);
                    rent.AddComic(globalUserId, publicGenre, publicBookCode);
                    Console.WriteLine("AAAAAAAAAAA");
                }
                else
                {
                    ErrorMes.Text = "You already put this book in inventory";
                }

                DatabaseClass.TutupDB("inventory");
            }
            else
            {
                LoginPage loginForm = Program.FrmLogin;
                loginForm.Show();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CommentPage FrmCommentPage = Program.FrmCommentPage;
            FrmCommentPage.PublicId(globalId, globalBookId);
            FrmCommentPage.RefreshComment();
            FrmCommentPage.Show();
        }

        private int globalUserId = -1;

        public void showComment(int paramFetchId)
        {
            globalUserId = paramFetchId;
            LoginPanel.Visible = false;
            //CommentButton.Location = new Point(97, 575);
            //LoginButtonComment.Location = new Point(1000, 737);
        }

        static string GetReadableTimeDifference(TimeSpan timeSpan)
        {
            timeSpan = timeSpan < TimeSpan.Zero ? TimeSpan.Zero : timeSpan;

            if (timeSpan.TotalDays >= 365)
            {
                int years = (int)(timeSpan.TotalDays / 365);
                return $"{years} year{(years > 1 ? "s" : "")} ago";
            }
            if (timeSpan.TotalDays >= 1)
            {
                int days = (int)timeSpan.TotalDays;
                return $"{days} day{(days > 1 ? "s" : "")} ago";
            }
            if (timeSpan.TotalHours >= 1)
            {
                int hours = (int)timeSpan.TotalHours;
                return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
            }
            if (timeSpan.TotalMinutes >= 1)
            {
                int minutes = (int)timeSpan.TotalMinutes;
                return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
            }
            int seconds = (int)timeSpan.TotalSeconds;
            return $"{seconds} second{(seconds > 1 ? "s" : "")} ago";
        }


        Panel originalPanel;

        private void Page_Load(object sender, EventArgs e)
        {
            //LoginButtonComment.Location = new Point(97, 575);
            //CommentButton.Location = new Point(1000, 737);

            originalPanel = ReviewPanel;
            label11.Text = "";
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            LoginPage loginForm = Program.FrmLogin;
            loginForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CommentPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void FiveStarSort_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, -1);
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, 5);
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, 4);
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, 3);
        }

        private void SecondButton_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, 2);
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            CommentDisplay(publicBookCode, 1);
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            CommentTabPanel.Visible = true;
            ReviewButton.BackColor = Color.White;
            RatingButton.BackColor = Color.LightGray;
            originalPanel.Visible = false;
            originalPanel = CommentTabPanel;
        }

        private void RatingButton_Click(object sender, EventArgs e)
        {
            ReviewPanel.Visible = true;
            RatingButton.BackColor = Color.White;
            ReviewButton.BackColor = Color.LightGray;
            originalPanel.Visible = false;
            originalPanel = ReviewPanel;
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            CommentPage FrmCommentPage = Program.FrmCommentPage;
            FrmCommentPage.PublicId(globalId, globalBookId);
            FrmCommentPage.RefreshComment();
            FrmCommentPage.Show();
        }
    }
}