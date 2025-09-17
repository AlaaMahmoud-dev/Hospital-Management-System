using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsHistory
    {
        public int HistoryID {  get; set; }
        public int PatientID {  get; set; }

        public clsPatient PatientInfo { get; set; }

        public DateTime CreatedAt { get; set; }

        public enStatus Status {  get; set; }

        public DateTime LastStatusDate { get; set; }

        public int CreatedByUserID {  get; set; }

        public clsUser UserInfo { get; set; }
        public enum enStatus { New=1,InProgress=2,Completed=3,Canceled=4}
        
        public clsHistory()
        {

            HistoryID = -1;
            PatientID = -1;
            CreatedAt = new DateTime();
            Status = enStatus.New;
            LastStatusDate = new DateTime();
            CreatedByUserID = -1;
        }

        clsHistory (int HistoryID, int PatientID, DateTime CreatedAt, short Status, DateTime LastStatusDate, int CreatedByUserID)
        {
            this.HistoryID = HistoryID;
            this.PatientID = PatientID;
            this.CreatedAt = CreatedAt;
            this.Status = (enStatus)Status;
            this.LastStatusDate = LastStatusDate;
            this.PatientInfo = clsPatient.FindBYPatientID(PatientID);
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
        }

        bool _AddNew()
        {
            this.HistoryID = clsHistoryData.AddNew(this.PatientID,this.CreatedAt,(short)this.Status, this.LastStatusDate,this.CreatedByUserID);

           return this.HistoryID != -1;
        }

        public static clsHistory FindBYHistoryID(int HistoryID)
        {
            int PatientID = -1;
            DateTime CreatedAt = new DateTime();
            short Status = -1;
            DateTime LastStatusDate = new DateTime();
            int CreatedByUserID = -1;

            if (clsHistoryData.FindByHistoryID( HistoryID, ref PatientID,
                ref CreatedAt, ref Status, ref LastStatusDate,
                ref CreatedByUserID))
            {
                return new clsHistory(HistoryID, PatientID, CreatedAt,
                    Status, LastStatusDate, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static clsHistory FindBYPatientID(int PatientID)
        {
            int HistoryID = -1;
            DateTime CreatedAt = new DateTime();
            short Status = -1;
            DateTime LastStatusDate = new DateTime();
            int CreatedByUserID = -1;

            if (clsHistoryData.FindByPatientID(ref HistoryID,  PatientID,
                ref CreatedAt, ref Status, ref LastStatusDate,
                ref CreatedByUserID))
            {
                return new clsHistory(HistoryID, PatientID, CreatedAt,
                    Status, LastStatusDate, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static int GetHistoryIDWithStatusNew(int PatientID)
        {

            return clsHistoryData.GetHistoryIDWithStatusNew(PatientID);

        }
        public static DataTable GetAllHistories()
        {
            return clsHistoryData.GetAllHistories();
        }

       public bool ChangeStatus( enStatus NewStatus)
        {
            return clsHistoryData.ChangeStatus(this.HistoryID, (int)NewStatus);
        }
        public bool Save()
        {
            return _AddNew();
        }
    }
}
