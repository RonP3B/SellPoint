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

namespace Entities.UI.Windows.ParentForms
{
    public partial class FormParent1 : Form
    {
        public FormParent1()
        {
            InitializeComponent();
        }

        private void cmd_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassEntity newEntity = new ClassEntity();
            ClassData objClassData = new ClassData();


            newEntity.Descripcion = txt_descripcion.Text;

            newEntity.Direccion = txt_direccion.Text;

            newEntity.Localidad = txt_localidad.Text;

            newEntity.TipoEntidad = cmb_tipoEntidad.Text;

            newEntity.TipoDocumento = cmb_tipoDocumento.Text;

            newEntity.NumeroDocumento = long.Parse(txt_numeroDocumento.Text);

            newEntity.Telefonos = txt_telefono.Text;

            newEntity.URLPaginaWeb = txt_web.Text;

            newEntity.URLFacebook = txt_facebook.Text;

            newEntity.URLInstagram = txt_instagram.Text;

            newEntity.URLTwitter = txt_twitter.Text;

            newEntity.URLTikTok = txt_tiktok.Text;

            newEntity.CodigoPostal = txt_codigoPostal.Text;

            newEntity.CoordenadasGPS = txt_gps.Text;

            newEntity.LimiteCredito = long.Parse(txt_credito.Text);

            newEntity.UserNameEntidad = txt_user.Text;

            newEntity.PasswordEntidad = txt_password.Text;

            newEntity.RolUserEntidad = cmb_rol.Text;

            newEntity.Comentario = txt_comentario.Text;

            newEntity.Estatus = cmb_status.Text;

            newEntity.NoEliminable = int.Parse(cmb_eliminable.Text);

            newEntity.FechaRegistro = DateTime.Now.Date.ToString("dd/MM/yyyy");

            objClassData.createEntity(newEntity);
        }
    }
}
