using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



/*  INTERPLAY EDITOR V2.0
 *  WRITTEN IN MICROSOFT C# -- PORTED FROM VB.NET, C++.  ORIGINAL VERSION IN MICROSOFT QUICKBASIC 4.5 BACK IN 1990'S.
 *  UTILIZES CODE FROM MICHAEL BENES C CODE.
 * 
 *  THIS IS A WORKING VERSION OF THE EDITOR.
 * 
 * LAST UPDATE 1/9/2021
 * 
 */



namespace Interplay_Editor_2_C_Sharp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
            Application.Run(new ProgramForm());
        }


      
    }
}
