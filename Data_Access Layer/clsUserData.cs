using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsUserData
    {

        public static bool FindUserByUserID(int UserID, ref int PersonID, ref string UserName,
            ref string Password, ref bool IsActive,ref int RoleID,
            ref int DepartmentID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Users Where UserID=@UserID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("UserID", UserID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];

                    if (bool.TryParse(reader["IsActive"].ToString(), out bool ActiveOrNot))
                        IsActive = ActiveOrNot;

                    RoleID = (int)reader["RoleID"];
                    DepartmentID = (int)reader["DepartmentID"];

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

        public static bool FindUserByUserName(ref int UserID, ref int PersonID, string UserName, 
            ref string Password, ref bool isActive,ref int RoleID,
            ref int DepartmentID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Users Where UserName=@UserName";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("UserName", UserName);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];


                    if (bool.TryParse(reader["IsActive"].ToString(), out bool ActiveOrNot))
                    {
                        isActive = ActiveOrNot;
                    }


                    RoleID = (int)reader["RoleID"];
                    DepartmentID = (int)reader["DepartmentID"];


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

        public static bool IsPersonAnUser(int PersonID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select PersonID from Users Where PersonID=@PersonID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("PersonID", PersonID);

            try
            {

                connection.Open();

                object Result = sqlCommand.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {

                    if (ID == PersonID)
                    {
                        isFound = true;
                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { connection.Close(); }

            return isFound;

        }

        public static DataTable GetUsersList()
        {

            DataTable dtUsersList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @" 
                            SELECT  Users.UserID,  Users.PersonID, 
                            People.FirstName + '   ' + People.SecondName + '   ' +
                            People.ThirdName + '   ' + People.LastName as FullName,
                            Users.UserName ,Users.RoleID, Roles.RoleTitle,
                            Users.DepartmentID, Departments.DepartmentName, Users.IsActive
                            from People
                            INNER JOIN Users ON People.PersonID = Users.PersonID
                            INNER join Roles on Users.RoleID=Roles.RoleID
                            INNER join Departments on Departments.DepartmentID=Users.DepartmentID";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtUsersList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtUsersList;
        }



        public static int AddNewUser(int PersonID, string UserName, string Password, 
            bool isActive, int RoleID, int DepartmentID)
        {

            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Users (PersonID,UserName,Password,IsActive,RoleID,DepartmentID)
                           Values(@PersonID,@UserName,@Password,@isActive,@RoleID,@DepartmentID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("UserName", UserName);
            command.Parameters.AddWithValue("Password", Password);
            command.Parameters.AddWithValue("isActive", Convert.ToInt16(isActive));
            command.Parameters.AddWithValue("RoleID", RoleID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
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
            return UserID;

        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName,
            string Password, bool isActive, int RoleID,
            int DepartmentID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                           set PersonID=@PersonID, 
                           UserName=@UserName,
                           Password=@Password,
                           IsActive=@isActive,
                           RoleID=@RoleID,
                           DepartmentID=@DepartmentID
                          
                           where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("UserID", UserID);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("UserName", UserName);
            command.Parameters.AddWithValue("Password", Password);
            command.Parameters.AddWithValue("isActive", Convert.ToInt16(isActive));
            command.Parameters.AddWithValue("RoleID", RoleID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);
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


        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Users where UserID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", UserID);

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

        
               public static bool FindByUsernameAndPassword(ref int UserID, ref int PersonID, string UserName,
             string Password, ref bool isActive, ref int RoleID,
            ref int DepartmentID)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Users Where UserName=@UserName and Password=@Password";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("UserName", UserName);
            sqlCommand.Parameters.AddWithValue("Password", Password);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];


                    if (bool.TryParse(reader["IsActive"].ToString(), out bool ActiveOrNot))
                    {
                        isActive = ActiveOrNot;
                    }


                    RoleID = (int)reader["RoleID"];
                    DepartmentID = (int)reader["DepartmentID"];


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
        public static bool GetLastLoginInfo(ref int LoginID, ref int UserID, ref string UserName, ref string Password, ref bool isActive, ref bool isRememberMeChecked)
        {
            bool isLoged = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query2 = @"select top 1 LoginID from Login
                           order by LoginID desc";

            SqlCommand command2 = new SqlCommand(query2, connection);

            object LastLoginID = null;
            try
            {
                connection.Open();

                LastLoginID = command2.ExecuteScalar();




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            string query = "select * from Login Where LoginID=@LastLoginID";

            SqlCommand command = new SqlCommand(query, connection);

            if (LastLoginID != null)
            {
                command.Parameters.AddWithValue("LastLoginID", Convert.ToInt16(LastLoginID.ToString()));
            }


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LoginID = (int)reader["LoginID"];
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];


                    if (!string.IsNullOrWhiteSpace(reader["isActive"].ToString()))
                    {
                        if (reader["isActive"].ToString() == "1")
                            isActive = true;

                    }
                    if (!string.IsNullOrWhiteSpace(reader["isRememberChecked"].ToString()))
                    {
                        if (reader["isRememberChecked"].ToString() == "1")
                            isRememberMeChecked = true;

                    }



                    isLoged = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isLoged;
        }

        public static bool SaveLoginData(int UserID, string UserName, string Password, bool isActive, bool isRememberMeChecked)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Login (UserID,UserName,Password,isActive,isRememberChecked) Values
                           (@UserID,@UserName,@Password,@isActive,@isRememberChecked)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("UserID", UserID);
            command.Parameters.AddWithValue("UserName", UserName);
            command.Parameters.AddWithValue("Password", Password);
            command.Parameters.AddWithValue("isActive", Convert.ToInt16(isActive));
            command.Parameters.AddWithValue("isRememberChecked", Convert.ToInt16(isRememberMeChecked));

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
