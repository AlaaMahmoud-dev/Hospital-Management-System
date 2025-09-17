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

namespace HMS
{
    public partial class ctrlInPatientRecordDetails: UserControl
    {
        clsInPatientRecord inPatientRecordInfo;
        clsHistory historyInfo;
        clsPatient patientInfo;
        public ctrlInPatientRecordDetails()
        {
            InitializeComponent();
            inPatientRecordInfo = new clsInPatientRecord();
            historyInfo = new clsHistory();
            patientInfo = new clsPatient();
        }

        private void llShowPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        void _ResetDefaultValues()
        {
            
            inPatientRecordInfo = new clsInPatientRecord();
            historyInfo = new clsHistory();
            patientInfo = new clsPatient();
            llShowPatientInfo.Visible = false;
            llUpdatePatientInfo.Visible = false;
            lblFullName.Text = "[????]";
            lblCreatedByUsername.Text = "[????]";
            lblPatientID.Text = "[????]";
            lblDepartment.Text = "[????]";
            lblHistoryID.Text = "[????]";
            lblLastStatusDate.Text = "[????]";
            lblRegistrationDate.Text = "[????]";
            lblRoomNumber.Text = "[????]";
            lblStatus.Text = "[????]";

        }
        void _FillData()
        {
            historyInfo = clsHistory.FindBYHistoryID(inPatientRecordInfo.HistoryID);
            patientInfo = clsPatient.FindBYPatientID(historyInfo.PatientID);
            clsRoom RoomInfo = clsRoom.FindRoomInfoByID(inPatientRecordInfo.RoomID);
            llShowPatientInfo.Visible = true;
            llUpdatePatientInfo.Visible = true;
            lblFullName.Text = patientInfo.PersonInfo.FullName;
            lblCreatedByUsername.Text = inPatientRecordInfo.UserInfo.UserName;
            lblPatientID.Text = patientInfo.PatientID.ToString();
            lblDepartment.Text = clsDepartment.FindDepartmentByID(RoomInfo.DepartmentID).DepartmentName;
            lblRoomNumber.Text = RoomInfo.RoomNumber;
            
            lblHistoryID.Text = historyInfo.HistoryID.ToString();
            lblLastStatusDate.Text = inPatientRecordInfo.LastStatusDate.ToString("dd/MMM/yyyy");
            lblRegistrationDate.Text = inPatientRecordInfo.CreatedAt.ToString("dd/MMM/yyyy");
            switch(inPatientRecordInfo.Status)
            {
                case clsInPatientRecord.enStatus.New:
                    lblStatus.Text = "New";
                    break;
                case clsInPatientRecord.enStatus.InProgress:
                    lblStatus.Text = "In Progress";
                    break;
                case clsInPatientRecord.enStatus.Canceled:
                    lblStatus.Text = "Canceled";
                    break;
                case clsInPatientRecord.enStatus.Completed:
                    lblStatus.Text = "Completed";
                    break;
                default:
                    lblStatus.Text = "Appointment Marked";
                    break;

            }
        }
        public void LoadData(int InPatientRecordID)
        {
            inPatientRecordInfo = clsInPatientRecord.FindBYRecordID(InPatientRecordID);

            if (inPatientRecordInfo==null)
            {
                MessageBox.Show($"Cannot Find Record With ID {InPatientRecordID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return;
            }
            _FillData();
        }
    }
}
