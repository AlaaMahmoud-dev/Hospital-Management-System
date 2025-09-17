using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsPersonData
    {



        public static DataTable GetPeopleList()
        {

            DataTable dtPeopleList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.Gendor,
            case when People.Gendor= 0 then 'Male' else 'Femail'
            end as GendorCaption, People.Address, People.Phone, People.Email
            FROM People";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    dtPeopleList.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtPeopleList;
        }

        public static bool FindPerson(int ID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref char Gendor, ref string Address,
            ref string Phone, ref string Email)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People Where PersonID=@PersonID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("PersonID", ID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {


                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == System.DBNull.Value)
                    {
                        ThirdName = "";
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalNo = (string)reader["NationalNo"];
                    if (bool.TryParse(reader["Gendor"].ToString(), out bool Type))
                    {
                        if (Type)
                        {
                            Gendor = 'F';
                        }

                        else
                        {
                            Gendor = 'M';
                        }
                    }

                    if (reader["Address"] == System.DBNull.Value)
                    {
                        Address = "";
                    }
                    else
                    {
                        Address = (string)reader["Address"];
                    }
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] == System.DBNull.Value)
                    {
                        Email = "";
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }



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
      

        public static DataTable GetCountriesList()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = "Select CountryName from Countries";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dt;
        }

        public static bool FindPerson(ref int ID, string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref char Gendor, ref string Address,
            ref string Phone, ref string Email)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People Where NationalNo=@NationalNo";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("NationalNo", NationalNo);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    
                    if (reader["ThirdName"] == System.DBNull.Value)
                    {
                        ThirdName = "";
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    if (bool.TryParse(reader["Gendor"].ToString(), out bool Type))
                    {
                        if (Type)
                        {
                            Gendor = 'F';
                        }

                        else
                        {
                            Gendor = 'M';
                        }
                    }
                    if (reader["Address"] == System.DBNull.Value)
                    {
                        Address = "";
                    }
                    else
                    {
                        Address = (string)reader["Address"];
                    }

                    Phone = (string)reader["Phone"];

                    if (reader["Email"] == System.DBNull.Value)
                    {
                        Email = "";
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }


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

        public static string GetCountryName(int CountryID)
        {
            string CountryName = "";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select CountryName from Countries where CountryID=@CountryID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("CountryID", CountryID);
            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    CountryName = (string)result;
                }
                else
                {
                    Console.WriteLine("Country Not Found");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            finally { connection.Close(); }

            return CountryName;


        }


        public static int GetCountryID(string CountryName)
        {
            int CountryID = -1;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select CountryID from Countries where CountryName=@CountryName";



            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("CountryName", CountryName);


            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    CountryID = (int)result;
                }
                else
                {
                    Console.WriteLine("Country Not Found");
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            finally { connection.Close(); }

            return CountryID;


        }


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, 
            char Gendor, string Address, string Phone, string Email)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Email,Phone,Address)
                           Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Email,@Phone,@Address);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
            {
                command.Parameters.AddWithValue("ThirdName", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("ThirdName", ThirdName);

            }

            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);
            if (string.IsNullOrEmpty(Address))
            {
                command.Parameters.AddWithValue("Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Address", Address);

            }
            command.Parameters.AddWithValue("Phone", Phone);

            if (string.IsNullOrEmpty(Email))
            {
                command.Parameters.AddWithValue("Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Email", Email);

            }
            if (Gendor == 'M')
            {
                command.Parameters.AddWithValue("Gendor", 0);
            }
            else
            {
                command.Parameters.AddWithValue("Gendor", 1);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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
            return PersonID;

        }


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, char Gendor, string Address,
            string Phone, string Email)

        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People 
                           set NationalNo=@NationalNo, 
                           FirstName=@FirstName,
                           SecondName=@SecondName,
                           ThirdName=@ThirdName,
                           LastName=@LastName,
                           Gendor=@Gendor,
                           Email=@Email,
                           Phone=@Phone,
                           Address=@Address,
                           DateOfBirth=@DateOfBirth
                           where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("NationalNo", NationalNo);
            command.Parameters.AddWithValue("FirstName", FirstName);
            command.Parameters.AddWithValue("SecondName", SecondName);

            if (ThirdName == "")
            {
                command.Parameters.AddWithValue("ThirdName", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("ThirdName", ThirdName);
            }


            command.Parameters.AddWithValue("LastName", LastName);
            command.Parameters.AddWithValue("DateOfBirth", DateOfBirth);

            if (Address == "")
            {
                command.Parameters.AddWithValue("Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Address", Address);
            }


            command.Parameters.AddWithValue("Phone", Phone);


            if (Email == "")
            {
                command.Parameters.AddWithValue("Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Email", Email);
            }

            if (Gendor == 'M')
            {
                command.Parameters.AddWithValue("Gendor", 0);
            }
            else
            {
                command.Parameters.AddWithValue("Gendor", 1);
            }

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

        public static DataTable GetAllNationalNumbers()
        {
            DataTable dtNationalNumbers = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select NationalNo from People";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtNationalNumbers.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }

            return dtNationalNumbers;
        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from People where PersonID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", PersonID);

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


        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            bool isFound= false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select PersonID from People Where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open ();
                object PersonID=command.ExecuteScalar();

                if (PersonID != null && int.TryParse(PersonID.ToString(), out int RetrivedPersonID))
                {
                    isFound = true;

                }
                

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return isFound;
        }










    }
}
