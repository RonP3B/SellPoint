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

        private void linkAngelInstagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/angelrafael420/");
        }

        private void linkRoniellLinkedin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/roniell-p%C3%A9rez-967882229/"); 
        }
    }
}
