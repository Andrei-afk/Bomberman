using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Bomberman.Connection
{
    class ServerConnection
    {
        public static string stringConnection = "Data Source = DESKTOP-PS8VUKL; Initial Catalog=Bomberman; Integrated Security=True";

        public static DataTable executeSQL(string sql)
        {
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                connection.ConnectionString = stringConnection;
                connection.Open();


                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);

                connection.Close();
                connection = null;
                return dt;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database connection error" + ex);
                dt = null; 
            }
            return dt;
        }

    }
}
