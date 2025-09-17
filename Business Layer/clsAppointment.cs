using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS_DataAccess;
namespace HMS_Business
{
    public class clsAppointment
    {

        public enum enMode { addNew = 0, update = 1 }
        public enMode Mode = enMode.addNew;



        public int AppointmentID { get; set; }
        public int ConsultationHistoryID { get; set; }
        public enStatus Status { get; set; }
        public DateTime LastStatusDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enStatus { New = 1, InProgress = 2, Completed = 3, Canceled = 4 }
        public clsAppointment()
        {
            this.AppointmentID = -1;
            this.ConsultationHistoryID = -1;
            this.Status = enStatus.New;
            this.LastStatusDate = DateTime.MinValue;
            this.AppointmentDate = DateTime.MinValue;
            this.CreatedByUserID = -1;
            this.Mode = enMode.addNew;
        }

        private clsAppointment(int AppointmentID, int ConsultationHistoryID, byte Status, DateTime LastStatusDate, DateTime AppointmentDate, int CreatedByUserID)
        {
            this.AppointmentID = AppointmentID;
            this.ConsultationHistoryID = ConsultationHistoryID;
            this.Status = (enStatus)Status;
            this.LastStatusDate = LastStatusDate;
            this.AppointmentDate = AppointmentDate;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.update;
        }
        private bool _AddNewAppointments()
        {
            // Call DataAccess Layer
            this.AppointmentID = clsAppointmentData.AddNewAppointment(this.ConsultationHistoryID, (byte)this.Status, this.LastStatusDate, this.AppointmentDate, this.CreatedByUserID);
            return (this.AppointmentID != -1);
        }

        private bool _UpdateAppointments()
        {
            // Call DataAccess Layer
            return clsAppointmentData.UpdateAppointment(this.AppointmentID, this.ConsultationHistoryID, (byte)this.Status, this.LastStatusDate, this.AppointmentDate, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.addNew:
                    if (_AddNewAppointments())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.update:
                    return _UpdateAppointments();
            }
            return false;
        }

        public static clsAppointment FindByAppointmentID(int AppointmentID)
        {
            // Call DataAccess Layer
            int ConsultationHistoryID =-1;
            byte Status = 1;
            DateTime LastStatusDate = DateTime.Now;
            DateTime AppointmentDate = DateTime.Now;
            int CreatedByUserID = -1;

            bool IsFound = clsAppointmentData.FindByAppointmentID(AppointmentID, ref ConsultationHistoryID, ref Status, ref LastStatusDate, ref AppointmentDate, ref CreatedByUserID);
            if (IsFound)
                return new clsAppointment(AppointmentID, ConsultationHistoryID, Status, LastStatusDate, AppointmentDate, CreatedByUserID);
            return null;
        }

        public static clsAppointment FindByConsultationHistoryID(int AppointmentID)
        {
            // Call DataAccess Layer
            int ConsultationHistoryID =-1;
            byte Status = 1;
            DateTime LastStatusDate = DateTime.Now;
            DateTime AppointmentDate = DateTime.Now;
            int CreatedByUserID = -1;

            bool IsFound = clsAppointmentData.FindByConsultationHistoryID(ref AppointmentID,  ConsultationHistoryID, ref Status, ref LastStatusDate, ref AppointmentDate, ref CreatedByUserID);
            if (IsFound)
                return new clsAppointment(AppointmentID, ConsultationHistoryID, Status, LastStatusDate, AppointmentDate, CreatedByUserID);
            else
                return null;
        }

        public static DataTable GetAllAppointments()
        {
            return clsAppointmentData.GetAllAppointments();
        }

        public static bool Delete(int AppointmentID)
        {
            // Call DataAccess Layer
            return clsAppointmentData.DeleteAppointment(AppointmentID);
        }

    }
}
