using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1PBO2021
{
    public partial class formHome : Form
    {

        public formHome()
        {
            InitializeComponent();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            formLogin login = new formLogin();
            login.Show();
            this.Hide();
        }
        private Produk[] items;
        public string selectedHarga { set; get; }
        public string selectedJenis { set; get; }
        private void formHome_Load(object sender, EventArgs e)
        {

            // NAV


            Button button_menu = new Button();

            button_menu.Name = "Menu";
            button_menu.Text = "Menu";
            button_menu.Click += new EventHandler(btn_reset_Click);

            button_menu.BackColor = Color.LightGray;
            button_menu.ForeColor = Color.Black;
            flowLayoutPanel2.Controls.Add(button_menu);
            button_menu.Location = new Point(5, 5);
            Label label = addLabel("1909331\nSarah Hanifah\nC1 Ilmu Komputer");
            flowLayoutPanel2.Controls.Add(label);

            LinkLabel hl = new LinkLabel();
            hl.Text = "Web Catalog";
            hl.Links.Add(24, 9, "http://www.shopee.co.id");
            hl.LinkArea = new LinkArea(0, 22);
            hl.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
            flowLayoutPanel2.Controls.Add(hl);
            hl.Location = new Point(label.Location.X - hl.Width - 15, 5);
            Button button = new Button();

            button.Name = "logout";
            button.Text = "Log Out";
            button.Click += new EventHandler(btn_logout_Click);

            button.BackColor = Color.LightGray;
            button.ForeColor = Color.Black;
            flowLayoutPanel2.Controls.Add(button);
            button.Location = new Point(flowLayoutPanel2.Width - button.Width - 5, 5);
            

            items = new Produk[10];

            items[0] = new Produk("Kemeja Hitam", "Pakaian", 167000, "Bahan nyaman dan berkualitas tinggi.");
            items[1] = new Produk("Saus Bulgogi", "Makanan", 27000, "Original dan mudah diolah.");
            items[2] = new Produk("SSD", "Elektronik", 1500000, "Barang original.");
            items[3] = new Produk("Mie Pedas", "Makanan", 20000, "Mie rebus pedas dengan banyak topping.");
            items[4] = new Produk("Jaket", "Pakaian", 149000, "Bahan nyaman, tidak panas dan berkualitas tinggi.");
            items[5] = new Produk("Kopi", "Makanan", 51000, "Kopi enak sekali.");
            items[6] = new Produk("Dress", "Pakaian", 490000, "Bahan berkualitas. Ukuran XS, S, M, L, XL");
            items[7] = new Produk("Headset", "Elektronik", 320000, "Suara yang dihasilkan mantap.");
            items[8] = new Produk("Keju Mozarella", "Makanan", 25000, "Keju asli murah sekali.");
            items[9] = new Produk("Case HP Murah", "Elektronik", 5000, "Case transparant.");

            foreach (var obj in items)
            {
                Panel panel = addPanel(obj.nama, obj.harga, obj.spesifikasi);
                flowLayoutPanel1.Controls.Add(panel);
            }

            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0;
            flowLayoutPanel1.AutoScroll = true;

            // SIDE PANEL

            Label l = new Label();
            l.Text = "Filter :";
            l.Location = new Point(5, 50);
            panel1.Controls.Add(l);

            ComboBox CB = new ComboBox();
            CB.DisplayMember = "Text";
            CB.ValueMember = "Value";
            CB.Items.Add(new { Text = "Makanan", Value = "1" });
            CB.Items.Add(new { Text = "Pakaian", Value = "2" });
            CB.Items.Add(new { Text = "Elektronik", Value = "3" });
            CB.Width = panel1.Width - 10;
            CB.Height = 15;
            panel1.Controls.Add(CB);
            CB.Location = new Point(5, 80);
            CB.SelectedIndexChanged += new EventHandler(CB_Selected);

            ComboBox CB2 = new ComboBox();
            CB2.DisplayMember = "Text";
            CB2.ValueMember = "Value";
            CB2.Items.Add(new { Text = "< 200000", Value = "1" });
            CB2.Items.Add(new { Text = "200000 - 500000", Value = "2" });
            CB2.Items.Add(new { Text = "> 500000", Value = "3" });
            CB2.Width = panel1.Width - 10;
            CB2.Height = 15;
            panel1.Controls.Add(CB2);
            CB2.Location = new Point(5, CB.Location.Y + CB.Height + 10);
            CB2.SelectedIndexChanged += new EventHandler(CB2_Selected);

            Button button2 = new Button();
            button2.Name = "Filter";
            button2.Text = "Filter";
            button2.BackColor = Color.LightGray;
            button2.ForeColor = Color.Black;
            panel1.Controls.Add(button2);
            button2.Location = new Point((panel1.Width - button2.Width) / 2, CB2.Location.Y + CB2.Height + 10);
            button2.Click += new EventHandler(btn_filter_Click);

            Button button3 = new Button();
            button3.Name = "Reset";
            button3.Text = "Reset";
            button3.BackColor = Color.LightGray;
            button3.ForeColor = Color.Black;
            panel1.Controls.Add(button3);
            button3.Location = new Point((panel1.Width - button3.Width) / 2, button2.Location.Y + button2.Height + 10);
            button3.Click += new EventHandler(btn_reset_Click);
        }
        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel hl = sender as LinkLabel;
            hl.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.shopee.co.id");
        }
        private void CB_Selected(object sender, EventArgs e)
        {
            ComboBox CB = sender as ComboBox;
            this.selectedJenis = (string)CB.Text;
        }
        private void CB2_Selected(object sender, EventArgs e)
        {
            ComboBox CB = sender as ComboBox;
            this.selectedHarga = (string)CB.Text;
        }
        private void btn_filter_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if(this.selectedHarga == "< 200000")
            {
                foreach(var obj in this.items)
                {
                    if(obj.harga < 200000 && obj.jenis == this.selectedJenis)
                    {
                        Panel panel = addPanel(obj.nama, obj.harga, obj.spesifikasi);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
            else if (this.selectedHarga == "200000 - 500000")
            {
                foreach (var obj in this.items)
                {
                    if (obj.harga > 200000 && obj.harga < 500000 && obj.jenis == this.selectedJenis)
                    {
                        Panel panel = addPanel(obj.nama, obj.harga, obj.spesifikasi);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
            else
            {
                foreach (var obj in this.items)
                {
                    if (obj.harga > 500000 && obj.jenis == this.selectedJenis)
                    {
                        Panel panel = addPanel(obj.nama, obj.harga, obj.spesifikasi);
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var obj in items)
            {
                Panel panel = addPanel(obj.nama, obj.harga, obj.spesifikasi);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }
        Panel addPanel(string nama, int harga, string spesifikasi)
        {
            Panel panel = new Panel();
            panel.Name = nama;
            panel.Width = 300;
            panel.Padding = new Padding(3);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            Label label = addLabel(nama + "\n\n" + harga.ToString());
            panel.Controls.Add(label);
            label.Location = new Point((panel.Width - label.Width) / 2, panel.Location.Y+5);
            Button button = addButton(spesifikasi);
            button.Location = new Point((panel.Width-button.Width)/2, label.Location.Y+60);
            panel.Controls.Add(button);
            return panel;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, Color.White, 1, ButtonBorderStyle.Solid, Color.White, 1, ButtonBorderStyle.Solid, Color.White, 1, ButtonBorderStyle.Solid, Color.White, 1, ButtonBorderStyle.Solid);
        }

        void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            flowLayoutPanel1.Controls.Clear();

            foreach (var obj in this.items)
            {
                if (obj.spesifikasi == btn.Name)
                {
                    Panel panel = addPanelDetail(obj.nama, obj.harga, obj.spesifikasi);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }

        Panel addPanelDetail(string nama, int harga, string spesifikasi)
        {
            Panel panel = new Panel();
            panel.Name = nama;
            panel.Padding = new Padding(1);
            panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel.Width = 400;
            panel.Height = 200;


            Label label = addLabel(nama + "\n\n" + harga.ToString() + "\n\n" + "Spesifikasi :\n" + spesifikasi);
            label.Height = 100;
            label.Width = 200;
            panel.Controls.Add(label);
            label.Location = new Point((panel.Width - label.Width) / 2, panel.Location.Y + 5);

            Button button = new Button();
            button.Name = "Back";
            button.Text = "Back";
            button.BackColor = Color.Yellow;
            button.ForeColor = Color.Black;
            button.Click += new EventHandler(btn_reset_Click);
            panel.Controls.Add(button);
            button.Location = new Point((panel.Width - button.Width)-10, panel.Height - 35);

            return panel;
        }
        Button addButton(string str)
        {
            Button button = new Button();
            button.Name = str;
            button.Text = "Beli";
            button.Click += new EventHandler(btn_click);

            button.BackColor = Color.ForestGreen;
            button.ForeColor = Color.White;

            return button;
        }
        Label addLabel(string str)
        {
            Label label = new Label();
            label.Name = str;
            label.Text = str;
            label.Width = 100;
            label.Height = 60;

            label.ForeColor = Color.Black;

            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;
        }
    }
}
