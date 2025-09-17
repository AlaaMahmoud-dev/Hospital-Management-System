using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsMedicinePrescriptionData
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

        public static bool DeleteMedicinesInPescription(int PrescriptionID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from MedicinePrescriptions where PrescriptionID=@PrescriptionID";

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
        public static bool SavePrescriptionMedicines(int PrescriptionID, int MedicineID, int Quantity)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into MedicinePrescriptions (PrescriptionID,MedicineID,Quantity,IsConfirmed) 
                             Values(@PrescriptionID,@MedicineID,@Quantity,@IsConfirmed);
                           ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("MedicineID", MedicineID);
            command.Parameters.AddWithValue("Quantity", Quantity);
            command.Parameters.AddWithValue("IsConfirmed", 1);
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






        public static DataTable GetPrescriptionMedicinesListData(int PrescriptionID)
        {

            DataTable dtMedicinesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT        Medicines.MedicineID, Medicines.MedicineName, Medicines.DosageForm,
                            Medicines.Strength, Medicines.TotalCost, MedicinePrescriptions.Quantity,
                            (case when MedicinePrescriptions.IsConfirmed=1 then 'Yes' when MedicinePrescriptions.IsConfirmed=0 then 'No' end)as IsConfirmed
                            FROM            MedicinePrescriptions INNER JOIN
                            Medicines ON MedicinePrescriptions.MedicineID = Medicines.MedicineID
                            where PrescriptionID=@PrescriptionID";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtMedicinesList.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtMedicinesList;
        }
        public static bool ChangeMedicineStatusInPrescription(int PrescriptionID,int MedicineID,bool IsConfirmed)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update MedicinePrescriptions 
                             set IsConfirmed=@IsConfirmed 
                             where PrescriptionID=@PrescriptionID and MedicineID=@MedicineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("MedicineID", MedicineID);
            command.Parameters.AddWithValue("IsConfirmed", IsConfirmed);
            


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

        public static bool IsMedicineConfirmed(int PrescriptionID,int MedicineID)
        {

            bool IsConfirmed = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsConfirmed
                            from MedicinePrescriptions 
                            where PrescriptionID = @PrescriptionID and MedicineID = @MedicineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("MedicineID", MedicineID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result!=null&&bool.TryParse(result.ToString(),out bool BooleanResult))
                {
                    IsConfirmed = BooleanResult;
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
            return IsConfirmed;

        }

        public static float GetMedicinePrescriptionFees(int PrescriptionID)
        {

            float PrescriptionFees = 0.0f;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select SUM(TotalCost)
                            from MedicinePrescriptions 
                            INNER JOIN Medicines on MedicinePrescriptions.MedicineID = Medicines.MedicineID
                            where PrescriptionID = @PrescriptionID and IsConfirmed = 1";

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
