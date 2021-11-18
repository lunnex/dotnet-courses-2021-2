using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms;
using DAL;
using BLL;

namespace _3Layers
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

            var daoUser = new UserListDAO();
            var logicUser = new UserBL(daoUser);

            var daoPrize = new PrizeListDAO();
            var logicPrize = new PrizeBL(daoPrize);

            Application.Run(new MainForm(logicPrize, logicUser));
        }
    }
}
