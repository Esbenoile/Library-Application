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



//PictureBox pictureBox = new PictureBox();
//if (book.BookImageCover != null && book.BookImageCover.Length > 0)
//{
//    using (MemoryStream ms = new MemoryStream(book.BookImageCover))
//    {
//        pictureBox.Image = Image.FromStream(ms);
//    }
//}
//else
//{
//    pictureBox.Image = null; // Clear the PictureBox if no image is found
//}


//pictureBox.Dock = DockStyle.Left;
//pictureBox.Size = new Size(150, 90);
//pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


//Label label = new Label();
//label.Text = bookTitle;
//label.Dock = DockStyle.Bottom;
//label.Font = new Font("Consolas", 12);


//List<int> RatingAmount = new List<int>();

//for (int i = 1; i <= 5; i++)
//{
//    var parameters = new Dictionary<string, object>();

//    string query1 = "SELECT * FROM Comments WHERE book_id = @BookId AND rating = @Rating";
//    parameters = new Dictionary<string, object>
//        {
//            { "@BookId", book.BookId },
//            { "@Rating", i}
//        };

//    query1 += " ORDER BY timestamp DESC";

//    List<DatabaseClass.Comment> commentList = DatabaseClass.BacaDataComment(query1, parameters);
//    int indexAmount = 0;
//    foreach (var comment in commentList)
//    {
//        indexAmount++;
//    }
//    RatingAmount.Add(indexAmount);
//}

//int halfSum = 0;

//for (int i = 1; i <= 5; i++)
//{
//    halfSum += RatingAmount[i - 1] * i;
//}

//float RatingScore = ((float)halfSum / RatingAmount.Sum());

//string formattedRating = float.IsNaN(RatingScore) ? "0.0" : RatingScore.ToString("0.0");

//Label label2 = new Label();
//label2.Text = genreNovel;
//label2.Dock = DockStyle.Left;
//label2.ForeColor = Color.FromArgb(175, 175, 175);
//label2.Font = new Font("Consolas", 10);

//for (int i = 0; i < 5; i++)
//{
//    Image starImage;

//    if (i < (int)RatingScore)
//    {
//        starImage = filledStar;
//    }
//    else if (i == (int)RatingScore && RatingScore % 1 != 0)
//    {
//        starImage = halfStar;
//    }
//    else
//    {
//        starImage = emptyStar; // Empty stars
//    }

//    PictureBox ratingPicture = new PictureBox
//    {
//        Image = starImage,
//        Location = new Point(i * 22, 0),
//        Size = new Size(20, 20),
//        SizeMode = PictureBoxSizeMode.StretchImage
//    };

//    ratingPanel.Controls.Add(ratingPicture);
//}


namespace Perpustakaan
{
    public partial class BlackListForm : Form
    {
        public BlackListForm()
        {
            InitializeComponent();
        }

        int publicUserId = -1;

        public void globalFunction()
        {
            DatabaseClass.BukaDB("Rental");
            List<Rental> userRentals = BacaDataRentalByUserId();

            // Group rentals by user and order by rental date
            var groupedRentals = userRentals
                .Where(r => r.EndDate < DateTime.Now) // Filter rentals where EndDate is in the past
                .GroupBy(r => r.RentalUserId) // Group by user ID
                .OrderBy(g => g.Key);

            foreach (var group in groupedRentals)
            {
               
                FlowLayoutPanel userPanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Margin = new Padding(10)
                };
                PageLayout.Controls.Add(userPanel);

                int streakCount = 1;
                Rental previousRental = null;

                DatabaseClass.BukaDB("users");
                List<Register> usernameById = DatabaseClass.GetUsernameById(group.Key);
                DatabaseClass.TutupDB("users");

                foreach (var user in usernameById)
                {
                    Label streakHeader = new Label
                    {
                        Text = $"User {user.Username} Streaks" + $", {user.RegisterId}",
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        ForeColor = Color.Black,
                        AutoSize = true,
                        Dock = DockStyle.Top
                    };
                    userPanel.Controls.Add(streakHeader);
                }

                Panel streakPanel = new Panel
                {
                    Size = new Size(800, 80),
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White,
                    Dock = DockStyle.Top
                };

                foreach (var rental in group.OrderBy(r => r.RentalDate))
                {
                    if (rental.StatusRental)
                    {
                        streakCount++; 

                        previousRental = rental; 
                    }
                }

                Label streakLabel = new Label
                {
                    Text = $"Streak {streakCount}",
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.Gray,
                    Dock = DockStyle.Top
                };

                streakPanel.Controls.Add(streakLabel);

                userPanel.Controls.Add(streakPanel);


                RoundButton detailsButton = new RoundButton();
                detailsButton.Text = "View Details";
                detailsButton.Dock = DockStyle.Bottom;
                detailsButton.BackColor = Color.FromArgb(7, 190, 185);
                detailsButton.ForeColor = Color.White;
                detailsButton.Font = new Font("Consolas", 8, FontStyle.Bold);
                detailsButton.FlatStyle = FlatStyle.Flat;
                detailsButton.Size = new Size(150, 25);

                detailsButton.Click += (s, e) =>
                {
                    PanelBlackList.Visible = false;

                    foreach (var user in usernameById)
                    {
                        if (user.BanStatus == true)
                        {
                            StatusUserLoL.Text = "Banned!!!";
                            StatusUserLoL.ForeColor = Color.Red; 
                        }
                        else
                        {
                            StatusUserLoL.Text = "Not Banned";
                            StatusUserLoL.ForeColor = Color.Black;
                        }
                    }

                    publicUserId = group.Key;
                    Console.WriteLine(group.Key);
                    PanelMod.Visible = true;
                    if (streakCount >= 3)
                    {
                        PanelBlackList.Visible = true;
                    }
                };
                streakPanel.Controls.Add(detailsButton);

            }


        }


        public void Reload()
        {
            PageLayout.Controls.Clear();
            globalFunction();
        }

        private void BlackListForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Warning: Action cannot be undone! Do you want to proceed?",
                                      "Warning",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StatusUserLoL.Text = "Banned!!!";
                StatusUserLoL.ForeColor = Color.Red;
                DatabaseClass.BukaDB("users");
                DatabaseClass.UpdateUserStatus(publicUserId);
                DatabaseClass.TutupDB("users");
            }
            else
            {
            }
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Warning: Action cannot be undone! Do you want to proceed?",
                          "Warning",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StatusUserLoL.Text = "Not Banned";
                StatusUserLoL.ForeColor = Color.Black;
                DatabaseClass.BukaDB("users");
                DatabaseClass.UpdateUserStatusWhite(publicUserId);
                DatabaseClass.TutupDB("users");
            }
            else
            {
            }
        }
    }
}
