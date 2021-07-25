using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Bomberman
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            string result = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "path.txt"));

            WebRequest req = WebRequest.Create(result);

            using (var response = req.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(str);
                }
            }

             
            label4.Text = "First at 5 wins." + "\r\n" + "Player1 movement: left and right \r\narrows" + "\r\n" + "Player1 shooting: up arrow"+ "\r\n"+
                "Player2 movement: A and D " + "\r\n" + "Player2 shooting: W"
                ;
            label5.Text = "Use arrows to move left and right" + "\r\n" + "Shoot with space" + "\r\n" + "Beware of enemies";
        }

  

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 OpenForm = new Form1();
            OpenForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
