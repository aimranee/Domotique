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

namespace smart_home
{
    public partial class Form2 : Form
    {
        private readonly form1 _prunt;
        TextBox textBox;
        Label label;
        private int nbrBox;
        Panel panel1 = new Panel();
        List<TextBox> textBoxs = new List<TextBox>();
        List<Label> labels = new List<Label>();
        Point p;
        Size s;

        public Form2(form1 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nbrBox = Int32.Parse(nbrZone.Text);

            panel1.Controls.Clear();
            p = new Point(250, 20);
            s = new Size(150, 20);
            //ScrollBar vScrollBar1 = new VScrollBar();
            //vScrollBar1.Dock = DockStyle.Right;
            //vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            //panel1.Controls.Add(vScrollBar1);
            panel1.Name = "panel1";
            panel1.Location = new Point(10, 100);
            panel1.Size = new Size (510, 223);
            panel2.Controls.Add(panel1);
            for (int i = 1; i <= nbrBox; i++)
            {
                label = new Label();
                label.Name = String.Format("label{0}", i);
                label.Location = new Point(100, p.Y);
                label.Text = String.Format("Zone {0}", i);
                label.Size = new Size(120, 17);
                panel1.Controls.Add(label);
                labels.Add(label);

                textBox = new TextBox();
                textBox.Name = String.Format("textBox{0}", i);
                textBox.Location = p;
                p.Y = p.Y + 40;
                textBox.Size = s;
                panel1.Controls.Add(textBox);
                textBoxs.Add(textBox);
            }
            Button btn1 = new Button();
            btn1.Text = "Enregistrer";
            btn1.Name = "btn1";
            btn1.Location = new Point (237, p.Y);
            btn1.Size = new Size(75, 23);
            btn1.Click += btn1_click;
            panel1.Controls.Add(btn1);
            
        }
        private void btn1_click(object sender, EventArgs e)
        {
            int n = 0;
            for (int i = 0; i <= textBoxs.Count-1; i++)
            {
                if (!string.IsNullOrEmpty(textBoxs[i].Text))
                {
                    //MessageBox.Show(DateTime.Now.ToString("dd/MM/yyyy"));
                    ZoneController.Ajouter(textBoxs[i].Text);
                    n++;
                }
            }
            
            MessageBox.Show("Nombre des zone bien ajouter est : "+n, "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        

        }
    }
}
