using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.UI.Windows
{
    static class Program
    {

        //Variables estaticas pára llevar rastreo del programa
        public static string UserName;
        public static bool UserAuthenticated, isOver = false, hasEntites = true;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSplash());

            //Si no hay datos en la tabla se abrirá el formulario de registro
            if (!hasEntites)
            {
                Application.Run(new FormCreateEntity());
            }


            while (!isOver)
            {
                Application.Run(new FormLogin());

                if (UserAuthenticated)
                {
                    Application.Run(new FormMainMenu());
                }
            }
        }
    }
}
