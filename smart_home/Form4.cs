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
    public partial class Form4 : Form
    {
        private readonly form1 _prunt;
        //form1 form = new form1();
        private string nom;
        private int x;
        private int y;
        private int w;
        private int h;
        private Zone z;

        public string Nom { get => nom; set => nom = value; }
        public int Y { get => y; set => y = value; }
        public int W { get => w; set => w = value; }
        public int H { get => h; set => h = value; }
        public int X { get => x; set => x = value; }
        internal Zone Z { get => z; set => z = value; }

        public Form4(form1 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Showl(_prunt.Name);
            DateTime theDate = DateTime.Now;

            Nom = "zone"+textBox1.Text + theDate.ToString("yyyy-MM-dd H:mm:ss");
            //MessageBox.Show(Nom);
            Z = new Zone(textBox1.Text, Nom, X, Y, W, H);
            ZoneController.Ajouter(textBox1.Text, Nom, X, Y, W, H);
            textBox1.Clear();
            Close();

        }
    }
}
