using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bomberman.Connection;
namespace Bomberman
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            timer2.Start();
        }
        bool pl, pr, ol, or;
        bool fire1, fire2;
        int ps = 4;
        

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                pr = true;
            else
               if (e.KeyCode == Keys.Left)
                pl = true;
            else
               if (e.KeyCode == Keys.A)
                ol = true;
            else
               if (e.KeyCode == Keys.D)
                or = true;


            if (e.KeyCode == Keys.W && !fire1)
            {
                fire1 = true;
                makeBulleto();

            }

            if (e.KeyCode == Keys.Up && !fire2)
            {
                fire2 = true;
                makeBulletp();
            }
        }
        private void spawn()
        {
            int x, y;
            Random rdn = new Random();
            x = rdn.Next(50, 600);
            y = rdn.Next(100, 140);
            PictureBox ob = new PictureBox();
            ob.Size = new Size(30, 30);
            ob.Location = new Point(x, y);
            ob.Image = Properties.Resources.Untitled_2 ;
            ob.SizeMode = PictureBoxSizeMode.StretchImage;
            ob.Tag = "wall";
            foreach (Control i in this.Controls)
                if (i is PictureBox && i.Tag == "wall")
                    while (i.Bounds.IntersectsWith(ob.Bounds))
                    {
                        x = rdn.Next(50, 600);
                        y = rdn.Next(100, 340);
                        ob.Location = new Point(x, y);
                    }
            this.Controls.Add(ob);
            ob.BringToFront();
        }
        private void Form3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                pr = false;
            else
            if (e.KeyCode == Keys.Left)
                pl = false;
            else
            if (e.KeyCode == Keys.A)
                ol = false;
            else
            if (e.KeyCode == Keys.D)
                or = false;
            if (fire1)
            {
                fire1 = false;
            }

            if (fire2)
            {
                fire2 = false;
            }
        }
        private void ppwin()
        {
            name1 = Form5.a1;
            name2 = Form5.a2;
            timer2.Stop();
            label1.Text = name1+" wins!";
            label1.Visible = true;
            button1.Visible = true;
        }
        private void oowin()
        {
            
            name1 = Form5.a1;
            name2 = Form5.a2;
            timer2.Stop();
            label1.Text = name2+" wins";
            label1.Visible = true;
            button1.Visible = true;
        }
        string name1;
        string name2;
        
        Form5 f = new Form5();
        private void button1_Click(object sender, EventArgs e)
        {

            string sql = string.Empty;

            name1 = Form5.a1;
            name2 = Form5.a2;


            // MessageBox.Show(name1);

                  sql += "UPDATE bbm SET Pl1score='" + pscor.Text + "',Pl2score='" + oscor.Text + "' where Pl1Name='" + name1 + "' and Pl2Name='" + name2 + "'";
                Bomberman.Connection.ServerConnection.executeSQL(sql);
            
               this.Close();
               Form1 OpenForm = new Form1();
               OpenForm.ShowDialog();
            
        }
        private void makeo()
        {
            PictureBox o = new PictureBox();
            o.Size = new Size(50, 50);
            o.Location = new Point(39, 38);
            o.Image = Properties.Resources.tank21;
            o.SizeMode = PictureBoxSizeMode.StretchImage;
            o.Tag = "oo";
            this.Controls.Add(o);
            o.BringToFront();
        }
        private void makep()
        {
            PictureBox p = new PictureBox();
            p.Size = new Size(50, 50);
            p.Location = new Point(595, 376);
            p.Image = Properties.Resources.tank;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Tag = "pp";
            this.Controls.Add(p);
            p.BringToFront();
        }
  
        int ppscore=0;
        int ooscore = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (pr && p.Left < 595)
                p.Left += ps;
            if (pl && p.Left > 50)
                p.Left -= ps;
            if (or && o.Left < 595)
                o.Left += ps;
            if (ol && o.Left > 50)
                o.Left -= ps;

            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bulletp")
                {
                    y.Top -= 10;
                    foreach(Control i in this.Controls)
                        if(i.Tag=="walls")
                            if (i.Bounds.IntersectsWith(y.Bounds))
                                this.Controls.Remove(y);
                }
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bulleto")
                {
                    y.Top += 10;
                    foreach (Control i in this.Controls)
                        if (i.Tag == "walls")
                            if (i.Bounds.IntersectsWith(y.Bounds))
                                this.Controls.Remove(y);
                }
            }
            foreach (Control y in this.Controls)
            {
                foreach (Control i in this.Controls)
                    if (y.Tag == "bulleto" && i.Tag == "bulletp")
                        if (i.Bounds.IntersectsWith(y.Bounds))
                        {
                        this.Controls.Remove(y);
                        this.Controls.Remove(i);
                        }
            }

                foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "oo" && j is PictureBox && j.Tag == "bulletp")
                    {
                        if (i.Bounds.IntersectsWith(j.Bounds))
                        {
                            this.Controls.Remove(j);
                            
                            if (ppscore < 4)
                            {
                                o.Location = new Point(39,38);
                                p.Location = new Point(595,376);
                                ppscore++;
                                pscor.Text = Convert.ToString(ppscore);
                            }
                            else
                            { 
                                 this.Controls.Remove(i);
                                ppscore++;
                                pscor.Text = Convert.ToString(ppscore);
                                ppwin();
                            }
                            
                        }
                    }
                    else
                        if (i is PictureBox && i.Tag == "pp" && j is PictureBox && j.Tag == "bulleto")
                    {
                        if (i.Bounds.IntersectsWith(j.Bounds))
                        {
                            this.Controls.Remove(j);
                            if (ooscore < 4)
                            {
                                o.Location = new Point(39, 38);
                                p.Location = new Point(595, 376);
                                ooscore++;
                                oscor.Text = Convert.ToString(ooscore);
                            }
                            else
                            {
                                this.Controls.Remove(i);
                                ooscore++;
                                oscor.Text = Convert.ToString(ooscore);
                                oowin();
                            }
                           
                        }
                    }
                    if (i is PictureBox && i.Tag == "wall" && j is PictureBox && j.Tag == "bulleto")
                    {
                        if (i.Bounds.IntersectsWith(j.Bounds))
                        {
                            this.Controls.Remove(i);
                            this.Controls.Remove(j);
                        }
                    }
                    if (i is PictureBox && i.Tag == "wall" && j is PictureBox && j.Tag == "bulletp")
                    {
                        if (i.Bounds.IntersectsWith(j.Bounds))
                        {
                            this.Controls.Remove(i);
                            this.Controls.Remove(j);
                        }
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            spawn();
        }
        private void makeBulleto()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bomb2;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Transparent;
            bullet.Size = new Size(20, 20);
            bullet.Tag = "bulleto";
            bullet.Left = o.Left + o.Width / 2;
            bullet.Top = o.Top + 55;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
        private void makeBulletp()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bomb;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Size = new Size(20, 20);
            bullet.BackColor = Color.Transparent;
            bullet.Tag = "bulletp";
            bullet.Left = p.Left + p.Width / 2;
            bullet.Top = p.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
    }
}
