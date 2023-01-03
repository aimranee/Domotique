using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using smart_home.Controllers;
using smart_home.Models;
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
        private Zone zn;
        private string nom;
        private string nomZ;
        List<Zone> list;

        public string Nom { get => nom; set => nom = value; }
        public string NomZ { get => nomZ; set => nomZ = value; }
        internal Zone Zn { get => zn; set => zn = value; }

        public Form3(form1 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
            ComboBox_Load();
        }

        public void ComboBox_Load()
        {
            list = ZoneController.afficher();
            foreach (Zone item in list)
            {
                
                comboBox1.Items.Add(item.Libelle);
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Showl(_prunt.Name);
            DateTime theDate = DateTime.Now;

            Nom = Name + theDate.ToString("yyyy-MM-dd H:mm:ss");
            //MessageBox.Show(Nom);
            
            //Zn = ZoneController.getIdByName(nomZ);
            
            

            if (comboBox1.SelectedItem != null)
            {
                Zone zn = list.Find(x => x.Libelle == comboBox1.SelectedItem.ToString());
                Zn = ZoneController.getIdByName(zn.Id);
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
