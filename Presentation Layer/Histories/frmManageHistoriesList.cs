using HMS.Patients;
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
    public partial class frmManageHistoriesList: Form
    {

        DataTable _dtAllHistories;
        DataTable _dtHistoriesList;
        public frmManageHistoriesList()
        {
            InitializeComponent();
            _dtAllHistories = new DataTable();
            _dtHistoriesList = new DataTable();

        }

        void _dgvLoadData()
        {
            _dtAllHistories = clsHistory.GetAllHistories();
            _dtHistoriesList = _dtAllHistories.DefaultView.ToTable(false, "HistoryID", "PatientID", "NationalNo",
                 "FullName", "CreatedAt", "CreatedBy", "Status", "LastStatusDate");

            dgvHistoriesList.DataSource = _dtHistoriesList;
            if (dgvHistoriesList.Rows.Count > 0)
            {
                dgvHistoriesList.Columns[0].HeaderText = "History ID";
                dgvHistoriesList.Columns[0].Width = 100;


                dgvHistoriesList.Columns[1].HeaderText = "Patient ID";
                dgvHistoriesList.Columns[1].Width = 100;


                dgvHistoriesList.Columns[2].HeaderText = "National No";
                dgvHistoriesList.Columns[2].Width = 120;

                dgvHistoriesList.Columns[3].HeaderText = "Full Name";
                dgvHistoriesList.Columns[3].Width = 300;



                dgvHistoriesList.Columns[4].HeaderText = "Created At";
                dgvHistoriesList.Columns[4].Width = 180;



                dgvHistoriesList.Columns[5].HeaderText = "Created By";
                dgvHistoriesList.Columns[5].Width = 180;



                dgvHistoriesList.Columns[6].HeaderText = "Status";
                dgvHistoriesList.Columns[6].Width = 100;



                dgvHistoriesList.Columns[7].HeaderText = "Last Status Date";
                dgvHistoriesList.Columns[7].Width = 180;
            }
            lblHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
        }
        private void frmManageHistoriesList_Load(object sender, EventArgs e)
        {

            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("History ID");
            cbSearchType.Items.Add("Patient ID");
            cbSearchType.Items.Add("National No");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Username");
            cbSearchType.Items.Add("Status");
            
            cbSearchType.SelectedIndex = 0;
            _dgvLoadData();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = "";
            _dtHistoriesList.DefaultView.RowFilter = "";
            lblHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";

        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "History ID":
                    FilterColumn = "HistoryID";
                    break;
                case "Patient ID":
                    FilterColumn = "PatientID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "CreatedBy";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtHistoriesList.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "HistoryID" || FilterColumn == "PatientID")
                {

                    _dtHistoriesList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtHistoriesList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.SelectedItem.ToString()=="History ID" || cbSearchType.SelectedItem.ToString() == "Patient ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void initialDiagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewDiagnosis newDiagnosis = new frmAddNewDiagnosis(int.Parse(dgvHistoriesList.CurrentRow.Cells[0].Value.ToString()));
            newDiagnosis.ShowDialog();
        }

        private void showPatientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmShowPatientInfo patientInfo = new frmShowPatientInfo(int.Parse(dgvHistoriesList.CurrentRow.Cells[1].Value.ToString()));
            patientInfo.ShowDialog();
        }
    }
}
