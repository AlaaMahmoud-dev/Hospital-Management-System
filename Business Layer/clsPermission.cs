using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Business
{
    public class clsPermission
    {

        public static DataTable GetPermissionsList()
        {
            return clsPermissionData.GetPermissionsList();
        }

        public static DataTable GetUserPermissionsList(int UserID) 
        {
            return clsPermissionData.GetUserPermissionsList(UserID);
        }

        static bool _DeleteUserPermissions(int UserID)
        {
            return clsPermissionData.DeleteUserPermissions(UserID);
        }
        public static bool SaveUserPermission(int UserID ,Queue<int>qPermissions)
        {
            if (!_DeleteUserPermissions(UserID))
            {
                return false;
            }
            while(qPermissions.Count > 0)
            {
                 if(!clsPermissionData.SaveUserPermission(UserID, qPermissions.Dequeue()))
                {
                    return false;
                }
            }
                
            return true;
        }
    }
}
