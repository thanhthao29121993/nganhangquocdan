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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        int sai = 5;

        SqlConnection cnn = new SqlConnection(@"Data Source=.;Initial Catalog=quanlyNH;Integrated Security=True");
        void ketnoi()
        {
            cnn.Open();
            string sql = "select * from [dbo].[Admin]";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            cnn.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tentk = txtUser.Text;
                string mk = txtPass.Text;
                if (tentk == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser.Focus();
                }
                else if (mk == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Focus();
                }
                else
                {
                    //string sql1 = "select count(*) from [dbo].[Admin] where taikhoan='" + tentk + "' and matkhau='" + mk + "'";
                    string sql1 = "select COUNT(*) as number  from [dbo].[Admin] where taikhoan = '" + tentk + "' and matkhau = '" + mk + "' and quyen = 'admin'";
                    SqlCommand comad = new SqlCommand(sql1, cnn);
                    int ad = (int)comad.ExecuteScalar();
                    comad.Dispose();
                    if (sai > 0)
                    {
                        if (ad != 0)
                        {
                            Admin f = new Admin();
                            this.Hide();
                            f.Show();
                        }
                        else
                        {
                            string sql2 = "select * from [dbo].[Admin] where taikhoan='" + tentk + "' and matkhau='" + mk + "' and quyen = 'user'";
                            SqlCommand comus = new SqlCommand(sql2, cnn);
                            SqlDataAdapter da = new SqlDataAdapter(comus);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //comus.Dispose();
                            int us = dt.Rows.Count;
                            if (us > 0)
                            {
                               
                                User f = new User();
                                f.currentUser = dt.Rows[0]["sotaikhoan"].ToString();
                                this.Hide();
                                f.Show();
                            }
                            else
                            {
                                string sql3 = "select count(*) from [dbo].[Admin] where taikhoan='" + tentk + "' and matkhau='" + mk + "' and quyen = 'nhanvien'";
                                SqlCommand comnv = new SqlCommand(sql3, cnn);
                                int nv = (int)comnv.ExecuteScalar();
                                comus.Dispose();
                                if (nv != 0)
                                {
                                    MessageBox.Show("Bạn đã đăng nhập thành công vào tài khoản nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Nhanvien f = new Nhanvien();
                                    this.Hide();
                                    f.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtUser.Clear();
                                    txtPass.Clear();
                                    txtUser.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã nhập sai quá nhiều", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!"+ex, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cnn.Close();
            }
        }

        

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDn.Focus();
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            cnn.Open();
            //txtUser.Focus();
        }

        private void FormDangNhap_Activated(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void btnDk_Click(object sender, EventArgs e)
        {
            Dangky f = new Dangky();
            this.Hide();
            f.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
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
    


