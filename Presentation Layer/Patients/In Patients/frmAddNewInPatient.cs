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

namespace HMS.Patients.In_Patients
{
    public partial class frmAddNewInPatient : Form
    {

        int _PatientID;
        int _HistoryID;
        public frmAddNewInPatient()
        {
            InitializeComponent();
            _PatientID = -1;
            _HistoryID = -1;
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int PersonID = obj;

            clsPerson personInfo = clsPerson.FindPerson(PersonID);


            if (personInfo != null)
            {
                clsPatient patientInfo = clsPatient.FindBYPersonID(PersonID);
                if (patientInfo != null)
                {
                    //ctrlPatientInfo1.LoadPatientInfo(patientInfo.PatientID);
                    if (clsHistory.GetHistoryIDWithStatusNew(patientInfo.PatientID)!=-1)
                    {
                        MessageBox.Show("Selected Patient has an active history not confirmed yet", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                  
                    _PatientID=patientInfo.PatientID;
                    btnSave.Enabled = true;
                }
                else
                {
                    _PatientID = -1;
                   // ctrlPatientInfo1.LoadPatientInfo(_PatientID);
                    if (MessageBox.Show("Patient was not found, do you want to add patient info??","Not Found",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)
                        ==DialogResult.Yes)
                    {
                        frmAddUpdatePatientInfo addPatientInfo = new frmAddUpdatePatientInfo();
                        addPatientInfo.OnPatientAdded += AddPatientInfo_OnPatientAdded;
                        addPatientInfo.ShowDialog();
                       
                    }
                    else
                        btnSave.Enabled = false;
                }
             
            }


        }

        private void AddPatientInfo_OnPatientAdded(object sender, int PatientID)
        {
            //ctrlPatientInfo1.LoadPatientInfo(PatientID);
            _PatientID = PatientID;
            btnSave.Enabled = true;    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            clsHistory historyInfo=new clsHistory();

            historyInfo.PatientID = _PatientID;
            historyInfo.Status = clsHistory.enStatus.New;
            historyInfo.LastStatusDate=DateTime.Now;
            historyInfo.CreatedAt = DateTime.Now;
            historyInfo.CreatedByUserID=clsGlobal.CurrentUser.UserID;

           
            if (historyInfo.Save())
            {
                MessageBox.Show("In Patient Registered Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _HistoryID = historyInfo.HistoryID;
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Saving Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddNewInPatient_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void ctrlPatientCardWithFilter1_OnPatientSelected(int obj)
        {
            clsPatient patientInfo = clsPatient.FindBYPatientID(obj);
            if (patientInfo != null)
            {
                //ctrlPatientInfo1.LoadPatientInfo(patientInfo.PatientID);
                if (clsHistory.GetHistoryIDWithStatusNew(patientInfo.PatientID) != -1)
                {
                    MessageBox.Show("Selected Patient have an active history not confirmed yet", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }

                _PatientID = patientInfo.PatientID;
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                _PatientID = -1;
                // ctrlPatientInfo1.LoadPatientInfo(_PatientID);
                if (MessageBox.Show("Patient was not found, do you want to add patient info??", "Not Found", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    
                    frmAddUpdatePatientInfo addPatientInfo = new frmAddUpdatePatientInfo();
                    //addPatientInfo.OnPatientAdded += AddPatientInfo_OnPatientAdded;
                    addPatientInfo.ShowDialog();
                }
               
            }
        }
    }
}
