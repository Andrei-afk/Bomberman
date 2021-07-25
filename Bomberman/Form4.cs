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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            timer2.Start();
        }
        bool goleft, goright;
        int speed = 5;
        int score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int playerSpeed = 6;
        private void Form4_KeyDown(object sender, KeyEventArgs e)
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

        private void Form4_KeyUp(object sender, KeyEventArgs e)
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
        int nr = 11;
        bool s1 = false, s2 = false, s3 = false, s4 = false, s5 = false, s6 = false, s7 = false, s8 = false, s9 = false, s10 = false, s11 = false;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //s1=s2=s3=s4=s5=s6=s7=s8=s9=s10=s11=false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft && player.Left > 50)
            {
                player.Left -= playerSpeed;
            }
            else
             if (goright && player.Left < 595)
            {
                player.Left += playerSpeed;
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 10;
                    foreach (Control i in this.Controls)
                        if (i.Tag == "walls" && i.Bounds.IntersectsWith(y.Bounds))

                            this.Controls.Remove(y);
                }
                if (y is PictureBox && y.Tag == "bullete")
                {
                    y.Top += 15;
                    foreach (Control i in this.Controls)
                    {
                        if (i.Tag == "walls" && i.Bounds.IntersectsWith(y.Bounds))
                            this.Controls.Remove(y);
                    }
                }
                foreach (Control i in this.Controls)
                {
                    if (y.Tag == "bullete" && i.Tag == "pl" && i.Bounds.IntersectsWith(y.Bounds))
                    {
                        this.Controls.Remove(i);
                        this.Controls.Remove(y);
                       DialogResult dialog= MessageBox.Show("You lost!","Exit",MessageBoxButtons.OK);
                        if (dialog == DialogResult.OK)
                        {
                            this.Hide();
                            Form1 OpenForm = new Form1();
                            OpenForm.ShowDialog();
                        }

                    }

                    if (y.Tag == "bullet" && i.Tag == "enemy" && i.Bounds.IntersectsWith(y.Bounds))
                    {
                        //i.Tag = "used";
                        this.Controls.Remove(i);
                        this.Controls.Remove(y);
                        nr--;
                        if (nr == 0) 
                        {
                            DialogResult dialog = MessageBox.Show("You win!", "Exit", MessageBoxButtons.OK);
                            if (dialog == DialogResult.OK)
                            {
                                this.Hide();
                                Form1 OpenForm = new Form1();
                                OpenForm.ShowDialog();
                            }
                        }
                           
                        if (i.Name == "e1")
                            s1 = true;
                        if (i.Name == "e2")
                            s2 = true;
                        if (i.Name == "e3")
                            s3 = true;
                        if (i.Name == "e4")
                            s4 = true;
                        if (i.Name == "e5")
                            s5 = true;
                        if (i.Name == "e6")
                            s6 = true;
                        if (i.Name == "e7")
                            s7 = true;
                        if (i.Name == "e8")
                            s8 = true;
                        if (i.Name == "e9")
                            s9 = true;
                        if (i.Name == "e10")
                            s10 = true;
                        if (i.Name == "e11")
                            s11 = true;

                    }
                }

            }
            foreach (Control i in this.Controls)
            {
                foreach (Control y in this.Controls)
                    if(i.Tag=="bullete" && y.Tag=="bullet")
                     if(   i.Bounds.IntersectsWith(y.Bounds))
                            {
                    this.Controls.Remove(i);
                    this.Controls.Remove(y);
                            }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int r;
            Random rdn = new Random();
            r = rdn.Next(1, 12);
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "enemy")
                    switch (r)
                    {
                        case 1:
                            if (s1 == false)
                                makeBullete(e1);
                            r = rdn.Next(1, 12);
                            break;
                        case 2:
                            if (s2 == false)
                                makeBullete(e2);
                            r = rdn.Next(1, 12);
                            break;
                        case 3:
                            if (s3 == false)
                                makeBullete(e3);
                            r = rdn.Next(1, 12);
                            break;
                        case 4:
                            if (s4 == false)
                                makeBullete(e4);
                            r = rdn.Next(1, 12);
                            break;
                        case 5:
                            if (s5 == false)
                                makeBullete(e5);
                            r = rdn.Next(1, 12);
                            break;
                        case 6:
                            if (s6 == false)
                                makeBullete(e6);
                            r = rdn.Next(1, 12);
                            break;
                        case 7:
                            if (s7 == false)
                                makeBullete(e7);
                            r = rdn.Next(1, 12);
                            break;
                        case 8:
                            if (s8 == false)
                                makeBullete(e8);
                            r = rdn.Next(1, 12);
                            break;
                        case 9:
                            if (s9 == false)
                                makeBullete(e9);
                            r = rdn.Next(1, 12);
                            break;
                        case 10:
                            if (s10 == false)
                                makeBullete(e10);
                            r = rdn.Next(1, 12);
                            break;
                        case 11:
                            if (s11 == false)
                                makeBullete(e11);
                            r = rdn.Next(1, 12);
                            break;
                    }
                break;
            }
        }
        private void makeBullete(Control x)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bomb2;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Transparent;
            bullet.Size = new Size(20, 20);
            bullet.Tag = "bullete";
            bullet.Left = x.Left + x.Width / 2;
            bullet.Top = x.Top + 55;
            this.Controls.Add(bullet);
            bullet.BringToFront();
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
    }
}