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
using static HMS_Business.clsMedicinePrescription;
using static System.Net.Mime.MediaTypeNames;

namespace HMS
{
    public partial class frmNewPrescription: Form
    {
        DataTable  _dtMedicinesList = clsMedicine.GetAllMedicines();
        DataTable _dtLaboratoryTestsList = clsLaboratoryTest.GetAllTests();
        int _PrescriptionID;
        int _HistoryID;
        clsPrescription _PrescriptionInfo;
        clsHistory _HistoryInfo;

      
        
        public frmNewPrescription(int HistoryID)
        {
            InitializeComponent();
            
            _HistoryID = HistoryID;
            _HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void _LoadData()
        {
            _dtMedicinesList = _dtMedicinesList.DefaultView.ToTable(false, "MedicineID", "MedicineName", "DosageForm", "StockQuantity", "Strength",  "TotalCost");
            _dtLaboratoryTestsList = _dtLaboratoryTestsList.DefaultView.ToTable(false, "TestID", "TestTitle", "TestFees", "Description");
            cbPrescriptionType.Items.Add("Direct Treatment");
            cbPrescriptionType.Items.Add("Medicine Prescription");
            cbPrescriptionType.Items.Add("Test Prescription");
            
            cbPrescriptionType.SelectedIndex = 0;
           

        }
        
        void _dgvFillData()
        {
            dgvSelectedMedicinesOrTestsList.Columns.Clear();

            if (cbPrescriptionType.SelectedIndex==0||cbPrescriptionType.SelectedIndex==1)
            {
                dgvSelectedMedicinesOrTestsList.Columns.Add("MedicineID", "Medicine ID");
                dgvSelectedMedicinesOrTestsList.Columns.Add("MedicineName", "Medicine Name");
                dgvSelectedMedicinesOrTestsList.Columns.Add("Strength", "Strength");
                dgvSelectedMedicinesOrTestsList.Columns.Add("DosageForm", "Dosage Form");
                dgvSelectedMedicinesOrTestsList.Columns.Add("Quantity", "Quantity");
                dgvSelectedMedicinesOrTestsList.Columns.Add("Cost", "Cost");

                dgvMedicinesAndTestsList.DataSource = _dtMedicinesList;

                if (dgvMedicinesAndTestsList.Rows.Count > 0)
                {


                    dgvMedicinesAndTestsList.Columns[0].HeaderText = "Medicine ID";
                    dgvMedicinesAndTestsList.Columns[0].Width = 100;

                    dgvMedicinesAndTestsList.Columns[1].HeaderText = "Medicine Name";
                    dgvMedicinesAndTestsList.Columns[1].Width = 250;

                    dgvMedicinesAndTestsList.Columns[2].HeaderText = "Dosage Form";
                    dgvMedicinesAndTestsList.Columns[2].Width = 200;


                    dgvMedicinesAndTestsList.Columns[3].HeaderText = "Stock Quantity";
                    dgvMedicinesAndTestsList.Columns[3].Width = 100;

                    dgvMedicinesAndTestsList.Columns[4].HeaderText = "Strength";
                    dgvMedicinesAndTestsList.Columns[4].Width = 100;


                    dgvMedicinesAndTestsList.Columns[5].HeaderText = "Cost";
                    dgvMedicinesAndTestsList.Columns[5].Width = 100;

                }

                gbMedicinesAndTestsList.Text = "All Medicines List";
                gbSelectedMedicinesOrTestsList.Text = "Selected Medicines";
                lblSearchType.Text = "Medicine Name:";


            }
            else
            {
                dgvSelectedMedicinesOrTestsList.Columns.Add("TestID", "Test ID");
                dgvSelectedMedicinesOrTestsList.Columns.Add("TestTitle", "Test Title");
                dgvSelectedMedicinesOrTestsList.Columns.Add("TestFees", "Test Fees");
                

                dgvMedicinesAndTestsList.DataSource = _dtLaboratoryTestsList;

                if (dgvMedicinesAndTestsList.Rows.Count > 0)
                {


                    dgvMedicinesAndTestsList.Columns[0].HeaderText = "Test ID";
                    dgvMedicinesAndTestsList.Columns[0].Width = 100;

                    dgvMedicinesAndTestsList.Columns[1].HeaderText = "Test Title";
                    dgvMedicinesAndTestsList.Columns[1].Width = 250;

                    dgvMedicinesAndTestsList.Columns[2].HeaderText = "Test Fees";
                    dgvMedicinesAndTestsList.Columns[2].Width = 120;


                    dgvMedicinesAndTestsList.Columns[3].HeaderText = "Description";
                    dgvMedicinesAndTestsList.Columns[3].Width = 350;

                   

                }

                gbMedicinesAndTestsList.Text = "All Tests List";
                gbSelectedMedicinesOrTestsList.Text = "Selected Tests";
                lblSearchType.Text = "Test Title:";
            }
        }

       

       

        private void cbPrescriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvSelectedMedicinesOrTestsList.Rows.Count>0)
            {
                dgvSelectedMedicinesOrTestsList.Rows.Clear();
            }
            _dgvFillData();
        }

