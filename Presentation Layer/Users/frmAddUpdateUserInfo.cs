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

namespace HMS
{
    public partial class frmAddUpdateUserInfo : Form
    {

        int _UserID=-1;
        clsUser _UserInfo=null;
        DataTable dtPermissionsList =null;
        DataTable dtCurrentUserPermissions = null;

        enum enMode
        {
            AddNew=1,
            Update=2
        }

        enMode _Mode = enMode.AddNew;
        public frmAddUpdateUserInfo()
        {
            InitializeComponent();

            _UserID = -1;
            _UserInfo = new clsUser();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _UserInfo=clsUser.FindUserByUserID(_UserID);
            _Mode = enMode.Update;
        }
        void _dgvFillPermissionsList()
        {
            dtPermissionsList=clsPermission.GetPermissionsList();
            dgvPermissions.DataSource = dtPermissionsList;
            if (dgvPermissions.Columns.Count > 0)
            {

                DataGridViewCheckBoxColumn IsSelected = new DataGridViewCheckBoxColumn();
                IsSelected.Name = "IsSelected";
                IsSelected.HeaderText = "Selected";
                IsSelected.Width = 100;
                IsSelected.ReadOnly = false;
                IsSelected.TrueValue = "true";
                IsSelected.FalseValue = null;

                dgvPermissions.Columns.Add(IsSelected);

                dgvPermissions.Columns[0].HeaderText = "Permission ID";
                dgvPermissions.Columns[0].Name = "PermissionID";
                dgvPermissions.Columns[0].Width = 125;
                dgvPermissions.Columns[0].ReadOnly = true;


                dgvPermissions.Columns[1].HeaderText = "Permission Number";
                dgvPermissions.Columns[1].Name = "PermissionNumber";

                dgvPermissions.Columns[1].Width = 125;
                dgvPermissions.Columns[1].ReadOnly = true;

                dgvPermissions.Columns[2].HeaderText = "Permission Title";
                dgvPermissions.Columns[2].Width = 375;
                dgvPermissions.Columns[2].ReadOnly = true;

            }

        }
        void _dgvFillUserPermissionsList()
        {
            dtCurrentUserPermissions = clsPermission.GetUserPermissionsList(_UserID);
            int dgvIndexCounter = 0;
            int dtIndexCounter = 0;
            while (dgvPermissions.Rows.Count > dgvIndexCounter && dtCurrentUserPermissions.Rows.Count > dtIndexCounter)
            {
                if (
                    string.Equals(dgvPermissions.Rows[dgvIndexCounter].Cells["PermissionNumber"].Value.ToString(),
                     dtCurrentUserPermissions.Rows[dtIndexCounter]["PermissionNumber"].ToString())
                   )
                {
                   

                    dgvPermissions.Rows[dgvIndexCounter].Cells["IsSelected"].Value = true;

                    dgvIndexCounter++;
                    dtIndexCounter++;
                }
                else
                {
                    dgvIndexCounter++;
                }

            }
        }


        void _dgvFillUserPermissionsList2()
        {
            //dgvPermissions.Rows[0].Cells["IsSelected"].Value = true;
            dtCurrentUserPermissions = clsPermission.GetUserPermissionsList(_UserID);
            int dgvIndexCounter = 0;
            int dtIndexCounter = 0;
           // while (dgvPermissions.Rows.Count > dgvIndexCounter && dtCurrentUserPermissions.Rows.Count > dtIndexCounter)
            //{
               if (
                  int.Parse( dgvPermissions.Rows[dgvIndexCounter].Cells["PermissionNumber"].Value.ToString())
                    == int.Parse(dtCurrentUserPermissions.Rows[dtIndexCounter]["PermissionNumber"].ToString())

                    )
                {
            //        MessageBox.Show(((DataGridViewCheckBoxColumn)dgvPermissions.Columns[3]).TrueValue.ToString());
            //        //dgvPermissions.Rows[0].Cells[3].Value = null;
                    //dgvPermissions.Rows[0].Cells["IsSelected"].Value = true;
                   dgvPermissions.Rows[dgvIndexCounter].Cells["IsSelected"].Value = true;

            //        dgvIndexCounter++;
            //        dtIndexCounter++;
                }
            //    else

            //    // int.Parse(dgvPermissions.Rows[dgvIndexCounter - 1].Cells["Permission Number"].Value.ToString())
            //    //<int.Parse(dtCurrentUserPermissions.Rows[dtIndexCounter - 1]["PermissionNumber"].ToString())

            //    {
            //        dgvIndexCounter++;
            //        // dgvIndexCounter += dtIndexCounter - dgvIndexCounter;
            //    }

            //}

        }

