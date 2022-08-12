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
    public partial class FormMaintenance : Form
    {
        public FormMaintenance()
        {
            InitializeComponent();
        }

        private void addDocument(string title, Form childForm)
        {
            
        }

        private void FormEntities_Load(object sender, EventArgs e)
        {
            ClassData ObjClassData = new ClassData();
            DataTable ObjDataTable = ObjClassData.readAllEntities();
            dataview.DataSource = ObjDataTable;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
        
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            //FormEntities ObjFormEntities = new FormEntities();
            //addDocument("Listado entidades", ObjFormEntities);
        }
    }
}
