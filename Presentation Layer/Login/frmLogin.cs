using HMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HMS.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            clsUser userinfo = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (userinfo==null)
            {
                MessageBox.Show("Invalid Username/Password","Invalid Info",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }
            if (!userinfo.IsActive)
            {
                MessageBox.Show("Your account is not active, Contact your admin","In Active account",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            clsGlobal.CurrentUser = userinfo;
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Please Enter Username");
               
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");

            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Please Enter Password");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");

            }
        }
    }
}
