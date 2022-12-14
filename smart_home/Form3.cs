using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using smart_home.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace smart_home
{
    public partial class Form3 : Form
    {
        private readonly form1 _prunt;
        //form1 form = new form1();
        List<Zone> list;
        private string nom;

        public string Nom { get => nom; set => nom = value; }

        public Form3(form1 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
            ComboBox_Load();
            //form = new form1();
        }

        private void ComboBox_Load()
        {
            list = new List<Zone>();
            try
            {
                string sql = "datasource=localhost;port=3306;username=root;password=;database=smarthome";
                MySqlConnection conn = new MySqlConnection(sql);

                string selectQuery = "SELECT * FROM zone";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //MessageBox.Show(reader.GetString("libelle"));
                    list.Add(new Zone(Int32.Parse(reader.GetString("id")), reader.GetString("libelle")));
                    comboBox1.Items.Add(reader.GetString("libelle"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Showl(_prunt.Name);
            DateTime theDate = DateTime.Now;

            Nom = Name + theDate.ToString("yyyy-MM-dd H:mm:ss");
            //MessageBox.Show(Nom);
            if (comboBox1.SelectedItem != null)
            {
                Zone zn = list.Find(x => x.Libelle == comboBox1.SelectedItem.ToString());
                DeviceController.Ajouter(textBox1.Text, Nom, zn.Id, theDate);
                textBox1.Clear();
                Close();
            }
            else
            {
                MessageBox.Show("choisi la zone ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
