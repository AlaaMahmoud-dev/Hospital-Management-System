using System;
using System.Data;
using System.Data.SqlClient;

namespace HMS_DataAccess
{
    public class clsDepartmentData
    {



        public static bool FindDepartmentByName(ref int DepartmentID, string DepartmentName,
            ref int DepartmentManagerID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Departments Where DepartmentName=@DepartmentName";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("DepartmentName", DepartmentName);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    DepartmentID = (int)reader["DepartmentID"];
                    DepartmentManagerID = (int)reader["DepartmentManagerID"];

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

        public static bool FindDepartmentByID(int DepartmentID, ref string DepartmentName,
           ref int DepartmentManagerID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Departments Where DepartmentID=@DepartmentID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("DepartmentID", DepartmentID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    DepartmentName = (string)reader["DepartmentName"];
                    DepartmentManagerID = (int)reader["DepartmentManagerID"];

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

        public static DataTable GetDepartmentsList()
        {

            DataTable dtDepartmentsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT Departments.DepartmentID, Departments.DepartmentName, Departments.DepartmentManagerID, People.NationalNo, 
                            People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName
                            FROM Departments INNER JOIN
                            Doctors ON Departments.DepartmentManagerID = Doctors.DoctorID 
                            INNER JOIN MedicalStaffs ON  Doctors.MedicalStaffID = MedicalStaffs.MedicalStaffID
                            INNER JOIN People ON MedicalStaffs.PersonID = People.PersonID";



            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDepartmentsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtDepartmentsList;
        }

        public static DataTable GetRoomsList()
        {

            DataTable dtRoomsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT Rooms.RoomID, Rooms.DepartmentID,
                            Departments.DepartmentName, Rooms.RoomNumber,
                            Rooms.Ward, Rooms.Capacity
                            FROM Departments INNER JOIN
                            Rooms ON Departments.DepartmentID = Rooms.DepartmentID";



            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtRoomsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtRoomsList;
        }


        public static int GetNumberOfPatientsInRoom(int RoomID)
        {

            int TotalNumberOfPatientsInRoom = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                             select count(*) from InPatientRecords where RoomID = @RoomID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Total))
                {
                    TotalNumberOfPatientsInRoom = Total;
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return TotalNumberOfPatientsInRoom;
        }
    }
}
