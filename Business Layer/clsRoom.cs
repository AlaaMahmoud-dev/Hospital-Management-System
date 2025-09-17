using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsRoom
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public int DepartmentID { get; set; }

        public enum enStatus { Male = 0, Female = 1 }

        public enStatus Ward { get; set; }

        public int Capacity { get; set; }

        

        public clsRoom()
        {
            RoomID = -1;
            RoomNumber = "";
            DepartmentID = -1;
            Capacity = -1;
            
        }

        clsRoom(int RoomID,int DepartmentID, string RoomNumber, enStatus Ward, int Capacity)
        {
            this.RoomID = RoomID;
            this.RoomNumber = RoomNumber;
            this.DepartmentID = DepartmentID;
            this.Ward = Ward;
            this.Capacity = Capacity;
        }

        public static clsRoom FindRoomInfoByID(int RoomID)
        {

            string RoomNumber = "";
            int DepartmentID = -1;
            int Capacity = -1;
            short Ward = 0;




            if (clsRoomData.FindRoomInfoByID(RoomID,ref DepartmentID,ref RoomNumber,ref Ward, ref Capacity))
            {
                return new clsRoom(RoomID,DepartmentID,RoomNumber,(enStatus)Ward, Capacity);
            }
            else { return null; }
        }

    }
}
