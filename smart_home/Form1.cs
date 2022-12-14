using MySql.Data.MySqlClient;
using smart_home.Controllers;
using smart_home.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace smart_home
{
    public partial class form1 : Form
    {
        Form2 form2;
        Form3 form3;
        Panel myPanel;
        Panel b;
        PictureBox s;
        private Control activeControle;
        List<Panel> panels = new List<Panel>();
        private static int nbrPanel = 1;
        private Point previousPoint;
        private List<Device> deviceList;
        public string nameDevice = "aa";
        List<Zone> list;
        int dev;

        public form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
            form3 = new Form3(this);
            ComboBox_Load();
        }

        void b_Click(object sender, EventArgs e)
        {
            b = sender as Panel;
            if (b != null)
            {
                button4.Visible = true;
                pictureBox1.Visible = true;
                nameDevice = b.Name;

                Panel p = panels.Find(r => r.Name == nameDevice);

                /*if (p != null)
                    MessageBox.Show(p.Name);
                else
                    MessageBox.Show("null");*/

                dev = DeviceController.getStatus(nameDevice);
                if (dev == 0)
                {
                    pictureBox1.Image = Properties.Resources.icons8_off_94;
                    pictureBox1.Name = "off";
                }
                else if (dev == 1)
                {
                    pictureBox1.Image = Properties.Resources.icons8_on_94;
                    pictureBox1.Name = "on";

                }
                else
                {
                    MessageBox.Show("erreur ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void myPanel_MMouseUp(object sender, MouseEventArgs e)
        {
            activeControle = null;
            ActiveControl = null;
            Cursor = Cursors.Default;
        }

        private void myPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControle == null || activeControle != sender)
            {
                return;
            }
            var location = activeControle.Location;
            location.Offset(e.Location.X - previousPoint.X, e.Location.Y - previousPoint.Y);
            activeControle.Location = location;
        }

        private void myPanel_MouseDown(object sender, MouseEventArgs e)
        {
            activeControle = sender as Control;
            previousPoint = e.Location;
            Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            try
            {
                pictureBox.Image = Image.FromFile(filePath);
                button1.Visible = false;
            }
            catch
            {  
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!button1.Visible)
            form2.ShowDialog();
            else
                MessageBox.Show("Le plan est vide!!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            Panel p = panels.Find(r => r.Name == nameDevice);
            pictureBox.Controls.Remove(p);
            panels.Remove(p);
            DeviceController.DeleteDevice(nameDevice);
            button4.Visible = false;
        }

        private void changeIconConn(PictureBox b)
        {

            if (b.Name.Contains("connection"))
                b.Image = Properties.Resources.icons8_connected_96;

            else if (b.Name.Contains("descon"))
                b.Image = Properties.Resources.icons8_disconnected_96;

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
                    list.Add(new Zone(Int32.Parse(reader.GetString("id")), reader.GetString("libelle")));
                    comboBox1.Items.Add(reader.GetString("libelle"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void connection_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                Zone zn = list.Find(x => x.Libelle == comboBox1.SelectedItem.ToString());
                int s = ZoneController.getStatus(zn.Id);
                if (s == 0)
                {
                    connection.Image = Properties.Resources.icons8_disconnected_96;
                    DialogResult dialogClose = MessageBox.Show("Vous voulez connecter la zone "+ zn.Libelle + "!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogClose == DialogResult.OK)
                    {
                        
                        ZoneController.Update(zn.Id, 1);
                        changeIconConn(connection);
                        connection.Name = "descon";
                    }
                }
                else
                {
                    connection.Image = Properties.Resources.icons8_connected_96;
                    DialogResult dialogClose = MessageBox.Show("Vous voulez deconnecter cette zone !!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogClose == DialogResult.OK)
                    {
                        ZoneController.Update(zn.Id, 0);
                        DeviceController.UpdateStatus(zn.Id, 0);
                        changeIconConn(connection);
                        connection.Name = "connection";
                    }
                }
            }
            else
            {
                MessageBox.Show("choisi la zone ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                                  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Zone zn = list.Find(x => x.Libelle == comboBox1.SelectedItem.ToString());
                int s = ZoneController.getStatus(zn.Id);
                connection.Visible = true;
                if (s == 0)
                {
                    connection.Image = Properties.Resources.icons8_disconnected_96;
                    connection.Name = "connection";
                }
                else if (s == 1)
                {
                    connection.Image = Properties.Resources.icons8_connected_96;
                    connection.Name = "descon";
                    
                }
                else
                {
                    MessageBox.Show("choisi la zone ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("choisi la zone ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Name == "off")
            {
                DialogResult dialogClose = MessageBox.Show("Vous voules ouvrire cette device !!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogClose == DialogResult.OK)
                {
                    pictureBox1.Name = "on";
                    pictureBox1.Image = Properties.Resources.icons8_on_94;
                    DeviceController.UpdateStatusByName(nameDevice, 1);
                    if (nameDevice.Contains("door"))
                        b.BackgroundImage = Properties.Resources.icons8_open_door_40;
                    else if (nameDevice.Contains("clima"))
                        b.BackgroundImage = Properties.Resources.icons8_air_conditioner_64;
                    else if (b.Name.Contains("light"))
                        b.BackgroundImage = Properties.Resources.icons8_light_on_48;
                    else if (b.Name.Contains("refr"))
                        b.BackgroundImage = Properties.Resources.icons8_fridge_64;
                }
            }
            else if (pictureBox1.Name == "on")
            {
                DialogResult dialogClose = MessageBox.Show("Vous voules arreter cette device !!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogClose == DialogResult.OK)
                {
                    pictureBox1.Name = "off";
                    pictureBox1.Image = Properties.Resources.icons8_off_94;
                    DeviceController.UpdateStatusByName(nameDevice, 0);
                   
                    if (b.Name.Contains("door")) b.BackgroundImage = Properties.Resources.icons8_door_closed_40;
                    else if (b.Name.Contains("clima")) b.BackgroundImage = Properties.Resources.icons8_air_conditioner_64_off;
                    else if (b.Name.Contains("light")) b.BackgroundImage = Properties.Resources.icons8_light_off_80;
                    else if (b.Name.Contains("refr")) b.BackgroundImage = Properties.Resources.icons8_fridge_64__1_;

                }
            }
        }

        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pictureBox_DragLeave(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {
            pictureBox.AllowDrop = true;
        }

        private void clima_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            s = sender as PictureBox;
            if (s != null)
            {
                nameDevice = s.Name;
                //MessageBox.Show(nameDevice);
            }
        }

        private void door_MouseDown(object sender, MouseEventArgs e)
        {
            s = sender as PictureBox;
            if (s != null)
            {
                nameDevice = s.Name;
                //MessageBox.Show(nameDevice);
            }
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            
        }

        private void refr_MouseDown(object sender, MouseEventArgs e)
        {
            s = sender as PictureBox;
            if (s != null)
            {
                nameDevice = s.Name;
                //MessageBox.Show(nameDevice);
            }
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            
        }

        private void light_MouseDown(object sender, MouseEventArgs e)
        {
            s = sender as PictureBox;
            if (s != null)
            {
                nameDevice = s.Name;
                //MessageBox.Show(nameDevice);
            }
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
            
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!button1.Visible)
            {
                
                    Image getPic = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                    myPanel = new Panel();
                    form3.Name = nameDevice;
                    form3.ShowDialog();
                    myPanel.Name = form3.Nom;
                    myPanel.Location = new Point(300, 200);
                    myPanel.Size = new Size(48, 48);
                    myPanel.BackColor = Color.Transparent;
                    myPanel.Click += b_Click;
                    myPanel.BackgroundImage = getPic;
                    myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                    myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
                    myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
                    myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
                    pictureBox.Controls.Add(myPanel);
                    myPanel.Cursor = Cursors.Hand;
                    panels.Add(myPanel);
                
            }
            else
                MessageBox.Show("Le plan est vide!!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
