using MySql.Data.MySqlClient;
using smart_home.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smart_home.Controllers
{
    class DeviceController
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

        public static void Ajouter(string libelle, int zoneId, DateTime theDate, int x, int y)
        {
            
            MySqlConnection conn = GetConnection();
            string LoadData = "insert into device(libelle,zoneId,x,y,nom,dateCreation,dateUpdate) values ('" + libelle + "','" + zoneId + "','" + x + "','" + y +"','" + (libelle + theDate.ToString("yyyy-MM-dd H:mm:ss")) + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "','" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "');";
            MySqlCommand cmd = new MySqlCommand(LoadData, conn);
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Le device est ajouté aves succés.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Le device n'est pas ajouté ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeleteDevice(string nom)
        {
            string sql = "DELETE FROM device WHERE nom = @nom";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = nom;
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Deleted Successfully", "InformationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Device not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static List<Device> afficher()
        {
            List<Device> deviceList = new List<Device>();
            string sql = "SELECT * from device";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    deviceList.Add(new Device(int.Parse(reader["id"].ToString()), reader["libelle"].ToString(), reader["nom"].ToString(), int.Parse(reader["statut"].ToString()), int.Parse(reader["zoneId"].ToString()), int.Parse(reader["x"].ToString()), int.Parse(reader["y"].ToString())));              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Device not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
            return deviceList;
        }

        public static void UpdateStatus(int id, int st)
        {
            string sql = "UPDATE device SET statut = " + st + " WHERE zoneId = " + id;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Le device est modifie avec success.", "InformationError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("La device n'est pas modifie.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
