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
            InitializeComponent();
            runTicker.Start();
        }
        List<PictureBox> alienPictureList = new List<PictureBox>();
        int gamephase = 0;
        List<int> createAlienWaitTimers = new List<int>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            gamephase = 1;
            createAlienWaitTimers.Add(50 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(60 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(70 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(80 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(90 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(100 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(110 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(120 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(130 + rand.Next(rand.Next(8)));
            createAlienWaitTimers.Add(140 + rand.Next(rand.Next(8)));
        }

        private void runTicker_Tick(object sender, EventArgs e)
        {
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
            alienPicture.Image = Properties.Resources.f3b38e0625012600f8c71693e75443dc526c1;
            alienPicture.Size = defaultalienPicture.Size;
            alienPicture.SizeMode = PictureBoxSizeMode.Zoom;
            alienPictureList.Add(alienPicture);
            Controls.Add(alienPictureList[alienPictureList.Count - 1]);
            alienPictureList[alienPictureList.Count - 1].Location = new Point(rand.Next(940), rand.Next(520));
        }
        private void killAlien(object sender)
        {
            PictureBox pbx = sender as PictureBox;
            alienList.RemoveAt(alienPictureList.IndexOf(pbx));
            alienPictureList.Remove(pbx);
            Controls.Remove(pbx);
            pbx.Dispose();
        }
    }
}
