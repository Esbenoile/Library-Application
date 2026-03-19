using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Perpustakaan
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
            EmailError.Text = "";
            PasswordError.Text = "";
            UsernameError.Text = "";
            ConfirmPasswordError.Text = "";
        }
        bool a = false;
        bool b = false;
        bool c = false;
        bool d = false;

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            TxtPass.PasswordChar = '*';
            string passWord = TxtPass.Text;

            PasswordError.Text = "";

            if (string.IsNullOrEmpty(passWord))
            {
                return;
            }

            if (passWord.Length < 6)
            {
                PasswordError.Text = "Password should be at least 6 characters.";
                a = false;
            }
            else if (passWord.Length > 20)
            {
                TxtPass.Text = passWord.Substring(0, 20);
                TxtPass.SelectionStart = TxtPass.Text.Length;
                PasswordError.Text = "Password reached maximum character limit!";
            }
            a = true;
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {
            string userName = TxtUserName.Text.Trim();

            UsernameError.Text = "";
            b = false;

            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            if (userName.Length <= 6)
            {
                UsernameError.Text = "Username should be at least 6 characters.";
            }
            else if (userName.Length > 20)
            {
                TxtUserName.Text = userName.Substring(0, 20);
                TxtUserName.SelectionStart = 20;
                UsernameError.Text = "Username reached maximum character limit!";
            }
            else
            {
                b = true;
            }
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (TxtEmail.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) || TxtEmail.Text == "")
            {
                EmailError.Text = "";
                c = true;
            }
            else
            {
                c = false;
                EmailError.Text = "The Email Adress must included @gmail.com";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtConPass_TextChanged(object sender, EventArgs e)
        {
            TxtConPass.PasswordChar = '*';
            string password = TxtPass.Text;
            string confirmPassword = TxtConPass.Text;
            ConfirmPasswordError.Text = ""; 

            if (confirmPassword == "")
            {
                return;
            }

            if (confirmPassword.Length < 6)
            {
                ConfirmPasswordError.Text = "Password should be at least 6 characters.";
                d = false;
                return;
            }

            if (confirmPassword.Length > 20)
            {
                TxtConPass.Text = confirmPassword.Substring(0, 20);
                TxtConPass.SelectionStart = TxtConPass.Text.Length;
            }

            if (password != confirmPassword)
            {
                ConfirmPasswordError.Text = "Confirm password isn't the same as password.";
                d = false;
            }
            else
            {
                ConfirmPasswordError.Text = "";
                d = true;
            }

        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (a == true && b == true && c == true && d == true)
            {
                Home homeForm = Program.FrmUtama;
                homeForm.Show();
                homeForm.WindowState = FormWindowState.Maximized;
                homeForm.BringToFront();

                DatabaseClass.BukaDB("users");

                string username = TxtUserName.Text;
                string email = TxtEmail.Text;
                string password = TxtPass.Text;

                bool userCheck = DatabaseClass.IsUserExists(username, "@username", "SELECT COUNT(*) FROM users WHERE username = @username");
                bool emailCheck = DatabaseClass.IsUserExists(email, "@email", "SELECT COUNT(*) FROM users WHERE email = @email");

                if (userCheck)
                {
                    UsernameError.Text = "Username already existed.";
                }

                if (emailCheck)
                {
                    EmailError.Text = "Email is already registered. Please choose a different one.";
                }


                if (!userCheck && !emailCheck)
                {
                    VerificationEmail verification = Program.FrmVerificationEmail;
                    verification.changeFunction(username, email, password);
                    verification.Show();
                    this.Hide();
                }

                DatabaseClass.TutupDB("users");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginPage login = Program.FrmLogin;
            login.Show();
            this.Hide();
        }
    }
}
