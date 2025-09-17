using HMS.People;
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
    public partial class frmManageUsers : Form
    {

        DataTable _dtAllUsersList;
        public frmManageUsers()
        {
            InitializeComponent();
            _dtAllUsersList = new DataTable();
        }

     
     
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
           
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");
            cbIsActive.SelectedIndex = 0;

            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("User ID");
            cbSearchType.Items.Add("Person ID");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Username");
            cbSearchType.Items.Add("Role");
            cbSearchType.Items.Add("Department");
            cbSearchType.Items.Add("Active or not");
            cbSearchType.SelectedIndex = 0;

            _LoadUsersDataInDataGridView();
           


        }
        void _LoadUsersDataInDataGridView()
        {
            _dtAllUsersList = clsUser.UsersList();
            _dtAllUsersList = _dtAllUsersList.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", 
                "UserName", "RoleTitle", "DepartmentName", "IsActive");

            dgvUsersList.DataSource = _dtAllUsersList;

            if (dgvUsersList.Columns.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 100;


                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 100;


                dgvUsersList.Columns[2].HeaderText = "Full Name";
                dgvUsersList.Columns[2].Width = 320;



                dgvUsersList.Columns[3].HeaderText = "Username";
                dgvUsersList.Columns[3].Width = 150;



                dgvUsersList.Columns[4].HeaderText = "User Role";
                dgvUsersList.Columns[4].Width = 160;



                dgvUsersList.Columns[5].HeaderText = "Department";
                dgvUsersList.Columns[5].Width = 200;


                dgvUsersList.Columns[6].HeaderText = "Is Active";
                dgvUsersList.Columns[6].Width = 100;

            }
            lblUsersCount.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = "";
            if (cbSearchType.SelectedItem.ToString() == "None")
            {
                cbIsActive.Visible = false;
                txtSearchValue.Visible = false;

            }
            else
            {
                if (cbSearchType.SelectedItem.ToString() == "Active or not")

                {
                    cbIsActive.Visible = true;
                    txtSearchValue.Visible = false;
                    cbIsActive.SelectedIndex = 0;
                }
                else
                {
                    cbIsActive.Visible = false;
                    txtSearchValue.Visible = true;
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem.ToString()=="All")
            {
                _dtAllUsersList.DefaultView.RowFilter = "";
            }
            else if(cbIsActive.SelectedItem.ToString() == "Yes")
            {
                _dtAllUsersList.DefaultView.RowFilter = "IsActive=1";
            }
            else
            {
                _dtAllUsersList.DefaultView.RowFilter = "IsActive=0";
            }
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn="None";
            switch(cbSearchType.Text)
            {
                case "None":
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "UserName";
                    break;
                case "Role":
                    FilterColumn = "RoleTitle";
                    break;
                case "Department":
                    FilterColumn = "DepartmentName";
                    break;
                default:
                    FilterColumn = "UserID";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllUsersList.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn=="UserID"||FilterColumn=="PersonID")
                {
                    
                    _dtAllUsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblUsersCount.Text = dgvUsersList.Rows.Count.ToString();

        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.Text=="Person ID"|| cbSearchType.Text == "User ID")
            {
                e.Handled=(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar));
            }
        }

        private void btnAddNewUser_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateUserInfo addNewUserInfo = new frmAddUpdateUserInfo();
            addNewUserInfo.Show();
            _LoadUsersDataInDataGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(
                int.Parse(dgvUsersList.CurrentRow.Cells["PersonID"].Value.ToString()));
            personInfo.ShowDialog();
            _LoadUsersDataInDataGridView();
        }

        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo showUserInfo = new frmShowUserInfo(
                int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString()));
            showUserInfo.ShowDialog();
            _LoadUsersDataInDataGridView();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUserInfo newUserInfo = new frmAddUpdateUserInfo();
            newUserInfo.Show();
            _LoadUsersDataInDataGridView();
        }

        private void updateUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUserInfo updateUserInfo = new frmAddUpdateUserInfo(
                int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString()));
            updateUserInfo.Show();
            _LoadUsersDataInDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to delete this user??", "Confirmation Message",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(int.Parse(dgvUsersList.CurrentRow.Cells["UserID"].Value.ToString())))
                {
                    MessageBox.Show("User was deleted successfully","Deleted",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadUsersDataInDataGridView();

                }
                else
                {
                    MessageBox.Show("You Can't Delete this User due to the data connected to it","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be available soon");

        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be available soon");
        }
    }
}
