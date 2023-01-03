using MySql.Data.MySqlClient;
using smart_home.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Runtime.CompilerServices;
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

        public static void Ajouter(string libelle, string nom, int x, int y, int w, int h)
        {
            DateTime theDate = DateTime.Now;
            theDate.ToString("yyyy-MM-dd H:mm:ss");
            MySqlConnection conn = GetConnection();
            string LoadData = "insert into zone(libelle,nom,x,y,w,h,dateCreation,dateUpdate) values('" + libelle + "','" + nom +"','" + x +"','" + y +"','" + w +"','" + h +"','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "');";
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

        public static int getStatus(string s)
        {
            int n = 2;
            string sql = "SELECT status FROM zone WHERE nom = '"+ s +"'";
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
                MessageBox.Show("Erreur.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return n;
        }

        public static List<Zone> afficher()
        {
            List<Zone> zoneList = new List<Zone>();
            string sql = "SELECT * from zone";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    zoneList.Add(new Zone(int.Parse(reader["id"].ToString()), reader["libelle"].ToString(), reader["nom"].ToString(), int.Parse(reader["status"].ToString()), int.Parse(reader["x"].ToString()), int.Parse(reader["y"].ToString()), int.Parse(reader["w"].ToString()), int.Parse(reader["h"].ToString())));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Device not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
            return zoneList;
        }

        public static Zone getIdByName(int id)
        {
            Zone d = null;
            string sql = "SELECT * FROM zone WHERE id = '" + id + "'";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d = new Zone (Int32.Parse(reader.GetString("id")), reader.GetString("libelle"), reader.GetString("nom"), Int32.Parse(reader.GetString("x")), Int32.Parse(reader.GetString("y")), Int32.Parse(reader.GetString("w")), Int32.Parse(reader.GetString("h")), Int32.Parse(reader.GetString("status")));
                }
            }
            catch
            {
                MessageBox.Show("La zone n'est pas modifie.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return d;
        }
    }
}
