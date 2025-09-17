using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsPermissionData
    {


        public static DataTable GetPermissionsList()
        {

            DataTable dtPermissionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT PermissionID, PermissionNumber, PermissionTitle
                            FROM Permissions";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPermissionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPermissionsList;
        }

        
             public static DataTable GetUserPermissionsList(int UserID)
        {

            DataTable dtUserPermissionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            select UserPermissions.PermissionID,Permissions.PermissionNumber,Permissions.PermissionTitle 
                            from Permissions inner join UserPermissions
                            on Permissions.PermissionID=UserPermissions.PermissionID
                            where UserID=@UserID";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserID", UserID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUserPermissionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtUserPermissionsList;
        }

        public static bool DeleteUserPermissions(int UserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from UserPermissions where UserID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", UserID);

            try
            {
                connection.Open();

                RowsAffected = cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }


            return RowsAffected > 0;
        }
        public static bool SaveUserPermission(int UserID,int PermissionID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into UserPermissions (UserID,PermissionID) 
                             Values(@UserID,@PermissionID);
                           ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserID", UserID);
            command.Parameters.AddWithValue("PermissionID", PermissionID);

            try
            {

                connection.Open();
           

                 RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); }
            return RowsAffected > 0;
        }
    }
}
