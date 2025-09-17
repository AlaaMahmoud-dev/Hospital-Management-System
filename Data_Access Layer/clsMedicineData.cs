using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsMedicineData
    {

      
        public static bool FindMedicine(int MedicineID, ref string MedicineName, ref short DosageForm,
            ref int StockQuantity, ref string Strength, ref float InitialPrice,
            ref float TaxFees, ref float TotalCost, ref DateTime CreatedAt,
            ref DateTime UpdatedAt)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Medicines Where MedicineID=@MedicineID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("MedicineID", MedicineID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    MedicineName = (string)reader["MedicineName"];
                    DosageForm = Convert.ToInt16(reader["DosageForm"]);
                    StockQuantity = (int)reader["StockQuantity"];
                    Strength = (string)reader["Strength"];
                    

                    InitialPrice = Convert.ToSingle(reader["InitialPrice"]);
                    TaxFees = Convert.ToSingle(reader["TaxFees"]);
                    TotalCost= Convert.ToSingle(reader["TotalCost"]);

                   

                    CreatedAt = (DateTime)reader["CreatedAt"];
                    UpdatedAt = (DateTime)reader["UpdatedAt"];


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


        public static int AddNewMedicine(string MedicineName, short DosageForm,
            int StockQuantity, string Strength, float InitialPrice,
            float TaxFees, float TotalCost, DateTime CreatedAt,
            DateTime UpdatedAt)
        {

            int MedicineID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Medicines (MedicineName,DosageForm,StockQuantity,Strength,InitialPrice,TaxFees,TotalCost,CreatedAt,UpdatedAt)
                           Values(@MedicineName,@DosageForm,@StockQuantity,@Strength,@InitialPrice,@TaxFees,@TotalCost,@CreatedAt,@UpdatedAt);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicineName", MedicineName);
            command.Parameters.AddWithValue("DosageForm", DosageForm);
            command.Parameters.AddWithValue("StockQuantity", StockQuantity);


            command.Parameters.AddWithValue("Strength", Strength);


            command.Parameters.AddWithValue("InitialPrice", InitialPrice);
            command.Parameters.AddWithValue("TaxFees", TaxFees);

            command.Parameters.AddWithValue("TotalCost", TotalCost);


            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("UpdatedAt", UpdatedAt);
        

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    MedicineID = insertedID;
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
            return MedicineID;

        }


        public static bool UpdateMedicine(int MedicineID, string MedicineName, short DosageForm,
            int StockQuantity, string Strength, float InitialPrice,
            float TaxFees, float TotalCost, DateTime CreatedAt,
            DateTime UpdatedAt)

        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Medicines 
                           set MedicineName=@MedicineName, 
                           DosageForm=@DosageForm,
                           StockQuantity=@StockQuantity,
                           Strength=@Strength,
                           InitialPrice=@InitialPrice,
                           TaxFees=@TaxFees,
                           TotalCost=@TotalCost,
                           CreatedAt=@CreatedAt,
                           UpdatedAt=@UpdatedAt
                           
                           where MedicineID=@MedicineID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MedicineID", MedicineID);
            command.Parameters.AddWithValue("MedicineName", MedicineName);
            command.Parameters.AddWithValue("DosageForm", DosageForm);
            command.Parameters.AddWithValue("StockQuantity", StockQuantity);


            command.Parameters.AddWithValue("Strength", Strength);


            command.Parameters.AddWithValue("InitialPrice", InitialPrice);
            command.Parameters.AddWithValue("TaxFees", TaxFees);

            command.Parameters.AddWithValue("TotalCost", TotalCost);


            command.Parameters.AddWithValue("CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("UpdatedAt", UpdatedAt);

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

        public static bool DeleteMedicineData(int MedicineID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "delete from Medicines where MedicineID=@MedicineID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("MedicineID", MedicineID);

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

        public static DataTable GetAllMedicinesData()
        {

            DataTable dtMedicinesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"SELECT
                            MedicineID, MedicineName, DosageForm, Strength, InitialPrice,
                            TaxFees, TotalCost, CreatedAt, UpdatedAt, StockQuantity
                            FROM   
                            Medicines ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();


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

        public static DataTable GetAllNamesOfMedicines()
        {

            DataTable dtNamesOfMedicines = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = "Select MedicineName from Medicines";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dtNamesOfMedicines.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtNamesOfMedicines;
        }
    }
}
