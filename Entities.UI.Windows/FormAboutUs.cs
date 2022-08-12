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
    public partial class FormAboutUs : Form
    {
        public FormAboutUs()
        {
            InitializeComponent();
        }

        private void linkAngelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/AngelRafael420");
        }

        private void linkRoniellGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/RonP3B");
        }
    }
}
