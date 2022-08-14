using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Entities.UI.Windows
{
    public partial class UserControlFields : UserControl
    {

        //Metodos getter
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

        private int MaxNumber = 0;

        //Constructor
        public UserControlFields()
        {
            InitializeComponent();
            cmb_tipoDocumento.SelectedIndex = 0;
            cmb_status.SelectedIndex = 0;
            cmb_tipoEntidad.SelectedIndex = 0;
            cmb_eliminable.SelectedIndex = 0;
            cmb_rol.SelectedIndex = 0;
            RadMessageBox.SetThemeName("MaterialPink");
        }

        //Para obtener la limitacion de digitos
        private void limitNumbers()
        {
            string tipoDocumento = cmb_tipoDocumento.Text;

            if (tipoDocumento == "RNC")
            {
                MaxNumber = 9;
                txt_numeroDocumento.PlaceholderText = "000000000";
            }

            else if (tipoDocumento == "Pasaporte")
            {
                MaxNumber = 7;
                txt_numeroDocumento.PlaceholderText = "0000000";
            }

            else
            {
                MaxNumber = 11;
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

        //Se limitan los caracteres del textbox_numero documento dependiendo en tipo de documento elegido
        private void txt_numeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_numeroDocumento.Text.Length > MaxNumber - 1 && e.KeyChar != 127 && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            checkNumber(e);
        }

        private void txt_credito_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(e);
        }

        //Limita el textbox a solo numero y tecla de borrar
        private void checkNumber(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 127 && e.KeyChar != 8)
            {
                e.Handled = true;
                RadMessageBox.Show(
                   this,
                   "En este campo solo se pueden digitar números.",
                   "Mensaje del sistema",
                   MessageBoxButtons.OK,
                   RadMessageIcon.Exclamation
                );
            }
        }

        
        public void documentNoEditable()
        {
            txt_numeroDocumento.Enabled = false;
            cmb_tipoDocumento.Enabled = false;
        }

        //Lenna todos los campos con los valores de los parametros
        public void fillFields
            (
                string descripcion, string direccion, string localidad,
                string TipoEntidad, string TipoDocumento, long NumeroDocumento,
                string Telefono, string web, string faceebok, string instagram,
                string twitter, string codigoPostal, string GPS, long Credito,
                string user, string Pass, string rol, string comentario,
                string status, int Eliminable, string tiktok
            )
        {
            txt_descripcion.Text = descripcion;
            txt_direccion.Text = direccion;
            txt_localidad.Text = localidad;
            cmb_tipoEntidad.SelectedIndex = TipoEntidad == "Física" ? 1:  0;
            txt_numeroDocumento.Text = NumeroDocumento.ToString();
            txt_telefono.Text = Telefono;
            txt_web.Text = web;
            txt_facebook.Text = faceebok;
            txt_instagram.Text = instagram;
            txt_twitter.Text = twitter;
            txt_tiktok.Text = tiktok;
            txt_codigoPostal.Text = codigoPostal;
            txt_gps.Text = GPS;
            txt_credito.Text = Credito.ToString();
            txt_user.Text = user;
            txt_password.Text = Pass;
            txt_comentario.Text = comentario;
            cmb_status.SelectedIndex = status == "Activa" ? 0 : 1;
            cmb_eliminable.SelectedIndex = Eliminable;
           
            if (TipoDocumento == "Cédula") cmb_tipoDocumento.SelectedIndex = 1;
            else if (TipoDocumento == "Pasaporte") cmb_tipoDocumento.SelectedIndex = 2;
            else cmb_tipoDocumento.SelectedIndex = 0;
            
            if (rol == "Admin") cmb_rol.SelectedIndex = 2;
            else if (rol == "Supervisor") cmb_rol.SelectedIndex = 1;
            else cmb_rol.SelectedIndex = 0;
            
        }
    }
}

