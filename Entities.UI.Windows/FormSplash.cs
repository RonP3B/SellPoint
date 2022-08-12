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
    public partial class FormSplash : Form
    {
        private int Start = 0;

        public FormSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Start += 3;
            progressBar.Value = Start;

            if (progressBar.Value == 100)
            {
                timer1.Stop();
                Close();
            }
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
            ClassConnectionDB.StringConnectionDB();
        }
    }
}
