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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();


        }
       public static string a1, a2;


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(p1n.Text) && !string.IsNullOrEmpty(p2n.Text))
            {
                bool n1 = true;
                bool n2 = true;

                string p1 = "Select Pl1name from bbm where Pl1name = '" + p1n.Text + "'";
                string p2 = "Select Pl2name from bbm where Pl2name = '" + p2n.Text + "'";
                DataTable checkDuplicates1 = Bomberman.Connection.ServerConnection.executeSQL(p1);
                DataTable checkDuplicates2 = Bomberman.Connection.ServerConnection.executeSQL(p2);
                if (checkDuplicates1.Rows.Count > 0)
                {
                    MessageBox.Show("Player1 name already used. Try anotherone");
                    n1 = false;
                }
                else
                    n1 = true;


                if (checkDuplicates2.Rows.Count > 0)
                {
                    MessageBox.Show("Player2 name already used. Try anotherone");
                    n2 = false;
                }
                else
                    n2 = true;
                if (n1 && n2)
                {
                    string sql = string.Empty;
                    string sql2 = string.Empty;
                    sql += "INSERT INTO bbm (Pl1name,Pl2name) VALUES('" + p1n.Text + "','" + p2n.Text + "')";
                   

                    a1 = p1n.Text;
                    a2 = p2n.Text;
                  

                    Bomberman.Connection.ServerConnection.executeSQL(sql);
                    this.Hide();
                    Form3 OpenForm = new Form3();
                    OpenForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Insert players name!");
            }

/*

            ;*/
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadUserData();
            p1n.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 OpenForm = new Form1();
            OpenForm.Show();
        }

        private void loadUserData()
        {
            DataTable userData = ServerConnection.executeSQL("Select Pl1name , Pl1score, Pl2score, Pl2name from bbm");
            
            dataGridView1.DataSource = userData;
            dataGridView1.Columns[0].Width = 128;
            dataGridView1.Columns[1].Width = 128;
            dataGridView1.Columns[2].Width = 128;
            dataGridView1.Columns[3].Width = 128;
             dataGridView1.Columns[0].HeaderText = "Player1 Name";
            dataGridView1.Columns[1].HeaderText = "Player1 Score";
            dataGridView1.Columns[2].HeaderText = "Player2 SCore";
            dataGridView1.Columns[3].HeaderText = "Player2 Name";

                    }
    }
}
