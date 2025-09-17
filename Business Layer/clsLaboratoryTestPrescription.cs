using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsLaboratoryTestPrescription
    {

        public static DataTable GetPermissionsList()
        {
            return clsPermissionData.GetPermissionsList();
        }

        public static DataTable GetPrescriptionTestsList(int PrescriptionID)
        {
            return clsLaboratoryTestPrescriptionData.GetPrescriptionTestsListData(PrescriptionID);
        }

        static bool _DeleteTestsInPrescription(int PrescriptionID)
        {
            return clsLaboratoryTestPrescriptionData.DeleteTestsInPrescription(PrescriptionID);
        }
        public static bool UpdatePrescriptionTests(int PrescriptionID, List<int> lstPrescriptionTests)
        {
            if (!_DeleteTestsInPrescription(PrescriptionID))
            {
                return false;
            }
            foreach (int TestID in lstPrescriptionTests)
            {

                if (!clsLaboratoryTestPrescriptionData.SavePrescriptionTests(PrescriptionID, TestID))
                {
                    return false;
                }
            }

            return true;
        }
        public static bool NewPrescriptionTests(int PrescriptionID, List<int> lstPrescriptionTests)
        {
           
            foreach (int TestID in lstPrescriptionTests)
            {

                if (!clsLaboratoryTestPrescriptionData.SavePrescriptionTests(PrescriptionID, TestID))
                {
                    return false;
                }
            }

            return true;
        }
        public static float GetTestsPrescriptionFees(int PrescriptionID)
        {
            return clsLaboratoryTestPrescriptionData.GetTestsPrescriptionFees(PrescriptionID);
        }
        
    }
}
