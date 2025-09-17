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
    public partial class ctrlPatientCardWithFilter : UserControl
    {
        public event Action<int> OnPatientSelected;

        clsPatient _PatientInfo;
         public int PatientID
        {

            get
            {
                return ctrlPatientCard1.PatientID;
            }
        }

        public clsPatient PatientInfo
        {
            get
            {
                return ctrlPatientCard1.PatientInfo;
            }
        }

        public bool FilterEnabled
        {
            set
            {
                gbFilter.Enabled = value;
            }
            get
            {
                return gbFilter.Enabled;
            }
        }

        public ctrlPatientCardWithFilter()
        {
            InitializeComponent();
            _PatientInfo = new clsPatient();
            cbSearchType.SelectedIndex = 0;
        }

        void _FindNow()
        {
            switch (cbSearchType.SelectedItem)
            {
                case "Person ID":
                    ctrlPatientCard1.LoadPatientInfoByPersonID(int.Parse(txtSearchValue.Text.Trim()));
                    break;
                case "Patient ID":
                    ctrlPatientCard1.LoadPatientInfoByPatientID(int.Parse(txtSearchValue.Text.Trim()));
                    break;
                case "National No":
                    ctrlPatientCard1.LoadPatientInfoByNationalNo(txtSearchValue.Text.Trim());
                    break;
                default:
                    break;
            }


            if (OnPatientSelected != null && gbFilter.Enabled)
                OnPatientSelected(ctrlPatientCard1.PatientID);
        }
      
      

        bool _LoadData()
        {
            if (_PatientInfo != null)
            {
                cbSearchType.SelectedIndex = 0;
                txtSearchValue.Text = _PatientInfo.PersonInfo.NationalNo;
                gbFilter.Enabled = false;
                _FindNow();
                return true;
            }
            else
            {
                MessageBox.Show($"Connot Find Patient With ID [{PatientID}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool LoadPatientInfoByPatientID(int PatientID)
        {
           _PatientInfo = clsPatient.FindBYPatientID(PatientID);
           return _LoadData();
        }
        public bool LoadPatientInfoByPersonID(int PersonID)
        {
            _PatientInfo=clsPatient.FindBYPersonID(PersonID);
            return _LoadData();
        }
       

      

       
      
       

        private void FrmAddPatientInfo_DataBack(object sender, int PatientID)
        {
            clsPatient patientInfo = clsPatient.FindBYPatientID(PatientID);
            cbSearchType.SelectedItem = "National No";
            txtSearchValue.Text = patientInfo.PersonInfo.NationalNo;
            _FindNow();
        }

        private void txtSearchValue_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text.Trim()))
            {
                btnSearch.Enabled = false;

            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void txtSearchValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (cbSearchType.SelectedItem.ToString() == "Person ID" || cbSearchType.SelectedItem.ToString() == "Patient ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

            }
            if (!e.Handled)
            {
                if (e.KeyChar == 13)
                    btnSearch_Click_1(null, null);
            }
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatientInfo addPatientInfo = new frmAddUpdatePatientInfo();
            addPatientInfo.OnPatientAdded += FrmAddPatientInfo_DataBack;
            addPatientInfo.Show();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            _FindNow();
        }
    }
}

