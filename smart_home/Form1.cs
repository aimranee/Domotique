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
        private Control activeControle;
        List<Panel> panels = new List<Panel>();
        private CheckBox check;
        //private static int nbrPanel = 1;
        private Point previousPoint;
        private List<Device> deviceList;
        private string nameDevice;
        List<Zone> list;
        public form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
            form3 = new Form3(this);
            initDevice();
            ComboBox_Load();
        }

        private void initDevice()
        {
            deviceList = DeviceController.afficher();
            /*foreach (Device item in deviceList)
            {
                //MessageBox.Show(item.X1.ToString());
                myPanel = new Panel();
                myPanel.Location = new Point(item.X1, item.Y1);
                myPanel.Size = new Size(64, 64);
                //myPanel.Text = (panelN).ToString();
                myPanel.Name = item.Nom;
                myPanel.BackColor = Color.Transparent;
                myPanel.Click += b_Click;
                //changeIcon(myPanel, item.Status);
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
                myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
                myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
                pictureBox.Controls.Add(myPanel);
                //panelN++;
            }*/
        }
        /*private void initFridge()
        {
            myPanel = new Panel();
            myPanel.Location = new Point(530, 500);
            myPanel.Size = new Size(64, 64);
            //myPanel.Text = (panelN).ToString();
            myPanel.Name = string.Format("Fridge1");
            myPanel.BackColor = Color.Transparent;
            myPanel.Click += b_Click;
            //myPanel.BackgroundImage = Properties.Resources.fridge;
            myPanel.BackgroundImageLayout = ImageLayout.Stretch;
            myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
            myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
            myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
            pictureBox.Controls.Add(myPanel);

        }*/
        /*private void initExitSwitch()
        {
            panel7.Click += ExitSwitch;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            if (!button1.Visible)
            {
                //form3.ShowDialog(myPanel.Name);
                //DialogResult res = form3.ShowDialog();

                /*if (res == DialogResult.OK)
                {*/
                form3.ShowDialog();
                
                //nbrPanel++;
                myPanel = new Panel();
                if (checkBox1.Checked)
                {
                    check = checkBox1;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    myPanel.Name = form3.Nom;
                }
                else if (checkBox2.Checked)
                {
                    check = checkBox2;
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    myPanel.Name = form3.Nom;
                }
                else if (checkBox3.Checked)
                {
                    check = checkBox3;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox4.Checked = false;
                    myPanel.Name = form3.Nom;
                }
                else if (checkBox4.Checked)
                {
                    check = checkBox4;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    myPanel.Name = form3.Nom;
                }

                myPanel.Location = new Point(300, 200);
                myPanel.Size = new Size(48, 48);
                //myPanel.Text = (nbrPanel).ToString();
                myPanel.BackColor = Color.Transparent;
                myPanel.Click += b_Click;
                myPanel.BackgroundImage = check.Image;
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
                myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
                myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
                pictureBox.Controls.Add(myPanel);
                myPanel.Cursor = Cursors.Hand;
                panels.Add(myPanel);

                //removeButton.Enabled = true;
                //}
            }
            else
                MessageBox.Show("Le plan est vide!!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        void b_Click(object sender, EventArgs e)
        {
            b = sender as Panel;
            if (b != null)
            {
                button4.Visible = true;
                MessageBox.Show(b.Name);
                nameDevice = b.Name;
                /*try
                {
                    string sql = "datasource=localhost;port=3306;username=root;password=;database=smarthome";
                    MySqlConnection conn = new MySqlConnection(sql);

                    string selectQuery = "SELECT * FROM device WHERE nom = '" + form3.Nom + "'";
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //MessageBox.Show(reader.GetString("libelle"));
                        //comboBox1.Items.Add(reader.GetString("libelle"));
                        button4.Visible = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }/*
                //MessageBox.Show(b.Name);
                //bool exist = homeService.AfficherParIndex(int.Parse(b.Text));
                /*if (exist == false)
                    panel6.Visible = true;
                else
                    checkStatus(b);*/
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox4.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
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
            DeviceController.DeleteDevice(nameDevice);
            MessageBox.Show(panels.Count().ToString());
/*            if (pictureBox.Controls.Count == deviceList.Count()) button4.Visible = false;
*/            //pictureBox.Controls.Remove(panels.Last());

            
            //DeviceController.DeleteDevice(form3.Nom);
            Panel p = panels.Find(r => r.Name == nameDevice);
            MessageBox.Show(p.Name);
            pictureBox.Controls.Remove(p);
            panels.Remove(p);
            MessageBox.Show(panels.Count().ToString());

            /*panels.RemoveAt(nbrPanel - deviceList.Count());
            nbrPanel--;*/
            button4.Visible = false;
        }

        private void changeIconConn(PictureBox b)
        {

            if (b.Name.Contains("connection"))
                b.Image = Properties.Resources.icons8_disconnected_96;

            else if (b.Name.Contains("descon"))
                b.Image = Properties.Resources.icons8_connected_96;

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

        private void connection_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                Zone zn = list.Find(x => x.Libelle == comboBox1.SelectedItem.ToString());
                int s = ZoneController.getStatus(zn.Id);
                if (s == 0)
                {
                    connection.Image = Properties.Resources.icons8_connected_96;
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
                    connection.Image = Properties.Resources.icons8_disconnected_96;
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
                    connection.Image = Properties.Resources.icons8_connected_96;
                    connection.Name = "connection";
                }
                else if (s == 1)
                {
                    connection.Image = Properties.Resources.icons8_disconnected_96;
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
    }
}
