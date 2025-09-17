using HMS.Prescriptions;
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
    public partial class frmHistoryPrescriptionsList: Form
    {
        DataTable _dtAllPrescriptionsList;
        
        int _HistoryID;
        public frmHistoryPrescriptionsList(int HistoryID)
        {
            InitializeComponent();
            _dtAllPrescriptionsList = new DataTable();
            _HistoryID = HistoryID;
        }

        private void frmHistoryPrescriptionsList_Load(object sender, EventArgs e)
        {
            
            _dtAllPrescriptionsList = clsPrescription.GetAllHistoryPrescriptions(_HistoryID);
            dgvPrescriptionslist.DataSource = _dtAllPrescriptionsList;

            if(dgvPrescriptionslist.Rows.Count>0)
            {
                dgvPrescriptionslist.Columns[0].HeaderText = "Prescription ID";
                dgvPrescriptionslist.Columns[0].Width = 100;

                dgvPrescriptionslist.Columns[1].HeaderText = "Patient Name";
                dgvPrescriptionslist.Columns[1].Width = 300;

                dgvPrescriptionslist.Columns[2].HeaderText = "Doctor Name";
                dgvPrescriptionslist.Columns[2].Width = 300;

                dgvPrescriptionslist.Columns[3].HeaderText = "Prescription Type";
                dgvPrescriptionslist.Columns[3].Width = 250;

                dgvPrescriptionslist.Columns[4].HeaderText = "Status";
                dgvPrescriptionslist.Columns[4].Width = 150;

                dgvPrescriptionslist.Columns[5].HeaderText = "Created At";
                dgvPrescriptionslist.Columns[5].Width = 200;
            }
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
                if (clsPrescription.ChangePrescriptionStatus(Convert.ToInt32(dgvPrescriptionslist.CurrentRow.Cells[0].Value), clsPrescription.enStatus.Canceled))
                {
                    MessageBox.Show("Prescription was canceled successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmHistoryPrescriptionsList_Load(null, null);

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
                    frmHistoryPrescriptionsList_Load(null, null);

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
                    frmHistoryPrescriptionsList_Load(null, null);

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

            frmHistoryPrescriptionsList_Load(null, null);
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
