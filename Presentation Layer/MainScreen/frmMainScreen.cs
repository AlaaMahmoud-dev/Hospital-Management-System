using HMS.Invoices;
using HMS.Login;
using HMS.MedicalStaffs;
using HMS.Patients;
using HMS.Patients.In_Patients;
using HMS.Prescriptions;
using HMS.Users;
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
    public partial class frmMainScreen : Form
    {

        public frmMainScreen()
        {
            InitializeComponent();
            
            frmLogin loginScreen = new frmLogin();

            loginScreen.ShowDialog();


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDoctors manageDoctorsForm = new frmManageDoctors();
            manageDoctorsForm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmManagePatients frmManagePatientsForm = new frmManagePatients();
            frmManagePatientsForm.ShowDialog();
        }

        private void receptionistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmInPaitentsList List=new frmInPaitentsList();
            //List.ShowDialog();
        }

        private void diagnosticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageHistoriesList medicalHistories = new frmManageHistoriesList();
            medicalHistories.ShowDialog();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
          
            if (clsGlobal.CurrentUser == null)
            {
                this.Close();
            }
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser=null;
            this.Hide();
            frmLogin loginScreen = new frmLogin();

            loginScreen.ShowDialog();
            if (clsGlobal.CurrentUser == null)
            {
                this.Close();
            }
            else
                this.Show();

        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatientInfo addPatientInfo = new frmAddUpdatePatientInfo();
            addPatientInfo.ShowDialog();
        }

        private void registerPatientForTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInPatient addNewInPatient = new frmAddNewInPatient();
            addNewInPatient.ShowDialog();
        }

        private void patientsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePatients managePatients = new frmManagePatients();
            managePatients.ShowDialog();
        }

        private void inPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInPatientRecords inPatientRecords = new frmManageInPatientRecords();
            inPatientRecords.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsersList = new frmManageUsers();
            manageUsersList.ShowDialog();
        }

        private void preescriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePrescriptionsList prescriptionsList = new frmManagePrescriptionsList();
            prescriptionsList.ShowDialog();
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInvoicesList invoicesList = new frmManageInvoicesList();
            invoicesList.ShowDialog();

        }
    }
}
