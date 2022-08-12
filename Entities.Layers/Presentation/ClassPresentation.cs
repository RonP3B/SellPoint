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
        public string FormatDocumentNumber(ClassEntity entity)
        {
            string FormatedDocumentNumber = "";

            if (entity.TipoDocumento == "Cédula")
            {
                FormatedDocumentNumber = FormatID(entity);
            }

            else if (entity.TipoDocumento == "Pasaporte")
            {
                FormatedDocumentNumber = FormatPassport(entity);
            }

            else
            {
                FormatedDocumentNumber = entity.NumeroDocumento.ToString();
            }


            return FormatedDocumentNumber;
        }

        private string FormatID(ClassEntity entity)
        {
            string strDocumentNumber = entity.NumeroDocumento.ToString();
            string FormatedDocumentNumber = strDocumentNumber.Insert(3, "-");
            FormatedDocumentNumber = FormatedDocumentNumber.Insert(11, "-");

            return FormatedDocumentNumber;
        }

        private string FormatPassport(ClassEntity entity)
        {
            string strDocumentNumber = entity.NumeroDocumento.ToString();
            string FormatedDocumentNumber = "RD" + strDocumentNumber;

            return FormatedDocumentNumber;
        }
    }
}
