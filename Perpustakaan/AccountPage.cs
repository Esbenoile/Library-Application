using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;

namespace Perpustakaan
{
    public partial class AccountPage : Form
    {

        private decimal balanceUSD = 0m;

        private Dictionary<string, string> languageToCurrency = new Dictionary<string, string>
        {
            { "English (United States)", "USD" },
            { "English (United Kingdom)", "GBP" },
            { "German (Germany)", "EUR" },
            { "Japanese (Japan)", "JPY" },
            { "French (France)", "EUR" },
            { "Hindi (India)", "INR" },
            { "Chinese (Simplified)", "CNY" },
            { "Russian (Russia)", "RUB" },
            { "Spanish (Spain)", "EUR" },
            { "Portuguese (Brazil)", "BRL" }
        };

        private Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.00m },  
            { "EUR", 0.92m },
            { "GBP", 0.80m },
            { "JPY", 140.00m },
            { "CNY", 7.30m },
            { "INR", 83.00m },
            { "RUB", 92.00m },
            { "BRL", 5.10m },
            { "AUD", 1.50m },
            { "CAD", 1.35m },
            { "ZAR", 18.00m },
            { "MXN", 17.00m }
        };

        public void RefreshComic(RoundButton buttonParam)
        {
            originalButton = buttonParam;
        }

        RoundButton originalButton = null;
        public AccountPage()
        {
            InitializeComponent();

            originalButton = MyAccountButton;
        }
        int globalFetchId;

        public void reload(int paramId)
        {
            DatabaseClass.BukaDB("users");
            Image profileImage = pictureBox1.Image = DatabaseClass.GetProfilePicture(paramId);
            if (profileImage != null)
            {
                pictureBox1.Image = profileImage;
            } else
            {
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("Profile_Picture_White");
            }


            balanceUSD = DatabaseClass.GetUserBalance(paramId);

            UpdateBalanceLabel();
            DatabaseClass.TutupDB("users");
        }

        public void LoadInformation(string email, int fetchId)
        {
            DatabaseClass.BukaDB("users");
            List<Register> usernameById = DatabaseClass.GetUsernameById(fetchId);
            DatabaseClass.TutupDB("users");

            reload(fetchId);

            foreach (var user in usernameById)
            {
                UsernameProfile.Text = user.Username;
                NameStuffDisplay.Text = user.Username;
                DateCreated.Text = user.Datetime.ToString("MMM d, yyyy");
            }
            GmailProfile.Text = email;
            globalFetchId = fetchId;
        }

        public void LoadPicture(Image image)
        {
            if (image != null)
            {
                pictureBox1.Image = image;  
            }
        }

        public void UpdateBalanceLabel()
        {
            if (LanguageCurrency.SelectedItem != null)
            {
                string selectedLanguage = LanguageCurrency.SelectedItem.ToString();

                if (languageToCurrency.TryGetValue(selectedLanguage, out string currency))
                {
                    if (exchangeRates.TryGetValue(currency, out decimal exchangeRate))
                    {
                        decimal convertedBalance = balanceUSD * exchangeRate;
                        Balance.Text = $"{convertedBalance:F2} {currency}";
                    }
                    else
                    {
                        Balance.Text = "Currency not supported.";
                    }
                }
            }
            else
            {
                Balance.Text = "Please select a language.";
            }
        }



        private void AccountPage_Load(object sender, EventArgs e)
        {
            LanguageCurrency.Items.AddRange(languageToCurrency.Keys.ToArray());
            LanguageCurrency.SelectedIndex = 0;

            UpdateBalanceLabel();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select a Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EditProfilePicture editProfileFrm = Program.FrmEditProfilePicture;

                    if (editProfileFrm == null || editProfileFrm.IsDisposed)
                    {
                        editProfileFrm = new EditProfilePicture();
                        Program.FrmEditProfilePicture = editProfileFrm;
                    }

                    editProfileFrm.SetProfilePicture(Image.FromFile(openFileDialog.FileName), globalFetchId);
                    editProfileFrm.Show();
                    editProfileFrm.BringToFront();
                }
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            balanceUSD += 10;

            DatabaseClass.BukaDB("users");
            DatabaseClass.UpdateUserBalance(globalFetchId, (long)balanceUSD);
            DatabaseClass.TutupDB("users");

            UpdateBalanceLabel();
        }

        private void LanguageCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBalanceLabel();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        Color grayBackColor = Color.FromArgb(224, 224, 224);
        Color silverBackColor = Color.FromKnownColor(KnownColor.Silver);
        private void roundButton3_Click(object sender, EventArgs e)
        {
            AccountPanel.Visible = true;
            FinancialPanel.Visible = false;
            originalButton.BackColor = grayBackColor;
            MyAccountButton.BackColor = silverBackColor;
            RefreshComic(MyAccountButton);
        }

        private void FinancialAccountButton_Click(object sender, EventArgs e)
        {
            AccountPanel.Visible = false;
            FinancialPanel.Visible = true;
            originalButton.BackColor = grayBackColor;
            FinancialAccountButton.BackColor = silverBackColor;
            RefreshComic(FinancialAccountButton);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
