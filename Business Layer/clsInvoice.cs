using HMS_DataAccess;
using System;
using System.Data;

namespace HMS_Business
{
    public class clsInvoice
    {

        public int InvoiceID { get; set; }


        public int HistoryID { get; set; }
        public clsHistory HistoryInfo {  get; set; }
        public short InvoiceReason { get; set; }
      
        public float Fees { get; set; }
        public float Discount { get; set; }
        public float TotalAmount { get; set; }
        public bool IsPaid { get; set; }


        public enum enInvoiceReason { DirectTreatment = 1, MedicinePrescription = 2, TestPrescription = 3, Consultation = 4 }


        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsInvoice()
        {
            InvoiceID = -1;
            HistoryID = -1;
            InvoiceReason = 1;
           
            Fees = -1;
            Discount = -1;
            TotalAmount = -1;
            IsPaid =false;
          
            _Mode = enMode.AddNew;

        }

        private clsInvoice(int InvoiceID, int HistoryID,
            short InvoiceReason,float Fees,
            float Discount, float TotalAmount,
            bool IsPaid)
        {
            this.InvoiceID = InvoiceID;
            this.HistoryID = HistoryID;
            HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            this.InvoiceReason = InvoiceReason;
           
            this.Fees = Fees;
            this.Discount = Discount;
            this.TotalAmount = TotalAmount;
            this.IsPaid = IsPaid;
           
            _Mode = enMode.Update;

        }

        public static clsInvoice FindInvoiceInfo(int InvoiceID)
        {
            
            int HistoryID = -1;
            short InvoiceReason = 1;
            
            float Fees = -1;
            float Discount = -1;
            float TotalAmount = -1;
            bool IsPaid =false;
          



            if (clsInvoiceData.FindInvoiceData(InvoiceID, ref HistoryID,
                ref InvoiceReason,
                ref Fees, ref Discount, ref TotalAmount,
                ref IsPaid))
            {
                return new clsInvoice(InvoiceID, HistoryID, InvoiceReason,
                   Fees, Discount,
                    TotalAmount, IsPaid);
            }
            else { return null; }
        }




        public static DataTable GetAllInvoices()
        {

            return clsInvoiceData.GetAllInvoicesData();
        }


        bool _AddNew()
        {
            this.InvoiceID = clsInvoiceData.AddNewInvoice(this.HistoryID, this.InvoiceReason, this.Fees,
                this.Discount, this.TotalAmount, this.IsPaid);

            return this.InvoiceID != -1;


        }
        bool _Update()
        {
            return clsInvoiceData.UpdateInvoice(this.InvoiceID, this.HistoryID, this.InvoiceReason,
                this.Fees,
                 this.Discount, this.TotalAmount,
                this.IsPaid
                );
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();


            }
            return false;
        }

        //public static bool DeleteMedicine(int MedicineID)
        //{
        //    return clsInvoiceData.DeleteMedicineData(MedicineID);

        //}

    }

}

