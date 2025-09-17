using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsPositionData
    {



        public static bool FindPositionInfoByPositionID(int PositionID, ref string PositionTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Positions Where PositionID=@PositionID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("PositionID", PositionID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PositionTitle = (string)reader["PositionTitle"];

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
        public static bool FindPositionInfoByPositionTitle(ref int PositionID, string PositionTitle)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Positions Where PositionTitle=@PositionTitle";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("PositionTitle", PositionTitle);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PositionID = (int)reader["PositionID"];

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

        public static DataTable GetPositionsList()
        {
            DataTable dtPositionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                       select * From Positions
                        ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPositionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPositionsList;
        }

    }
}
