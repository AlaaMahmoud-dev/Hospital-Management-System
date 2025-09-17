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
    public partial class frmShowPatientInfo : Form
    {
        int _PatientID;
        clsPatient _PatientInfo;

        public frmShowPatientInfo(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
            _PatientInfo=clsPatient.FindBYPatientID(PatientID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _LoadData()
        {
            ctrlPatientCard1.LoadPatientInfoByPatientID(_PatientID);
         
        }
        private void frmShowPatientInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
