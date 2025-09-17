using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsMedicalStaff
    {
        public int MedicalStaffID {  get; set; }
        public int PersonID {  get; set; }

        public clsPerson PersonInfo { get; set; }

        public int PositionID {  get; set; }
        public clsPosition PositionInfo { get; set; }

        public int DepartmentID {  get; set; }

        //public clsDepartment DepartmentInfo { get; set; }
        public short YearsOfExperience {  get; set; }
        public string Certificates {  get; set; }
        public int CreatedByUserID {  get; set; }
        //public clsUser UserInfo { get; set; }

        public enum enMode
        {
            AddNew=1,
            Update=2
        }
        
       public enMode Mode = enMode.AddNew;
        public clsMedicalStaff()
        {
            MedicalStaffID = -1;
            PersonID = -1;
            PositionID = -1;
            DepartmentID = -1;
            YearsOfExperience = -1;
            Certificates = "";
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        clsMedicalStaff(int MedicalStaffID, int PersonID, int PositionID,
            int DepartmentID, short YearsOfExperience,
            string Certificates, int CreatedByUserID)
        {
            this.MedicalStaffID = MedicalStaffID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.PositionID = PositionID;
            this.PositionInfo=clsPosition.FindPositionInfoByID(PositionID);
            this.DepartmentID = DepartmentID;
           // DepartmentInfo=clsDepartment.FindDepartmentByID(DepartmentID);
            this.YearsOfExperience = YearsOfExperience;
            this.Certificates = Certificates;
            this.CreatedByUserID = CreatedByUserID;
            //UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
            Mode=enMode.Update;
        }

        public static clsMedicalStaff FindBYMedicalStaffID(int MedicalStaffID)
        {
            int PersonID = -1;
            int PositionID = -1;
            int DepartmentID = -1;
            short YearsOfExperience = -1;
            string Certificates = "";
            int CreatedByUserID = -1;

            if (clsMedicalStaffData.FindMedicalStaffInfoBYMedicalStaffID(MedicalStaffID, ref PersonID,
                ref PositionID, ref DepartmentID, ref YearsOfExperience,
                ref Certificates, ref CreatedByUserID))
            {
                return new clsMedicalStaff(MedicalStaffID, PersonID, PositionID,
                    DepartmentID, YearsOfExperience, Certificates, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
        public static clsMedicalStaff FindBYPersonID(int PersonID)
        {
            int MedicalStaffID = -1;
            int PositionID = -1;
            int DepartmentID = -1;
            short YearsOfExperience = -1;
            string Certificates = "";
            int CreatedByUserID = -1;

            if (clsMedicalStaffData.FindMedicalStaffInfoBYPersonID(ref MedicalStaffID, PersonID,
                ref PositionID, ref DepartmentID, ref YearsOfExperience,
                ref Certificates, ref CreatedByUserID))
            {
                return new clsMedicalStaff(MedicalStaffID, PersonID, PositionID,
                    DepartmentID, YearsOfExperience, Certificates, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        //public static DataTable MedicalStaffsList()
        //{

        //    return clsUserData.GetUsersList();
        //}

        bool _AddNew()
        {
            this.MedicalStaffID = clsMedicalStaffData.AddNewMedicalStaff(this.PersonID,
                this.PositionID, this.DepartmentID, this.YearsOfExperience,
                this.Certificates, this.CreatedByUserID);

            return this.MedicalStaffID != -1;


        }
        bool _Update()
        {
            return clsMedicalStaffData.UpdateMedicalStaff(this.MedicalStaffID, this.PersonID,
                this.PositionID, this.DepartmentID, this.YearsOfExperience,
                this.Certificates, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
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

        public bool Delete()
        {
            return clsMedicalStaffData.DeleteMedicalStaff(this.MedicalStaffID);

        }


    }
}
