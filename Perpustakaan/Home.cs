using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Perpustakaan.DatabaseClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Perpustakaan
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private Form originalForm = null;

        public void SwitchForm(Form targetForm, int transitionSpeed = 100, double increment = 0.05)
        {
            if (targetForm != originalForm)
            {
                originalForm.Hide();
                targetForm.WindowState = FormWindowState.Maximized;
                targetForm.BringToFront();
                targetForm.Show();
                targetForm.WindowState = FormWindowState.Maximized;
                targetForm.BringToFront();


                originalForm = targetForm;
            }
        }


        public string textDetector()
        {
            return textBox1.Text;
        }

        public string globalId;
        public void userChange(int fetchId, string emailParam)
        {
            MiniPanel.Visible = true;
            globalId = fetchId.ToString();
            DatabaseClass.BukaDB("users");
            List<Register> usernameById = DatabaseClass.GetUsernameById(fetchId);


            foreach (var user in usernameById)
            {
                NameProfilePicture.Text = user.Username;
                ProfilePictureName.Text = user.Username;
            }

            Image profileImage = DatabaseClass.GetProfilePicture(fetchId);

            if (profileImage != null)
            {
                ProfilePictureImage.Image = profileImage;
                MenuProfile.Image = profileImage;
            } else
            {
                ProfilePictureImage.Image = (Image)Properties.Resources.ResourceManager.GetObject("ProfilePictureDefault");
                MenuProfile.Image = (Image)Properties.Resources.ResourceManager.GetObject("Profile_Picture_White");
            }

            if (emailParam == "leonardoalexyoung11@gmail.com")
            {
                PanelMod.Visible = true;
            }
            DatabaseClass.TutupDB("users");


            //ProfilePictureImage.Location = new Point(LoginButton.Location.X, LoginButton.Location.Y - 5);
            //NameProfilePicture.Location = new Point(ProfilePictureImage.Location.X + 50, ProfilePictureImage.Location.Y);
            UserPanel.Visible = true;
            ProfilePictureEmail.Text = emailParam;

            //LoginButton.Location = new Point(3066, 52);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //TitleHome.Parent = GradientBoxTop;
            //TitleHome.BackColor = Color.Transparent;

            //LoginButton.Parent = pictureBox2;

            //ProfilePictureImage.Location = new Point(3066, 52);
            //NameProfilePicture.Location = new Point(3066, 52);

            UserPanel.Visible = false;

            Menu menu = Program.FrmMenu;
            menu.Show();
            menu.WindowState = FormWindowState.Maximized;
            menu.BringToFront();

            MiniPanel.Location = new Point(-160, 48);
            PanelThreeDot.Location = new Point(-10, 82);
            //MenuProfile.Location = new Point(-160, 30);

            originalForm = menu;
        }

        Color colorDefault = Color.FromArgb(88, 101, 251);
        private void button1_Click(object sender, EventArgs e)
        {
            SwitchForm(Program.FrmMenu);

            button1.BackColor = Color.FromArgb(7, 190, 185);
            Collection.BackColor = colorDefault;
            button3.BackColor = colorDefault;
            button4.BackColor = colorDefault;
            InboxForm inboxFrm = Program.FrmInbox;
            inboxFrm.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchForm(Program.FrmRent);

            button1.BackColor = colorDefault;
            Collection.BackColor = colorDefault;
            button3.BackColor = colorDefault;
            button4.BackColor = Color.FromArgb(29, 132, 192);
            InboxForm inboxFrm = Program.FrmInbox;
            inboxFrm.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchForm(Program.FrmUiDesign);

            button1.BackColor = colorDefault;
            Collection.BackColor = colorDefault;
            button3.BackColor = Color.FromArgb(29, 132, 192);
            button4.BackColor = colorDefault;
            InboxForm inboxFrm = Program.FrmInbox;
            inboxFrm.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void TitleHome_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void GradientBoxTop_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginPage loginForm = Program.FrmLogin;
            loginForm.Show();
            loginForm.BringToFront();

            //this.Hide();
        }

        private void Collection_Click(object sender, EventArgs e)
        {
            button1.BackColor = colorDefault;
            Collection.BackColor = Color.FromArgb(29, 132, 192);
            button3.BackColor = colorDefault;
            button4.BackColor = colorDefault;

            SwitchForm(Program.FrmDiscover);
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
          
        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;
            Discover discover = Program.FrmDiscover;
            discover.SearchBarFunc(searchTerm);
        }

        int cooldown = 1;
        bool state = true;
        bool debounce = true;

        private void button2_Click(object sender, EventArgs e)
        {
            if (debounce == true)
            {
                state = !state;
                debounce = false;
                timer1.Start();
            }
        }

        private double fadeProgress = 0.0;
        private double fadeSpeed = 0.008;
        int originalSize = 186;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (state)
            {
                fadeProgress += fadeSpeed;

                double easedOpacity = Math.Sin(fadeProgress * (Math.PI / 2)) * 200;
                PanelThreeDot.Size = new Size(200 -(int)easedOpacity, 1000);
                MiniPanel.Location = new Point(15 - (int)easedOpacity, 0);
                //MenuProfile.Location = new Point(48 - (int)easedOpacity, 30);

                if (fadeProgress >= 1)
                {
                    timer1.Stop();
                    fadeProgress = 0;
                    debounce = true;
                }
            } else
            {
                fadeProgress += fadeSpeed;

                double easedOpacity = Math.Sin(fadeProgress * (Math.PI / 2)) * 200;
                PanelThreeDot.Size = new Size((int)easedOpacity, 1000);
                MiniPanel.Location = new Point(-185 + (int)easedOpacity, 0);
                //MenuProfile.Location = new Point(-160 + (int)easedOpacity, 30);

                if (fadeProgress >= 1)
                {
                    fadeProgress = 0;
                    timer1.Stop();
                    debounce = true;
                }
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            InboxForm inboxFrm = Program.FrmInbox;
            inboxFrm.Show();
            inboxFrm.WindowState = FormWindowState.Maximized;
            inboxFrm.BringToFront();
        }

        private void ProfilePictureImage_Click(object sender, EventArgs e)
        {
            AccountPage accountFrm = Program.FrmAccount;
            accountFrm.Show();
            accountFrm.WindowState = FormWindowState.Maximized;
            accountFrm.BringToFront();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            SessionActivityForm sessionActivity = Program.FrmSessionActivityForm;
            sessionActivity.Show();
            sessionActivity.WindowState = FormWindowState.Maximized;
            sessionActivity.BringToFront();
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            UserPanel.Visible = false;
            Program.FrmPage.GlobalLoginId();
            MiniPanel.Visible = false;
            PanelMod.Visible = false;

            SwitchForm(Program.FrmMenu);

            button1.BackColor = Color.FromArgb(7, 190, 185);
            Collection.BackColor = colorDefault;
            button3.BackColor = colorDefault;
            button4.BackColor = colorDefault;
            InboxForm inboxFrm = Program.FrmInbox;
            inboxFrm.Hide();

            Program.FrmLogin.reloadUserPass();
            Program.FrmRent.LogOut();

            //DatabaseClass.BukaDB("users");

            //Page page = Program.FrmPage;
            //int fetchId = DatabaseClass.FetchUserId(email, password);
            //page.GlobalUserFetch(fetchId);

            //DatabaseClass.TutupDB("users");

            //Home homeForm = Program.FrmUtama;
            //homeForm.Show();
            //homeForm.WindowState = FormWindowState.Maximized;
            //homeForm.BringToFront();


            //Program.FrmPage.showComment();
            //Program.FrmAccount.LoadInformation(email, fetchId);

            //Program.FrmUtama.userChange(fetchId, email);
            //Program.FrmInbox.loadInbox(fetchId.ToString());
            //Program.FrmSessionActivityForm.loadInbox(fetchId.ToString());

            //this.Hide();
        }

        private void AccountButton_Click_1(object sender, EventArgs e)
        {
            AccountPage accountFrm = Program.FrmAccount;
            accountFrm.Show();
            accountFrm.WindowState = FormWindowState.Maximized;
            accountFrm.BringToFront();
        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            AdminEditBook adminEdit = Program.FrmAdminEditBook;
            adminEdit.Show();
            adminEdit.WindowState = FormWindowState.Maximized;
            adminEdit.BringToFront();
        }

        private void roundButton5_Click(object sender, EventArgs e)
        {
            CashierForm cashierForm = Program.FrmCashierForm;
            cashierForm.reload(globalId);
            cashierForm.Show();
            cashierForm.WindowState = FormWindowState.Maximized;
            cashierForm.BringToFront();
        }

        private void roundButton6_Click(object sender, EventArgs e)
        {
            BlackListForm blacklistForm = Program.FrmBlackListForm;
            blacklistForm.Reload();
            blacklistForm.Show();
            blacklistForm.WindowState = FormWindowState.Maximized;
            blacklistForm.BringToFront();
        }
    }
}