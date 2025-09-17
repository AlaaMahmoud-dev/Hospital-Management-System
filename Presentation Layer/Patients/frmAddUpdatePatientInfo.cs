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

namespace HMS.Patients
{
    public partial class frmAddUpdatePatientInfo : Form
    {
        public delegate void DataBackEventHandler(object sender,int PatientID);

        public event DataBackEventHandler OnPatientAdded; 

        int _PatientID;

        clsPatient _PatientInfo;

        enum enMode
        {
            AddNew=1,
            Update=2
        }

        enMode _Mode = enMode.AddNew;
        public frmAddUpdatePatientInfo(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
            _PatientInfo=clsPatient.FindBYPatientID(PatientID);
            _Mode = enMode.Update;
        }
        public frmAddUpdatePatientInfo()
        {
            InitializeComponent();
            _PatientID = -1;
            _PatientInfo = new clsPatient();
            _Mode = enMode.AddNew;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _LoadData()
        {
            if (_PatientInfo == null)
            {
                MessageBox.Show($"Connot Find Patient With ID {_PatientID}", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _Enable();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PatientInfo.PersonID);
            lblPatientID.Text = _PatientID.ToString();
            lblRegistrationDate.Text = _PatientInfo.RegestrationDate.ToString("dd,M,yyyy");
            lblCreatedByUsername.Text = _PatientInfo.UserInfo.UserName;
            cbBloodTypes.SelectedItem = _PatientInfo.BloodTypeName;


        }
        void _Enable()
        {
            btnSave.Enabled = true;
          gbPatientInfo.Enabled = true;
        }

        void _ResetDefaultValues()
        {
            
            btnSave.Enabled = false;
            gbPatientInfo.Enabled = false;
           
            lblCreatedByUsername.Text = "[????]";
            lblPatientID.Text = "[????]";
            lblRegistrationDate.Text = "[????]";
            
        }
        void _LoadBloodTypesInComboBox()
        {
            DataTable dtBloodTypesList = clsPatient.GetBloodTypesList();

            for (int i = 0; i < dtBloodTypesList.Rows.Count; i++)
            {
                cbBloodTypes.Items.Add(dtBloodTypesList.Rows[i]["BloodTypeName"].ToString());
            }
            if (cbBloodTypes.Items.Count > 0)
            {
                cbBloodTypes.SelectedItem = "AB+";
            }

        }
     
        private void frmAddUpdatePatientInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadBloodTypesInComboBox();
          
            if (_Mode == enMode.AddNew)
            {
                lblModeTitle.Text = "Add New Patient Info";
                this.Text = lblModeTitle.Text + " Screen";
                return;
            }
            lblModeTitle.Text = "Update Patient Info";
            this.Text = lblModeTitle.Text + " Screen";
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not valid, Check red icons next to the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to save data ??", "Confimation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _PatientInfo.BloodTypeName = cbBloodTypes.Text;
                _PatientInfo.BloodTypeID = clsPatient.GetBloodTypeIDByName(cbBloodTypes.SelectedItem.ToString());
                _PatientInfo.RegestrationDate = DateTime.Now;
                _PatientInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
             
                if (_PatientInfo.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _PatientID = _PatientInfo.PatientID;
                    lblCreatedByUsername.Text=clsGlobal.CurrentUser.UserName;
                    lblRegistrationDate.Text = DateTime.Now.ToString("dd/M/yyyy");


                }
                if(_Mode==enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    ctrlPersonCardWithFilter1.FilterEnabled = false;
                    lblPatientID.Text = _PatientID.ToString();
                    lblModeTitle.Text = "Update Patient Info";
                    this.Text=lblModeTitle.Text+" Screen";
                    if (OnPatientAdded!=null)
                    {
                        OnPatientAdded(this, _PatientID);
                    }
                }
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int PersonID = obj;
            if (clsPerson.FindPerson(PersonID)!=null)
            {
                if (clsPatient.FindBYPersonID(PersonID)!=null)
                {
                    MessageBox.Show($"Selected Person With ID {PersonID} is already a patient","Not Valide",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    _PatientInfo.PersonID = -1;
                    
                    return;
                }
                _PatientInfo.PersonID=PersonID;
                _Enable();
            }


        }
    }
}
