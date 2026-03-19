using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;

namespace Perpustakaan
{
    public partial class EditProfilePicture : Form
    {

        private Image originalImage;
        private Rectangle cropRectangle;
        private bool isDragging;
        private Point dragStart;
        public EditProfilePicture()
        {
            InitializeComponent();
            cropRectangle = new Rectangle(50, 50, 100, 100); 
            this.DoubleBuffered = true;
        }

        public void SetProfilePicture(Image image, int userId)
        {
            originalImage = image;
            cropRectangle = new Rectangle(50, 50, 100, 100); 
            Invalidate();
            publicUserId = userId;
        }

        private void EditProfilePicture_Load(object sender, EventArgs e)
        {
            vScrollBar1.Minimum = 10;   
            vScrollBar1.Maximum = 200; 
            vScrollBar1.Value = cropRectangle.Width * 2;
            vScrollBar1.SmallChange = 5;  
            vScrollBar1.LargeChange = 10; 
        }

        int publicUserId;
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            DatabaseClass.BukaDB("users");
            try
            {
                Image croppedImage = GetCroppedImage();
                this.Hide();
                Program.FrmAccount.LoadPicture(croppedImage);
                DatabaseClass.SaveProfilePicture(publicUserId, croppedImage);
                MessageBox.Show("Profile picture updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DatabaseClass.TutupDB("users");

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (originalImage != null)
            {
                pictureBox1.Image = originalImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                using (Pen cropPen = new Pen(Color.Red, 2))
                {
                    cropPen.DashStyle = DashStyle.Solid;
                    g.DrawEllipse(cropPen, cropRectangle);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - dragStart.X;
                int dy = e.Y - dragStart.Y;
                cropRectangle.X += dx;
                cropRectangle.Y += dy;

                dragStart = e.Location;
                Invalidate(); 
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int newSize = vScrollBar1.Value * 2;

            cropRectangle.Width = newSize;
            cropRectangle.Height = newSize;

            cropRectangle.X = Math.Max(0, cropRectangle.X - (newSize - cropRectangle.Width) / 2);
            cropRectangle.Y = Math.Max(0, cropRectangle.Y - (newSize - cropRectangle.Height) / 2);

            pictureBox1.Invalidate(); 
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (cropRectangle.Contains(e.Location))
            {
                isDragging = true;
                dragStart = e.Location;
            }
        }

        public Image GetCroppedImage()
        {
            if (originalImage == null) return null;

            float scaleX = (float)pictureBox1.Width / originalImage.Width;
            float scaleY = (float)pictureBox1.Height / originalImage.Height;

            Rectangle imageCropRectangle = new Rectangle(
                (int)(cropRectangle.X / scaleX),
                (int)(cropRectangle.Y / scaleY),
                (int)(cropRectangle.Width / scaleX),
                (int)(cropRectangle.Height / scaleY)
            );

            imageCropRectangle = new Rectangle(
                Math.Max(imageCropRectangle.X, 0),
                Math.Max(imageCropRectangle.Y, 0),
                Math.Min(imageCropRectangle.Width, originalImage.Width - imageCropRectangle.X),
                Math.Min(imageCropRectangle.Height, originalImage.Height - imageCropRectangle.Y)
            );

            Bitmap croppedImage = new Bitmap(imageCropRectangle.Width, imageCropRectangle.Height);

            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, imageCropRectangle.Width, imageCropRectangle.Height);
                    g.SetClip(path); 

                    g.DrawImage(
                        originalImage,
                        new Rectangle(0, 0, croppedImage.Width, croppedImage.Height),
                        imageCropRectangle,
                        GraphicsUnit.Pixel
                    );
                }
            }

            return croppedImage;
        }


    }
}
