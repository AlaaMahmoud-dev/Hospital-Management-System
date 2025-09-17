using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsMedicalStaffData
    {

        public static bool FindMedicalStaffInfoBYMedicalStaffID(int MedicalStaffID, ref int PersonID, ref int PositionID,
            ref int DepartmentID, ref short YearsOfExperience, ref string Certificates, ref int CreatedByUserID)
        {
            bool isFound=false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from MedicalStaffs where MedicalStaffID = @MedicalStaffID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicalStaffID", MedicalStaffID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    PositionID = (int)reader["PositionID"];
                    DepartmentID = (int)reader["DepartmentID"];


                    if (reader["YearsOfExperience"] == System.DBNull.Value)
                        YearsOfExperience = -1;
                    else
                        YearsOfExperience = short.Parse(reader["YearsOfExperience"].ToString());


                    if (reader["Certificates"] == System.DBNull.Value)
                        Certificates = "";
                    else
                        Certificates = (string)reader["Certificates"];


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
        public static bool FindMedicalStaffInfoBYPersonID(ref int MedicalStaffID, int PersonID,
            ref int PositionID,ref int DepartmentID, ref short YearsOfExperience,
            ref string Certificates, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"select * from MedicalStaffs where PersonID = @PersonID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MedicalStaffID = (int)reader["MedicalStaffID"];
                    PositionID = (int)reader["PositionID"];
                    DepartmentID = (int)reader["DepartmentID"];


                    if (reader["YearsOfExperience"] == System.DBNull.Value)
                        YearsOfExperience = -1;
                    else
                        YearsOfExperience = Convert.ToInt16( reader["YearsOfExperience"]);


                    if (reader["Certificates"] == System.DBNull.Value)
                        Certificates = "";
                    else
                        Certificates = (string)reader["Certificates"];


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

        
        public static int AddNewMedicalStaff(int PersonID, int PositionID,int DepartmentID,
            short YearsOfExperience, string Certificates, int CreatedByUserID)
        {

            int MedicalStaffID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into MedicalStaffs (PersonID,PositionID,DepartmentID,YearsOfExperience,Certificates,CreatedByUserID)
                           Values(@PersonID,@PositionID,@DepartmentID,@YearsOfExperience,@Certificates,@CreatedByUserID);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("PositionID", PositionID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);

            if (YearsOfExperience == -1)
                command.Parameters.AddWithValue("YearsOfExperience", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("YearsOfExperience", YearsOfExperience);

            if (Certificates == "")
                command.Parameters.AddWithValue("Certificates", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("Certificates", Certificates);

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

        public static bool UpdateMedicalStaff(int MedicalStaffID, int PersonID, int PositionID,
         int DepartmentID, short YearsOfExperience, string Certificates, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update MedicalStaffs
                           set MedicalStaffID=@MedicalStaffID,
                           PersonID=@PersonID, 
                           PositionID=@PositionID,
                           DepartmentID=@DepartmentID,
                           YearsOfExperience=@YearsOfExperience,
                           Certificates=@Certificates,
                           CreatedByUserID=@CreatedByUserID                         
                           where MedicalStaffID=@MedicalStaffID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicalStaffID", MedicalStaffID);
            command.Parameters.AddWithValue("PersonID", PersonID);
            command.Parameters.AddWithValue("PositionID", PositionID);
            command.Parameters.AddWithValue("DepartmentID", DepartmentID);

            if (YearsOfExperience == -1)
                command.Parameters.AddWithValue("YearsOfExperience", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("YearsOfExperience", YearsOfExperience);

            if (Certificates == "")
                command.Parameters.AddWithValue("YearsOfExperience", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("Certificates", Certificates);

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


        public static bool DeleteMedicalStaff(int MedicalStaffID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from MedicalStaffs where MedicalStaffID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", MedicalStaffID);

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

        public static DataTable GetMedicalStaffsList()
        {

            DataTable dtMedicalStaffsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT MedicalStaffs.MedicalStaffID, MedicalStaffs.PersonID,
                            People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName
                            + ' ' + People.LastName AS FullName, Positions.PositionID, Positions.PositionTitle, 
                            Departments.DepartmentID, Departments.DepartmentName, MedicalStaffs.YearsOfExperience,
                            MedicalStaffs.Certificates
                            FROM Departments 
                            INNER JOIN
                            MedicalStaffs ON Departments.DepartmentID = MedicalStaffs.DepartmentID
                            INNER JOIN
                            People ON MedicalStaffs.PersonID = People.PersonID
                            INNER JOIN
                            Positions ON MedicalStaffs.PositionID = Positions.PositionID
                           ";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMedicalStaffsList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtMedicalStaffsList;
        }

    }
}
