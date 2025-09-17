using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsDepartment
    {

        public int DepartmentID {  get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentManagerID { get; set; }

        public clsDoctor ManagerInfo;

        public clsDepartment()
        {
            DepartmentID = -1;
            DepartmentName = "";
            DepartmentManagerID = -1;
            //ManagerInfo = null;
        }

        clsDepartment(int DepartmentID, string DepartmentName, int DepartmentManagerID)
        {
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
            this.DepartmentManagerID = DepartmentManagerID;
            this.ManagerInfo = clsDoctor.FindBYDoctorID(DepartmentManagerID);
        }

        public static clsDepartment FindDepartmentByID(int DepartmentID)
        {

            string DepartmentName = "";
            int DepartmentManagerID =-1;
           


            if (clsDepartmentData.FindDepartmentByID(DepartmentID, ref DepartmentName, ref DepartmentManagerID))
            {
                return new clsDepartment(DepartmentID, DepartmentName, DepartmentManagerID);
            }
            else { return null; }
        }

        public static clsDepartment FindDepartmentByName(string DepartmentName)
        {

            int DepartmentID = -1;
            int DepartmentManagerID = -1;



            if (clsDepartmentData.FindDepartmentByName(ref DepartmentID,  DepartmentName, ref DepartmentManagerID))
            {
                return new clsDepartment(DepartmentID, DepartmentName, DepartmentManagerID);
            }
            else { return null; }
        }

        public static DataTable GetDepartmentsList()
        {
            return clsDepartmentData.GetDepartmentsList();
        }
        public static DataTable GetRoomsList()
        {
            return clsDepartmentData.GetRoomsList();
        }
        public static int GetNumberOfPatientsInRoom(int RoomID)
        {
            return clsDepartmentData.GetNumberOfPatientsInRoom(RoomID);
        }
    }
}
