using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Layers.Bussiness
{
    public class ClassBussiness
    {
        //Funcion que verifica si el credito dado es mayor o igual a cero
        public static bool validateCredit(long Credits){
            return Credits >= 0;
        }
    }
}