        void _LoadData()
        {
            if (_UserInfo==null)
            {
                MessageBox.Show($"Connot Find User With ID {_UserID}", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _Enable();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_UserInfo.PersonID);
            lblUserID1.Text = _UserID.ToString();
            lblUserID2.Text = _UserID.ToString();
            lblFullName1.Text=_UserInfo.PersonInfo.FullName;
            lblFullName2.Text = _UserInfo.PersonInfo.FullName;
            lblRoleID.Text=_UserInfo.RoleID.ToString();
            lblDepartmentID.Text=_UserInfo.DepartmentID.ToString();
            txtUserName.Text = _UserInfo.UserName;
            txtPassword.Text = _UserInfo.Password;
            cbDepartment.SelectedItem = _UserInfo.UserDepartment.DepartmentName;
            cbRole.SelectedItem = _UserInfo.UserRole.RoleTitle;
            cbIsActive.SelectedItem = _UserInfo.IsActive ? "Yes" : "No";
            //_dgvFillUserPermissionsList();


        }
        void _Enable()
        {
            btnSave.Enabled = true;
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
            txtConfirmPassword.Enabled = true;
            cbDepartment.Enabled = true;
            cbIsActive.Enabled = true;
            cbRole.Enabled = true;
            llShowUserPermissionsList.Enabled = true;
            //_dgvFillPermissionsList();
        }

        void _ResetDefaultValues()
        {
            btnSave.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            cbDepartment.Enabled = false;
            cbIsActive.Enabled = false;
            cbRole.Enabled = false;
            lblUserID1.Text = "[????]";
            lblUserID2.Text = "[????]";
            lblDepartmentID.Text = "[????]";
            lblRoleID.Text = "[????]";
            lblFullName1.Text = "[????]";
            lblFullName2.Text = "[????]";
            dgvPermissions.DataSource = null;
            llShowUserPermissionsList.Enabled = false;
            cbIsActive.SelectedItem = "Yes";
        }
       void _LoadDepartmentsInComboBox()
        {
            DataTable dtDepartmentsList = clsDepartment.GetDepartmentsList();

            for(int i=0;i<dtDepartmentsList.Rows.Count;i++)
            {
                cbDepartment.Items.Add(dtDepartmentsList.Rows[i]["DepartmentName"].ToString());
            }
            if (cbDepartment.Items.Count > 0)
            {
                cbDepartment.SelectedItem = "Emergency Medicine";
            }

        }
       void _LoadRolesInComboBox()
        {
            DataTable dtRolesList = clsRole.GetRolesList();

            for (int i = 0; i < dtRolesList.Rows.Count; i++)
            {
                cbRole.Items.Add(dtRolesList.Rows[i]["RoleTitle"].ToString());
            }
            if (cbRole.Items.Count > 0)
            {
                cbRole.SelectedItem = "Administrator";
            }
        }
        private void frmAddUpdateUserInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadDepartmentsInComboBox();
            _LoadRolesInComboBox();
            if (_Mode==enMode.AddNew)
            {
                lblModeTitle.Text = "Add New User Info";
                this.Text = lblModeTitle.Text+" Screen";
                return;
            }
            lblModeTitle.Text = "Update User Info";
            this.Text = lblModeTitle.Text + " Screen";
            _LoadData();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int PersonID = obj;


            if (PersonID != -1)
            {
                if (clsUser.IsPersonAnUser(PersonID))
                {
                    MessageBox.Show($"Selected Person With ID {PersonID} is already an user", "Not Valide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = false;
                    return;
                }
                _Enable();
                lblFullName1.Text = ctrlPersonCardWithFilter1.PersonInfo.FullName;
                lblFullName2.Text = ctrlPersonCardWithFilter1.PersonInfo.FullName;

            }
            else
            {
                _ResetDefaultValues();
            }

        }
        bool _SavePermissionsData()
        {

            Queue<int> qPermissionIDList = new Queue<int>(dgvPermissions.Rows.Count);

            for (int i = 0; i < dgvPermissions.Rows.Count; i++)
            {
                if (dgvPermissions.Rows[i].Cells["IsSelected"].Value != null && bool.Parse(dgvPermissions.Rows[i].Cells["IsSelected"].Value.ToString()))
                {
                    qPermissionIDList.Enqueue(int.Parse(dgvPermissions.Rows[i].Cells["PermissionID"].Value.ToString()));
                }
            }
            if (qPermissionIDList.Count>0)
            {
                return clsPermission.SaveUserPermission(_UserInfo.UserID,qPermissionIDList);
            }
            return true;
        }


        private void _HandleEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox txtBoxSender = (TextBox)sender;

            e.Cancel = true;

            errorProvider1.SetError(txtBoxSender, "This Field is required");


        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not valid, Check red icons next to the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to save data ??", "Confimation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _UserInfo.PersonID = ctrlPersonCardWithFilter1.PersonID;
                _UserInfo.UserName = txtUserName.Text.Trim();
                _UserInfo.Password = txtPassword.Text.Trim();
                _UserInfo.RoleID = clsRole.FindRoleInfoByRoleTitle(cbRole.SelectedItem.ToString()).RoleID;
                _UserInfo.DepartmentID = clsDepartment.FindDepartmentByName(cbDepartment.SelectedItem.ToString()).DepartmentID;
                _UserInfo.IsActive = cbIsActive.SelectedItem.ToString() == "Yes";
                Queue<int> qPermissionIDList = new Queue<int>();


                if (_UserInfo.Save() && _SavePermissionsData())
                {
                    MessageBox.Show("Data Saved Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _UserID = _UserInfo.UserID;
                    lblDepartmentID.Text = _UserInfo.DepartmentID.ToString();
                    lblRoleID.Text = _UserInfo.RoleID.ToString();
                    lblUserID1.Text = _UserInfo.UserID.ToString();
                    lblUserID2.Text = _UserInfo.UserID.ToString();
                    if (_Mode == enMode.AddNew)
                    {
                        _Mode = enMode.Update;
                        lblModeTitle.Text = "Update User Info";
                        this.Text = lblModeTitle.Text + " Screen";
                        ctrlPersonCardWithFilter1.FilterEnabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Saving Data Failed", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      

        private void llShowUserPermissionsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dgvFillPermissionsList();

            if (_Mode == enMode.Update)
                _dgvFillUserPermissionsList();
            llShowUserPermissionsList.Enabled = false;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                _HandleEmptyTextBox(sender, e);
            else
            {


                if (clsUser.FindUserByUserName(txtUserName.Text.Trim())!=null)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "This username is Used, Choose another one");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, "");
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                _HandleEmptyTextBox(sender, e);
            else
                errorProvider1.SetError(txtPassword, "");


        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
                _HandleEmptyTextBox(sender, e);
            else
            {
                if (!string.Equals(txtPassword.Text.Trim(), txtConfirmPassword.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtConfirmPassword, "This Field Doesn't Mach the entered password");
                }
                else
                    errorProvider1.SetError(txtConfirmPassword, "");
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
