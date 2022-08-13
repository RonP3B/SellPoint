using Entities.Layers.Data;
using Entities.Layers.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Entities.UI.Windows
{
    public partial class FormMaintenance : Form
    {

        private Form parent;

        public FormMaintenance(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            RadMessageBox.SetThemeName("MaterialPink");
        }

        private void FormEntities_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            FormMainMenu ObjFormMainMenu = new FormMainMenu();
            FormCreateEntity ObjFormCreateEntity = new FormCreateEntity();
            ObjFormMainMenu.addDocument("Registro de entidad", ObjFormCreateEntity, parent);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataview.SelectedRows.Count == 1)
            {

                ClassData ObjClassData = new ClassData();

                int selectedRow = dataview.SelectedRows[0].Index;
                int EntityId = Convert.ToInt32(dataview.Rows[selectedRow].Cells["IdEntidad"].Value);
                string user = dataview.Rows[selectedRow].Cells["UserNameEntidad"].Value.ToString();

                DialogResult response = RadMessageBox.Show(
                    this,
                    "Estas seguro que deseas eliminar al usuario: '" + user + "'",
                    "Mensaje del sistema",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Exclamation
                );

                if (response == DialogResult.Yes)
                {
                    ObjClassData.deleteEntity(EntityId);

                    RadMessageBox.Show(
                        this,
                        "El usuario: '" + user + "' ha sido eliminado",
                        "Mensaje del sistema",
                        MessageBoxButtons.OK,
                        RadMessageIcon.Info
                    );

                    refresh();
                }

            } else
            {
                RadMessageBox.Show(
                    this,
                    "Debes seleccionar al usuario que deseas eliminar",
                    "Mensaje del sistema",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );
            }    
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            ClassData ObjClassData = new ClassData();
            DataTable ObjDataTable = ObjClassData.readAllEntities();

            
            ObjDataTable.Columns.Add("#DocumentoFormateado").SetOrdinal(5);

            ClassPresentation a = new ClassPresentation();

            foreach (DataRow row in ObjDataTable.Rows) 
            {
                string tipoDocumento = row["TipoDocumento"].ToString();
                long numeroDocumento = Convert.ToInt64(row["NumeroDocumento"]);

                row["#DocumentoFormateado"] = a.FormatDocumentNumber(tipoDocumento, numeroDocumento);
                
            }

            ObjDataTable.Columns.Remove("NumeroDocumento");

            dataview.DataSource = ObjDataTable;
            dataview.AutoResizeColumns();
            dataview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataview.Rows[0].Selected = false;
        }
    }
}
