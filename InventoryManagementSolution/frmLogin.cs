using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImsBusinessLogicLayer;


namespace InventoryManagementSolution
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("User name must be entered !");
                txtUser.Focus();
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Password must be entered");
                txtPass.Focus();
                return;
            }
            MainBLL mainBll = new MainBLL();
            if (mainBll.Login(txtUser.Text, txtPass.Text) == true)
            {
                frmMain FormCls = new frmMain();
                FormCls.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User authentication failed !");
                txtUser.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtUser.Text.Trim() != "")
            {
                //txtPass.Focus();
                btnLogin_Click(sender, e);
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtPass.Text.Trim() != "")
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
