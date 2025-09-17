using System;
using System.Data;
using System.Data.SqlClient;

namespace HMS_DataAccess
{
    public class clsLaboratoryTestData
    {

        public static bool FindTest(int TestID, ref string TestTitle,
            ref float TestFees, ref string Description)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from LaboratoryTests Where TestID=@TestID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("TestID", TestID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    TestTitle = (string)reader["TestTitle"];
                  
                    Description = (string)reader["Description"];


                    TestFees = Convert.ToSingle(reader["TestFees"]);
                 


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


        public static int AddNewTest(string TestTitle, float TestFees, string Description
           )
        {

            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into LaboratoryTests (TestTitle,TestFees,Description)
                           Values(@TestTitle,@TestFees,@Description);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("TestTitle", TestTitle);

            command.Parameters.AddWithValue("TestFees", TestFees);

            command.Parameters.AddWithValue("Description", Description);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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
            return TestID;

        }


        public static bool UpdateTest(int TestID, string TestTitle, float TestFees, string Description
           )

        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update LaboratoryTests 
                           set TestTitle=@TestTitle, 
                           TestFees=@TestFees,
                           Description=@Description
                           
                           where TestID=@TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("TestID", TestID);
            command.Parameters.AddWithValue("TestTitle", TestTitle);
           
            command.Parameters.AddWithValue("TestFees", TestFees);
            command.Parameters.AddWithValue("Description", Description);
            

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

        public static bool DeleteTestData(int TestID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from LaboratoryTests where TestID=@TestID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("TestID", TestID);

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

        public static DataTable GetAllTestsData()
        {

            DataTable dtTestsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query =
                @"SELECT  
                TestID, TestTitle, TestFees, Description
                FROM 
                LaboratoryTests";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();


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


    }
}
