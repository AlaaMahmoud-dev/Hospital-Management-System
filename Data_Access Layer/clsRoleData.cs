using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsRoleData
    {


        public static bool FindRoleInfoByRoleID(int RoleID, ref string RoleTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Roles Where RoleID=@RoleID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("RoleID", RoleID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    RoleTitle = (string)reader["RoleTitle"];

                    isFound = true;
                }
                reader.Close();




            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { connection.Close(); }

            return isFound;

        }
        public static bool FindRoleInfoByRoleTitle(ref int RoleID, string RoleTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Roles Where RoleTitle=@RoleTitle";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("RoleTitle", RoleTitle);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    RoleID = (int)reader["RoleID"];

                    isFound = true;
                }
                reader.Close();




            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { connection.Close(); }

            return isFound;

        }

        
   public static DataTable GetRolesList()
        {

            DataTable dtRolesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Select Roles.RoleID,Roles.RoleTitle from Roles";



            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtRolesList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtRolesList;
        }
    }
}
