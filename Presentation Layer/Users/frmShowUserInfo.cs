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

namespace HMS.Users
{
    public partial class frmShowUserInfo : Form
    {
        int _UserID;
        clsUser _UserInfo;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _UserInfo=clsUser.FindUserByUserID(_UserID);
        }

        void _LoadData()
        {
            
            if (_UserInfo != null)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_UserInfo.PersonID);
                lblUserID.Text = _UserInfo.UserID.ToString();
                lblUserName.Text = _UserInfo.UserName;
                lblDepartmentName.Text=_UserInfo.UserDepartment.DepartmentName;
                lblRoleName.Text = _UserInfo.UserRole.RoleTitle.ToString();
                lblActiveOrNot.Text = _UserInfo.IsActive ? "Yes" : "No";
            }
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
