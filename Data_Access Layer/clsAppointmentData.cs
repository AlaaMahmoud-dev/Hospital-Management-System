using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsAppointmentData
    {


        public static bool FindByAppointmentID(int AppointmentID, ref int ConsultationHistoryID,
         ref byte Status, ref DateTime LastStatusDate, ref DateTime AppointmentDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Appointments where AppointmentID = @AppointmentID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("AppointmentID", AppointmentID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ConsultationHistoryID = (int)reader["ConsultationHistoryID"];
                   
                    Status = (byte)reader["Status"];

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
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
        public static bool FindByConsultationHistoryID(ref int AppointmentID,  int ConsultationHistoryID,
         ref byte Status, ref DateTime LastStatusDate, ref DateTime AppointmentDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Appointments where ConsultationHistoryID = @ConsultationHistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ConsultationHistoryID", ConsultationHistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AppointmentID = (int)reader["AppointmentID"];
                   

                    Status = (byte)reader["Status"];

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
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


        public static int AddNewAppointment(int ConsultationHistoryID,
         byte Status,  DateTime LastStatusDate,  DateTime AppointmentDate,  int CreatedByUserID)
        {

            int AppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Appointments (ConsultationHistoryID,Status,LastStatusDate,AppointmentDate,CreatedByUserID)
                           Values(@ConsultationHistoryID,@Status,@LastStatusDate,@AppointmentDate,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ConsultationHistoryID", ConsultationHistoryID);
            command.Parameters.AddWithValue("Status", Status);
            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
           
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AppointmentID = insertedID;
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
            return AppointmentID;

        }

        public static bool UpdateAppointment(int AppointmentID,int ConsultationHistoryID, byte Status, DateTime LastStatusDate, DateTime AppointmentDate, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Appointments
                           set AppointmentID=@AppointmentID,
                           ConsultationHistoryID=@ConsultationHistoryID,
                           Status=@Status, 
                           LastStatusDate=@LastStatusDate,
                           AppointmentDate=@AppointmentDate,
                           CreatedByUserID=@CreatedByUserID                         
                           where ConsultationHistoryID=@ConsultationHistoryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("AppointmentID", AppointmentID);
            command.Parameters.AddWithValue("ConsultationHistoryID", ConsultationHistoryID);
            command.Parameters.AddWithValue("Status", Status);
            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
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


        public static bool DeleteAppointment(int AppointmentID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Appointments where AppointmentID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", AppointmentID);

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

        public static DataTable GetAllAppointments()
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

