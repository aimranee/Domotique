using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Windows.Forms;

namespace smart_home.Controllers
{
    class ZoneController
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=smarthome";
            MySqlConnection conn = new MySqlConnection(sql);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Can not open connection ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static void Ajouter(string libelle)
        {
            DateTime theDate = DateTime.Now;
            theDate.ToString("yyyy-MM-dd H:mm:ss");
            MySqlConnection conn = GetConnection();
            string LoadData = "insert into zone(libelle,dateCreation,dateUpdate) values('" + libelle + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "');";
            MySqlCommand cmd = new MySqlCommand(LoadData, conn);
            try
            {
                cmd.ExecuteNonQuery();
/*              MessageBox.Show("La client est ajouté aves succés.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("La zone n'est pas ajouté ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
        public static void Update(int id, int st)
        {
            string sql = "UPDATE zone SET status = "+ st + " WHERE id = "+id;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Le zone est modifie avec success.", "InformationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("La zone n'est pas modifie.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static int getStatus(int id)
        {
            int n = 2;
            string sql = "SELECT status FROM zone WHERE id = "+id;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    n = Int32.Parse(reader.GetString("status"));
                }
            }catch{
                MessageBox.Show("La zone n'est pas modifie.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return n;
        }

    }
}
