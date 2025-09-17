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

namespace HMS.Prescriptions
{
    public partial class frmManagePrescriptionsList: Form
    {
        DataTable _dtAllPrescriptionsList;

        
        public frmManagePrescriptionsList()
        {

            InitializeComponent();
            _dtAllPrescriptionsList = new DataTable();
        }

        private void frmManagePrescriptionsList_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.Clear();


            cbSearchType.Items.Add("None");

            cbSearchType.Items.Add("Prescription ID");
            cbSearchType.Items.Add("History ID");

           
            cbSearchType.Items.Add("Full Name");

            cbSearchType.Items.Add("Creation Date");
            cbSearchType.SelectedItem = "None";

            _dtAllPrescriptionsList = clsPrescription.GetAllPrescriptions();
            dgvPrescriptionslist.DataSource = _dtAllPrescriptionsList;

            if (dgvPrescriptionslist.Rows.Count > 0)
            {
                dgvPrescriptionslist.Columns[0].HeaderText = "Prescription ID";
                dgvPrescriptionslist.Columns[0].Width = 100;

                dgvPrescriptionslist.Columns[1].HeaderText = "History ID";
                dgvPrescriptionslist.Columns[1].Width = 100;

                dgvPrescriptionslist.Columns[2].HeaderText = "Patient Name";
                dgvPrescriptionslist.Columns[2].Width = 300;

                dgvPrescriptionslist.Columns[3].HeaderText = "Doctor Name";
                dgvPrescriptionslist.Columns[3].Width = 300;

                dgvPrescriptionslist.Columns[4].HeaderText = "Prescription Type";
                dgvPrescriptionslist.Columns[4].Width = 250;

                dgvPrescriptionslist.Columns[5].HeaderText = "Status";
                dgvPrescriptionslist.Columns[5].Width = 150;

                dgvPrescriptionslist.Columns[6].HeaderText = "Created At";
                dgvPrescriptionslist.Columns[6].Width = 200;
            }
            lblPrescriptionsCount.Text = dgvPrescriptionslist.Rows.Count.ToString();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPrescriptionInfo prescriptionInfo = new frmShowPrescriptionInfo(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value));
            prescriptionInfo.ShowDialog();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to cancel the selected prescription??", "Confirmation Message",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPrescription.ChangePrescriptionStatus(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value),clsPrescription.enStatus.Canceled))
                {
                    MessageBox.Show("Prescription was canceled successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManagePrescriptionsList_Load(null, null);

                }
                else
                {
                    MessageBox.Show("cancel process failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to delete the selected prescription??", "Confirmation Message",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPrescription.DeletePrescription(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Prescription was deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManagePrescriptionsList_Load(null,null);

                }
                else
                {
                    MessageBox.Show("You can't delete this prescription, due to the data connected to it", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to submit the selected prescription??", "Confirmation Message",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPrescription.ChangePrescriptionStatus(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value), clsPrescription.enStatus.Submitted))
                {
                    MessageBox.Show("Prescription was Submitted successfully", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManagePrescriptionsList_Load(null, null);

                }
                else
                {
                    MessageBox.Show("submit process failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePrescription managePrescription = new frmManagePrescription(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value));
            managePrescription.ShowDialog();

            frmManagePrescriptionsList_Load(null, null);
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text))
                _dtAllPrescriptionsList.DefaultView.RowFilter = "";
            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";


        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Prescription ID":
                    FilterColumn = "PrescriptionID";
                    break;
                case "History ID":
                    FilterColumn = "HistoryID";
                    break;
                case "Full Name":
                    FilterColumn = "PatientName";
                    break;
                default:
                    FilterColumn = "CreatedAt";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllPrescriptionsList.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "CreatedAt")
                {
                    _dtAllPrescriptionsList.DefaultView.RowFilter = string.Format("CONVERT([{0}], System.String) LIKE '{1}%'",
                       FilterColumn, txtSearchValue.Text.Trim());
                }
                else if (FilterColumn == "PrescriptionID" || FilterColumn == "HistoryID")
                {

                    _dtAllPrescriptionsList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllPrescriptionsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblPrescriptionsCount.Text = dgvPrescriptionslist.Rows.Count.ToString();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.Text == "Prescription ID" || cbSearchType.Text == "History ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PrescriptionID = Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value);
            clsPrescription PrescriptionInfo = clsPrescription.FindBYPrescriptionID(PrescriptionID);

            if ((clsPrescription.enStatus)PrescriptionInfo.Status == clsPrescription.enStatus.New)
            {
                cancelToolStripMenuItem.Enabled = true;
                manageToolStripMenuItem.Enabled = true;
                submitToolStripMenuItem.Enabled = false;
            }
            else if ((clsPrescription.enStatus)PrescriptionInfo.Status == clsPrescription.enStatus.Confirmed)
            {
                cancelToolStripMenuItem.Enabled = false;
                manageToolStripMenuItem.Enabled = false;
                submitToolStripMenuItem.Enabled = true;
            }

        }
    }
    
}
