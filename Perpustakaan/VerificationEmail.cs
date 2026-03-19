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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Perpustakaan
{


    public partial class VerificationEmail : Form
    {
        string password = "scchxtpeqwbsqgwh";
        string gmailPersonal = "redboxcorp137@gmail.com";


        public VerificationEmail()
        {
            InitializeComponent();
        }

        private static Dictionary<int, (string Code, DateTime Expiration)> verificationCodes =
    new Dictionary<int, (string Code, DateTime Expiration)>();

        public static string GenerateVerificationCode(int length = 6)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            byte[] randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            for (int i = 0; i < length; i++)
            {
                int index = randomBytes[i] % validChars.Length;
                result.Append(validChars[index]);
            }

            return result.ToString();
        }

        public static void StoreVerificationCode(int userId, string code)
        {
            var expirationTime = DateTime.Now.AddMinutes(1);
            verificationCodes[userId] = (code, expirationTime);
            //timeLeft = 60;
            //DateLabelCountdown.Text = "01:00"; 
            //timer.Start(); 

        }


        public static string HashVerificationCode(string code)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));
                StringBuilder hashString = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }
        }

        public static bool VerifyCode(int userId, string code)
        {
            if (verificationCodes.TryGetValue(userId, out var storedCode))
            {
                if (DateTime.Now > storedCode.Expiration)
                {
                    verificationCodes.Remove(userId);
                    return false;
                }

                return code == storedCode.Code;
            }
            return false;
        }

        public static void SendVerificationEmail(string toEmail, string verificationCode, string userGlobal1)
        {
            var fromAddress = new MailAddress("redboxcorp137@gmail.com", "Verification Library");
            var toAddress = new MailAddress(toEmail);

            const string subject = "Your Verification Code";
            string body = $"Dear User {userGlobal1},\n\n" +
                          $"We hope this message finds you well.\n\n" +
                          $"Your verification code is: {verificationCode}\n\n" +
                          $"Please enter this code in the designated field to verify your account.\n\n" +
                          $"If you did not request this code, please ignore this message.\n\n" +
                          $"Thank you for your attention.\n\n" +
                          $"Best regards,\n" +
                          $"Red Box";
            ;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "scchxtpeqwbsqgwh")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


        private Timer timer;
        private int timeLeft;

        public void StartCountdown(int seconds)
        {
            timeLeft = seconds;
            DateLabelCountdown.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss"); 
            timer.Start(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            DateLabelCountdown.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

            if (timeLeft > 20)
            {
                DateLabelCountdown.ForeColor = Color.White;
            } else if (timeLeft > 0)
            {
                DateLabelCountdown.ForeColor = Color.Red;
            }
            else
            {
                timer.Stop();
                DateLabelCountdown.Text = "00:00";
                RetryLabel.Text = "Retry";
            }
        }

        int userIndex = 0;
        string userGlobal;
        string emailGlobal;
        string passGlobal;

        public void changeFunction(string user, string email, string pass)
        {
            userGlobal = user;
            emailGlobal = email;
            passGlobal = pass; 
            HelloLabel.Text = "Hello, " + user;
            userIndex++;

            string verificationCode = GenerateVerificationCode();
            StoreVerificationCode(userIndex, verificationCode);
            timer = new Timer(); 
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            DateLabelCountdown.Text = "03:00";
            StartCountdown(180);

            SendVerificationEmail(email, verificationCode, user);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (VerifyCode(userIndex, KodeVerification.Text))
            {
                DatabaseClass.BukaDB("users");
                DatabaseClass.RegisterUser(userGlobal, emailGlobal, passGlobal);

                Page page = Program.FrmPage;
                int fetchId = DatabaseClass.FetchUserId(emailGlobal, passGlobal);
                page.GlobalUserFetch(fetchId);
                Program.FrmPage.showComment(fetchId);
                Program.FrmAccount.LoadInformation(emailGlobal, fetchId);
                ErrorMessage.Text = "";
                Program.FrmUtama.userChange(fetchId, emailGlobal);
                Program.FrmInbox.loadInbox(fetchId.ToString());
                Program.FrmRent.Reload(fetchId);
                this.Hide();
                DatabaseClass.TutupDB("users");
            }
            else
            {
                ErrorMessage.Text = "Invalid Code Verification";
            }
        }

        private void VerificationEmail_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            RetryLabel.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RetryLabel.Text = "";
            HelloLabel.Text = "Hello, " + userGlobal;
            userIndex++;

            string verificationCode = GenerateVerificationCode();
            StoreVerificationCode(userIndex, verificationCode);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            DateLabelCountdown.Text = "03:00";
            StartCountdown(60);

            SendVerificationEmail(emailGlobal, verificationCode, userGlobal);
        }
    }
}
