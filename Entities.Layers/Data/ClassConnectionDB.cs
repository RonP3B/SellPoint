using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Layers.Data
{
    //Patrón de diseño singleton
    public class ClassConnectionDB
    {
        //Variable estatica que guardará la conexión
        private static SqlConnection ObjSqlConnection;

        private ClassConnectionDB() { }

        public static SqlConnection StringConnectionDB()
        {
            if (ObjSqlConnection == null) {
                try
                {
                    string stringConnection =
                                        ConfigurationManager
                                        .ConnectionStrings["SQLServerConnection"]
                                        .ConnectionString;

                    ObjSqlConnection = new SqlConnection(stringConnection);

                    System.Diagnostics.Debug.WriteLine(
                        "Conexión a la base de datos realizada con exito."
                    );
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "No fue posible conectarse con la base de datos\nExcepción: " + e
                    );
                }
            }

            return ObjSqlConnection;
        }

    }
}
