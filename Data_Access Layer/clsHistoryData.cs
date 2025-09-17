using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsHistoryData
    {

        public static int AddNew(int PatientID, DateTime CreatedAt, short Status, DateTime LastStatusDate, int CreatedByUserID)
        {
            int HistoryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Histories (PatientID,CreatedAt,Status,LastStatusDate,CreatedByUserID)
                           Values(@PatientID,@CreatedAt,@Status,@LastStatusDate,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PatientID", PatientID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("Status", Status);


            command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);


            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    HistoryID = insertedID;
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
            return HistoryID;
        }


        public static bool FindByHistoryID(int HistoryID, ref int PatientID,
           ref DateTime CreatedAt, ref short Status, 
           ref DateTime LastStatusDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Histories where HistoryID = @HistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PatientID = (int)reader["PatientID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    Status = short.Parse(reader["Status"].ToString());

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
        public static bool FindByPatientID(ref int HistoryID,  int PatientID,
           ref DateTime CreatedAt, ref short Status,
           ref DateTime LastStatusDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Histories where PatientID = @PatientID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PatientID", PatientID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HistoryID = (int)reader["HistoryID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    Status = (short)reader["Status"];

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
        public static int GetHistoryIDWithStatusNew(int PatientID)
        {
            int histoyID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select HistoryID from Histories where PatientID = @PatientID and Status=1";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PatientID", PatientID);

            try
            {
                connection.Open();

                object result= command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    histoyID = ID;
                }
                   
                
            }
            catch (Exception ex)
            {
               
            }
            finally { connection.Close(); }
            return histoyID;
        }

        public static DataTable GetAllHistories()
        {

            DataTable dtHistoriesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT        Histories.HistoryID, Histories.PatientID, People.NationalNo, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName,
                            Histories.CreatedAt, Histories.CreatedByUserID, 
                            Users.UserName AS CreatedBy,case when Histories.Status=1 then 'New' when Histories.Status=2 then 'In Progress' when Histories.Status=3 then 'Completed' when Histories.Status=4 then 'Canceled' end as Status ,Histories.LastStatusDate
                            FROM            Histories INNER JOIN
                            Patients ON Histories.PatientID = Patients.PatientID INNER JOIN
                            People ON Patients.PersonID = People.PersonID INNER JOIN
                            Users ON Histories.CreatedByUserID = Users.UserID AND Patients.CreatedByUserID = Users.UserID AND People.PersonID = Users.PersonID
                        ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtHistoriesList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtHistoriesList;
        }
        public static bool ChangeStatus(int HistoryID,int NewStatus)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Histories
                           set  Status=@NewStatus,
                           LastStatusDate=@LastStatusDate
                           where HistoryID=@HistoryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
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
