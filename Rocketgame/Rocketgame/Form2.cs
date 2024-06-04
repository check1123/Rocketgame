using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Rocketgame
{
    public partial class Form2 : Form
    {
        Random random = new Random();
        int points = 0;
        SoundPlayer mysound=new SoundPlayer(@"C:\Users\labstudent\Downloads\erg.wav");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.A)
            {
                pictureBox1.Left -= 10;
            }
            if(e.KeyCode == Keys.D)
            {
                pictureBox1.Left += 10;
            }
            if(e.KeyCode==Keys.Space)
            {
                if (timer2.Enabled == false)
                {
                    pictureBox3.Location = pictureBox1.Location;
                    timer2.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            pictureBox2.Top += 10;
            pictureBox2.Visible = true;
            if (pictureBox2.Location.Y>377)
            {
                int newX = random.Next(2, 701);
                    pictureBox2.Location = new Point(newX, 0);
            }
            if(pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                points++;
                label1.Text=points.ToString();
                pictureBox2.Visible = false;
                int newX = random.Next(2, 701);
                pictureBox2.Location = new Point(newX, 0);
                pictureBox3.Visible = false;
                pictureBox3.Location = pictureBox1.Location;
                timer2.Stop();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mysound.Play();
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox3.Top -= 15;
            if (pictureBox3.Location.Y < 0)
            {
                pictureBox3.Visible = false;
                pictureBox3.Location = pictureBox1.Location;
                timer2.Stop();

            }
        }
    }
}
