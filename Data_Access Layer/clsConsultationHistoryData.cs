using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsConsultationHistoryData
    {
      
        public static bool FindByConsultationHistoryID(int ConsultationHistoryID, ref int HistoryID, 
        ref int DepartmentID, ref int DoctorID, ref DateTime CreatedAt, ref byte Status, ref DateTime LastStatusDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from ConsultationHistories where ConsultationHistoryID = @ConsultationHistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ConsultationHistoryID", ConsultationHistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HistoryID = (int)reader["HistoryID"];
                    DoctorID = (int)reader["DoctorID"];
                    DepartmentID = (int)reader["DepartmentID"];

                    CreatedAt = (DateTime)reader["CreatedAt"];

                    Status = (byte)reader["Status"];

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
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
        public static bool FindByHistoryID(ref int ConsultationHistoryID, int HistoryID, 
        ref int DepartmentID, ref int DoctorID, ref DateTime CreatedAt, ref byte Status, ref DateTime LastStatusDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from ConsultationHistories where HistoryID = @HistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ConsultationHistoryID = (int)reader["ConsultationHistoryID"];
                    DoctorID = (int)reader["DoctorID"];
                    DepartmentID = (int)reader["DepartmentID"];

                    CreatedAt = (DateTime)reader["CreatedAt"];

                    Status = (byte)reader["Status"];

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
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


        public static int AddNewConsultationHistory(int HistoryID,
        int DepartmentID, int DoctorID, DateTime CreatedAt,
        byte Status, DateTime LastStatusDate, int CreatedByUserID)
        {

            int MedicalStaffID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into ConsultationHistories (HistoryID,DepartmentID,DoctorID,CreatedAt,Status,LastStatusDate,CreatedByUserID)
                           Values(@HistoryID,@DepartmentID,@DoctorID,@CreatedAt,@Status,@LastStatusDate,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);
            command.Parameters.AddWithValue("DoctorID", DoctorID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("Status", Status);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);

        


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    MedicalStaffID = insertedID;
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
            return MedicalStaffID;

        }

        public static bool UpdateConsultationHistory(int ConsultationHistoryID, int HistoryID,
         int DepartmentID, int DoctorID, DateTime CreatedAt,
        byte Status, DateTime LastStatusDate, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update ConsultationHistories
                           set ConsultationHistoryID=@ConsultationHistoryID,
                           HistoryID=@HistoryID, 
                           DepartmentID=@DepartmentID,
                           DoctorID=@DoctorID,
                           CreatedAt=@CreatedAt,
                           Status=@Status,  
                           LastStatusDate=@LastStatusDate,
                           CreatedByUserID=@CreatedByUserID                         
                           where ConsultationHistoryID=@ConsultationHistoryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ConsultationHistoryID", ConsultationHistoryID);
            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);
            command.Parameters.AddWithValue("DoctorID", DoctorID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("Status", Status);
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


        public static bool DeleteConsultationHistory(int ConsultationHistoryID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from ConsultationHistories where ConsultationHistoryID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", ConsultationHistoryID);

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

        public static DataTable GetConsultationHistoriesList()
        {

            DataTable dtConsultationHistoriesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT        ConsultationHistories.ConsultationHistoryID, ConsultationHistories.HistoryID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS PatientName,
                            Doctor.FirstName + ' ' + Doctor.SecondName + ' ' + Doctor.ThirdName + ' ' + Doctor.LastName AS DoctorName, Departments.DepartmentName, 
                            ConsultationHistories.CreatedAt, ConsultationHistories.Status, ConsultationHistories.LastStatusDate
                            FROM            ConsultationHistories INNER JOIN
                            Departments ON ConsultationHistories.DepartmentID = Departments.DepartmentID INNER JOIN
                            Doctors ON ConsultationHistories.DoctorID = Doctors.DoctorID INNER JOIN
                            Histories ON ConsultationHistories.HistoryID = Histories.HistoryID INNER JOIN
                            Patients ON Histories.PatientID = Patients.PatientID INNER JOIN
                            People ON Patients.PersonID = People.PersonID INNER JOIN
                            MedicalStaffs ON Doctors.MedicalStaffID = MedicalStaffs.MedicalStaffID INNER JOIN 
                            People as Doctor ON Doctor.PersonID=MedicalStaffs.MedicalStaffID
                           ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtConsultationHistoriesList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtConsultationHistoriesList;
        }

    }
}
