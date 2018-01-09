using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace QuanLyNganHangQuocDan
{
    public partial class User : Form
    {
        public string currentUser;

        public User()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=quanlyNH;Integrated Security=True");

       
        private void btnGui_Click(object sender, EventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string sql = "select * from [dbo].[Khachhang] where sotaikhoan = '" + this.currentUser + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                txtTenkh.Text = dt.Rows[0]["hoten"].ToString();
                txtSotaikhoan.Text = dt.Rows[0]["sotaikhoan"].ToString();
                txtSohoso.Text = dt.Rows[0]["sohoso"].ToString();
                txtSdt.Text = dt.Rows[0]["sdt"].ToString();
                txtNogoc.Text = dt.Rows[0]["nogoc"].ToString();
                string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                         "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                         "MM/d/yyyy HH:mm:ss.ffffff" };
                DateTime dtime = DateTime.ParseExact(dt.Rows[0]["hanno"].ToString(), formats, new CultureInfo("en-US"),DateTimeStyles.None);
                dtpNogoc.Value = dtime;
                da.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

        private void trạngVayVốnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