        private void frmNewPrescription_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void llShowPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmShowPatientInfo patientInfo = new frmShowPatientInfo(_HistoryInfo.PatientID);
            patientInfo.ShowDialog();
        }

        private void btnClearAllSelectedList_Click(object sender, EventArgs e)
        {

            if (dgvSelectedMedicinesOrTestsList.Rows.Count > 0)
            {
                dgvSelectedMedicinesOrTestsList.Rows.Clear();
            }
        }

        private void btnDeleteSelectedMedicineOrTest_Click(object sender, EventArgs e)
        {

            if (dgvSelectedMedicinesOrTestsList.Rows.Count > 0&& dgvSelectedMedicinesOrTestsList.CurrentRow!=null)
            {


                int IndexOfSelectedRow = dgvSelectedMedicinesOrTestsList.CurrentRow.Index;
                dgvSelectedMedicinesOrTestsList.Rows.RemoveAt(IndexOfSelectedRow);
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            if (dgvMedicinesAndTestsList.Rows.Count > 0 && dgvMedicinesAndTestsList.CurrentRow != null)
            {
                if (cbPrescriptionType.SelectedIndex==0|| cbPrescriptionType.SelectedIndex == 1)
                {
                    clsMedicine SelectedMedicineInfo = clsMedicine.FindMedicineInfo(Convert.ToInt32(dgvMedicinesAndTestsList.CurrentRow.Cells[0].Value));
                    if (SelectedMedicineInfo!=null)
                    {
                        dgvSelectedMedicinesOrTestsList.Rows.Add(SelectedMedicineInfo.MedicineID, SelectedMedicineInfo.MedicineName, SelectedMedicineInfo.Strength,
                            SelectedMedicineInfo.DosageForm, numericUpDown1.Value, SelectedMedicineInfo.TotalCost);
                    }
                }
                else
                {
                    clsLaboratoryTest SelectedLaboratoryTest = clsLaboratoryTest.FindTestInfo(Convert.ToInt32(dgvMedicinesAndTestsList.CurrentRow.Cells[0].Value));
                    if (SelectedLaboratoryTest != null)
                    {
                        dgvSelectedMedicinesOrTestsList.Rows.Add(SelectedLaboratoryTest.TestID, SelectedLaboratoryTest.TestTitle, SelectedLaboratoryTest.TestFees);
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

          
            if (dgvSelectedMedicinesOrTestsList.Rows.Count<=0)
            {
                if (cbPrescriptionType.SelectedItem.ToString()== "Direct Treatment"|| cbPrescriptionType.SelectedItem.ToString() == "Medicine Prescription")
                {
                    MessageBox.Show("There is no Medicines Selected, Please Select Medicines First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    MessageBox.Show("There is no Tests Selected, Please Select Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }


            clsPrescription prescription = new clsPrescription();
            List<clsMedicinePrescription.stSelectedMedicineInfo> lstSelectedMedicinesInfo = new List<clsMedicinePrescription.stSelectedMedicineInfo>();
            List<int> lstIDs = new List<int>();
            bool isPrescriptionSaved = false;

            bool isMedicinesOrTestsSaved = false;


            prescription.HistoryID = _HistoryID;
            prescription.CreatedByDoctorID = clsDoctor.FindBYMedicalStaffID(clsMedicalStaff.FindBYPersonID(clsGlobal.CurrentUser.PersonID).MedicalStaffID).DoctorID;
            prescription.Status = Convert.ToInt16(clsPrescription.enStatus.New);
            prescription.CreatedAt = DateTime.Now;


            if (cbPrescriptionType.SelectedItem.ToString() == "Direct Treatment")
            {
                prescription.PrescriptionType = Convert.ToInt16(clsPrescription.enPrescriptionType.DirectTreatment);
                
            }
            else if (cbPrescriptionType.SelectedItem.ToString() == "Medicine Prescription")
            {
                prescription.PrescriptionType = Convert.ToInt16(clsPrescription.enPrescriptionType.MedicinePrescription);
            }
            else
            {
                prescription.PrescriptionType = Convert.ToInt16(clsPrescription.enPrescriptionType.TestPrescription);
            }
            isPrescriptionSaved = prescription.Save();

            for (int i = 0; i < dgvSelectedMedicinesOrTestsList.Rows.Count; i++)
            {
                lstIDs.Add(Convert.ToInt32(dgvSelectedMedicinesOrTestsList.Rows[i].Cells[0].Value));
            }
            
            if (cbPrescriptionType.SelectedItem.ToString() == "Direct Treatment" || cbPrescriptionType.SelectedItem.ToString() == "Medicine Prescription")
            {
               
                for (int i = 0; i < dgvSelectedMedicinesOrTestsList.Rows.Count; i++)
                {
                    clsMedicinePrescription.stSelectedMedicineInfo medicineInfo = new clsMedicinePrescription.stSelectedMedicineInfo();
                    medicineInfo.MedicineID = lstIDs[i];
                    medicineInfo.Quantity = Convert.ToInt32(dgvSelectedMedicinesOrTestsList.Rows[i].Cells["Quantity"].Value);
                    lstSelectedMedicinesInfo.Add(medicineInfo);
                }
                isMedicinesOrTestsSaved= clsMedicinePrescription.AddPrescriptionMedicines(prescription.PrescriptionID,lstSelectedMedicinesInfo);
            }
            else
            {
                isMedicinesOrTestsSaved= clsLaboratoryTestPrescription.NewPrescriptionTests(prescription.PrescriptionID, lstIDs);
            }
            





            if (isPrescriptionSaved && isMedicinesOrTestsSaved)
            {
                btnSave.Enabled = false;
                btnDeleteSelectedMedicineOrTest.Enabled = false;
                btnClearAllSelectedList.Enabled = false;
                btnSelectItem.Enabled = false;
                btnShowSelectedItemInfo.Enabled = false;
                MessageBox.Show("Data Saved Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Saving Data Failed", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtLaboratoryTestsList.DefaultView.RowFilter = "";
                _dtMedicinesList.DefaultView.RowFilter = "";
                return;
            }
            string FilterColumn = "";

            switch (cbPrescriptionType.SelectedIndex)
            {
                case 2:
                    FilterColumn = "TestTitle";
                    _dtLaboratoryTestsList.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtSearchValue.Text.Trim());
                    break;
                default:
                    FilterColumn = "MedicineName";
                    _dtMedicinesList.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtSearchValue.Text.Trim());
                    break;
            }
        }
    }
}
