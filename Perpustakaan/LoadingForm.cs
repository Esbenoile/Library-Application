using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Perpustakaan
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private double animationProgress = 0.0;
        private double animationSpeed = 0.004;

        private void timer1_Tick(object sender, EventArgs e)
        {
            animationProgress += animationSpeed;

            double easedProgress = 1 - Math.Pow(1 - animationProgress, 3);
            panel3.Width = (int)(easedProgress * 800);

            if (panel3.Width > 650)
            {
                timer1.Stop();
                fadeTimer.Start();
            }
        }

        private double fadeProgress = 0.0;
        private double fadeSpeed = 0.08;
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            fadeProgress += fadeSpeed;

            double easedOpacity = 1 - Math.Pow(1 - fadeProgress, 3);
            Opacity = 1 - easedOpacity;

            if (fadeProgress >= 1)
            {
                fadeTimer.Stop();
                this.Hide();
                Home FrmUtama = Program.FrmUtama;
                FrmUtama.Show();
                FrmUtama.WindowState = FormWindowState.Maximized;
                FrmUtama.BringToFront();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
