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
        struct players
        {
            public int position;
            public int health;
        }
        struct lasers
        {
            public int position;
            public int damage;
        }
        List<aliens> alienList = new List<aliens>();
        public Form1()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            runTicker.Start();
        }
        List<lasers> laserList = new List<lasers>();
        List<PictureBox> laserPictureList = new List<PictureBox>();
        List<PictureBox> alienPictureList = new List<PictureBox>();
        List<players> playersList = new List<players>();
        int gamephase = 0;
        List<int> createAlienWaitTimers = new List<int>();
        int position = 0;

        bool rightDown = false;
        bool leftDown = false;
        bool mousePress = false;

        int waitingToMove = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
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
                position++;
                rotate(defaultalienPicture, Properties.Resources.space_invader, position);
            }
            if (leftDown == true)
            {
                position--;
                rotate(defaultalienPicture, Properties.Resources.space_invader, position);
            }
            if (gamephase == 1)
            {
                for (int x = 0; x < playersList.Count; x++)
                {
                    players player = playersList[x];
                    player.position = PointControlTowardsCursor(spaceship, Properties.Resources.spaceship);
                    playersList[x] = player;
                    if (waitingToMove < 1)
                    {
                        MoveTowardsCursor(spaceship, player.position);
                        waitingToMove = 3;
                    }
                }
                waitingToMove--;
                
                for (int x = 0; x < laserList.Count; x++)
                {
                    MoveTowardsPosition(laserList[x].position, 5, laserPictureList[x]);
                    if (laserPictureList[x].Location.Y > this.Height || laserPictureList[x].Location.Y < -40 || laserPictureList[x].Location.X > this.Width || laserPictureList[x].Location.X < -40)
                    {
                        laserList.RemoveAt(x);
                        Controls.Remove(laserPictureList[x]);
                        laserPictureList[x].Dispose();
                        laserPictureList.RemoveAt(x);
                    }
                }

                for (int x = 0; x < alienList.Count; x++)
                {
                    for (int y = 0; x < laserList.Count; x++)
                    {
                        if ((laserPictureList[y].Location.X > (alienPictureList[x].Location.X + alienPictureList[x].Width - 5) && laserPictureList[y].Location.X < (alienPictureList[x].Location.X + 5)) && (laserPictureList[y].Location.Y > (alienPictureList[x].Location.Y + alienPictureList[x].Height - 5) && laserPictureList[y].Location.Y < (alienPictureList[x].Location.Y + 5)))
                        {
                            MessageBox.Show("Gottem");
                        }
                    }
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

        private int PointControlTowardsCursor(PictureBox pcb, Bitmap btm)
        {
            double ydistance = (pcb.Location.Y + (pcb.Height / 2)) - (Cursor.Position.Y - this.Location.Y - 30);
            double xdistance = (Cursor.Position.X - this.Location.X - 8) - (pcb.Location.X + (pcb.Width / 2));
            int newControlPosition = - Convert.ToInt32(Math.Atan2(ydistance, xdistance) * 180 / Math.PI);
            label1.Text = newControlPosition.ToString() + " " + (Cursor.Position.X - this.Location.X).ToString() + " " + (Cursor.Position.Y - this.Location.Y).ToString() + " " + (pcb.Location.X + (pcb.Width / 2)).ToString() + " " + (pcb.Location.Y + (pcb.Height / 2)).ToString() + " " + pcb.Location.X + " "  + pcb.Location.Y;
            rotate(pcb, btm, newControlPosition + 90);
            return newControlPosition;
        }

        private void MoveTowardsCursor(PictureBox pcb, int controlPosition)
        {
            int distanceToTravel = 3;
            double ydistance = (pcb.Location.Y + (pcb.Height / 2)) - (Cursor.Position.Y - this.Location.Y - 30);
            double xdistance = (Cursor.Position.X - this.Location.X - 8) - (pcb.Location.X + (pcb.Width / 2));
            int distanceAway = Convert.ToInt32(Math.Sqrt((ydistance * ydistance) + (xdistance * xdistance)));
            if (distanceAway > 40)
            {
                MoveTowardsPosition(controlPosition, distanceToTravel, pcb);
            }
        }

        private void MoveTowardsPosition(int controlPosition, int distanceToTravel, PictureBox pcb)
        {
            int xDistanceToMove = Convert.ToInt32(Math.Cos(controlPosition * Math.PI / 180) * distanceToTravel);
            int yDistanceToMove = Convert.ToInt32(Math.Sin(controlPosition * Math.PI / 180) * distanceToTravel);
            pcb.Location = new Point(pcb.Location.X + xDistanceToMove, pcb.Location.Y + yDistanceToMove);
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
            alienPicture.MouseDown += mouseDown;
            alienPicture.MouseUp += mouseUp;
            alienPicture.Image = Properties.Resources.space_invader;
            alienPicture.Size = defaultalienPicture.Size;
            alienPicture.SizeMode = PictureBoxSizeMode.Zoom;
            alienPictureList.Add(alienPicture);
            Controls.Add(alienPictureList[alienPictureList.Count - 1]);
            int choice = rand.Next(4);
            if (choice == 0)
            { alienPictureList[alienPictureList.Count - 1].Location = new Point(rand.Next(this.Size.Width), rand.Next(5)); }
            if (choice == 1)
            { alienPictureList[alienPictureList.Count - 1].Location = new Point(rand.Next(this.Size.Width), this.Size.Height - rand.Next(5)); }
            if (choice == 2)
            { alienPictureList[alienPictureList.Count - 1].Location = new Point(rand.Next(5), rand.Next(this.Size.Height)); }
            if (choice == 3)
            { alienPictureList[alienPictureList.Count - 1].Location = new Point(this.Size.Width - rand.Next(5), rand.Next(this.Size.Height)); }

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

        private void rotate(PictureBox pbx, Bitmap btp, float angle)
        {
            pbx.Image = RotateImage(btp, new PointF(pbx.Image.Width / 2, pbx.Image.Height / 2), angle, pbx);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gamephase = 1;
            button1.Visible = false;
            this.Focus();
            this.Cursor = Cursors.Cross;
            players player = new players();
            playersList.Add(player);
        }

        private void spaceship_Click(object sender, EventArgs e)
        {
            label1.Text = Cursor.Position.X.ToString() + " " + Cursor.Position.Y.ToString();
        }

        private void formClick(object sender, EventArgs e)
        {
            
        }
        private void mouseDown(object sender, MouseEventArgs e)
        {
            mousePress = true;
            if (laserShootingTimer.Enabled == false)
            {
                laserShoot();
                laserShootingTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mousePress == true)
            {
                laserShoot();
            }
            else
            {
                laserShootingTimer.Stop();
            }
        }

        private void laserShoot()
        {
            lasers laser = new lasers();
            PictureBox laserPicture = new PictureBox();
            players player = playersList[0];
            laser.position = player.position;
            laserPicture.Size = laserDefaultPicture.Size;
            laserPicture.Image = laserDefaultPicture.Image;
            laserPicture.MouseDown += mouseDown;
            laserPicture.MouseUp += mouseUp;
            rotate(laserPicture, Properties.Resources.Laser2, laser.position + 90);
            laserPicture.SizeMode = laserDefaultPicture.SizeMode;
            laserPicture.Location = spaceship.Location;
            laser.damage = 1;
            laserList.Add(laser);
            laserPictureList.Add(laserPicture);
            Controls.Add(laserPictureList[laserPictureList.Count - 1]);
            MoveTowardsPosition(laser.position, 40, laserPictureList[laserPictureList.Count - 1]);
            laserPictureList[laserPictureList.Count - 1].BringToFront();
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            mousePress = false;
        }
    }
}
