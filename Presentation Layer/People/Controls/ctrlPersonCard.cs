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

namespace HMS.People
{
    public partial class ctrlPersonCard : UserControl
    {
        int _PersonID = -1;
        clsPerson _PersonInfo = null;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson PersonInfo
        {
            get { return _PersonInfo; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        void _ResetDefaultValues()
        {
            _PersonID = -1;
            _PersonInfo = null;
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendorCaption.Text = "[????]";
            llUpdatePersonInfo.Visible = false;
        }
        void _FillPersonInfo()
        {
            lblPersonID.Text=_PersonInfo.ID.ToString();
            lblFullName.Text=_PersonInfo.FullName;
            lblEmail.Text=_PersonInfo.Email;
            lblPhone.Text=_PersonInfo.Phone;
            lblAddress.Text=_PersonInfo.Address;
            lblDateOfBirth.Text=_PersonInfo.DateOfBirth.ToString("dd/M/yyyy");
            lblGendorCaption.Text = _PersonInfo.Gendor == 'M' ? "Male" : "Female";
            lblNationalNo.Text = _PersonInfo.NationalNo;
            llUpdatePersonInfo.Visible = true;
           
        }
        public bool FillPersonInfo(int PersonID)
        {
            _PersonInfo = clsPerson.FindPerson(PersonID);
           
            if (_PersonInfo == null)
            {
                MessageBox.Show($"Connot Find Person With ID [{PersonID}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return false;
            }
            _PersonID = PersonID;
            _FillPersonInfo();
            return true;
        }
        public bool FillPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPerson.FindPerson(NationalNo);
            if (_PersonInfo == null)
            {
                MessageBox.Show($"Connot Find Person With National [{NationalNo}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return false;
            }
            _PersonID=_PersonInfo.ID;
            _FillPersonInfo();
            return true;
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void llUpdatePersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePersonInfo frmAddUpdatePersonInfo = new frmAddUpdatePersonInfo(_PersonID);
            frmAddUpdatePersonInfo.ShowDialog();
            this.FillPersonInfo(_PersonID);
        }
    }
}
