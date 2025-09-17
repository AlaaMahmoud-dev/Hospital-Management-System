using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsDiagnosisData
    {

        public static int AddNew(int HistoryID, string CaseDescription, string SymptomsDescription, DateTime CreatedAt, int CreatedByUserID)
        {
            int DiagnosisID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Diagnoses (HistoryID,CaseDescription,SymptomsDescription,CreatedAt,CreatedByUserID)
                           Values(@HistoryID,@CaseDescription,@SymptomsDescription,@CreatedAt,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("CaseDescription", CaseDescription);

            if (string.IsNullOrEmpty(SymptomsDescription))
                command.Parameters.AddWithValue("SymptomsDescription", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("SymptomsDescription", SymptomsDescription);

            command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DiagnosisID = insertedID;
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
            return DiagnosisID;
        }


        public static bool FindByHistoryID(ref int DiagnosisID, int HistoryID,
            ref string CaseDescription, ref string SymptomsDescription,
            ref DateTime CreatedAt, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Diagnoses where HistoryID = @HistoryID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DiagnosisID = (int)reader["DiagnosisID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CaseDescription = (string)reader["CaseDescription"];

                    if (reader["SymptomsDescription"] == System.DBNull.Value)
                        SymptomsDescription = "";
                    else
                        SymptomsDescription = (string)reader["SymptomsDescription"];

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


        public static bool FindByDiagnosisID(int DiagnosisID,ref int HistoryID,
            ref string CaseDescription, ref string SymptomsDescription,
            ref DateTime CreatedAt, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from Diagnoses where DiagnosisID = @DiagnosisID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("DiagnosisID", DiagnosisID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    HistoryID = (int)reader["HistoryID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CaseDescription = (string)reader["CaseDescription"];

                    if (reader["SymptomsDescription"] == System.DBNull.Value)
                        SymptomsDescription = "";
                    else
                        SymptomsDescription = (string)reader["SymptomsDescription"];

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
    }
}
