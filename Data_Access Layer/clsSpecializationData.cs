using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsSpecializationData
    {

        public static bool FindSpecializationInfoBySpecializationID(int SpecializationID, ref string SpecializationTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Specializations Where SpecializationID=@SpecializationID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("SpecializationID", SpecializationID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    SpecializationTitle = (string)reader["SpecializationTitle"];

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
        public static bool FindSpecializationInfoBySpecializationTitle(ref int SpecializationID, string SpecializationTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Specializations Where SpecializationTitle=@SpecializationTitle";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("SpecializationTitle", SpecializationTitle);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    SpecializationID = (int)reader["SpecializationID"];

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

        public static DataTable GetSpecializationsList()
        {
            DataTable dtSpicializationsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                       select * From Specializations
                        ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtSpicializationsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtSpicializationsList;
        }


    }
}
