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
    public partial class frmAddNewDiagnosis : Form
    {

        DataTable dtRoomsList = clsDepartment.GetRoomsList();

        int _HistoryID;
        clsHistory _HistoryInfo;
        clsPatient _PatientInfo;
        public frmAddNewDiagnosis(int HistoryID)
        {
            InitializeComponent();
            _HistoryID = HistoryID;
            _HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            _PatientInfo = clsPatient.FindBYPatientID(_HistoryInfo.PatientID);

        }

        private void tpDiagnosisInfo_Click(object sender, EventArgs e)
        {

        }
        void _LoadDepartmentsInComboBox()
        {
            DataTable dtDepartmentsList = clsDepartment.GetDepartmentsList();

            for (int i = 0; i < dtDepartmentsList.Rows.Count; i++)
            {
                cbDepartments.Items.Add(dtDepartmentsList.Rows[i]["DepartmentName"].ToString());
            }
            if (cbDepartments.Items.Count > 0)
            {
                cbDepartments.SelectedItem = "Emergency Medicine";
            }

        }

        void _LoadRoomsInComboBox()
        {
            short PatientGendorKey = ((short)(_PatientInfo.PersonInfo.Gendor == 'M' ? 0 : 1));
            dtRoomsList.DefaultView.RowFilter = string.Format("{0} like '{1}' AND {2} = {3}", "DepartmentName", cbDepartments.SelectedItem.ToString(),
               "Ward",PatientGendorKey);         
            cbRoomNumber.Items.Clear();
            for (int i = 0; i < dtRoomsList.DefaultView.Count; i++)
            {
                cbRoomNumber.Items.Add(dtRoomsList.DefaultView[i]["RoomNumber"].ToString());
            }
            if (cbRoomNumber.Items.Count > 0)
            {
               cbRoomNumber.SelectedIndex = 0;
            }

        }
        private void frmAddNewDiagnosis_Load(object sender, EventArgs e)
        {
            _LoadDepartmentsInComboBox();
            _LoadRoomsInComboBox();
            lblCreatedAt.Text = DateTime.Now.ToString("dd/M/yyyy");
            lblCreatedByUsername.Text=clsGlobal.CurrentUser.UserName;
            lblhistoryID.Text = _HistoryID.ToString();
            lblFullName.Text = _HistoryInfo.PatientInfo.PersonInfo.FullName;
            
        }

     
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not validated, Check red icons next to the fields", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDiagnosis diagnosisInfo = new clsDiagnosis();
            diagnosisInfo.HistoryID = _HistoryID;
            diagnosisInfo.CaseDescription = txtCaseDescription.Text.Trim();
            diagnosisInfo.SymptomsDescription = txtSymptomsDescription.Text.Trim();
            diagnosisInfo.CreatedAt = DateTime.Now;
            diagnosisInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            
            if (diagnosisInfo.Save())
            {
                _HistoryInfo.ChangeStatus(clsHistory.enStatus.InProgress);
                MessageBox.Show("New Diagnosis Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDiagnosisID.Text = diagnosisInfo.DiagnosisID.ToString();
                clsInPatientRecord inPatientRecord = new clsInPatientRecord();
                inPatientRecord.HistoryID = _HistoryID;
                inPatientRecord.Status = clsInPatientRecord.enStatus.New;
                inPatientRecord.LastStatusDate = DateTime.Now;
                inPatientRecord.CreatedAt = DateTime.Now;
                inPatientRecord.RoomID = int.Parse(lblRoomID.Text);
                inPatientRecord.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (inPatientRecord.Save())
                {
                    MessageBox.Show($"Data Saved Successfully, Patient Was Moved To Room:{cbRoomNumber.SelectedItem.ToString()}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Saving Data Failed, Patient Was not moved to the selected Room", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Saving Diagnosis Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            btnSave.Enabled = false;
        }

    
        private void cbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtRoomsList.DefaultView.RowFilter = string.Format("{0} like '{1}'","RoomNumber",cbRoomNumber.SelectedItem.ToString());
            lblCapacity.Text = dtRoomsList.DefaultView[0]["Capacity"].ToString();
            int RoomID= int.Parse(dtRoomsList.DefaultView[0]["RoomID"].ToString());
            lblNumberOfPatientsInRoom.Text = clsDepartment.GetNumberOfPatientsInRoom(RoomID).ToString();
            lblRoomID.Text = RoomID.ToString();
        }

        private void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadRoomsInComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCaseDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCaseDescription.Text))
            {
                errorProvider1.SetError(txtCaseDescription, "This Field is required");

            }
            else
            {
                errorProvider1.SetError(txtCaseDescription, null);
            }
        }
    }
}
