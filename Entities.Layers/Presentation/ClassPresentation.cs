using Entities.Layers.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Layers.Presentation
{
    public class ClassPresentation
    {
        public string FormatDocumentNumber(string TipoDocumento, long NumeroDocumento)
        {
            string FormatedDocumentNumber = "";

            if (TipoDocumento == "Cédula")
            {
                FormatedDocumentNumber = FormatID(NumeroDocumento);
            }

            else if (TipoDocumento == "Pasaporte")
            {
                FormatedDocumentNumber = FormatPassport(NumeroDocumento);
            }

            else
            {
                FormatedDocumentNumber = NumeroDocumento.ToString();
            }


            return FormatedDocumentNumber;
        }

        private string FormatID(long NumeroDocumento)
        {
            string strDocumentNumber = NumeroDocumento.ToString();
            string FormatedDocumentNumber = strDocumentNumber.Insert(3, "-");
            FormatedDocumentNumber = FormatedDocumentNumber.Insert(11, "-");

            return FormatedDocumentNumber;
        }

        private string FormatPassport(long NumeroDocumento)
        {
            string strDocumentNumber = NumeroDocumento.ToString();
            string FormatedDocumentNumber = "RD" + strDocumentNumber;

            return FormatedDocumentNumber;
        }
    }
}
