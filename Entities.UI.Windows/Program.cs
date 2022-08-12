using Entities.UI.Windows.ParentForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entities.UI.Windows
{
    static class Program
    {

        public static string UserName;
        public static bool UserAuthenticated, isOver = false;


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSplash());


            while (!isOver)
            {
                //Prueba
                Application.Run(new FormParent1());
                //Prueba
                Application.Run(new FormLogin());

                if (UserAuthenticated)
                {
                    Application.Run(new FormMainMenu());
                }
            }


            

        }
    }
}
