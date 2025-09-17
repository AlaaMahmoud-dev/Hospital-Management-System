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

namespace HMS.Patients.Controls
{
    public partial class ctrlPatientCard : UserControl
    {
        int _PatientID;
        clsPatient _PatientInfo;
        public int PatientID
        {
            get
            {
                return _PatientID;
            }
        }
        public clsPatient PatientInfo
        {
            get { return _PatientInfo; }
        }
        public ctrlPatientCard()
        {
            InitializeComponent();
            _PatientID = -1;
            _PatientInfo = new clsPatient();
        }

        void _ResetDefaultValues()
        {
            _PatientID = -1;
            _PatientInfo = new clsPatient();
            llShowPersonInfo.Visible = false;
            llUpdatePatientInfo.Visible = false;
            lblBloodTypeName.Text = "[????]";
            lblCreatedByUsername.Text = "[????]";
            lblPatientID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblRegistrationDate.Text = "[????]";

        }
        void _FillPatientInfo()
        {
            _PatientID=_PatientInfo.PatientID;
            lblPatientID.Text = _PatientInfo.PatientID.ToString();
            lblFullName.Text = _PatientInfo.PersonInfo.FullName;
            lblNationalNo.Text = _PatientInfo.PersonInfo.NationalNo;
            lblPersonID.Text = _PatientInfo.PersonID.ToString();
            lblBloodTypeName.Text = _PatientInfo.BloodTypeName.ToString();
            lblRegistrationDate.Text = _PatientInfo.RegestrationDate.ToString("dd/M/yyyy");
            lblCreatedByUsername.Text = _PatientInfo.UserInfo.UserName.ToString();
            llShowPersonInfo.Visible = true;
            llUpdatePatientInfo.Visible = true;
        }

        void _FindNow()
        {
            if (_PatientInfo == null)
            {
                _PatientID = -1;
                MessageBox.Show($"Patient was not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return;
            }
            _FillPatientInfo();
        }
        public void LoadPatientInfoByPatientID(int PatientID)
        {
            _PatientInfo = clsPatient.FindBYPatientID(PatientID);

           _FindNow();

        }

        public void LoadPatientInfoByPersonID(int PersonID)
        {
            _PatientInfo = clsPatient.FindBYPersonID(PersonID);
            _FindNow();
        }
        public void LoadPatientInfoByNationalNo(string NationalNo)
        {
            clsPerson personInfo = clsPerson.FindPerson(NationalNo);
            if (personInfo != null)
            { 
                _PatientInfo = clsPatient.FindBYPersonID(personInfo.ID);
                
            }
            else
            {
                _PatientInfo = null;
            }
            _FindNow();
        }

        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(_PatientInfo.PersonID);
            personInfo.ShowDialog();
        }

        private void llUpdatePatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePatientInfo patientInfo = new frmAddUpdatePatientInfo(_PatientID);
            patientInfo.ShowDialog();
            _PatientInfo = clsPatient.FindBYPatientID(_PatientID);
            _FindNow();
        }
    }
}
