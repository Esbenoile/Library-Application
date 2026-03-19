using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class RentingViewPage : Form
    {
        public RentingViewPage()
        {
            InitializeComponent();
        }

        string publicBookCode;
        string userId;
        string publicBookName;
        int publicBookQuantity;

        private string GenerateCode(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var secureCode = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[length];
                rng.GetBytes(buffer);
                foreach (var b in buffer)
                {
                    secureCode.Append(characters[b % characters.Length]);
                }
            }
            return secureCode.ToString();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(depositLabel.Text, out int deposit) && deposit >= 50)
            {
                ErrorMist.Text = "";
                if (publicBookCode != null && userId != null)
                {
                    DatabaseClass.BukaDB("Rental");
                    DateTime rentDate = DateTime.Today;
                    DateTime endDate = dateTimePicker1.Value;

                    if (endDate <= rentDate)
                    {
                        return;
                    }

                    string rentalCode = GenerateCode(20);

                    InboxForm frmInbox = Program.FrmInbox;


                    DateTime startTime = DateTime.Now;

                    DatabaseClass.AddNewRental(publicBookCode, userId, endDate, rentDate, rentalCode, startTime);
                    frmInbox.generateInbox(publicBookCode, userId, publicBookName);

                    Program.FrmSessionActivityForm.generateInbox(publicBookCode, userId, publicBookName);

                    publicBookQuantity--;
                    DatabaseClass.BukaDB("book");

                    Program.FrmCodeItem.SentInfo(publicBookCode, userId, publicBookName, publicBookQuantity, comicBook.Image, rentalCode, startTime);

                    CodeItem frmCodeItem = Program.FrmCodeItem;
                    frmCodeItem.Show();
                    frmCodeItem.WindowState = FormWindowState.Maximized;
                    frmCodeItem.BringToFront();

                    Program.FrmDiscover.reload();
                    DatabaseClass.TutupDB("book");

                    DatabaseClass.TutupDB("Rental");
                }
                else
                {
                    MessageBox.Show("Please ensure book and user details are set.");
                }
            } else
            {
                ErrorMist.Text = "Your balance doesn't meet the requirement to rent this book!!";
            }
        }

        private void RentingViewPage_Load(object sender, EventArgs e)
        {
            ErrorMist.Text = "";
            dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
            dateTimePicker1.MaxDate = DateTime.Today.AddMonths(1);
        }

        public void rentingInfo(string ParamBookCode, string ParamUserId, string bookName, int bookQuantity, Image bookImage)
        {
            publicBookCode = ParamBookCode;
            userId = ParamUserId;
            publicBookName = bookName;
            publicBookQuantity = bookQuantity;
            comicBook.Image = bookImage;

            DatabaseClass.BukaDB("users");
            depositLabel.Text = DatabaseClass.GetUserBalance(int.Parse(ParamUserId)).ToString();
            DatabaseClass.TutupDB("users");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime today = DateTime.Today;

            if (selectedDate <= today)
            {
                //MessageBox.Show("Please select a future date.");
                dateTimePicker1.Value = today.AddDays(1); 
                return;
            }

            int daysInFuture = (selectedDate - today).Days;
            decimal cost = 10 * daysInFuture;
        }

        private void depositLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MoneyLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
