using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListviewClickHeaderIssue.SampleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new frmMain();
            if (args.Length > 0)
                form.ItemCount = Convert.ToInt32(args[0]);
            Application.Run(form);
        }
    }
}
