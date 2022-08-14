using Entities.Layers.Bussiness;
using Entities.Layers.Data;
using Entities.Layers.Data.Model;
using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Entities.UI.Windows
{
    public partial class FormUpdateEntity : Form
    {
        ClassData ObjClassData = new ClassData();
        ClassEntity ObjClassEntity;

        public FormUpdateEntity(string user)
        {
            InitializeComponent();
            RadMessageBox.SetThemeName("MaterialPink");

            //Se obtienen los datos del usuario a actualizar
            ObjClassEntity = ObjClassData.readEntity(user).Item2;

            //Rellenamos todos los campos con los datos del usuario a actualizar
            userControlFields1.fillFields(
                ObjClassEntity.Descripcion, ObjClassEntity.Direccion,
                ObjClassEntity.Localidad, ObjClassEntity.TipoEntidad,
                ObjClassEntity.TipoDocumento, ObjClassEntity.NumeroDocumento,
                ObjClassEntity.Telefonos, ObjClassEntity.URLPaginaWeb, 
                ObjClassEntity.URLFacebook, ObjClassEntity.URLInstagram,
                ObjClassEntity.URLTwitter, ObjClassEntity.CodigoPostal,
                ObjClassEntity.CoordenadasGPS, ObjClassEntity.LimiteCredito, 
                ObjClassEntity.UserNameEntidad, ObjClassEntity.PasswordEntidad, 
                ObjClassEntity.RolUserEntidad, ObjClassEntity.Comentario, 
                ObjClassEntity.Estatus, ObjClassEntity.NoEliminable,
                ObjClassEntity.URLTikTok 
           );

            //Volvemos los campos de numero de documento y tipo de documento no editables
            userControlFields1.documentNoEditable();  
            
        }

        //Función para Verificar de la cantidad de digitos del numero de documento
        private Tuple<bool, string> isValidDocumentNumber(long numeroDocumento, string TipoDocumento)
        {
            //El -404 quiere decir nulo/vació
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

            //Obtención de valores requeridos
            string user = userControlFields1.UserNameEntidad;
            long numeroDocumento = ObjClassEntity.NumeroDocumento;
            string descripcion = userControlFields1.Descripcion;
            string direccion = userControlFields1.Direccion;
            string localidad = userControlFields1.Localidad;
            string telefono = userControlFields1.Telefonos;
            long credito = userControlFields1.LimiteCredito;
            string password = userControlFields1.PasswordEntidad;
            string tipoDocumento = ObjClassEntity.TipoDocumento;

            //Verificación de que se llenaron los campos requeridos
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

            //Verificación de la cantidad de digitos del numero de documento
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

            //Verificación de que el credito no sea negativo
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

            //Verificación de que no exista el usuario
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
            
            // Creacion de la nueva entidad actualizada
            ClassEntity newEntity = new ClassEntity();

            //Asignación de variables
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

            //Se actualiza la entidad
            ObjClassData.updateEntity(ObjClassEntity.IdEntidad, newEntity);

            RadMessageBox.Show(
              this,
               "La entidad se ha editado con éxito.",
               "Mensaje del sistema",
               MessageBoxButtons.OK,
               RadMessageIcon.Info
            );

            Close();
        }
    }
}
