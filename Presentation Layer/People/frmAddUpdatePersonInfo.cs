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
    public partial class frmAddUpdatePersonInfo : Form
    {


        public delegate void DataBackEventHandler(object sender, int PersonID);


        public event DataBackEventHandler DataBack;


        int _PersonID=-1;
        clsPerson _CurrentPerson=null;
        enum enMode
        {
            AddNew=1,
            Update=2
        }

        enMode _Mode = enMode.Update;
        public frmAddUpdatePersonInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _CurrentPerson = new clsPerson();
        }
        public frmAddUpdatePersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
            _CurrentPerson = clsPerson.FindPerson(PersonID);
        }
       
        void _LoadData()
        {
            if (_CurrentPerson==null)
            {
                MessageBox.Show("Person Was Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text = _PersonID.ToString();
            txtNationalNo.Text = _CurrentPerson.NationalNo;
            txtFirstName.Text = _CurrentPerson.FirstName;
            txtSeconsName.Text = _CurrentPerson.SecondName;
            txtThirdName.Text = _CurrentPerson.ThirdName;
            txtLastName.Text = _CurrentPerson.LastName;
            txtPhone.Text = _CurrentPerson.Phone;
            txtEmail.Text = _CurrentPerson.Email;
            txtAddress.Text = _CurrentPerson.Address;
            dtpDateOfBirth.Value=_CurrentPerson.DateOfBirth;
            if (_CurrentPerson.Gendor=='M')
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
        }
        private void frmAddUpdatePersonInfo_Load(object sender, EventArgs e)
        {

            dtpDateOfBirth.CustomFormat = "dd/M/yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;

            if (_Mode==enMode.Update)
            {
                lblModeTitle.Text = "Update Person Info";
                this.Text = lblModeTitle.Text;
                _LoadData();
                return;
            }
            lblModeTitle.Text = "Add Person Info" ;
            this.Text=lblModeTitle.Text ;

        }
        
       

       

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox txtBoxSender = (TextBox)sender;
            if (string.IsNullOrEmpty(txtBoxSender.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtBoxSender, "This Field is required");
            }
            else
            {
                errorProvider1.SetError(txtBoxSender, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtNationalNo, "This Field is required");
            }
            else
            {
                if (txtNationalNo.Text.Trim()!=_CurrentPerson.NationalNo && clsPerson.IsPersonExistByNationalNo(txtNationalNo.Text.Trim()))
                {
                    e.Cancel = true;

                    errorProvider1.SetError(txtNationalNo, "This NationalNo belongs to another person");
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, "");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not validated, Check red icons next to the fields","Missing Data",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            _CurrentPerson.NationalNo = txtNationalNo.Text.Trim();
            _CurrentPerson.FirstName = txtFirstName.Text.Trim();
            _CurrentPerson.SecondName = txtSeconsName.Text.Trim();
            _CurrentPerson.ThirdName = txtThirdName.Text.Trim();
            _CurrentPerson.LastName = txtLastName.Text.Trim();
            _CurrentPerson.Email = txtEmail.Text.Trim();
            _CurrentPerson.Address = txtAddress.Text.Trim();
            _CurrentPerson.DateOfBirth=dtpDateOfBirth.Value;
            _CurrentPerson.Phone = txtPhone.Text.Trim();
            _CurrentPerson.Gendor = rbMale.Checked ? 'M' : 'F';

            if(_CurrentPerson.Save())
            {
               
                MessageBox.Show("Data Saved Successfully","Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Saving Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Mode==enMode.AddNew)
            {
                _PersonID = _CurrentPerson.ID;
                lblPersonID.Text = _CurrentPerson.ID.ToString();
                _Mode = enMode.Update;
                lblModeTitle.Text = "Update Person Info";
            }
            if (DataBack != null)
                DataBack?.Invoke(this, _PersonID);
        }

        private void rbFemale_Enter(object sender, EventArgs e)
        {
            rbFemale.Checked = true;
        }

        private void rbMale_Enter(object sender, EventArgs e)
        {
            rbMale.Checked = true;

        }
    }
}
