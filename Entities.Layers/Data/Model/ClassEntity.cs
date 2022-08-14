using Entities.Layers.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Layers.Data.Model
{
    public class ClassEntity
    {
        //Propiedades Setters y getters

        public int IdEntidad { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        public string Localidad { get; set; }

        public string TipoEntidad { get; set; }

        public string TipoDocumento { get; set; }

        public long NumeroDocumento { get; set; }

        public string Telefonos { get; set; }

        public string URLPaginaWeb { get; set; }

        public string URLFacebook { get; set; }

        public string URLInstagram { get; set; }

        public string URLTwitter { get; set; }

        public string URLTikTok { get; set; }

        public string CodigoPostal { get; set; }

        public string CoordenadasGPS { get; set; }

        public long LimiteCredito { get; set; }

        public string UserNameEntidad { get; set; }

        public string PasswordEntidad { get; set; }

        public string RolUserEntidad { get; set; }

        public string Comentario { get; set; }

        public string Estatus { get; set; }

        public int NoEliminable { get; set; }

        public DateTime FechaRegistro { get; set; }

        //Constructores

        public ClassEntity()
        {
        }

        public ClassEntity(
            int IdEntidad, string Descripcion, string Direccion,
            string Localidad, string TipoEntidad, string TipoDocumento,
            long NumeroDocumento, string Telefonos, string URLPaginaWeb,
            string URLFacebook, string URLInstagram, string URLTwitter,
            string URLTikTok, string CodigoPostal, string CoordenadasGPS,
            long LimiteCredito, string UserNameEntidad, string PasswordEntidad, 
            string RolUserEntidad, string Comentario, string Estatus, int NoEliminable,
            DateTime FechaRegistro
         )
        {

            this.IdEntidad = IdEntidad;
            this.Descripcion = Descripcion;
            this.Direccion = Direccion;
            this.Localidad = Localidad;
            this.TipoEntidad = TipoEntidad;
            this.TipoDocumento = TipoDocumento;
            this.NumeroDocumento = NumeroDocumento;
            this.Telefonos = Telefonos;
            this.URLPaginaWeb = URLPaginaWeb;
            this.URLFacebook = URLFacebook;
            this.URLInstagram = URLInstagram;
            this.URLTwitter = URLTwitter;
            this.URLTikTok = URLTikTok;
            this.CodigoPostal = CodigoPostal;
            this.CoordenadasGPS = CoordenadasGPS;
            this.LimiteCredito =  ClassBussiness.validateCredit(LimiteCredito) ? LimiteCredito:  0;
            this.UserNameEntidad = UserNameEntidad;
            this.PasswordEntidad = PasswordEntidad;
            this.RolUserEntidad = RolUserEntidad;
            this.Comentario = Comentario;
            this.Estatus = Estatus;
            this.NoEliminable = NoEliminable;
            this.FechaRegistro = FechaRegistro;
        }
    }
}
