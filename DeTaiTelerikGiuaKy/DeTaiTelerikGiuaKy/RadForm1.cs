using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls.UI;
using Telerik.WinControls.CodedUI;


namespace DeTaiTelerikGiuaKy
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        SqlConnection cn;
        string cnStr = @"Server = .; Database = Login ; Integrated security = true";
        SqlCommand cmd;

        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                cn = new SqlConnection(cnStr);
                cn.Open();
                string sql = "Select count(*) From [Login].[dbo].[TKLogin] Where TaiKhoan = @acc And MatKhau = @pass ";
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(new SqlParameter("@acc", txtAccounnt.Text));
                cmd.Parameters.Add(new SqlParameter("@pass", txtPassword.Text));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
                    MessageBox.Show("Đăng Nhập Thành Công !", "Nofitication");
                    //this.Hide();
                    //fm = new Form2();
                    //fm.Show();
                }
                else
                {
                    lbconnect.Text = "Tài Khoản hoặc mật khẩu không thể đăng nhập";
                    txtAccounnt.Text = "";
                    txtPassword.Text = "";
                    txtAccounnt.Focus();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
