using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Perpustakaan.DatabaseClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Perpustakaan
{
    public partial class ProfilePictureOther : Form
    {
        public ProfilePictureOther()
        {
            InitializeComponent();
        }
        int globalUser = -1;

        private void roundButton2_Click(object sender, EventArgs e)
        {

            if (globalUser != -1)
            {
                DatabaseClass.BukaDB("friendrequests");
                //DatabaseClass.AddNewRequest(globalUser, );
                DatabaseClass.TutupDB("friendrequests");
            }
            else
            {
                LoginPage loginForm = Program.FrmLogin;
                loginForm.Show();
                loginForm.BringToFront();
            }

        }

        public void LoadInformation(int fetchId, int globalUserFetch)
        {
            globalUser = globalUserFetch;
            DatabaseClass.BukaDB("users");
            List<Register> usernameById = DatabaseClass.GetUsernameById(fetchId);
            DatabaseClass.TutupDB("users");

            //reload(fetchId);

            foreach (var user in usernameById)
            {
                UsernameProfile.Text = user.Username;
                NameStuffDisplay.Text = user.Username;
                DateCreated.Text = user.Datetime.ToString("MMM d, yyyy");
                GmailProfile.Text = user.Email;
                byte[] pictureUserOther = user.ProfilePicture;

                try
                {
                    if (pictureUserOther != null && pictureUserOther.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(pictureUserOther))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    pictureBox1.Image = null;
                }
            }
            //globalFetchId = fetchId;

        }

        private void ProfilePictureOther_Load(object sender, EventArgs e)
        {

        }
    }
}
