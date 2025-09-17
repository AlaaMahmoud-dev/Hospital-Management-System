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
    public partial class ctrlHistoryInfo : UserControl
    {
        int _HistoryID;
        public ctrlHistoryInfo()
        {
            InitializeComponent();
            _HistoryID = -1;
        }
        void _ResetDefaultValues()
        {
            _HistoryID=-1;
            lblCreatedByUsername.Text = "[????]";
            lblCreationDate.Text = "[????]";
            lblHistoryID.Text = "[????]";
            lblPatientID.Text = "[????]";
            lblStatus.Text = "[????]";
        }
        public void LoadHistoryInfo(int HistoryID)
        {
            clsHistory history = clsHistory.FindBYHistoryID(HistoryID);
            if (HistoryID == -1 || (history = clsHistory.FindBYHistoryID(HistoryID)) == null)
            {
                MessageBox.Show($"History was not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();

                return;
            }
            lblHistoryID.Text = HistoryID.ToString();
            lblPatientID.Text = history.PatientID.ToString();
            lblStatus.Text = history.Status.ToString();
            lblCreationDate.Text = history.CreatedAt.ToString("dd/M/yyyy");
            lblCreatedByUsername.Text = history.UserInfo.UserName;

        }

        

    }
}
