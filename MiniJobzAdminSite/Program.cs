using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniJobzAdminSite
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (AdminSite login = new AdminSite())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string loggedInUser = login.LoggedInUser;

                    Application.Run(new Main(loggedInUser));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
