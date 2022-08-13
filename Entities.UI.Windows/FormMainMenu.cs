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
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
            label_user.Text = "Usuario: " + Program.UserName;
            label_title.Text = "Hola " + Program.UserName;
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.IsMdiContainer = true;
            this.radDock2.AutoDetectMdiChildren = true;
        }

        private void btn_entities_Click(object sender, EventArgs e)
        {
            FormMaintenance childForm = new FormMaintenance(this);
            addDocument("Ventana mantenimiento", childForm, this);
        }

        public void addDocument(string title, Form childForm, Form parent)
        {
            childForm.Text = title;
            childForm.MdiParent = parent;
            childForm.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            Program.isOver = true;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_hour.Text = "Hora actual: " + DateTime.Now.ToShortTimeString(); 
        }

        private void radMenuButtonItem4_Click(object sender, EventArgs e)
        {
            Program.isOver = true;
            Close();
        }

        private void radMenuButtonItem3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radMenuButtonItem2_Click(object sender, EventArgs e)
        {
            FormAboutUs ObjFormAboutUs = new FormAboutUs();
            addDocument("Acerca de... ", ObjFormAboutUs, this);
        }
    }
}
