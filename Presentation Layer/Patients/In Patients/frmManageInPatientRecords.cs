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
    public partial class frmManageInPatientRecords: Form
    {
        DataTable _dtAllRecords;
        
        public frmManageInPatientRecords()
        {
            InitializeComponent();
            _dtAllRecords = new DataTable();
            
           
        }
        void _dgvLoadData()
        {
            _dtAllRecords = clsInPatientRecord.GetAllInPatientRecords();
           

            dgvInPatientRecordsList.DataSource = _dtAllRecords;
            if (dgvInPatientRecordsList.Rows.Count > 0)
            {
                dgvInPatientRecordsList.Columns[0].HeaderText = "Record ID";
                dgvInPatientRecordsList.Columns[0].Width = 100;



                dgvInPatientRecordsList.Columns[1].HeaderText = "History ID";
                dgvInPatientRecordsList.Columns[1].Width = 100;



                dgvInPatientRecordsList.Columns[2].HeaderText = "Patient ID";
                dgvInPatientRecordsList.Columns[2].Width = 100;


                dgvInPatientRecordsList.Columns[3].HeaderText = "Full Name";
                dgvInPatientRecordsList.Columns[3].Width = 300;
              

                



                dgvInPatientRecordsList.Columns[4].HeaderText = "Status";
                dgvInPatientRecordsList.Columns[4].Width = 120;



                dgvInPatientRecordsList.Columns[5].HeaderText = "Last Status Date";
                dgvInPatientRecordsList.Columns[5].Width = 180;



                dgvInPatientRecordsList.Columns[6].HeaderText = "Room Number";
                dgvInPatientRecordsList.Columns[6].Width = 150;



                dgvInPatientRecordsList.Columns[7].HeaderText = "Department";
                dgvInPatientRecordsList.Columns[7].Width = 200;


              
            }
            lblInPatientRecordsCount.Text = dgvInPatientRecordsList.Rows.Count.ToString();
        }

        private void frmManageInPatientRecords_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("Record ID");
            cbSearchType.Items.Add("History ID");
            cbSearchType.Items.Add("Patient ID");
            //cbSearchType.Items.Add("National No");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Room");
            cbSearchType.Items.Add("Department");
            cbSearchType.Items.Add("Status");

            cbSearchType.SelectedIndex = 0;
            _dgvLoadData();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = "";
            _dtAllRecords.DefaultView.RowFilter = "";
            lblInPatientRecordsCount.Text = dgvInPatientRecordsList.Rows.Count.ToString();
            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Record ID":
                    FilterColumn = "RecordID";
                    break;
                case "History ID":
                    FilterColumn = "HistoryID";
                    break;
                case "Patient ID":
                    FilterColumn = "PatientID";
                    break;
                //case "National No":
                //    FilterColumn = "NationalNo";
                //    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Room":
                    FilterColumn = "RoomNumber";
                    break;
                case "Department":
                    FilterColumn = "DepartmentName";
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
                _dtAllRecords.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "HistoryID" || FilterColumn == "PatientID" || FilterColumn == "RecordID")
                {

                    _dtAllRecords.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllRecords.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblInPatientRecordsCount.Text = dgvInPatientRecordsList.Rows.Count.ToString();
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newPrescriptionOrTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewPrescription newPrescription = new frmNewPrescription(Convert.ToInt32(dgvInPatientRecordsList.CurrentRow.Cells[1].Value));
            newPrescription.ShowDialog();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.SelectedItem.ToString()=="Record ID"|| cbSearchType.SelectedItem.ToString() == "History ID"||cbSearchType.SelectedItem.ToString() == "Patient ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void showPrescriptionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistoryPrescriptionsList prescriptionsList = new frmHistoryPrescriptionsList(Convert.ToInt32(dgvInPatientRecordsList.CurrentRow.Cells[1].Value));
            prescriptionsList.ShowDialog();
        }
    }
}
