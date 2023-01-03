namespace smart_home
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.light = new System.Windows.Forms.PictureBox();
            this.refr = new System.Windows.Forms.PictureBox();
            this.clima = new System.Windows.Forms.PictureBox();
            this.door = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.connection = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.light)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.light);
            this.panel1.Controls.Add(this.refr);
            this.panel1.Controls.Add(this.clima);
            this.panel1.Controls.Add(this.door);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 256);
            this.panel1.TabIndex = 0;
            // 
            // light
            // 
            this.light.Cursor = System.Windows.Forms.Cursors.Hand;
            this.light.Image = global::smart_home.Properties.Resources.icons8_light_on_48;
            this.light.Location = new System.Drawing.Point(144, 91);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(64, 64);
            this.light.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.light.TabIndex = 19;
            this.light.TabStop = false;
            this.light.MouseDown += new System.Windows.Forms.MouseEventHandler(this.light_MouseDown);
            // 
            // refr
            // 
            this.refr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refr.Image = global::smart_home.Properties.Resources.icons8_fridge_64;
            this.refr.Location = new System.Drawing.Point(46, 91);
            this.refr.Name = "refr";
            this.refr.Size = new System.Drawing.Size(64, 64);
            this.refr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.refr.TabIndex = 18;
            this.refr.TabStop = false;
            this.refr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.refr_MouseDown);
            // 
            // clima
            // 
            this.clima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clima.Image = global::smart_home.Properties.Resources.icons8_air_conditioner_64;
            this.clima.Location = new System.Drawing.Point(46, 9);
            this.clima.Name = "clima";
            this.clima.Size = new System.Drawing.Size(64, 64);
            this.clima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.clima.TabIndex = 17;
            this.clima.TabStop = false;
            this.clima.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clima_MouseDown);
            // 
            // door
            // 
            this.door.Cursor = System.Windows.Forms.Cursors.Hand;
            this.door.Image = global::smart_home.Properties.Resources.icons8_open_door_40;
            this.door.Location = new System.Drawing.Point(144, 9);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(64, 64);
            this.door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.door.TabIndex = 16;
            this.door.TabStop = false;
            this.door.MouseDown += new System.Windows.Forms.MouseEventHandler(this.door_MouseDown);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 181);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Enregistre";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 181);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Supprimer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(211, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Ajouter zones";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(694, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(12, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 119);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::smart_home.Properties.Resources.icons8_on_94;
            this.pictureBox1.Location = new System.Drawing.Point(103, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.connection);
            this.panel3.Location = new System.Drawing.Point(12, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(271, 145);
            this.panel3.TabIndex = 5;
            // 
            // connection
            // 
            this.connection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connection.Image = global::smart_home.Properties.Resources.icons8_connected_96;
            this.connection.Location = new System.Drawing.Point(95, 34);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(69, 67);
            this.connection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.connection.TabIndex = 1;
            this.connection.TabStop = false;
            this.connection.Visible = false;
            this.connection.Click += new System.EventHandler(this.connection_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(315, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(811, 532);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 569);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.light)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox connection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox light;
        private System.Windows.Forms.PictureBox refr;
        private System.Windows.Forms.PictureBox clima;
        private System.Windows.Forms.PictureBox door;
    }
}

