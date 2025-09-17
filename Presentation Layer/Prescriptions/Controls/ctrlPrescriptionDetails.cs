using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMS_Business;

namespace HMS.Prescriptions.Controls
{
    public partial class ctrlPrescriptionDetails: UserControl
    {
        clsPrescription _PrescriptionInfo;
        
        public ctrlPrescriptionDetails()
        {
            InitializeComponent();
        }

        void _ResetDefaultValues()
        {

            _PrescriptionInfo = new clsPrescription();
           
            llShowInPatientRecordInfo.Visible = false;
            lblPrescriptionID.Text = "[????]";
            lblHistoryID.Text = "[????]";
            lblPatientFullName.Text = "[????]";
            lblDoctorFullName.Text = "[????]";
            lblStatus.Text = "[????]";
            lblPrescriptionType.Text = "[????]";
            lblCreatedAt.Text = "[????]";
           

        }
        void _FillData()
        {
            
           
            llShowInPatientRecordInfo.Visible = true;
            
            lblPatientFullName.Text = _PrescriptionInfo.HistoryInfo.PatientInfo.PersonInfo.FullName;
            lblDoctorFullName.Text = _PrescriptionInfo.DoctorInfo.PersonInfo.FullName; ;
            lblPrescriptionID.Text = _PrescriptionInfo.PrescriptionID.ToString();
            lblHistoryID.Text = _PrescriptionInfo.HistoryID.ToString();
            lblCreatedAt.Text = _PrescriptionInfo.CreatedAt.ToString("dd/MMM/yyyy");

            switch ((clsPrescription.enStatus)_PrescriptionInfo.Status)
            {
                case clsPrescription.enStatus.New:
                    lblStatus.Text = "New";
                    break;
                case clsPrescription.enStatus.Confirmed:
                    lblStatus.Text = "Confirmed";
                    break;
                case clsPrescription.enStatus.Canceled:
                    lblStatus.Text = "Canceled";
                    break;
                default:
                    lblStatus.Text = "Completed";
                    break;

            }

            switch ((clsPrescription.enPrescriptionType)_PrescriptionInfo.PrescriptionType)
            {
                case clsPrescription.enPrescriptionType.DirectTreatment:
                    lblPrescriptionType.Text = "Direct Treatment";
                    break;
                case clsPrescription.enPrescriptionType.MedicinePrescription:
                    lblPrescriptionType.Text = "Medicine Prescription";
                    break;
                default:
                    lblPrescriptionType.Text = "Test Prescription";
                    break;

            }

        }
        public void LoadData(int PrescriptionID)
        {
            _PrescriptionInfo = clsPrescription.FindBYPrescriptionID(PrescriptionID);

            if (_PrescriptionInfo == null)
            {
                MessageBox.Show($"Cannot Find Record With ID {PrescriptionID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return;
            }
            _FillData();
        }

        private void llShowInPatientRecordInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
