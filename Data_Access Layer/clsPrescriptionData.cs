using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace HMS_DataAccess
{
    public class clsPrescriptionData
    {
      
        public static int AddNew(int HistoryID, int CreatedByDoctorID, short PrescriptionType, short Status, DateTime CreatedAt)
        {
            int PrescriptionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Prescriptions (HistoryID,CreatedByDoctorID,PrescriptionType,Status,CreatedAt)
                           Values(@HistoryID,@CreatedByDoctorID,@PrescriptionType,@Status,@CreatedAt);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("PrescriptionType", PrescriptionType);

          
                command.Parameters.AddWithValue("Status", Status);

            command.Parameters.AddWithValue("CreatedByDoctorID", CreatedByDoctorID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PrescriptionID = insertedID;
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
            return PrescriptionID;
        }

       
        public static bool FindByHistoryID(ref int PrescriptionID, int HistoryID,
            ref int CreatedByDoctorID,ref short PrescriptionType, ref short Status,
            ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from  Prescriptions where HistoryID = @HistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PrescriptionID = (int)reader["PrescriptionID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    PrescriptionType = Convert.ToInt16(reader["PrescriptionType"]);

                    Status = Convert.ToInt16(reader["Status"]);

                    CreatedByDoctorID = (int)reader["CreatedByDoctorID"];

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

      
        public static bool FindByPrescriptionID(int PrescriptionID, ref int HistoryID, ref int CreatedByDoctorID,
            ref short PrescriptionType, ref short Status,
            ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Prescriptions where PrescriptionID = @PrescriptionID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HistoryID = (int)reader["HistoryID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    PrescriptionType = Convert.ToInt16(reader["PrescriptionType"]);

                   
                        Status = Convert.ToInt16(reader["Status"]);

                    CreatedByDoctorID = (int)reader["CreatedByDoctorID"];

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


        public static DataTable GetAllHistoryPrescriptionsData(int HistoryID)
        {

            DataTable dtPrescriptionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                           SELECT        Prescriptions.PrescriptionID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS PatientName, 
                         People_1.FirstName + ' ' + People_1.SecondName + ' ' + People_1.ThirdName + ' ' + People_1.LastName AS DoctorName,
						 (case when Prescriptions.PrescriptionType=1 then 'Direct Treatment' when Prescriptions.PrescriptionType=2 then 'Medicine Prescription'
						 when Prescriptions.PrescriptionType=3 then 'Laboratory Test Prescription' end)as PrescriptionType,
						 (case when Prescriptions.Status=1 then 'New' when Prescriptions.Status=2 then 'Confirmed'
						 when Prescriptions.Status=3 then 'Canceled' when Prescriptions.Status=4 then 'Completed' end)as Status,
						 Prescriptions.CreatedAt
FROM            Histories INNER JOIN
                         Patients ON Histories.PatientID = Patients.PatientID INNER JOIN
                         People ON Patients.PersonID = People.PersonID INNER JOIN
                         Prescriptions ON Histories.HistoryID = Prescriptions.HistoryID INNER JOIN
                         Doctors ON Prescriptions.CreatedByDoctorID = Doctors.DoctorID INNER JOIN
                         MedicalStaffs ON Doctors.MedicalStaffID = MedicalStaffs.MedicalStaffID INNER JOIN
                         People AS People_1 ON MedicalStaffs.PersonID = People_1.PersonID
WHERE        (Histories.HistoryID = @HistoryID)";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("HistoryID", HistoryID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPrescriptionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPrescriptionsList;
        }
        public static bool ChangePrescriptionStatus(int PrescriptionID, short NewStatus)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Prescriptions 
                             set Status=@NewStatus 
                             where PrescriptionID=@PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);

            command.Parameters.AddWithValue("NewStatus", NewStatus);



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

        public static DataTable GetAllPrescriptions()
        {

            DataTable dtPrescriptionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                           SELECT        Prescriptions.PrescriptionID,Prescriptions.HistoryID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS PatientName, 
                         People_1.FirstName + ' ' + People_1.SecondName + ' ' + People_1.ThirdName + ' ' + People_1.LastName AS DoctorName,
						 (case when Prescriptions.PrescriptionType=1 then 'Direct Treatment' when Prescriptions.PrescriptionType=2 then 'Medicine Prescription'
						 when Prescriptions.PrescriptionType=3 then 'Laboratory Test Prescription' end)as PrescriptionType,
						 (case when Prescriptions.Status=1 then 'New' when Prescriptions.Status=2 then 'Confirmed'
						 when Prescriptions.Status=3 then 'Canceled' when Prescriptions.Status=4 then 'Completed' end)as Status,
						 Prescriptions.CreatedAt
                         FROM            Histories INNER JOIN
                         Patients ON Histories.PatientID = Patients.PatientID INNER JOIN
                         People ON Patients.PersonID = People.PersonID INNER JOIN
                         Prescriptions ON Histories.HistoryID = Prescriptions.HistoryID INNER JOIN
                         Doctors ON Prescriptions.CreatedByDoctorID = Doctors.DoctorID INNER JOIN
                         MedicalStaffs ON Doctors.MedicalStaffID = MedicalStaffs.MedicalStaffID INNER JOIN
                         People AS People_1 ON MedicalStaffs.PersonID = People_1.PersonID";




            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPrescriptionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPrescriptionsList;
        }
        public static bool DeletePrescription(int PrescriptionID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Prescriptions where PrescriptionID=@PrescriptionID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("PrescriptionID", PrescriptionID);

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

        
    }
}
