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

namespace HMS.ConsultationHistories
{
    public partial class frmManageConsultationHistories: Form
    {
         DataTable _dtAllHistories;
        public frmManageConsultationHistories()
        {
            InitializeComponent();
            _dtAllHistories = new DataTable();
          
        }

        private void frmManageConsultationHistories_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.Clear();
            cbSearchType.Items.Add("None");
            cbSearchType.Items.Add("Consultation.H ID");
            cbSearchType.Items.Add("History ID");
            cbSearchType.Items.Add("Patient Name");
            cbSearchType.Items.Add("Doctor Name");
            cbSearchType.Items.Add("Department");
            cbSearchType.Items.Add("Status");
            cbSearchType.SelectedIndex = 0;

            _dtAllHistories = clsHistory.GetAllHistories();
            dgvHistoriesList.DataSource = _dtAllHistories;
            if (dgvHistoriesList.Rows.Count > 0)
            {
                
                dgvHistoriesList.Columns[0].HeaderText = "Consultation.H ID";
                dgvHistoriesList.Columns[0].Width = 100;


                dgvHistoriesList.Columns[1].HeaderText = "History ID";
                dgvHistoriesList.Columns[1].Width = 100;


                dgvHistoriesList.Columns[2].HeaderText = "Patient Name";
                dgvHistoriesList.Columns[2].Width = 300;

                dgvHistoriesList.Columns[3].HeaderText = "Doctor Name";
                dgvHistoriesList.Columns[3].Width = 300;



                dgvHistoriesList.Columns[4].HeaderText = "Department";
                dgvHistoriesList.Columns[4].Width = 180;



                dgvHistoriesList.Columns[5].HeaderText = "Created At";
                dgvHistoriesList.Columns[5].Width = 180;



                dgvHistoriesList.Columns[6].HeaderText = "Status";
                dgvHistoriesList.Columns[6].Width = 100;



                dgvHistoriesList.Columns[7].HeaderText = "Last Status Date";
                dgvHistoriesList.Columns[7].Width = 180;
            }
            lblConsultationHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchValue.Text = "";
            _dtAllHistories.DefaultView.RowFilter = "";
            lblConsultationHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";

        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Consultation.H ID":
                    FilterColumn = "ConsultationHistoryID";
                    break;
                case "History ID":
                    FilterColumn = "HistoryID";
                    break;
                case "Patient Name":
                    FilterColumn = "PatientName";
                    break;
                case "Doctor Name":
                    FilterColumn = "DoctorName";
                    break;
                case "Department":
                    FilterColumn = "Department";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllHistories.DefaultView.RowFilter = "";
            }
            else
            {
                if (FilterColumn == "ConsultationHistoryID" || FilterColumn == "HistoryID")
                {

                    _dtAllHistories.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllHistories.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblConsultationHistoriesCount.Text = dgvHistoriesList.Rows.Count.ToString();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.SelectedItem.ToString() == "History ID" || cbSearchType.SelectedItem.ToString() == "Consultation.H ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
