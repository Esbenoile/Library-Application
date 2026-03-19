using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class CodeItem : Form
    {
        public CodeItem()
        {
            InitializeComponent();
        }

        private void CodeItem_Load(object sender, EventArgs e)
        {
            
        }

        private DateTime endTime;  

        private void UpdateTimerDisplay()
        {
            TimeSpan remainingTime = endTime - DateTime.Now;

            if (remainingTime.TotalSeconds <= 0)
            {
                timerSession.Stop();
                Timer.Text = "00:00:00";
                return;
            }

            string formattedTime = remainingTime.ToString(@"hh\:mm\:ss");

            Timer.Text = formattedTime;
        }


        public void SentInfo(string ParamBookCode, string ParamUserId, string bookName, int bookQuantity, Image bookImage, string rentalCode, DateTime startTime)
        {
            PictureCover.Image = bookImage;
            VerificationCode.Text = rentalCode;

            DateTime closingTime = DateTime.Today.AddDays(1).AddHours(0); 
            endTime = closingTime;

            TimeSpan sessionDuration = endTime - startTime;
            int durationHours = (int)sessionDuration.TotalHours;
            UpdateTimerDisplay();
            timerSession.Start();
        }

        private void timerSession_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = endTime - DateTime.Now;

            if (remainingTime.TotalSeconds <= 0)
            {
                timerSession.Stop();
                Timer.Text = "00:00:00";
                return;
            }

            string formattedTime = remainingTime.ToString(@"hh\:mm\:ss");

            Timer.Text = formattedTime;
        }
    }
}
