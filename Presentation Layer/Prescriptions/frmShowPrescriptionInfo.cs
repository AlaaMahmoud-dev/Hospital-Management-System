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
    public partial class frmShowPrescriptionInfo: Form
    {
        int _PrescriptionID;
        clsPrescription _PrescriptionInfo;
        public frmShowPrescriptionInfo(int PrescriptionID)
        {
            InitializeComponent();
            _PrescriptionID = PrescriptionID;
            _PrescriptionInfo = clsPrescription.FindBYPrescriptionID(PrescriptionID);
        }
        void _FillPrescriptionTests()
        {
            DataTable dtTestsList = clsLaboratoryTestPrescription.GetPrescriptionTestsList(_PrescriptionID);
            dgvTestsList.DataSource = dtTestsList;

            if (dgvTestsList.Rows.Count>0)
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
                
            }
        }
        private void frmShowPrescriptionInfo_Load(object sender, EventArgs e)
        {
            ctrlPrescriptionDetails1.LoadData(_PrescriptionID);
            if (_PrescriptionInfo!=null)
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
    }
}
