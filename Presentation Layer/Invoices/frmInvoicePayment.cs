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
    public partial class frmInvoicePayment: Form
    {
        int _InvoiceID;
        clsInvoice _InvoiceInfo;

        public frmInvoicePayment(int InvoiceID)
        {
            InitializeComponent();
            _InvoiceID = InvoiceID;
            _InvoiceInfo = clsInvoice.FindInvoiceInfo(InvoiceID);
        }

        void _LoadData()
        {
            lblInvoiceID.Text = _InvoiceID.ToString();
            lblHistoryID.Text = _InvoiceInfo.HistoryID.ToString();
            lblPatientFullName.Text = _InvoiceInfo.HistoryInfo.PatientInfo.PersonInfo.FullName;
            txtFees.Text = _InvoiceInfo.Fees.ToString();
            txtDiscount.Text = "0.0";
            txtTotalAmount.Text = (_InvoiceInfo.Fees - (_InvoiceInfo.Fees * Convert.ToSingle(txtDiscount.Text))).ToString();
            
        }
        private void frmInvoicePayment_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _InvoiceInfo.Discount = Convert.ToSingle(txtDiscount.Text);
            _InvoiceInfo.TotalAmount = Convert.ToSingle(txtTotalAmount.Text);
            _InvoiceInfo.IsPaid = true;
            if (MessageBox.Show("Are you sure you want to save payment data ??", "Confimation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_InvoiceInfo.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Saving Data Failed", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                txtDiscount.Text = "0.0";
            }
            txtTotalAmount.Text = (_InvoiceInfo.Fees - (_InvoiceInfo.Fees * Convert.ToSingle(txtDiscount.Text))).ToString();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
