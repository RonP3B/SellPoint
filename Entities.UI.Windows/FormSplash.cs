using Entities.Layers.Data;
using System;
using System.Data;
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
            ClassData ObjClassData = new ClassData();
            DataTable ObjDataTable = ObjClassData.readAllEntities();

            //Verifica si existen registros en la tabla de la base de datos
            if (ObjDataTable.Rows.Count == 0) Program.hasEntites = false;
        }
    }
}
