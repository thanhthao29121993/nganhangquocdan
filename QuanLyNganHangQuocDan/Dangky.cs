using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNganHangQuocDan
{
    public partial class Dangky : Form
    {
        public Dangky()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=quanlyNH;Integrated Security=True");

        private void Dangky_Load(object sender, EventArgs e)
        {
            cnn.Open();
        }
        private void ok_Click(object sender, EventArgs e)
        {
            string a = txtmatkhau.Text;
            string b = txtnlmk.Text;
            string sql1 = "select COUNT(*) as number  from [dbo].[Khachhang] where sotaikhoan = '" + txtStk.Text + "'";
            SqlCommand comad = new SqlCommand(sql1, cnn);
            int ad = (int)comad.ExecuteScalar();
            comad.Dispose();
            if (ad != 0)
            {
                if (a == b)
                {
                    

                    string sql = "select count(*) from [dbo].[Admin] where taikhoan='" + txtten.Text + "'";
                    if (txtten.Text == "")
                        MessageBox.Show("Bạn chưa nhập tên đăng nhập", "Đăng ký");
                    else if (txtmatkhau.Text == "")

                        MessageBox.Show("Bạn chưa nhập mật khẩu", "Đăng ký");
                    else
                    {
                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        int i = (int)cmd.ExecuteScalar();
                        cmd.Dispose();
                        if (i != 0)
                        {
                            MessageBox.Show("Tài khoản đã được đăng kí vui lòng sử dụng tên khác", "đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtten.Clear();
                            txtmatkhau.Clear();
                            txtnlmk.Clear();
                            txtten.Focus();
                        }

                        else
                        {
                            
                            string s = "insert into [dbo].[Admin] values('" + txtten.Text + "','" + txtmatkhau.Text + "','user', '"+ txtStk.Text +"')";
                            SqlCommand com = new SqlCommand(s, cnn);
                            com.ExecuteNonQuery();
                            com.Dispose();
                            cnn.Close();
                            if (MessageBox.Show("Đăng kí thành công bạn muốn đăng nhập không", "Đăng kí", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FormDangNhap frm = new FormDangNhap();
                                frm.Show();
                                this.Hide();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng kiểm tra lại!", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmatkhau.Clear();
                txtnlmk.Clear();
                txtmatkhau.Focus();
            }
        }

        private void Dangky_Activated(object sender, EventArgs e)
        {
            txtStk.Focus();
        }
        private void txtStk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtten.Focus();
            }
        }
        private void txtten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmatkhau.Focus();
            }
        }
        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtnlmk.Focus();
            }
        }
        private void txtnlmk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok.Focus();
            }
        }

        private void ok_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {

            }
        } 
    }
}
