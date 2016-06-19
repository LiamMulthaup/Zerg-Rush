using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zerg_Rush
{
    public partial class Form1 : Form
    {
        struct aliens
        {
            public int position;
            public int health;
        }
        List<aliens> alienList = new List<aliens>();
        public Form1()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            runTicker.Start();
        }

        List<PictureBox> alienPictureList = new List<PictureBox>();
        int gamephase = 0;
        List<int> createAlienWaitTimers = new List<int>();
        int position = 0;

        bool rightDown = false;
        bool leftDown = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            gamephase = 1;
            createAlienWaitTimers.Add(500 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(600 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(700 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(800 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(900 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(1000 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(1100 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(1200 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(1300 + rand.Next(rand.Next(80)));
            createAlienWaitTimers.Add(1400 + rand.Next(rand.Next(80)));
        }

        private void runTicker_Tick(object sender, EventArgs e)
        {
            if (rightDown == true)
            {
                rotateRight(defaultalienPicture, Properties.Resources.space_invader, position);
                position++;
            }
            if (leftDown == true)
            {
                rotateLeft(defaultalienPicture, Properties.Resources.space_invader, position);
                position--;
            }
            if (gamephase == 1)
            {
                for (int x = 0; x < alienList.Count; x++)
                {

                }
                for (int x = createAlienWaitTimers.Count - 1; x >= 0; x--)
                {
                    createAlienWaitTimers[x] = createAlienWaitTimers[x] - 1;
                    if (createAlienWaitTimers[x] < 1)
                    {
                        createAlien();
                        createAlienWaitTimers.RemoveAt(x);
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (sender != defaultalienPicture)
            {
                killAlien(sender);
            }
            else
            {
                createAlien();
            }
        }
        private void createAlien()
        {
            Random rand = new Random();
            aliens alien = new aliens();
            alien.health = rand.Next(2 + rand.Next(3));
            alien.position = 0;
            alienList.Add(alien);
            PictureBox alienPicture = new PictureBox();
            alienPicture.Click += pictureBox1_Click;
            alienPicture.Image = Properties.Resources.space_invader;
            alienPicture.Size = defaultalienPicture.Size;
            alienPicture.SizeMode = PictureBoxSizeMode.Zoom;
            alienPictureList.Add(alienPicture);
            Controls.Add(alienPictureList[alienPictureList.Count - 1]);
            alienPictureList[alienPictureList.Count - 1].Location = new Point(rand.Next(940), rand.Next(20));
        }
        private void killAlien(object sender)
        {
            PictureBox pbx = sender as PictureBox;
            alienList.RemoveAt(alienPictureList.IndexOf(pbx));
            alienPictureList.Remove(pbx);
            Controls.Remove(pbx);
            pbx.Dispose();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Right))
            {
                rightDown = true;
            }
            if (e.KeyValue == Convert.ToChar(Keys.Left))
            {
                leftDown = true;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Right))
            {
                rightDown = false;
            }
            if (e.KeyValue == Convert.ToChar(Keys.Left))
            {
                leftDown = false;
            }
        }

        private void rotateRight(PictureBox pbx, Bitmap btp, float angle)
        {
            pbx.Image = RotateImage(btp, new PointF(pbx.Image.Width / 2, pbx.Image.Height / 2), angle + 1F, pbx);
        }

        private void rotateLeft(PictureBox pbx, Bitmap btp, float angle)
        {
            pbx.Image = RotateImage(btp, new PointF(pbx.Image.Width / 2, pbx.Image.Height / 2), angle - 1F, pbx);
        }

        public static Bitmap RotateImage(Image image, PointF offset, float angle, PictureBox pbx)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;

            //Used in an experiment, didn't go well.
            //double y = Math.Sqrt((image.Width * image.Width) + (image.Height * image.Height)) / 2;
            //int newWidth = Convert.ToInt32(Math.Abs(Math.Cos(angle) * y * 2));
            //int newHeight = Convert.ToInt32(Math.Abs(Math.Cos(90 - angle) * y * 2));

        }
    }
}
