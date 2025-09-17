using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsInPatientRecordData
    {

        public static int AddNew(int HistoryID, DateTime CreatedAt, short Status, DateTime LastStatusDate,int RoomID, int CreatedByUserID)
        {
            int RecordID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into InPatientRecords (HistoryID,CreatedAt,Status,LastStatusDate,RoomID,CreatedByUserID)
                           Values(@HistoryID,@CreatedAt,@Status,@LastStatusDate,@RoomID,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("Status", Status);


            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);


            command.Parameters.AddWithValue("RoomID", RoomID);
            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    RecordID = insertedID;
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
            return RecordID;
        }


        public static bool FindByHistoryID(ref int RecordID, int HistoryID, 
           ref DateTime CreatedAt, ref short Status,
           ref DateTime LastStatusDate,ref int RoomID, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from InPatientRecords where HistoryID = @HistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    RecordID = (int)reader["RecordID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    Status = short.Parse(reader["Status"].ToString());

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    RoomID = (int)reader["RoomID"];
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

        public static bool FindByRecordID( int RecordID,ref int HistoryID,
           ref DateTime CreatedAt, ref short Status,
           ref DateTime LastStatusDate, ref int RoomID, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from InPatientRecords where RecordID = @RecordID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("RecordID", RecordID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HistoryID = (int)reader["HistoryID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    Status = short.Parse(reader["Status"].ToString());

                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    RoomID = (int)reader["RoomID"];
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
        public static DataTable GetAllInPatientRecords()
        {

            DataTable dtRecordsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT
                            InPatientRecords.RecordID, InPatientRecords.HistoryID, Patients.PatientID,
                            (People.FirstName+' '+ People.SecondName+' '+ People.ThirdName+' '+ People.LastName)As FullName,
                            case when InPatientRecords.Status=1 then 'New' when InPatientRecords.Status=2 then 'In Progress' 
                            when InPatientRecords.Status=3 then 'Completed' when InPatientRecords.Status=4 then 'Canceled'
                            when InPatientRecords.Status=5 then 'Appointment Marked' end as Status, 
                            InPatientRecords.LastStatusDate, Rooms.RoomNumber, Departments.DepartmentName
                            FROM
                            InPatientRecords
                            INNER JOIN
                            Histories ON InPatientRecords.HistoryID = Histories.HistoryID
                            INNER JOIN
                            Patients ON Histories.PatientID = Patients.PatientID
                            INNER JOIN
                            People ON Patients.PersonID = People.PersonID 
                            INNER JOIN
                            Rooms ON InPatientRecords.RoomID = Rooms.RoomID
                            INNER JOIN
                            Departments ON Rooms.DepartmentID = Departments.DepartmentID
                        ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtRecordsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtRecordsList;
        }

        public static bool ChangeStatus(int RecordID, int NewStatus)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update InPatientRecords
                           set  Status=@NewStatus,
                           LastStatusDate=@LastStatusDate
                           where RecordID=@RecordID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("RecordID", RecordID);
            command.Parameters.AddWithValue("NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);



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


    }
}
