using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmallBlessing.Desktop.Forms.Membership;
namespace SmallBlessing.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Manage());
        }
    }
}
