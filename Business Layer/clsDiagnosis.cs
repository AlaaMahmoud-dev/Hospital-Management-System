using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsDiagnosis
    {

        public int DiagnosisID { get; set; }
        public int HistoryID { get; set; }
        public clsHistory HistoryInfo { get; set; }

        public clsPatient PatientInfo { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CaseDescription { get; set; }

        public string SymptomsDescription { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUser UserInfo { get; set; }
      


        public clsDiagnosis()
        {

            DiagnosisID = -1;
            HistoryID = -1;
            CreatedAt = new DateTime();
            CaseDescription = "";
            SymptomsDescription = "";
            CreatedByUserID = -1;
        }

        clsDiagnosis(int DiagnosisID, int HistoryID, string CaseDescription, string SymptomsDescription, DateTime CreatedAt, int CreatedByUserID)
        {
            this.DiagnosisID = DiagnosisID;
            this.HistoryID = HistoryID;
            this.CreatedAt = CreatedAt;
            this.CaseDescription = CaseDescription;
            this.SymptomsDescription = SymptomsDescription;
            this.HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            this.PatientInfo = clsPatient.FindBYPatientID(HistoryInfo.PatientID);
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
        }

        bool _AddNew()
        {
            this.DiagnosisID = clsDiagnosisData.AddNew(this.HistoryID, this.CaseDescription, this.SymptomsDescription, this.CreatedAt, this.CreatedByUserID);

            return this.DiagnosisID != -1;
        }

        public static clsDiagnosis FindBYHistoryID(int HistoryID)
        {
            int DiagnosisID = -1;
            DateTime CreatedAt = new DateTime();
            string CaseDescription = "";
            string SymptomsDescription = "";
            int CreatedByUserID = -1;

            if (clsDiagnosisData.FindByHistoryID(ref DiagnosisID, HistoryID,
                 ref CaseDescription, ref SymptomsDescription, ref CreatedAt,
                ref CreatedByUserID))
            {
                return new clsDiagnosis(DiagnosisID,HistoryID, 
                    CaseDescription, SymptomsDescription, CreatedAt, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static clsDiagnosis FindBYDiagnosisID(int DiagnosisID)
        {
            int HistoryID = -1;
            DateTime CreatedAt = new DateTime();
            string CaseDescription = "";
            string SymptomsDescription = "";
            int CreatedByUserID = -1;

            if (clsDiagnosisData.FindByDiagnosisID( DiagnosisID,ref HistoryID,
                 ref CaseDescription, ref SymptomsDescription, ref CreatedAt,
                ref CreatedByUserID))
            {
                return new clsDiagnosis(HistoryID, DiagnosisID,
                    CaseDescription, SymptomsDescription, CreatedAt, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public bool Save()
        {
            return _AddNew();
        }


    }
}
