using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using HMS_DataAccess;
namespace HMS_Business
{


    public class clsUser
    {


        public int UserID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo { get; set; }
        public string UserName { get ; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; }

        public int RoleID {  get; set; }
        public clsRole UserRole {  get; set; }
        public int DepartmentID {  get; set; }

        public clsDepartment UserDepartment { get; set; }


        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        private enMode _Mode = enMode.Update;
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            RoleID = -1;
            DepartmentID = -1;
            UserRole = new clsRole();
            UserDepartment = new clsDepartment();
            PersonInfo = new clsPerson();
            _Mode = enMode.AddNew;

        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool isActive, int RoleID,int DepartmentID)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = isActive;
            this.RoleID =RoleID;
            this.DepartmentID = DepartmentID;
            PersonInfo = clsPerson.FindPerson(PersonID);
            UserRole = clsRole.FindRoleInfoByID(RoleID);
            UserDepartment=clsDepartment.FindDepartmentByID(DepartmentID);
            _Mode = enMode.Update;

        }

        public static clsUser FindUserByUserID(int UserID)
        {

            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            int RoleID=-1;
            int DepartmentID=-1;

            if (clsUserData.FindUserByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive, ref RoleID, ref DepartmentID))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, RoleID, DepartmentID);
            }
            else { return null; }
        }

        public static clsUser FindUserByUserName(string UserName)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = "";
            bool IsActive = false;
            int RoleID = -1;
            int DepartmentID = -1;
            int Permessions = 0;

            if (clsUserData.FindUserByUserName(ref UserID, ref PersonID, UserName, ref Password, ref IsActive, ref RoleID, ref DepartmentID))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, RoleID, DepartmentID);
            }
            else { return null; }
        }


        public static bool IsPersonAnUser(int PersonID)
        {


            return clsUserData.IsPersonAnUser(PersonID);


        }

        public static DataTable UsersList()
        {

            return clsUserData.GetUsersList();
        }



        bool _AddNew()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password,
                this.IsActive, this.RoleID, this.DepartmentID
                );

            return this.UserID != -1;


        }
        bool _Update()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName,
                this.Password, this.IsActive, this.RoleID,
                this.DepartmentID);
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

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
          
        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;
            int RoleID = -1;
            int DepartmentID = -1;
            int Permessions = 0;

            if (clsUserData.FindByUsernameAndPassword(ref UserID, ref PersonID, UserName,  Password, ref IsActive, ref RoleID, ref DepartmentID))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, RoleID, DepartmentID);
            }
            else { return null; }
        }

    }

}

