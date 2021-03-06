using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool goleft, goright;
        int speed = 5;
        int score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int playerSpeed = 6;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft)
            {
                player.Left -= playerSpeed;
            }
            else
               if (goright)
            {
                player.Left += playerSpeed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "invaders")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver();
                    }
                    ((PictureBox)x).Left += speed;
                    if (((PictureBox)x).Left > 720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                }
            }

            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20;
                    if (((PictureBox)y).Top < this.Height - 490)
                        this.Controls.Remove(y);
                }
            }
            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "invaders")
                    {
                        if (j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(i);

                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
            label1.Text = "Score: " + score;
            if (score > totalEnemies - 1)
            {
                gameOver();
                MessageBox.Show("You Win");
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makeBullet();
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (isPressed)
            {
                isPressed = false;

            }
        }
        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 OpenForm = new Form1();
            OpenForm.Show();
        }

      

        private void gameOver()
        {
            timer1.Stop();
            label1.Text += " Game Over";
            button1.Visible = true;
        }
    }
}
