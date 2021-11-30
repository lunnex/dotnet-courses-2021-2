using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms;
using DALDB;
using BLL;
using System.Data.SqlClient;

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

            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "DESKTOP-34RCMFS\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "usersAndPrizes";
            connectionStringBuilder.IntegratedSecurity = true;

            var connection = connectionStringBuilder.ToString();

            var daoUser = new UserDAL(connection);
            var logicUser = new UserBL(daoUser);

            var daoPrize = new PrizeDAL(connection);
            var logicPrize = new PrizeBL(daoPrize);

            Application.Run(new MainForm(logicPrize, logicUser));
        }
    }
}
