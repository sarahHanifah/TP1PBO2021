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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            tb_password.PasswordChar = '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            global::Login login = new global::Login();
            login.username = Convert.ToString(tb_username.Text);
            login.password = Convert.ToString(tb_password.Text);

            if(login.Validation() == 1)
            {
                formHome home = new formHome();
                home.Show();
                this.Hide();
            }
            else
            {
                string Msg = "Password anda salah!";
                DialogResult result = MessageBox.Show(Msg, "Warning", MessageBoxButtons.OK);
            }
        }
    }
}
