using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsDoctorData
    {

        public static bool FindByDoctorID(int DoctorID, ref int MedicalStaffID, ref int SpecializationID,
         ref int AvailabilityOfWeek)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Doctors where DoctorID = @DoctorID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("DoctorID", DoctorID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MedicalStaffID = (int)reader["MedicalStaffID"];
                    SpecializationID = (int)reader["SpecializationID"];
                    AvailabilityOfWeek = (int)reader["AvailabilityOfWeek"];



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
        public static bool FindByMedicalStaffID(ref int DoctorID, int MedicalStaffID, ref int SpecializationID,
           ref int AvailabilityOfWeek)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Doctors where MedicalStaffID = @MedicalStaffID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicalStaffID", MedicalStaffID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DoctorID = (int)reader["DoctorID"];
                    SpecializationID = (int)reader["SpecializationID"];
                    AvailabilityOfWeek = (int)reader["AvailabilityOfWeek"];



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


        public static int AddNewDoctor(int MedicalStaffID, int SpecializationID,
           int AvailabilityOfWeek)
        {

            int DoctorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Doctors (MedicalStaffID,SpecializationID,AvailabilityOfWeek)
                           Values(@MedicalStaffID,@SpecializationID,@AvailabilityOfWeek);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicalStaffID", MedicalStaffID);
            command.Parameters.AddWithValue("SpecializationID", SpecializationID);
            command.Parameters.AddWithValue("AvailabilityOfWeek", AvailabilityOfWeek);






            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DoctorID = insertedID;
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
            return DoctorID;

        }

        public static bool UpdateDoctor(int DoctorID, int MedicalStaffID, int SpecializationID,
          int AvailabilityOfWeek)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Doctors
                           set MedicalStaffID=@MedicalStaffID,
                           SpecializationID=@SpecializationID, 
                           AvailabilityOfWeek=@AvailabilityOfWeek
                           where DoctorID=@DoctorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicalStaffID", MedicalStaffID);
            command.Parameters.AddWithValue("DoctorID", DoctorID);
            command.Parameters.AddWithValue("SpecializationID", SpecializationID);
            command.Parameters.AddWithValue("AvailabilityOfWeek", AvailabilityOfWeek);



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


        public static bool DeleteDoctor(int DoctorID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Doctors where DoctorID=@ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("ID", DoctorID);

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

        public static DataTable GetDoctorsList()
        {

            DataTable dtMedicalStaffsList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT Doctors.DoctorID, Doctors.MedicalStaffID, People.NationalNo,
                            (People.FirstName + '  ' + People.SecondName+ '  ' + People.ThirdName+'  '+ People.LastName)AS FullName,
                            People.Phone, Positions.PositionTitle, Specializations.SpecializationTitle, 
                            Departments.DepartmentName
                            FROM Departments
                            INNER JOIN
                            Doctors ON Departments.DepartmentManagerID = Doctors.DoctorID 
                            INNER JOIN
                            MedicalStaffs ON Departments.DepartmentID = MedicalStaffs.DepartmentID AND Doctors.MedicalStaffID = MedicalStaffs.MedicalStaffID
                            INNER JOIN
                            People ON MedicalStaffs.PersonID = People.PersonID 
                            INNER JOIN
                            Positions ON MedicalStaffs.PositionID = Positions.PositionID 
                            INNER JOIN
                            Specializations ON Doctors.SpecializationID = Specializations.SpecializationID
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
