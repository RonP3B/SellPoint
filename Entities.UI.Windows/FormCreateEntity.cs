using Entities.Layers.Bussiness;
using Entities.Layers.Data;
using Entities.Layers.Data.Model;
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
    public partial class FormCreateEntity : Form
    {
        public FormCreateEntity()
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("MaterialPink");
        }

        private Tuple<bool, string> isValidDocumentNumber(long numeroDocumento, string TipoDocumento)
        {

            if (numeroDocumento == -404) return Tuple.Create(true, "0");

            string document = numeroDocumento.ToString();

            if (TipoDocumento == "Cédula" && document.Length != 11)
            {
                return Tuple.Create(false, "11");
            }

            else if (TipoDocumento == "Pasaporte" && document.Length != 7)
            {
                return Tuple.Create(false, "7");
            }

            else if (TipoDocumento == "RNC" && document.Length != 9)
            {
                return Tuple.Create(false, "9");

            }

            return Tuple.Create(true, "0");
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            ClassData ObjClassData = new ClassData();

            string user = userControlFields1.UserNameEntidad;
            long numeroDocumento = userControlFields1.NumeroDocumento;
            string descripcion = userControlFields1.Descripcion;
            string direccion = userControlFields1.Direccion;
            string localidad = userControlFields1.Localidad;
            string telefono = userControlFields1.Telefonos; 
            long credito = userControlFields1.LimiteCredito;
            string password = userControlFields1.PasswordEntidad;
            string tipoDocumento = userControlFields1.TipoDocumento;

            if (user == "" || descripcion == "" || direccion == "" || 
                localidad == "" || telefono == "" || password == "" ||
                numeroDocumento == -404 || credito == -404)
            {
                RadMessageBox.Show(
                   this,
                   "Debes llenar los campos requeridos",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );

                return;
            }

            Tuple<bool, string> validatedDocument = isValidDocumentNumber(numeroDocumento, tipoDocumento);

            if (!validatedDocument.Item1)
            {
                string digitos = validatedDocument.Item2;

                RadMessageBox.Show(
                   this,
                   "El documento de: " + tipoDocumento + " debe tener " + digitos + " digitos",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );

                return;
            }

            if (credito < 0)
            {
                RadMessageBox.Show(
                   this,
                   "El limite de credito no puede ser negativo.",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );

                return;
            }

            if (ObjClassData.userExist(user))
            {
                RadMessageBox.Show(
                   this,
                   "El nombre de usuario ya está registrado.",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );

                return;

            }

            if (ObjClassData.documentNumberExist(numeroDocumento))
            {
                 
                RadMessageBox.Show(
                   this,
                   "El numero del documento ya está registrado.",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );

                return;

            } 
                
            ClassEntity newEntity = new ClassEntity();

            newEntity.Descripcion = descripcion;
            newEntity.Direccion = direccion;
            newEntity.Localidad = localidad;
            newEntity.TipoEntidad = userControlFields1.TipoEntidad;
            newEntity.TipoDocumento = tipoDocumento;
            newEntity.NumeroDocumento = numeroDocumento;
            newEntity.Telefonos = telefono;
            newEntity.URLPaginaWeb = userControlFields1.URLPaginaWeb;
            newEntity.URLFacebook = userControlFields1.URLFacebook;
            newEntity.URLInstagram = userControlFields1.URLInstagram;
            newEntity.URLTwitter = userControlFields1.URLTwitter;
            newEntity.URLTikTok = userControlFields1.URLTikTok;
            newEntity.CodigoPostal = userControlFields1.CodigoPostal;
            newEntity.CoordenadasGPS = userControlFields1.CoordenadasGPS;
            newEntity.LimiteCredito = ClassBussiness.validateCredit(credito) ? credito : 0;
            newEntity.UserNameEntidad = user;
            newEntity.PasswordEntidad = password;
            newEntity.RolUserEntidad = userControlFields1.RolUserEntidad;
            newEntity.Comentario = userControlFields1.Comentario;
            newEntity.Estatus = userControlFields1.Estatus;
            newEntity.NoEliminable = userControlFields1.NoEliminable;
            newEntity.FechaRegistro = DateTime.Now.Date;

            ObjClassData.createEntity(newEntity);

            RadMessageBox.Show(
               this,
               "La entidad se ha registrado con éxito.",
               "Mensaje del sistema",
               MessageBoxButtons.OK,
               RadMessageIcon.Info
            );

            Close();
        }
    }
}
