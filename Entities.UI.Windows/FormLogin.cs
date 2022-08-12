using Entities.Layers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.UI.Windows
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Program.isOver = true;
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            ClassData ObjClassData = new ClassData();

            string User = "", Pass = "";

            User = txt_user.Text;
            Pass = txt_password.Text;

            if (ObjClassData.isAuthenticated(User, Pass))
            {
                Program.UserAuthenticated = true;
                Program.UserName = User;
                Close();
            }

            else
            {
                Program.UserAuthenticated = false;
                MessageBox.Show("El usuario es incorrecto");
            }
        }
    }
}
