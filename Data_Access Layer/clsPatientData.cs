using System;
using System.Data;
using System.Data.SqlClient;

namespace HMS_DataAccess
{
    public class clsPatientData
    {

        public static bool FindByPatientID(int PatientID, ref int PersonID, ref int BloodTypeID,
           ref DateTime RegestrationDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Patients where PatientID = @PatientID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PatientID", PatientID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    BloodTypeID = (int)reader["BloodTypeID"];
                    RegestrationDate = (DateTime)reader["RegestrationDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    isFound = true;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;

        }
        public static bool FindBYPersonID(ref int PatientID, int PersonID, ref int BloodTypeID,
           ref DateTime RegestrationDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Patients where PersonID = @PersonID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PatientID = (int)reader["PatientID"];
                    BloodTypeID = (int)reader["BloodTypeID"];
                    RegestrationDate = (DateTime)reader["RegestrationDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    isFound = true;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;

        }


        public static int AddNewPatient(int PersonID, int BloodTypeID, DateTime RegestrationDate,int CreatedByUserID)
        {

            int PatientID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Patients (PersonID,BloodTypeID,RegestrationDate,CreatedByUserID)
                           Values(@PersonID,@BloodTypeID,@RegestrationDate,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("BloodTypeID", BloodTypeID);
            command.Parameters.AddWithValue("RegestrationDate", RegestrationDate);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PatientID = insertedID;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return PatientID;

        }

        public static bool UpdatePatient(int PatientID, int PersonID, int BloodTypeID, DateTime RegestrationDate, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Patients
                           set  PersonID=@PersonID, 
                           BloodTypeID=@BloodTypeID,
                           RegestrationDate=@RegestrationDate,
                           CreatedByUserID=@CreatedByUserID                         
                           where PatientID=@PatientID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PatientID", PatientID);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("BloodTypeID", BloodTypeID);
            command.Parameters.AddWithValue("RegestrationDate", RegestrationDate);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return RowsAffected > 0;
        }


        public static bool DeletePatient(int PatientID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Patients where PatientID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", PatientID);

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

        public static DataTable GetPatientsList()
        {

            DataTable dtPatientsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT Patients.PatientID, Patients.PersonID, People.NationalNo,
                            People.FirstName + '  ' + People.SecondName + '  ' +
                            People.ThirdName+ '  ' + People.LastName AS FullName,
                            People.Phone, BloodTypes.BloodTypeName
                            FROM BloodTypes 
                            INNER JOIN
                            Patients ON BloodTypes.BloodTypeID = Patients.BloodTypeID
                            INNER JOIN
                            People ON Patients.PersonID = People.PersonID
                           ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPatientsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPatientsList;
        }

        public static string GetBloodTypeNameByTypeID(int BloodTypeID)
        {
            string BloodTypeName = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select BloodTypeName from BloodTypes where BloodTypeID=@BloodTypeID";

            SqlCommand command1 = new SqlCommand(query, connection);

            command1.Parameters.AddWithValue("BloodTypeID", BloodTypeID);

            try
            {
                connection.Open();
                object Result = command1.ExecuteScalar();

                if (Result!=null)
                {
                    BloodTypeName= Result.ToString();
                }
               
            }
            catch (Exception ex)
            {
               
            }
            finally { connection.Close(); }
            return BloodTypeName;
        }

        public static int GetBloodTypeIDByTypeName(string BloodTypeName)
        {
            int BloodTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select BloodTypeID from BloodTypes where BloodTypeName=@BloodTypeName";

            SqlCommand command1 = new SqlCommand(query, connection);

            command1.Parameters.AddWithValue("BloodTypeName", BloodTypeName);

            try
            {
                connection.Open();
                object Result = command1.ExecuteScalar();

                if (Result != null)
                {
                    if (!int.TryParse(Result.ToString(), out BloodTypeID))
                        BloodTypeID = -1;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return BloodTypeID;
        }


        public static DataTable GetBloodTypesList()
        {

            DataTable dtBloodTypesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                       select * From BloodTypes
                        ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtBloodTypesList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtBloodTypesList;
        }
    }
}
