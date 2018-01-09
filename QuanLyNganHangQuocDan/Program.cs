using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNganHangQuocDan
{
    static class Program
    {
       // SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=quanlyNH;Integrated Security=True");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
