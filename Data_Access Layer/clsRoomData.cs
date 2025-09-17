using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsRoomData
    {
        public static bool FindRoomInfoByID(int RoomID, ref int DepartmentID, ref string RoomNumber,
          ref short Ward, ref int Capacity)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Rooms Where RoomID=@RoomID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("RoomID", RoomID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    DepartmentID = (int)reader["DepartmentID"];
                    RoomNumber = (string)reader["RoomNumber"];
                    Ward = short.Parse(reader["Ward"].ToString());
                    Capacity = (int)reader["Capacity"];

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

        
    }
}
