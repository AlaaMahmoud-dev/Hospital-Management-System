using HMS.MedicalStaffs.Doctors;
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

namespace HMS.MedicalStaffs
{
    public partial class frmManageDoctors : Form
    {
        DataTable _dtAllDoctorsList;

        public frmManageDoctors()
        {
            InitializeComponent();
            _dtAllDoctorsList = new DataTable();

        }
       
        private void clsManageDoctors_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("Doctor ID");
            cbSearchType.Items.Add("MedicalStaff ID");
            cbSearchType.Items.Add("National No");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Phone");
            cbSearchType.Items.Add("Position");
            cbSearchType.Items.Add("Specialization");
            cbSearchType.Items.Add("Department");
            cbSearchType.SelectedIndex = 0;

            _LoadDoctorsDataInDataGridView();
        }
        void _LoadDoctorsDataInDataGridView()
        {

            _dtAllDoctorsList = clsDoctor.DoctorsList();

            dgvDoctorsList.DataSource = _dtAllDoctorsList;

            if (dgvDoctorsList.Columns.Count > 0)
            {
                dgvDoctorsList.Columns[0].HeaderText = "Doctor ID";
                dgvDoctorsList.Columns[0].Width = 100;


                dgvDoctorsList.Columns[1].HeaderText = "Medical Staff ID";
                dgvDoctorsList.Columns[1].Width = 100;


                dgvDoctorsList.Columns[2].HeaderText = "National No";
                dgvDoctorsList.Columns[2].Width = 150;

                dgvDoctorsList.Columns[3].HeaderText = "Full Name";
                dgvDoctorsList.Columns[3].Width = 300;



                dgvDoctorsList.Columns[4].HeaderText = "Phone";
                dgvDoctorsList.Columns[4].Width = 170;



                dgvDoctorsList.Columns[5].HeaderText = "Position";
                dgvDoctorsList.Columns[5].Width = 200;



                dgvDoctorsList.Columns[6].HeaderText = "Specialization";
                dgvDoctorsList.Columns[6].Width = 200;



                dgvDoctorsList.Columns[7].HeaderText = "Department";
                dgvDoctorsList.Columns[7].Width = 200;
            }
            lblPatientsCount.Text = dgvDoctorsList.Rows.Count.ToString();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text))
                _dtAllDoctorsList.DefaultView.RowFilter = "";

            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";
        }
           
            
        

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Doctor ID":
                    FilterColumn = "DoctorID";
                    break;
                case "Medical Staff ID":
                    FilterColumn = "MedicalStaffID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Position":
                    FilterColumn = "Position";
                    break;                               
                case "Specialization":
                    FilterColumn = "Specialization";
                    break;
                case "Department":
                    FilterColumn = "Department";
                    break;
                default:
                    FilterColumn = "NationalNo";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllDoctorsList.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "DoctorID" || FilterColumn == "MedicalStaffID")
                {

                    _dtAllDoctorsList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllDoctorsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblPatientsCount.Text = dgvDoctorsList.Rows.Count.ToString();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(
             dgvDoctorsList.CurrentRow.Cells["NationalNo"].Value.ToString());
            personInfo.ShowDialog();
            _LoadDoctorsDataInDataGridView();
        }

        private void showDoctorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDoctorInfo DoctorInfo = new frmShowDoctorInfo(
             int.Parse(dgvDoctorsList.CurrentRow.Cells["DoctorID"].Value.ToString()));
            DoctorInfo.ShowDialog();
            _LoadDoctorsDataInDataGridView();
        }

        private void addNewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctorInfo DoctorInfo = new frmAddUpdateDoctorInfo();
            DoctorInfo.ShowDialog();
            _LoadDoctorsDataInDataGridView();
        }

        private void updateDoctorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctorInfo DoctorInfo = new frmAddUpdateDoctorInfo(
            int.Parse(dgvDoctorsList.CurrentRow.Cells["DoctorID"].Value.ToString()));
            DoctorInfo.ShowDialog();
            _LoadDoctorsDataInDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to delete this Doctor??", "Confirmation Message",
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDoctor doctorInfo = clsDoctor.FindBYDoctorID(int.Parse(dgvDoctorsList.CurrentRow.Cells["DoctorID"].Value.ToString()));

                if (doctorInfo.Delete())
                {
                    MessageBox.Show("Doctor was deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadDoctorsDataInDataGridView();

                }
                else
                {
                    MessageBox.Show("You Can't Delete this Doctor due to the data connected to it", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddNewDoctor_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctorInfo addUpdateDoctorInfo = new frmAddUpdateDoctorInfo();
            addUpdateDoctorInfo.ShowDialog();
        }
    }
}
