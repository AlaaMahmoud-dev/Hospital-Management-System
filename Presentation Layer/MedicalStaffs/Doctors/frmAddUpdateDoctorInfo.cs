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
    public partial class frmAddUpdateDoctorInfo : Form
    {
        int _DoctorID;
        clsDoctor _DoctorInfo;

        enum enMode
        {
            AddNew=1,
            Update=2
        }

        enMode _Mode = enMode.AddNew;
        public frmAddUpdateDoctorInfo()
        {
            InitializeComponent();
            _DoctorID = -1;
            _DoctorInfo = new clsDoctor();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateDoctorInfo(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            _DoctorInfo = clsDoctor.FindBYDoctorID(DoctorID);
            _Mode = enMode.Update;
        }

        void _FillAvailabilityOfWeek()
        {
            chkSunday.Checked = (int)clsDoctor.enWeekDays.Sunday == ((int)clsDoctor.enWeekDays.Sunday & _DoctorInfo.AvailabilityOfWeek);
            chkMonday.Checked = (int)clsDoctor.enWeekDays.Monday == ((int)clsDoctor.enWeekDays.Monday & _DoctorInfo.AvailabilityOfWeek);
            chkTuseday.Checked = (int)clsDoctor.enWeekDays.Tuseday == ((int)clsDoctor.enWeekDays.Tuseday & _DoctorInfo.AvailabilityOfWeek);
            chkWednesday.Checked = (int)clsDoctor.enWeekDays.Wednesday == ((int)clsDoctor.enWeekDays.Wednesday & _DoctorInfo.AvailabilityOfWeek);
            chkThursday.Checked = (int)clsDoctor.enWeekDays.Thursday == ((int)clsDoctor.enWeekDays.Thursday & _DoctorInfo.AvailabilityOfWeek);
            chkFriday.Checked = (int)clsDoctor.enWeekDays.Friday == ((int)clsDoctor.enWeekDays.Friday & _DoctorInfo.AvailabilityOfWeek);
            chkSaturday.Checked = (int)clsDoctor.enWeekDays.Saturday == ((int)clsDoctor.enWeekDays.Saturday & _DoctorInfo.AvailabilityOfWeek);
        }

        void _LoadData()
        {
            if (_DoctorInfo == null)
            {
                MessageBox.Show($"Connot Find User With ID {_DoctorID}", "Not Found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _Enable();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_DoctorInfo.PersonID);
            lblDoctorID.Text = _DoctorID.ToString();
            lblMedicalStaffID.Text = _DoctorInfo.MedicalStaffID.ToString();
            lblRegisteredByUserName.Text = clsUser.FindUserByUserID(_DoctorInfo.CreatedByUserID).UserName;
            txtCertificates.Text = _DoctorInfo.Certificates;
            txtYearsOfExperience.Text = _DoctorInfo.YearsOfExperience.ToString();
            cbDepartment.SelectedItem = clsDepartment.FindDepartmentByID(_DoctorInfo.DepartmentID).DepartmentName;
            cbMedicalStaffPosition.SelectedItem = _DoctorInfo.PositionInfo.PositionTitle;
            cbSpecialization.SelectedItem = _DoctorInfo.SpecializationInfo.SpecializationTitle;

            _FillAvailabilityOfWeek();


        }
        void _Enable()
        {
            btnSave.Enabled = true;
          pDoctorInfoConrols.Enabled = true;
        }

        void _ResetDefaultValues()
        {
            btnSave.Enabled = false;
            
            
          pDoctorInfoConrols.Enabled = false;
            lblDoctorID.Text = "[????]";
            lblMedicalStaffID.Text = "[????]";
            lblRegisteredByUserName.Text = "[????]";
            txtCertificates.Text = "";
            txtYearsOfExperience.Text = "";
            cbDepartment.SelectedItem = "Emergency Medicine";
            cbMedicalStaffPosition.SelectedItem = "Consultant";
            cbSpecialization.SelectedItem = "Emergency Medicine";

        }
        void _LoadDepartmentsInComboBox()
        {
            DataTable dtDepartmentsList = clsDepartment.GetDepartmentsList();

            for (int i = 0; i < dtDepartmentsList.Rows.Count; i++)
            {
                cbDepartment.Items.Add(dtDepartmentsList.Rows[i]["DepartmentName"].ToString());
            }
            if (cbDepartment.Items.Count > 0)
            {
                cbDepartment.SelectedItem = "Emergency Medicine";
            }

        }
        void _LoadPositionsInComboBox()
        {
            DataTable dtPositionsList = clsPosition.GetPositionsList();

            for (int i = 0; i < dtPositionsList.Rows.Count; i++)
            {
                cbMedicalStaffPosition.Items.Add(dtPositionsList.Rows[i]["PositionTitle"].ToString());
            }
            if (cbMedicalStaffPosition.Items.Count > 0)
            {
                cbMedicalStaffPosition.SelectedItem = "Consultant";
            }
        }
        void _LoadSpecializationsInComboBox()
        {
            DataTable dtSpicializationsList = clsSpecialization.GetSpecializationsList();

            for (int i = 0; i < dtSpicializationsList.Rows.Count; i++)
            {
                cbSpecialization.Items.Add(dtSpicializationsList.Rows[i]["SpecializationTitle"].ToString());
            }
            if (cbSpecialization.Items.Count > 0)
            {
                cbSpecialization.SelectedItem = "Emergency Medicine";
            }
        }
        private void frmAddUpdateDoctorInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            _LoadDepartmentsInComboBox();
            _LoadPositionsInComboBox();
            _LoadSpecializationsInComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblModeTitle.Text = "Add New Doctor Info";
                this.Text = lblModeTitle.Text + " Screen";
                return;
            }
            lblModeTitle.Text = "Update Doctor Info";
            this.Text = lblModeTitle.Text + " Screen";
            _LoadData();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int PersonID = obj;
            clsMedicalStaff medicalStaffInfo = null;
         

            if (PersonID != -1)
            {
                medicalStaffInfo = clsMedicalStaff.FindBYPersonID(PersonID);
                if (medicalStaffInfo != null)
                {
                    MessageBox.Show("Selected Person is already a medical staff, please select another person",
                           "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _DoctorInfo.PersonID = -1;
                    _ResetDefaultValues();
                    return;

                }
                _DoctorInfo.PersonID = PersonID;
                _Enable();
                
               
            }
            else
            {
                _DoctorInfo.PersonID = -1;
                _ResetDefaultValues();
            }
        }

        int SaveAvailabilityOfWeek()
        {
            int AvailabilityOfWeek= chkSunday.Checked?(int)clsDoctor.enWeekDays.Sunday:0;
             AvailabilityOfWeek += chkMonday.Checked ? (int)clsDoctor.enWeekDays.Monday : 0;
             AvailabilityOfWeek += chkTuseday.Checked ? (int)clsDoctor.enWeekDays.Tuseday : 0;
             AvailabilityOfWeek += chkWednesday.Checked ? (int)clsDoctor.enWeekDays.Wednesday : 0;
             AvailabilityOfWeek += chkThursday.Checked ? (int)clsDoctor.enWeekDays.Thursday : 0;
             AvailabilityOfWeek += chkFriday.Checked ? (int)clsDoctor.enWeekDays.Friday : 0;
            AvailabilityOfWeek += chkSaturday.Checked ? (int)clsDoctor.enWeekDays.Saturday : 0;
            return AvailabilityOfWeek;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not valid, Check red icons next to the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to save data ??", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                _DoctorInfo.PersonID = ctrlPersonCardWithFilter1.PersonID;
                _DoctorInfo.Certificates = txtCertificates.Text.Trim();
                _DoctorInfo.DepartmentID = clsDepartment.FindDepartmentByName(cbDepartment.SelectedItem.ToString()).DepartmentID;
                _DoctorInfo.SpecializationID = clsSpecialization.FindInfoBySpecializationTitle(cbSpecialization.SelectedItem.ToString()).SpecializationID;
                _DoctorInfo.PositionID = clsPosition.FindPositionInfoByTitle(cbMedicalStaffPosition.SelectedItem.ToString()).PositionID;
                _DoctorInfo.YearsOfExperience = short.Parse(txtYearsOfExperience.Text.Trim());
                _DoctorInfo.AvailabilityOfWeek = SaveAvailabilityOfWeek();
                _DoctorInfo.CreatedByUserID=clsGlobal.CurrentUser.UserID;
                


                if (_DoctorInfo.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _DoctorID = _DoctorInfo.DoctorID;
                    lblDoctorID.Text = _DoctorID.ToString();
                    lblMedicalStaffID.Text = _DoctorInfo.MedicalStaffID.ToString();
                    lblRegisteredByUserName.Text = clsGlobal.CurrentUser.UserName.ToString();
                  
                    if (_Mode == enMode.AddNew)
                    {
                        _Mode = enMode.Update;
                        lblModeTitle.Text = "Update Doctor Info";
                        this.Text = lblModeTitle.Text + " Screen";
                        ctrlPersonCardWithFilter1.FilterEnabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Saving Data Failed", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
