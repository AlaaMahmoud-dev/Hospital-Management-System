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

namespace HMS.Invoices
{
    public partial class frmManageInvoicesList: Form
    {
        DataTable _dtAllInvoicesList;
        public frmManageInvoicesList()
        {
            InitializeComponent();
            _dtAllInvoicesList = new DataTable();
        }

        private void frmManageInvoicesList_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.Clear();


            cbSearchType.Items.Add("None");

            cbSearchType.Items.Add("Invoice ID");
            cbSearchType.Items.Add("History ID");
            cbSearchType.Items.Add("Full Name");
            cbSearchType.Items.Add("Invoice Reason");
            cbSearchType.SelectedItem = "None";

            _dtAllInvoicesList = clsInvoice.GetAllInvoices();
            dgvInvoiceslist.DataSource = _dtAllInvoicesList;
           
            if (dgvInvoiceslist.Rows.Count > 0)
            {
                dgvInvoiceslist.Columns[0].HeaderText = "Invoice ID";
                dgvInvoiceslist.Columns[0].Width = 100;

                dgvInvoiceslist.Columns[1].HeaderText = "History ID";
                dgvInvoiceslist.Columns[1].Width = 100;

                dgvInvoiceslist.Columns[2].HeaderText = "Patient Name";
                dgvInvoiceslist.Columns[2].Width = 300;

                dgvInvoiceslist.Columns[3].HeaderText = "Invoice Reason";
                dgvInvoiceslist.Columns[3].Width = 200;

                dgvInvoiceslist.Columns[4].HeaderText = "Total Amount";
                dgvInvoiceslist.Columns[4].Width = 150;

                dgvInvoiceslist.Columns[5].HeaderText = "Is Paid";
                dgvInvoiceslist.Columns[5].Width = 100;

             
            }
            lblPrescriptionsCount.Text = dgvInvoiceslist.Rows.Count.ToString();
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoicePayment invoicePayment = new frmInvoicePayment(Convert.ToInt32(dgvInvoiceslist.CurrentRow.Cells[0].Value));
            invoicePayment.ShowDialog();
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text))
                _dtAllInvoicesList.DefaultView.RowFilter = "";
            txtSearchValue.Visible = cbSearchType.SelectedItem.ToString() != "None";
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "None";
            switch (cbSearchType.Text)
            {
                case "None":
                    break;
                case "Invoice ID":
                    FilterColumn = "InvoiceID";
                    break;
                case "History ID":
                    FilterColumn = "HistoryID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "InvoiceReason";
                    break;
            }

            if (string.IsNullOrEmpty(txtSearchValue.Text))
            {
                _dtAllInvoicesList.DefaultView.RowFilter = "";
            }
            else
            {
               
                if (FilterColumn == "InvoiceID" || FilterColumn == "HistoryID")
                {

                    _dtAllInvoicesList.DefaultView.RowFilter = string.Format("[{0}] = {1}",
                        FilterColumn, txtSearchValue.Text.Trim());
                }
                else
                {
                    _dtAllInvoicesList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                        FilterColumn, txtSearchValue.Text.Trim());

                }
            }
            lblPrescriptionsCount.Text = dgvInvoiceslist.Rows.Count.ToString();
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchType.Text == "Invoice ID" || cbSearchType.Text == "History ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int InvoiceID = Convert.ToInt32(dgvInvoiceslist.CurrentRow.Cells[0].Value);
            clsInvoice InvoiceInfo = clsInvoice.FindInvoiceInfo(InvoiceID);

            payToolStripMenuItem.Enabled = !InvoiceInfo.IsPaid;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
