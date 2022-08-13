using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.UI.Windows
{
    public partial class UserControlFields : UserControl
    {

        public string Descripcion
        {
            get
            {
                return txt_descripcion.Text;
            }
        }


        public string Direccion
        {
            get
            {
                return txt_direccion.Text;
            }
        }

        public string Localidad
        {
            get
            {
                return txt_localidad.Text;
            }
        }

        public string TipoEntidad
        {
            get
            {
                return cmb_tipoEntidad.Text;
            }
        }

        public string TipoDocumento
        {
            get
            {
                return cmb_tipoDocumento.Text;
            }
        }

        public long NumeroDocumento
        {
            get
            {
                //-404 significará vacío
                return long.Parse(txt_numeroDocumento.Text == "" ? "-404" : txt_numeroDocumento.Text);
            }
        }

        public string Telefonos
        {
            get
            {
                return txt_telefono.Text;
            }
        }

        public string URLPaginaWeb
        {
            get
            {
                return txt_web.Text;
            }
        }

        public string URLFacebook
        {
            get
            {
                return txt_facebook.Text;
            }
        }

        public string URLInstagram
        {
            get
            {
                return txt_instagram.Text;
            }
        }

        public string URLTwitter
        {
            get
            {
                return txt_twitter.Text;
            }
        }

        public string URLTikTok
        {
            get
            {
                return txt_tiktok.Text;
            }
        }

        public string CodigoPostal
        {
            get
            {
                return txt_codigoPostal.Text;
            }
        }

        public string CoordenadasGPS
        {
            get
            {
                return txt_gps.Text;
            }
        }


        public long LimiteCredito
        {
            get
            {
                //-404 vacío
                return long.Parse(txt_credito.Text == "" ? "-404" : txt_credito.Text);
            }
        }

        public string UserNameEntidad
        {
            get
            {
                return txt_user.Text;
            }
        }

        public string PasswordEntidad
        {
            get
            {
                return txt_password.Text;
            }
        }

        public string RolUserEntidad
        {
            get
            {
                return cmb_rol.Text;
            }
        }

        public string Comentario
        {
            get
            {
                return txt_comentario.Text;
            }
        }

        public string Estatus
        {
            get
            {
                return cmb_status.Text;
            }
        }

        public int NoEliminable
        {
            get
            {
                return cmb_eliminable.Text == "Si" ?  1 : 0;
            }
        }

        public UserControlFields()
        {
            InitializeComponent();
            cmb_tipoDocumento.SelectedIndex = 0;
            cmb_status.SelectedIndex = 0;
            cmb_tipoEntidad.SelectedIndex = 0;
            cmb_eliminable.SelectedIndex = 0;
            cmb_rol.SelectedIndex = 0;
        }

        private int maxNumbers = 0;

        private void limitNumbers()
        {
            string tipoDocumento = cmb_tipoDocumento.Text;

            if (tipoDocumento == "RNC")
            {
                maxNumbers = 9;
                txt_numeroDocumento.PlaceholderText = "000000000";
            }

            else if (tipoDocumento == "Pasaporte")
            {
                maxNumbers = 7;
                txt_numeroDocumento.PlaceholderText = "0000000";
            }

            else
            {
                maxNumbers = 11;
                txt_numeroDocumento.PlaceholderText = "00000000000";
            }
        }

        private void cmb_tipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_numeroDocumento.Text = "";
            limitNumbers();
        }

        private void UserControlFields_Load(object sender, EventArgs e)
        {
            limitNumbers();
        }

        private void txt_numeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_numeroDocumento.Text.Length > maxNumbers)
            {
                e.Handled = true;
            }
            
            else if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(this, "Solo números");
            }
        }
    }
}

