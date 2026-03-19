using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Perpustakaan
{
    public partial class CommentPage : Form
    {
        private double initialRating = 4.3;

        public CommentPage()
        {
            InitializeComponent();
            this.Load += CommentPage_Load; 
        }

        private List<PictureBox> imageList = new List<PictureBox>();
        int originalValue = 0;
        int userId;
        string bookId;

        public void RefreshComment()
        {
            ErrorLimit.Text = "";
            Comment.Text = "";
            SetRating(0);
        }


        public void PublicId(int paramUserId, string paramBookId)
        {
            userId = paramUserId;
            bookId = paramBookId;
        }

        private void SetRating(int rating)
        {
            Image filledStar = Properties.Resources.full_rating_star;
            Image emptyStar = Properties.Resources.empty_rating_star;

            for (int i = 0; i < originalValue; i++)
            {
                imageList[i].Image = emptyStar;
            }

            originalValue = rating;


            for (int i = 0; i < rating; i++)
            {
                imageList[i].Image = (i < originalValue) ? filledStar : emptyStar;
            }
        }

        private void CommentPage_Load(object sender, EventArgs e)
        {
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(pictureBook);
            //pictureBox.Dock = DockStyle.Top;
            //pictureBox.Size = new Size(150, 220);
            //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ErrorLimit.Text = "";

            imageList.Add(FirstRating);
            imageList.Add(SecondRating);
            imageList.Add(ThirdRating);
            imageList.Add(FourthRating);
            imageList.Add(FifthRating);

            FirstRating.Click += (s, ev) => SetRating(1);
            SecondRating.Click += (s, ev) => SetRating(2);
            ThirdRating.Click += (s, ev) => SetRating(3);
            FourthRating.Click += (s, ev) => SetRating(4);
            FifthRating.Click += (s, ev) => SetRating(5);
        }


        private void CommentButton_Click(object sender, EventArgs e)
        {
            DatabaseClass.BukaDB("Comments");
            if (!DatabaseClass.CanAddComment(userId, bookId))
            {
                ErrorLimit.Text = "your limit reach 3 times to comment";
                DatabaseClass.TutupDB("Comments");
                return;
            }
            DatabaseClass.TutupDB("Comments");

            Page FrmPage = Program.FrmPage;
            Console.WriteLine(originalValue);
            if (originalValue <= 0)
            {
                ErrorLimit.Text = "you need to rate at least 1 - 5";
            }
            else
            {
                FrmPage.CommentPage(Comment.Text, originalValue);
                ErrorLimit.Text = "";
                Program.FrmDiscover.reload();
                this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}