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
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
      
        

        public int PersonID
        {
            
            get
            {
                return ctrlPersonCard1.PersonID;
            }
        }

        public clsPerson PersonInfo 
        {
            get 
            { 
                return ctrlPersonCard1.PersonInfo; 
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

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cbSearchType.SelectedIndex = 0;
        }

        void _FindNow()
        {
            switch (cbSearchType.SelectedItem)
            {
                case "Person ID":
                     ctrlPersonCard1.FillPersonInfo(int.Parse(txtSearchValue.Text.Trim()));
                    break;
                case "National No":
                     ctrlPersonCard1.FillPersonInfo(txtSearchValue.Text.Trim());
                    break;
                default:
                    break;
            }
           

            if (OnPersonSelected != null && gbFilter.Enabled)
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }

        public bool LoadPersonInfo(int PersonID)
        {
            clsPerson personData = clsPerson.FindPerson(PersonID);
            if (personData != null)
            {
                cbSearchType.SelectedIndex = 0;
                txtSearchValue.Text = personData.NationalNo;
                gbFilter.Enabled = false;
                _FindNow();
                return true;
            }
            else
            {
                MessageBox.Show($"Connot Find Person With ID [{PersonID}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //public bool LoadPersonInfo(string NationalNo)
        //{
        //    clsPerson personData = clsPerson.FindPerson(NationalNo);
        //    if (personData != null)
        //    {
        //        cbSearchType.SelectedIndex = 0;
        //        txtSearchValue.Text = personData.NationalNo;
        //        gbFilter.Enabled = false;
        //        _FindNow();
        //        return true;
        //    }

        //    else
        //    {
        //        MessageBox.Show($"Connot Find Person With National NO [{NationalNo}]", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;

        //    }
        //}

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
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

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.SelectedItem.ToString() == "Person ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
                
            }
            if (!e.Handled)
            {
                if (e.KeyChar == 13)
                    btnSearch_Click(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePersonInfo frmAddPersonInfo = new frmAddUpdatePersonInfo();
            frmAddPersonInfo.DataBack += FrmAddPersonInfo_DataBack;
            frmAddPersonInfo.Show();
        }

        private void FrmAddPersonInfo_DataBack(object sender, int PersonID)
        {
            clsPerson person = clsPerson.FindPerson(PersonID);
            cbSearchType.SelectedItem = "National No";
            txtSearchValue.Text = person.NationalNo;
            _FindNow();
        }

       

    
    }
}
