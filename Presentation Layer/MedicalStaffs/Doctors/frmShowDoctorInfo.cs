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

namespace HMS.MedicalStaffs.Doctors
{
    public partial class frmShowDoctorInfo : Form
    {
        int _DoctorID;
        int _MedicalStaffID;
        int _PersonID;
        clsDoctor _DoctorInfo;

        public frmShowDoctorInfo(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            _DoctorInfo=clsDoctor.FindBYDoctorID(DoctorID);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        bool _IsAvailableInDay(int DayOrder)
        {
            return DayOrder==(DayOrder & _DoctorInfo.AvailabilityOfWeek);
        }
        void _FillWeekDaysAvailableTextBox()
        {
            string strWeekDaysAvailable = "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Sunday) ? "Sunday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Monday) ? "Monday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Tuseday) ? "Tuseday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Wednesday) ? "Wednesday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Thursday) ? "Thursday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Friday) ? "Friday," : "";
            strWeekDaysAvailable += _IsAvailableInDay((int)clsDoctor.enWeekDays.Saturday) ? "Saturday," : "";
            txtAvailabilityOfWeek.Text = strWeekDaysAvailable.Remove(strWeekDaysAvailable.Length - 1, 1);

        }

        void _LoadData()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_DoctorInfo.PersonID);
            lblDoctorID.Text = _DoctorInfo.DoctorID.ToString();
            lblMedicalStaffID.Text = _DoctorInfo.MedicalStaffID.ToString();
            lblDepartmentName.Text=clsDepartment.FindDepartmentByID(_DoctorInfo.DepartmentID).DepartmentName;
            lblPositionTitle.Text = _DoctorInfo.PositionInfo.PositionTitle;
            lblSpecializationTitle.Text=_DoctorInfo.SpecializationInfo.SpecializationTitle;
            lblYearsOfExperience.Text=_DoctorInfo.YearsOfExperience.ToString();
            lblRegisteredByUserName.Text = clsUser.FindUserByUserID(_DoctorInfo.CreatedByUserID).UserName;
            lblCertificates.Text = _DoctorInfo.Certificates.ToString();
            _FillWeekDaysAvailableTextBox();
        }
        private void frmShowDoctorInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
