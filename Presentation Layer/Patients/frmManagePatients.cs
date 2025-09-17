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

namespace HMS.Patients
{
    public partial class frmManagePatients : Form
    {

        DataTable _dtAllPatientsList;
     
        public frmManagePatients()
        {
            InitializeComponent();
            _dtAllPatientsList = new DataTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FillBloodTypesInComboBox()
        {
            DataTable dtBloodTypesList = clsPatient.GetBloodTypesList();
            cbBloodTypes.Items.Add("All");
            for (int i = 0; i < dtBloodTypesList.Rows.Count; i++)
            {
                cbBloodTypes.Items.Add(dtBloodTypesList.Rows[i]["BloodTypeName"].ToString());
            }
           
        }
        private void frmManagePatients_Load(object sender, EventArgs e)
        {
          
         
            FillBloodTypesInComboBox();
            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("Patient ID");
            cbSearchType.Items.Add("Person ID");
            cbSearchType.Items.Add("National No");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Phone");
            cbSearchType.Items.Add("Blood Type");
            cbSearchType.SelectedIndex = 0;

            _LoadPatientsDataInDataGridView();
        }

        void _LoadPatientsDataInDataGridView()
        {
            
            _dtAllPatientsList = clsPatient.PatientsList();
            _dtAllPatientsList = _dtAllPatientsList.DefaultView.ToTable(false, "PatientID", "PersonID", "NationalNo",  "FullName",
                "Phone", "BloodTypeName");

            dgvPatientsList.DataSource = _dtAllPatientsList;

            if (dgvPatientsList.Columns.Count > 0)
            {
                dgvPatientsList.Columns[0].HeaderText = "Patient ID";
                dgvPatientsList.Columns[0].Width = 150;


                dgvPatientsList.Columns[1].HeaderText = "Person ID";
                dgvPatientsList.Columns[1].Width = 150;


                dgvPatientsList.Columns[2].HeaderText = "National No";
                dgvPatientsList.Columns[2].Width = 150;

                dgvPatientsList.Columns[3].HeaderText = "Full Name";
                dgvPatientsList.Columns[3].Width = 320;



                dgvPatientsList.Columns[4].HeaderText = "Phone";
                dgvPatientsList.Columns[4].Width = 200;



                dgvPatientsList.Columns[5].HeaderText = "Blood Type";
                dgvPatientsList.Columns[5].Width = 100;



            

            }
            lblPatientsCount.Text = dgvPatientsList.Rows.Count.ToString();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(txtSearchValue.Text))
                _dtAllPatientsList.DefaultView.RowFilter = "";

            if (cbSearchType.SelectedItem.ToString() == "None")
            {
                cbBloodTypes.Visible = false;
                txtSearchValue.Visible = false;

            }
            else
            {
                if (cbSearchType.SelectedItem.ToString() == "Blood Type")

                {
                    cbBloodTypes.Visible = true;
                    txtSearchValue.Visible = false;
                    cbBloodTypes.SelectedIndex = 0;
                }
                else
                {
                    cbBloodTypes.Visible = false;
                    txtSearchValue.Visible = true;
                }
            }
        }

        private void cbBloodTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbBloodTypes.SelectedItem.ToString() == "All")
            {
                _dtAllPatientsList.DefaultView.RowFilter = "";
            }
           
            else
            {
                _dtAllPatientsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}'", "BloodTypeName", cbBloodTypes.Text);
            }
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Patient ID":
                    FilterColumn = "PatientID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
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
                case "Blood Type":
                    FilterColumn = "BloodTypeName";
                    break;
                default:
                    FilterColumn = "NationalNo";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllPatientsList.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "PatientID" || FilterColumn == "PersonID")
                {

                    _dtAllPatientsList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllPatientsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblPatientsCount.Text = dgvPatientsList.Rows.Count.ToString();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.Text == "Person ID" || cbSearchType.Text == "Patient ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(
             int.Parse(dgvPatientsList.CurrentRow.Cells["PersonID"].Value.ToString()));
            personInfo.ShowDialog();
            _LoadPatientsDataInDataGridView();
        }

        private void showPatientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPatientInfo patientInfo = new frmShowPatientInfo(
            int.Parse(dgvPatientsList.CurrentRow.Cells["PatientID"].Value.ToString()));
            patientInfo.ShowDialog();
            _LoadPatientsDataInDataGridView();
        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatientInfo patientInfo = new frmAddUpdatePatientInfo();
            patientInfo.ShowDialog();
            _LoadPatientsDataInDataGridView();
        }

        private void updatePatientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatientInfo patientInfo = new frmAddUpdatePatientInfo(
       int.Parse(dgvPatientsList.CurrentRow.Cells["PatientID"].Value.ToString()));
            patientInfo.ShowDialog();
            _LoadPatientsDataInDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to delete this patient??", "Confirmation Message",
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(int.Parse(dgvPatientsList.CurrentRow.Cells["PatientID"].Value.ToString())))
                {
                    MessageBox.Show("Patient was deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadPatientsDataInDataGridView();

                }
                else
                {
                    MessageBox.Show("You Can't Delete this Patient due to the data connected to it", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatientInfo addUpdatePatientInfoScreen = new frmAddUpdatePatientInfo();
            addUpdatePatientInfoScreen.ShowDialog();
        }
    }
}
