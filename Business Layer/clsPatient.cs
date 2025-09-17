using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsPatient
    {



        public int PatientID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public int BloodTypeID { get; set; }

        public string BloodTypeName { get; set; }

        public DateTime RegestrationDate { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser UserInfo { get; set; }

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        enMode _Mode = enMode.AddNew;
        public clsPatient()
        {
            PatientID = -1;
            PersonID = -1;
            PersonInfo = null;
            BloodTypeID = -1;
            BloodTypeName = "";
            RegestrationDate = new DateTime();
            CreatedByUserID = -1;
            UserInfo = null;
            _Mode = enMode.AddNew;
        }
        clsPatient(int PatientID, int PersonID, int BloodTypeID,
            DateTime RegestrationDate, int CreatedByUserID)
        {
            this.PatientID = PatientID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.BloodTypeID = BloodTypeID;
            this.BloodTypeName = clsPatientData.GetBloodTypeNameByTypeID(BloodTypeID);
            this.RegestrationDate = RegestrationDate;
            this.CreatedByUserID = CreatedByUserID;
            UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
            _Mode = enMode.Update;
        }

        public static clsPatient FindBYPatientID(int PatientID)
        {
            int PersonID = -1;
            int BloodTypeID = -1;
            DateTime RegestrationDate=new DateTime();
            int CreatedByUserID = -1;

            if (clsPatientData.FindByPatientID(PatientID, ref PersonID,
                ref BloodTypeID, ref RegestrationDate, ref CreatedByUserID))
            {
                return new clsPatient(PatientID, PersonID, BloodTypeID,
                    RegestrationDate, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static clsPatient FindBYPersonID(int PersonID)
        {
            int PatientID = -1;
            int BloodTypeID = -1;
            DateTime RegestrationDate = new DateTime();
            int CreatedByUserID = -1;

            if (clsPatientData.FindBYPersonID(ref PatientID, PersonID,
                ref BloodTypeID, ref RegestrationDate, ref CreatedByUserID))
            {
                return new clsPatient(PatientID, PersonID, BloodTypeID,
                    RegestrationDate, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable PatientsList()
        {

            return clsPatientData.GetPatientsList();
        }

        bool _AddNew()
        {
            this.PatientID = clsPatientData.AddNewPatient(this.PersonID,
                this.BloodTypeID, this.RegestrationDate, this.CreatedByUserID);

            return this.PatientID != -1;


        }
        bool _Update()
        {
            return clsPatientData.UpdatePatient(this.PatientID, this.PersonID,
                this.BloodTypeID, this.RegestrationDate, this.CreatedByUserID);
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

        public static bool DeletePatient(int PatientID)
        {
            return clsPatientData.DeletePatient(PatientID);

        }

        public static int GetBloodTypeIDByName(string BloodTypeName)
        {
            return clsPatientData.GetBloodTypeIDByTypeName(BloodTypeName);
        }

        public static DataTable GetBloodTypesList()
        {
            return clsPatientData.GetBloodTypesList();
        }

    }
}









