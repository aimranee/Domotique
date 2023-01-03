using MySql.Data.MySqlClient;
using smart_home.Controllers;
using smart_home.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace smart_home
{
    public partial class form1 : Form
    {
        Form2 form2;
        Form3 form3;
        Form4 form4;
        Panel myPanel;
        Panel b;
        
        enum DrawKind { RESIZABLERECTANGLE };
        PictureBox s;
        private Control activeControle;
        List<Panel> panels = new List<Panel>();
        List<PictureBox> zones = new List<PictureBox>();
        private static int nbrPanel = 1;
        private static int nbrZone = 1;
        private Point previousPoint;
        private List<Device> deviceList;
        private List<Zone> zoneList;
        public string nameDevice = "null";
        public string nameZone = "null";
        int dev;
        private int x, y;
        bool flagMouseDown = false;
        int x1, y1, x2, y2;
        Bitmap bmp1;
        //List<Zone> list;
        Graphics g;
        //DrawKind drawkind = DrawKind.RESIZABLERECTANGLE;
        Pen pen;

        public form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
            form3 = new Form3(this);
            form4 = new Form4(this);
            
        }

        private void initCapt()
        {
            deviceList = DeviceController.afficher();
            foreach (Device item in deviceList)
            {
                myPanel = new Panel();
                myPanel.Location = new Point(item.X, item.Y);
                myPanel.Size = new Size(64, 64);
                myPanel.Text = (nbrPanel).ToString();
                myPanel.Name = item.Nom;
                myPanel.BackColor = Color.Transparent;
                //myPanel.Paint += new PaintEventHandler(myPanel_Paint);
                myPanel.Click += b_Click;
                if (item.Status == 0)
                {
                    pictureBox1.Name = "off";
                    pictureBox1.Image = Properties.Resources.icons8_off_94;

                    if (item.Nom.Contains("door")) myPanel.BackgroundImage = Properties.Resources.icons8_door_closed_40;
                    else if (item.Nom.Contains("clima")) myPanel.BackgroundImage = Properties.Resources.icons8_air_conditioner_64_off;
                    else if (item.Nom.Contains("light")) myPanel.BackgroundImage = Properties.Resources.icons8_light_off_80;
                    else if (item.Nom.Contains("refr")) myPanel.BackgroundImage = Properties.Resources.icons8_fridge_64__1_;
                } else {
                    pictureBox1.Name = "on";
                    pictureBox1.Image = Properties.Resources.icons8_on_94;

                    if (nameDevice.Contains("door")) myPanel.BackgroundImage = Properties.Resources.icons8_open_door_40;
                    else if (nameDevice.Contains("clima")) myPanel.BackgroundImage = Properties.Resources.icons8_air_conditioner_64;
                    else if (item.Nom.Contains("light")) myPanel.BackgroundImage = Properties.Resources.icons8_light_on_48;
                    else if (item.Nom.Contains("refr")) myPanel.BackgroundImage = Properties.Resources.icons8_fridge_64;
                }
                //changeIcon(myPanel, item.Status);
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
                myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
                myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
                pictureBox.Controls.Add(myPanel);
                nbrPanel++;
            }
        }

        private void initZone()
        {
            zoneList = ZoneController.afficher();
            foreach (Zone item in zoneList)
            {
                s = new PictureBox();
                s.Location = new Point(item.Y, item.X);
                s.Size = new Size(item.H, item.W);
                //myPanel.Text = (nbrZone).ToString();
                s.Name = item.Nom;
                s.BackColor = Color.Transparent;
                s.BorderStyle = BorderStyle.FixedSingle;
                s.Click += s_Click;
                /*if (item.Status == 0)
                {
                    connection.Image = Properties.Resources.icons8_connected_96;
                    connection.Name = "descon";
                }
                else
                {
                    connection.Image = Properties.Resources.icons8_disconnected_96;
                    connection.Name = "connection";

                }*/
                s.DragDrop += new DragEventHandler(panel_DragDrop);
                s.DragEnter += new DragEventHandler(panel_DragEnter);
                s.DragOver += new DragEventHandler(panel_DragLeave);
                s.AllowDrop = true;
                pictureBox.Controls.Add(s);
                nbrZone++;
            }
        }

        void s_Click(object sender, EventArgs e)
        {
            s = sender as PictureBox;
            if (s != null)
            {
                connection.Visible = true;
                //pictureBox1.Visible = true;
                nameZone = s.Name;
                PictureBox p = zones.Find(r => r.Name == nameZone);

                /*if (p != null)
                    MessageBox.Show(p.Name);
                else
                    MessageBox.Show("null");*/
                
                dev = ZoneController.getStatus(nameZone);

                if (dev == 0)
                {
                    pictureBox1.Image = Properties.Resources.icons8_connected_96;
                    pictureBox1.Name = "connection";
                }
                else if (dev == 1)
                {
                    pictureBox1.Image = Properties.Resources.icons8_disconnected_96;
                    pictureBox1.Name = "descon";

                }
                else
                {
                    MessageBox.Show("erreur ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            x = activeControle.Location.X;
            y = activeControle.Location.Y;
        }

        private void myPanel_MouseDown(object sender, MouseEventArgs e)
        {
            activeControle = sender as Control;
            previousPoint = e.Location;
            Cursor = Cursors.Hand;
            button5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            try
            {
                pictureBox.Image = Image.FromFile(filePath);
                button1.Visible = false;
                //initZone();
                //initCapt();
                
            }
            catch
            {  
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
             //if (!button1.Visible && !button5.Visible)
            //{
                button3.Enabled = false;

            //}
            //form2.ShowDialog();
            //else
              //  MessageBox.Show("Le plan est vide!!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        

        private void connection_Click(object sender, EventArgs e)
        {

                Zone zn = zoneList.Find(x => x.Nom == nameZone);
                int s = ZoneController.getStatus(zn.Nom);
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

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
           // MessageBox.Show("heerre");
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel_DragLeave(object sender, EventArgs e)
        {

        }

        private void form1_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
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

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            if (!button1.Visible && !button5.Visible)
            {
                
                Image getPic = (Bitmap)e.Data.GetData(DataFormats.Bitmap);

                myPanel = new Panel();
                form3.Name = nameDevice;
                form3.NomZ = nameZone;
                form3.ShowDialog();
                
                myPanel.Name = form3.Nom;
                myPanel.Location = new Point(0,0);
                myPanel.Size = new Size(48, 48);
                myPanel.BackColor = Color.Transparent;
                myPanel.Click += b_Click;
                myPanel.BackgroundImage = getPic;
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                myPanel.MouseDown += new MouseEventHandler(myPanel_MouseDown);
                myPanel.MouseMove += new MouseEventHandler(myPanel_MouseMove);
                myPanel.MouseUp += new MouseEventHandler(myPanel_MMouseUp);
                PictureBox p = zones.Find(r => r.Name == form3.Zn.Nom);
                p.Controls.Add(myPanel);
                myPanel.Cursor = Cursors.Hand;
                panels.Add(myPanel);
                button5.Visible = true;
            }
            else
              MessageBox.Show("Le plan est vide!!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!button3.Enabled)
            {
                x1 = e.X;
                y1 = e.Y;
                flagMouseDown = true;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!button3.Enabled)
            {
                if (flagMouseDown == true)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    pictureBox.Refresh();

                    bmp1 = new Bitmap(pictureBox.Image);
                    g = Graphics.FromImage(bmp1);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!button3.Enabled)
            {
                bmp1 = new Bitmap(pictureBox.Image);
                g = Graphics.FromImage(bmp1);
                s = new PictureBox();
                int w, h;

                w = Math.Abs(x2 - x1);
                h = Math.Abs(y2 - y1);

                //MessageBox.Show(w + "  " + h);

                g.DrawRectangle(pen, x1, y1, w, h);
                pictureBox.Image = bmp1;

                g.Dispose();
                pictureBox.Image = bmp1;
                flagMouseDown = false;
                pictureBox.Cursor = Cursors.Default;
                form4.X = x1;
                form4.Y = y1;
                form4.W = w;
                form4.H = h;
                form4.ShowDialog();
                
                //form3.Name = nameDevice;
                //form3.ShowDialog();
                s.Name = form4.Nom;
                s.Location = new Point(form4.X, form4.Y);
                //MessageBox.Show(form4.X + "    " + form4.Y);
                s.Size = new Size(w, h);
                s.BackColor = Color.Transparent;
                s.Click += s_Click;
                s.BorderStyle = BorderStyle.Fixed3D;
                s.DragDrop += new DragEventHandler(panel_DragDrop);
                s.DragEnter += new DragEventHandler(panel_DragEnter);
                s.DragLeave += new EventHandler(panel_DragLeave);
                s.AllowDrop = true;
                pictureBox.Controls.Add(s);
                s.Cursor = Cursors.Hand;
                nbrZone++;
                zones.Add(s);
                //zoneList.Add(form4.Z);
                form3.ComboBox_Load();
                button3.Enabled = true;
                
            }

        }

        /*private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            
        }*/

        private void button5_Click(object sender, EventArgs e)
        {
            Point locationOnForm = b.FindForm().PointToClient(b.Parent.PointToScreen(b.Location));

            DialogResult dialogClose = MessageBox.Show("Do you Want To Add This " + b.Name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogClose == DialogResult.OK)
            {
                //MessageBox.Show((x) + "  " + (y));
                DeviceController.UpdateLocation(x, y, b.Name);
                button5.Visible = false;
            }
            else if (dialogClose == DialogResult.Cancel)
            {
                pictureBox.Controls.Remove(panels.Last());
                panels.RemoveAt(nbrPanel - 2);
                nbrPanel--;
                button5.Visible = false;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!button1.Visible)
            {
                if (flagMouseDown == true)
                {
                    int w, h;
                    w = Math.Abs(x2 - x1);
                    h = Math.Abs(y2 - y1);
                    
                    e.Graphics.DrawRectangle(pen, x1, y1, w, h);
                    
                }
            }
            
        }

        private void myPanel_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            Point[] points = new Point[4];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, p.Height);
            points[2] = new Point(p.Width, p.Height);
            points[3] = new Point(p.Width, 0);

            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);
        }
    }
}
