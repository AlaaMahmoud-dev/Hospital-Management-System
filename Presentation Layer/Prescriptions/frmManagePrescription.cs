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
    public partial class frmManagePrescription: Form
    {
        int _PrescriptionID;
        clsPrescription _PrescriptionInfo;
        public frmManagePrescription(int PrescriptionID)
        {
            InitializeComponent();
            _PrescriptionID = PrescriptionID;
            _PrescriptionInfo = clsPrescription.FindBYPrescriptionID(PrescriptionID);
        }
        void _FillPrescriptionTests()
        {
            DataTable dtTestsList = clsLaboratoryTestPrescription.GetPrescriptionTestsList(_PrescriptionID);
            dgvTestsList.DataSource = dtTestsList;

            if (dgvTestsList.Rows.Count > 0)
            {
                dgvTestsList.Columns[0].HeaderText = "Test ID";
                dgvTestsList.Columns[0].Width = 100;

                dgvTestsList.Columns[1].HeaderText = "Test Title";
                dgvTestsList.Columns[1].Width = 200;

                dgvTestsList.Columns[2].HeaderText = "Test Fees";
                dgvTestsList.Columns[2].Width = 100;

                dgvTestsList.Columns[3].HeaderText = "Description";
                dgvTestsList.Columns[3].Width = 300;
            }
        }

        void _FillPrescriptionMedicines()
        {
            DataTable dtmedicinesList = clsMedicinePrescription.GetPrescriptionMedicinesList(_PrescriptionID);
            dgvMedicinesList.DataSource = dtmedicinesList;

            if (dgvMedicinesList.Rows.Count > 0)
            {
                dgvMedicinesList.Columns[0].HeaderText = "Medicine ID";
                dgvMedicinesList.Columns[0].Width = 100;

                dgvMedicinesList.Columns[1].HeaderText = "Medicine Name";
                dgvMedicinesList.Columns[1].Width = 150;

                dgvMedicinesList.Columns[2].HeaderText = "Dosage Form";
                dgvMedicinesList.Columns[2].Width = 120;

                dgvMedicinesList.Columns[3].HeaderText = "Strength";
                dgvMedicinesList.Columns[3].Width = 100;

                dgvMedicinesList.Columns[4].HeaderText = "Cost";
                dgvMedicinesList.Columns[4].Width = 100;

                dgvMedicinesList.Columns[5].HeaderText = "Quantity";
                dgvMedicinesList.Columns[5].Width = 90;

                dgvMedicinesList.Columns[6].HeaderText = "IsConfirmed";
                dgvMedicinesList.Columns[6].Width = 90;
                
            }
        }
        private void cmsMedicinesManager_Opening(object sender, CancelEventArgs e)
        {
            confirmToolStripMenuItem.Enabled = !(cancelToolStripMenuItem.Enabled = clsMedicinePrescription.IsConfirmed(_PrescriptionID,
                Convert.ToInt32(dgvMedicinesList.CurrentRow.Cells[0].Value)));
        }

        private void frmManagePrescription_Load(object sender, EventArgs e)
        {
            ctrlPrescriptionDetails1.LoadData(_PrescriptionID);
            if (_PrescriptionInfo != null)
            {
                switch ((clsPrescription.enPrescriptionType)_PrescriptionInfo.PrescriptionType)
                {
                    case clsPrescription.enPrescriptionType.TestPrescription:
                        _FillPrescriptionTests();
                        break;
                    default:
                        _FillPrescriptionMedicines();
                        break;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            clsInvoice newInvoice = new clsInvoice();
            newInvoice.HistoryID = _PrescriptionInfo.HistoryID;
            newInvoice.Discount = 0.0f;
            newInvoice.IsPaid = false;

            switch ((clsPrescription.enPrescriptionType)_PrescriptionInfo.PrescriptionType)
            {
                case clsPrescription.enPrescriptionType.TestPrescription:
                    newInvoice.InvoiceReason = Convert.ToInt16(clsInvoice.enInvoiceReason.TestPrescription);
                    
                    newInvoice.Fees=clsLaboratoryTestPrescription.GetTestsPrescriptionFees(_PrescriptionID);
                    break;
                case clsPrescription.enPrescriptionType.DirectTreatment:
                    newInvoice.InvoiceReason = Convert.ToInt16(clsInvoice.enInvoiceReason.DirectTreatment);
                    newInvoice.Fees = clsMedicinePrescription.GetMedicinePrescriptionFees(_PrescriptionID);
                    break;

                default:
                    newInvoice.InvoiceReason = Convert.ToInt16(clsInvoice.enInvoiceReason.MedicinePrescription);
                    newInvoice.Fees = clsMedicinePrescription.GetMedicinePrescriptionFees(_PrescriptionID);
                    break;
            }

            newInvoice.TotalAmount = newInvoice.Fees - (newInvoice.Discount * newInvoice.Fees);

            bool isChanged = clsPrescription.ChangePrescriptionStatus(_PrescriptionID, clsPrescription.enStatus.Confirmed);
            
            if (newInvoice.Save()&& isChanged)
            {
                MessageBox.Show($"Prescription confirmed successfully and new Invoice Created with ID {newInvoice.InvoiceID}", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Saving Data Failed", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnConfirm.Enabled = false;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMedicinePrescription.ChangeMedicineStatusInPrescription(_PrescriptionID, Convert.ToInt32(dgvMedicinesList.CurrentRow.Cells[0].Value),
                clsMedicinePrescription.enConfirmedOrNot.NotConfirmed);
            _FillPrescriptionMedicines();

        }

        private void confirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMedicinePrescription.ChangeMedicineStatusInPrescription(_PrescriptionID, Convert.ToInt32(dgvMedicinesList.CurrentRow.Cells[0].Value),
                clsMedicinePrescription.enConfirmedOrNot.Confirmed);
            _FillPrescriptionMedicines();
        }
    }
}
