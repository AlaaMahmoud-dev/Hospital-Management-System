using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
   


public class clsConsultationHistory
    { 
        public enum enMode { addNew = 0, update = 1 }
        public enMode Mode = enMode.addNew;



        public int ConsultationHistoryID { get; set; }
        public int HistoryID { get; set; }
        public int DepartmentID { get; set; }
        public int DoctorID { get; set; }
        public DateTime CreatedAt { get; set; }
        public enStatus Status { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int CreatedByUserID { get; set; }

        public enum enStatus { New = 1, InProgress = 2, Completed = 3, Canceled = 4}
        public clsConsultationHistory()
        {
            this.ConsultationHistoryID = -1;
            this.HistoryID = -1;
            this.DepartmentID = -1;
            this.DoctorID = -1;
            this.CreatedAt = DateTime.MinValue;
            this.Status = enStatus.New;
            this.LastStatusDate = DateTime.MinValue;
            this.CreatedByUserID = -1;
            this.Mode = enMode.addNew;
        }

        private clsConsultationHistory(int ConsultationHistoryID, int HistoryID, int DepartmentID, int DoctorID, DateTime CreatedAt, byte Status, DateTime LastStatusDate, int CreatedByUserID)
        {
            this.ConsultationHistoryID = ConsultationHistoryID;
            this.HistoryID = HistoryID;
            this.DepartmentID = DepartmentID;
            this.DoctorID = DoctorID;
            this.CreatedAt = CreatedAt;
            this.Status = (enStatus)Status;
            this.LastStatusDate = LastStatusDate;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.update;
        }
        private bool _AddNewConsultationHistories()
        {
            // Call DataAccess Layer
            this.ConsultationHistoryID = clsConsultationHistoryData.AddNewConsultationHistory(this.HistoryID, this.DepartmentID, this.DoctorID,
                this.CreatedAt, (byte)this.Status, this.LastStatusDate, this.CreatedByUserID);
            return (this.ConsultationHistoryID != -1);
        }

        private bool _UpdateConsultationHistories()
        {
            // Call DataAccess Layer
            return clsConsultationHistoryData.UpdateConsultationHistory(this.ConsultationHistoryID, this.HistoryID, this.DepartmentID, this.DoctorID,
                this.CreatedAt, (byte)this.Status, this.LastStatusDate, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.addNew:
                    if (_AddNewConsultationHistories())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.update:
                    return _UpdateConsultationHistories();
            }
            return false;
        }

        public static clsConsultationHistory FindByID(int ConsultationHistoryID)
        {
            // Call DataAccess Layer
            int HistoryID =-1;
            int DepartmentID = -1;
            int DoctorID = -1;
            DateTime CreatedAt = new DateTime();
            byte Status = 0;
            DateTime LastStatusDate = new DateTime();
            int CreatedByUserID = -1;

            bool IsFound = clsConsultationHistoryData.FindByConsultationHistoryID(ConsultationHistoryID, ref  HistoryID, ref DepartmentID, ref DoctorID,
                ref CreatedAt, ref Status, ref LastStatusDate, ref CreatedByUserID);
            if (IsFound)
                return new clsConsultationHistory(ConsultationHistoryID, HistoryID, DepartmentID, DoctorID, CreatedAt, Status,
                    LastStatusDate, CreatedByUserID);
            return null;
        }

        public static clsConsultationHistory FindByHistoryID(int HistoryID)
        {
            // Call DataAccess Layer
            int ConsultationHistoryID = -1;
            int DepartmentID = -1;
            int DoctorID = -1;
            DateTime CreatedAt = new DateTime();
            byte Status = 0;
            DateTime LastStatusDate = new DateTime();
            int CreatedByUserID = -1;

            bool IsFound = clsConsultationHistoryData.FindByHistoryID(ref ConsultationHistoryID, HistoryID, ref DepartmentID, ref  DoctorID,
                ref  CreatedAt, ref  Status, ref  LastStatusDate, ref  CreatedByUserID);
            if (IsFound)
                return new clsConsultationHistory(ConsultationHistoryID, HistoryID, DepartmentID, DoctorID, CreatedAt, Status,
                    LastStatusDate, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllConsultationHistories()
        {
            return clsConsultationHistoryData.GetConsultationHistoriesList();
        }

        public static bool Delete(int ConsultationHistoryID)
        {
            // Call DataAccess Layer
            return clsConsultationHistoryData.DeleteConsultationHistory(ConsultationHistoryID);
        }

    }

}

