using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsLaboratoryTestPrescriptionData
    {
        public static DataTable GetPermissionsList()
        {

            DataTable dtPermissionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT PermissionID, PermissionNumber, PermissionTitle
                            FROM Permissions";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPermissionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPermissionsList;
        }


        public static DataTable GetUserPermissionsList(int UserID)
        {

            DataTable dtUserPermissionsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            select UserPermissions.PermissionID,Permissions.PermissionNumber,Permissions.PermissionTitle 
                            from Permissions inner join UserPermissions
                            on Permissions.PermissionID=UserPermissions.PermissionID
                            where UserID=@UserID";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("UserID", UserID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUserPermissionsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtUserPermissionsList;
        }

        public static bool DeleteTestsInPrescription(int PrescriptionID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from TestPrescriptions where PrescriptionID=@PrescriptionID";

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
        public static bool SavePrescriptionTests(int PrescriptionID, int TestID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into TestPrescriptions (PrescriptionID,TestID) 
                             Values(@PrescriptionID,@TestID);
                           ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("TestID", TestID);

            try
            {

                connection.Open();


                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); }
            return RowsAffected > 0;
        }
        public static DataTable GetPrescriptionTestsListData(int PrescriptionID)
        {

            DataTable dtTestsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                    
                            SELECT        LaboratoryTests.TestID, LaboratoryTests.TestTitle, LaboratoryTests.TestFees, LaboratoryTests.Description
                            FROM            LaboratoryTests INNER JOIN
                            TestPrescriptions ON LaboratoryTests.TestID = TestPrescriptions.TestID
                            where PrescriptionID=@PrescriptionID";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtTestsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtTestsList;
        }
        public static float GetTestsPrescriptionFees(int PrescriptionID)
        {

            float PrescriptionFees = 0.0f;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select SUM(TestFees)
                            from TestPrescriptions 
                            INNER JOIN LaboratoryTests on TestPrescriptions.TestID = LaboratoryTests.TestID
                            where PrescriptionID = @PrescriptionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && float.TryParse(result.ToString(), out float FloatResult))
                {
                    PrescriptionFees = FloatResult;
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
            return PrescriptionFees;

        }
        
    }
}
