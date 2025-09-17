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
    public partial class frmShowPersonInfo : Form
    {
        int _PersonID;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            _PersonID = clsPerson.FindPerson(NationalNo).ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
        }
    }
}
