using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsMedicine
    {

        public int MedicineID { get; set; }


        public string MedicineName { get; set; }
        public short DosageForm { get; set; }
        public int StockQuantity { get; set; }
        public string Strength { get; set; }
        public float InitialPrice { get; set; }
        public float Taxfees { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



      
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsMedicine()
        {
            MedicineID = -1;
            MedicineName = string.Empty;
            DosageForm = -1;
            StockQuantity = -1;
            Strength = string.Empty;
            InitialPrice = -1;
            Taxfees = -1;
            TotalCost = -1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;      
            _Mode = enMode.AddNew;

        }

        private clsMedicine(int MedicineID, string MedicineName,
            short DosageForm, int StockQuantity, string Strength,
            float InitialPrice,  float Taxfees, float TotalCost,
            DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.MedicineID = MedicineID;
            this.MedicineName = MedicineName;
            this.DosageForm = DosageForm;
            this.StockQuantity = StockQuantity;
            this.Strength = Strength;
            this.InitialPrice = InitialPrice;
            this.Taxfees = Taxfees;
            this.TotalCost = TotalCost;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            _Mode = enMode.Update;

        }

        public static clsMedicine FindMedicineInfo(int MedicineID)
        {

            string MedicineName = "";
            short DosageForm = -1;
            int StockQuantity = -1;
            string Strength = "";
            float InitialPrice = -1;
            float Taxfees =-1;
            float TotalCost = -1;
            DateTime CreatedAt = DateTime.Now;
            DateTime UpdatedAt = DateTime.Now;
           


            if (clsMedicineData.FindMedicine(MedicineID, ref MedicineName,
                ref DosageForm, ref StockQuantity, ref Strength,
                ref InitialPrice, ref Taxfees, ref TotalCost,
                ref CreatedAt, ref UpdatedAt))
            {
                return new clsMedicine(MedicineID, MedicineName, DosageForm,
                    StockQuantity, Strength, InitialPrice, Taxfees,
                    TotalCost, CreatedAt, UpdatedAt);
            }
            else { return null; }
        }



    
        public static DataTable GetAllMedicines()
        {

            return clsMedicineData.GetAllMedicinesData();
        }

       
        bool _AddNew()
        {
            this.MedicineID = clsMedicineData.AddNewMedicine(this.MedicineName, this.DosageForm, this.StockQuantity,
                this.Strength, this.InitialPrice, 
                this.Taxfees, this.TotalCost, this.CreatedAt, this.UpdatedAt);

            return this.MedicineID != -1;


        }
        bool _Update()
        {
            return clsMedicineData.UpdateMedicine(this.MedicineID, this.MedicineName, this.DosageForm,
                this.StockQuantity, this.Strength, this.InitialPrice,
                 this.Taxfees, this.TotalCost,
                this.CreatedAt, this.UpdatedAt
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
      
        public static bool DeleteMedicine(int MedicineID)
        {
            return clsMedicineData.DeleteMedicineData(MedicineID);

        }

    }
}
