using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsRole
    {


        public int RoleID { get; set; }
        public string RoleTitle { get; set; }

        //public clsDoctor ManagerInfo;

        public clsRole()
        {
            RoleID = -1;
            RoleTitle = "";
        }

        clsRole(int RoleID, string RoleTitle)
        {
            this.RoleID = RoleID;
            this.RoleTitle = RoleTitle;
        }

        public static clsRole FindRoleInfoByID(int RoleID)
        {

            string RoleTitle = "";



            if (clsRoleData.FindRoleInfoByRoleID(RoleID, ref RoleTitle))
            {
                return new clsRole(RoleID, RoleTitle);
            }
            else { return null; }
        }
        public static clsRole FindRoleInfoByRoleTitle(string RoleTitle)
        {

            int RoleID = -1;



            if (clsRoleData.FindRoleInfoByRoleTitle(ref RoleID, RoleTitle))
            {
                return new clsRole(RoleID, RoleTitle);
            }
            else { return null; }
        }

        public static DataTable GetRolesList()
        {
            return clsRoleData.GetRolesList();
        }
    }
}

