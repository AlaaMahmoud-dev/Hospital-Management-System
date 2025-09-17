using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsInPatientRecord
    {

        public int RecordID { get; set; }
        public int HistoryID { get; set; }
        public clsHistory HistoryInfo { get; set; }

        public clsPatient PatientInfo { get; set; }

        public DateTime CreatedAt { get; set; }

        public enStatus Status { get; set; }

        public DateTime LastStatusDate { get; set; }

        public int RoomID { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser UserInfo { get; set; }
        public enum enStatus { New = 1, InProgress = 2, Completed = 3, Canceled = 4 ,AppointmentMarked = 5}

        public clsInPatientRecord()
        {

            RecordID = -1;
            HistoryID = -1;
            CreatedAt = new DateTime();
            Status = enStatus.New;
            LastStatusDate = new DateTime();
            RoomID = -1;
            CreatedByUserID = -1;
        }

        clsInPatientRecord( int RecordID, int HistoryID, DateTime CreatedAt, short Status, DateTime LastStatusDate,int RoomID, int CreatedByUserID)
        {
            this.RecordID = RecordID;
            this.HistoryID = HistoryID;
            this.CreatedAt = CreatedAt;
            this.Status = (enStatus)Status;
            this.LastStatusDate = LastStatusDate;
            this.HistoryInfo = clsHistory.FindBYHistoryID(HistoryID);
            this.PatientInfo = clsPatient.FindBYPatientID(HistoryInfo.PatientID);
            this.RoomID = RoomID;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
        }

        bool _AddNew()
        {
            this.RecordID = clsInPatientRecordData.AddNew(this.HistoryID, this.CreatedAt, (short)this.Status, this.LastStatusDate,this.RoomID, this.CreatedByUserID);

            return this.RecordID != -1;
        }

        public static clsInPatientRecord FindBYHistoryID(int HistoryID)
        {
            int RecordID = -1;
            DateTime CreatedAt = new DateTime();
            short Status = -1;
            DateTime LastStatusDate = new DateTime();
            int RoomID = -1;
            int CreatedByUserID = -1;

            if (clsInPatientRecordData.FindByHistoryID(ref RecordID, HistoryID,
                ref CreatedAt, ref Status, ref LastStatusDate, ref RoomID,
                ref CreatedByUserID)) 
            {
                return new clsInPatientRecord(RecordID, HistoryID, CreatedAt,
                    Status, LastStatusDate,RoomID, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static clsInPatientRecord FindBYRecordID(int RecordID)
        {
            int HistoryID = -1;
            DateTime CreatedAt = new DateTime();
            short Status = -1;
            DateTime LastStatusDate = new DateTime();
            int RoomID = -1;
            int CreatedByUserID = -1;

            if (clsInPatientRecordData.FindByRecordID(RecordID,ref HistoryID,
                ref CreatedAt, ref Status, ref LastStatusDate, ref RoomID,
                ref CreatedByUserID))
            {
                return new clsInPatientRecord(RecordID, HistoryID, CreatedAt,
                    Status, LastStatusDate, RoomID, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static DataTable GetAllInPatientRecords()
        {
            return clsInPatientRecordData.GetAllInPatientRecords();
        }

       
        public bool ChangeStatus( enStatus NewStatus)
        {
            return clsInPatientRecordData.ChangeStatus(this.RecordID, (int)NewStatus);
        }
        public bool Save()
        {
            return _AddNew();
        }
    }
}
