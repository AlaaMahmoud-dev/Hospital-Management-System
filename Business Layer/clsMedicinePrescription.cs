using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{

    public class clsMedicinePrescription
    {
        public struct stSelectedMedicineInfo
        {
            public int MedicineID;
            public int Quantity;
        }

        public enum enConfirmedOrNot { NotConfirmed = 0, Confirmed = 1 }
        public static DataTable GetPermissionsList()
        {
            return clsPermissionData.GetPermissionsList();
        }

        public static DataTable GetPrescriptionMedicinesList(int PrescriptionID)
        {
            return clsMedicinePrescriptionData.GetPrescriptionMedicinesListData(PrescriptionID);
        }

        public static bool ChangeMedicineStatusInPrescription(int PrescriptionID, int MedicineID,enConfirmedOrNot Status)
        {
            return clsMedicinePrescriptionData.ChangeMedicineStatusInPrescription(PrescriptionID, MedicineID,Convert.ToBoolean(Status));

        }

        public static bool IsConfirmed(int PrescriptionID, int MedicineID)
        {
            return clsMedicinePrescriptionData.IsMedicineConfirmed(PrescriptionID, MedicineID);
        }
        static bool _DeleteMedicinesInPrescription(int PrescriptionID)
        {
            return clsMedicinePrescriptionData.DeleteMedicinesInPescription(PrescriptionID);
        }
        public static bool UpdatePrescriptionMedicines(int PrescriptionID, List<stSelectedMedicineInfo> lstSelectedMedicineInfo)
        {
            if (!_DeleteMedicinesInPrescription(PrescriptionID))
            {
                return false;
            }
            foreach (stSelectedMedicineInfo currentMedicineInfo in lstSelectedMedicineInfo)
            {
                if (!clsMedicinePrescriptionData.SavePrescriptionMedicines(PrescriptionID, currentMedicineInfo.MedicineID,currentMedicineInfo.Quantity))
                {
                    return false;
                }
            }
          
            return true;
        }
        public static bool AddPrescriptionMedicines(int PrescriptionID, List<stSelectedMedicineInfo> lstSelectedMedicineInfo)
        {
            
            foreach (stSelectedMedicineInfo currentMedicineInfo in lstSelectedMedicineInfo)
            {
                if (!clsMedicinePrescriptionData.SavePrescriptionMedicines(PrescriptionID, currentMedicineInfo.MedicineID, currentMedicineInfo.Quantity))
                {
                    return false;
                }
            }

            return true;
        }

        public static float GetMedicinePrescriptionFees(int PrescriptionID)
        {
            return clsMedicinePrescriptionData.GetMedicinePrescriptionFees(PrescriptionID);
        } 
    }
}
