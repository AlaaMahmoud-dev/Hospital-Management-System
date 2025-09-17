using HMS_DataAccess;
using System.Data;

namespace HMS_Business
{
    public class clsDoctor:clsMedicalStaff
    {
        public int DoctorID {  get; set; }

        public int SpecializationID {  get; set; }

        public clsSpecialization SpecializationInfo {  get; set; } 
        public int AvailabilityOfWeek {  get; set; }

        public enum enWeekDays
        {
            Sunday=1,
            Monday=2,
            Tuseday=4,
            Wednesday=8,
            Thursday=16,
            Friday=32,
            Saturday=64,
        }
        enum enMode
        {
            AddNew=1,
            Update=2
        }
        enMode _Mode = enMode.AddNew;
        public clsDoctor()
        {
            DoctorID = -1;
            SpecializationID = -1;
            SpecializationInfo=new clsSpecialization();
            AvailabilityOfWeek = -1;
            _Mode=enMode.AddNew;
        }

        clsDoctor(int DoctorID, int MedicalStaffID,int PersonID, 
            int PositionID,int DepartmentID, short YearsOfExperience,
            string Certificates, int CreatedByUserID, int SpecializationID,
            int AvailabilityOfWeek)
        {
            this.DoctorID = DoctorID;   
            this.MedicalStaffID = MedicalStaffID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.FindPerson(PersonID);
            this.PositionID = PositionID;
            this.PositionInfo=clsPosition.FindPositionInfoByID(PositionID);
            this.DepartmentID = DepartmentID;
            this.YearsOfExperience=YearsOfExperience;
            this.Certificates = Certificates;
            this.CreatedByUserID = CreatedByUserID;
            this.SpecializationID = SpecializationID;
            SpecializationInfo=clsSpecialization.FindInfoBySpecializationID(this.SpecializationID);
            this.AvailabilityOfWeek = AvailabilityOfWeek;
            _Mode=enMode.Update;

        }












        public static clsDoctor FindBYDoctorID(int DoctorID)
        {
            int MedicalStaffID = -1;
            int SpecializationID = -1;
            int AvailabilityOfWeek = -1;

            bool isFound=false;

            isFound = clsDoctorData.FindByDoctorID(DoctorID,ref MedicalStaffID,
                 ref SpecializationID, ref AvailabilityOfWeek);

            if (isFound)
            {
                clsMedicalStaff medicalStaff = clsMedicalStaff.FindBYMedicalStaffID(MedicalStaffID);

                if (medicalStaff != null)
                {
                    return new clsDoctor(DoctorID, MedicalStaffID, medicalStaff.PersonID,
                   medicalStaff.PositionID, medicalStaff.DepartmentID, medicalStaff.YearsOfExperience,
                   medicalStaff.Certificates, medicalStaff.CreatedByUserID,
                   SpecializationID, AvailabilityOfWeek);
                }
                else
                {
                    return null;
                }
            }

            else
                return null;
            
         

        }
        public static new clsDoctor FindBYMedicalStaffID(int MedicalStaffID)
        {
            int DoctorID = -1;
            int SpecializationID = -1;
            int AvailabilityOfWeek = -1;

            bool isFound = false;

            isFound = clsDoctorData.FindByMedicalStaffID(ref DoctorID, MedicalStaffID,
                 ref SpecializationID, ref AvailabilityOfWeek);

            if (isFound)
            {
                clsMedicalStaff medicalStaff = clsMedicalStaff.FindBYMedicalStaffID(MedicalStaffID);

                if (medicalStaff != null)
                {
                    return new clsDoctor(DoctorID, MedicalStaffID, medicalStaff.PersonID,
                   medicalStaff.PositionID, medicalStaff.DepartmentID, medicalStaff.YearsOfExperience,
                   medicalStaff.Certificates, medicalStaff.CreatedByUserID,
                   SpecializationID, AvailabilityOfWeek);
                }
                else
                {
                    return null;
                }
            }

            else
                return null;



        }
        


        public static DataTable DoctorsList()
        {

            return clsDoctorData.GetDoctorsList();
        }

        bool _AddNew()
        {
            this.DoctorID = clsDoctorData.AddNewDoctor(this.MedicalStaffID,
                this.SpecializationID, this.AvailabilityOfWeek);

            return this.DoctorID != -1;


        }
        bool _Update()
        {
            return clsDoctorData.UpdateDoctor(this.DoctorID, this.MedicalStaffID,
                this.SpecializationID, this.AvailabilityOfWeek);
        }
        public bool Save()
        {
            base.Mode = (clsMedicalStaff.enMode)this._Mode;

            if (!base.Save())
                return false;


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

            public bool Delete()
        {
            if (!clsDoctorData.DeleteDoctor(this.DoctorID))
            {
                return false;
            }

            return base.Delete();

        }


    }
}
