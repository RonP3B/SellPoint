using Entities.Layers.Data;
using Entities.Layers.Presentation;
using System;
using System.Data;
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

        //Abrimos una ventana de registro de entidad
        private void btn_create_Click(object sender, EventArgs e)
        {
            FormMainMenu ObjFormMainMenu = new FormMainMenu();
            FormCreateEntity ObjFormCreateEntity = new FormCreateEntity();
            ObjFormMainMenu.addDocument("Registro de entidad", ObjFormCreateEntity, parent);
        }

        //Abrimos una ventana de edicion de entidad
        private void btn_update_Click(object sender, EventArgs e)
        {

            if (dataview.SelectedRows.Count == 1)
            {
                int selectedRow = dataview.SelectedRows[0].Index;
                string user = dataview.Rows[selectedRow].Cells["UserNameEntidad"].Value.ToString();

                FormMainMenu ObjFormMainMenu = new FormMainMenu();
                FormUpdateEntity ObjUpdateEntity = new FormUpdateEntity(user);
                ObjFormMainMenu.addDocument("Edición de entidad", ObjUpdateEntity, parent);
            }
            else
            {
                RadMessageBox.Show(
                   this,
                   "Debes seleccionar al usuario que deseas editar",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
               );
            }


            
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
                        "Estas seguro que desea eliminar al usuario '" + user + "'",
                        "Mensaje del sistema",
                        MessageBoxButtons.YesNo,
                        RadMessageIcon.Exclamation
                );


                bool eliminable = Convert.ToInt32(dataview.Rows[selectedRow].Cells["NoEliminable"].Value) == 1;

                if (eliminable)
                {
                    RadMessageBox.Show(
                        this,
                        "El usuario seleccionado no es eliminable",
                        "Mensaje del sistema",
                        MessageBoxButtons.OK,
                        RadMessageIcon.Exclamation
                    );

                    return;
                }

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
            }
            else
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

        //Actualizamos la tabla y colocamos una nueva columna con el numero documento formateado
        private void refresh()
        {
            panel1.Visible = false;
            txt_buscar.Text = "";

            ClassData ObjClassData = new ClassData();
            DataTable ObjDataTable = ObjClassData.readAllEntities();
            ClassPresentation classPresentation = new ClassPresentation();

            ObjDataTable.Columns.Add("#Documento").SetOrdinal(5);

            foreach(DataRow row in ObjDataTable.Rows)
            {
                string TipoDocumento = row["TipoDocumento"].ToString();
                long NumeroDocumento = Convert.ToInt64(row["NumeroDocumento"]);

                row["#Documento"] = classPresentation.FormatDocumentNumber(TipoDocumento, NumeroDocumento);
            }

            ObjDataTable.Columns.Remove("NumeroDocumento");

            fillDataGridView(ObjDataTable);
        }

        //Cada que cambie el data grid view se deselecciona la primera fila
        private void dataview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataview.Rows.Count > 0) dataview.Rows[0].Selected = false;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btn_cerrarBuscarUsuario_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            refresh();
            txt_buscar.Text = "";
        }

        private void btn_buscarUsuario_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == "")
            {
                RadMessageBox.Show(
                    this,
                    "Debes escribir el nombre del usuario que desea buscar",
                    "Mensaje del sistema",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Exclamation
                );

                return;
            }

            ClassData ObjClassData = new ClassData();


            string user = txt_buscar.Text;

            DataTable searchedEntity = ObjClassData.readEntity(user).Item1;

            if (searchedEntity.Rows.Count == 0)
            {
                RadMessageBox.Show(
                    this,
                    "El usuario '" + user + "' no existe",
                    "Mensaje del sistema",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Info
                );

                return;
            }

            fillDataGridView(searchedEntity);

        }

        //Rellena el data grid view y lo ajusta
        private void fillDataGridView(DataTable table)
        {
            dataview.DataSource = table;
            dataview.AutoResizeColumns();
            dataview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
