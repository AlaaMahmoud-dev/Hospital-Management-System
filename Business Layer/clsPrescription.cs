using HMS_DataAccess;
using System;
using System.Data;
using static HMS_Business.clsMedicinePrescription;
using System.Data.SqlClient;

namespace HMS_Business
{
    public class clsPrescription
    {

        public int PrescriptionID { get; set; }
        public int HistoryID { get; set; }
        public clsHistory HistoryInfo { get; set; }

        public clsPatient PatientInfo { get; set; }

        public int CreatedByDoctorID { get; set; }
        public clsDoctor DoctorInfo { get; set; }
        public short PrescriptionType { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }


        public enum enStatus { New = 1, Confirmed = 2, Canceled = 3, Submitted = 4 }

        public enum enPrescriptionType { DirectTreatment = 1, MedicinePrescription = 2, TestPrescription = 3 }
        public clsPrescription()
        {

            PrescriptionID = -1;
            HistoryID = -1;
            CreatedByDoctorID = -1;
            PrescriptionType = Convert.ToInt16(enPrescriptionType.MedicinePrescription);
            Status = Convert.ToInt16(enStatus.New);
            CreatedAt = new DateTime();
        }

        clsPrescription(int PrescriptionID, int HistoryID, int CreatedByDoctorID, enPrescriptionType PrescriptionType, enStatus Status, DateTime CreatedAt)
        {
            this.PrescriptionID = PrescriptionID;
            this.HistoryID = HistoryID;
            this.CreatedByDoctorID = CreatedByDoctorID;
            this.PrescriptionType = Convert.ToInt16(PrescriptionType);
            this.Status = Convert.ToInt16(Status);
            this.HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            this.PatientInfo = clsPatient.FindBYPatientID(HistoryInfo.PatientID);
            this.CreatedAt = CreatedAt;
            this.DoctorInfo = clsDoctor.FindBYDoctorID(CreatedByDoctorID);
        }

        bool _AddNew()
        {
            this.PrescriptionID = clsPrescriptionData.AddNew(this.HistoryID, this.CreatedByDoctorID, this.PrescriptionType, this.Status, this.CreatedAt);

            return this.PrescriptionID != -1;
        }

        public static clsPrescription FindBYHistoryID(int HistoryID)
        {
            int PrescriptionID = -1;
            int CreatedByDoctorID = -1;

            short PrescriptionType = Convert.ToInt16(enPrescriptionType.MedicinePrescription);
            short Status = Convert.ToInt16(enStatus.New);
            DateTime CreatedAt = new DateTime();

            if (clsPrescriptionData.FindByHistoryID(ref PrescriptionID, HistoryID,
                ref CreatedByDoctorID,
                 ref PrescriptionType, ref Status, ref CreatedAt))
            {
                return new clsPrescription(PrescriptionID, HistoryID, CreatedByDoctorID,
                    (enPrescriptionType)PrescriptionType, (enStatus)Status, CreatedAt);
            }
            else
            {
                return null;
            }

        }
        public static clsPrescription FindBYPrescriptionID(int PrescriptionID)
        {
            int HistoryID = -1;
            int CreatedByDoctorID = -1;
            short PrescriptionType = Convert.ToInt16(enPrescriptionType.MedicinePrescription);
            short Status = Convert.ToInt16(enStatus.New);
            DateTime CreatedAt = new DateTime();

            if (
                clsPrescriptionData.FindByPrescriptionID
                (
                PrescriptionID, ref HistoryID, ref CreatedByDoctorID,
                 ref PrescriptionType, ref Status, ref CreatedAt
                 )
                )
            {
                return new clsPrescription(PrescriptionID, HistoryID, CreatedByDoctorID,
                   (enPrescriptionType)PrescriptionType, (enStatus)Status, CreatedAt);
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

        public static DataTable GetAllHistoryPrescriptions(int HistoryID)
        {
            return clsPrescriptionData.GetAllHistoryPrescriptionsData(HistoryID);
        }

        public static DataTable GetAllPrescriptions()
        {
            return clsPrescriptionData.GetAllPrescriptions();
        }
        public static bool ChangePrescriptionStatus(int PrescriptionID, enStatus NewStatus)
        {
            return clsPrescriptionData.ChangePrescriptionStatus(PrescriptionID, Convert.ToInt16(NewStatus));

        }
        public static bool DeletePrescription(int PrescriptionID)
        {
            return clsPrescriptionData.DeletePrescription(PrescriptionID);

        }

    }
}
