using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsInvoiceData
    {

       
        public static bool FindInvoiceData(int InvoiceID, ref int HistoryID, ref short InvoiceReason,
            ref float Fees,
            ref float Discount, ref float TotalAmount, ref bool IsPaid)
        {

            bool isFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Invoices Where InvoiceID=@InvoiceID";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("InvoiceID", InvoiceID);

            try
            {

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    HistoryID = (int)reader["HistoryID"];
                    InvoiceReason = Convert.ToInt16(reader["InvoiceReason"]);
                  


                    Fees = Convert.ToSingle(reader["Fees"]);
                    Discount = Convert.ToSingle(reader["Discount"]);
                    TotalAmount = Convert.ToSingle(reader["TotalAmount"]);



                    IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                   


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
       

        public static int AddNewInvoice(int HistoryID, short InvoiceReason,
             float Fees,
            float Discount, float TotalAmount, bool IsPaid)
        {

            int InvoiceID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Insert into Invoices (HistoryID,InvoiceReason,Fees,Discount,TotalAmount,IsPaid)
                           Values(@HistoryID,@InvoiceReason,@Fees,@Discount,@TotalAmount,@IsPaid);
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("InvoiceReason", InvoiceReason);
            


            command.Parameters.AddWithValue("Fees", Fees);
            command.Parameters.AddWithValue("Discount", Discount);

            command.Parameters.AddWithValue("TotalAmount", TotalAmount);


            command.Parameters.AddWithValue("IsPaid", IsPaid);
        


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InvoiceID = insertedID;
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
            return InvoiceID;

        }
       

        public static bool UpdateInvoice(int InvoiceID, int HistoryID, short InvoiceReason,
           float Fees,
            float Discount, float TotalAmount, bool IsPaid)

        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Invoices 
                           set HistoryID=@HistoryID, 
                           InvoiceReason=@InvoiceReason,
                           Fees=@Fees,
                           Discount=@Discount,
                           TotalAmount=@TotalAmount,
                           IsPaid=@IsPaid
                           
                           
                           where InvoiceID=@InvoiceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("InvoiceID", InvoiceID);
            command.Parameters.AddWithValue("HistoryID", HistoryID);
            command.Parameters.AddWithValue("InvoiceReason", InvoiceReason);
        
            command.Parameters.AddWithValue("Fees", Fees);
            command.Parameters.AddWithValue("Discount", Discount);

            command.Parameters.AddWithValue("TotalAmount", TotalAmount);


            command.Parameters.AddWithValue("IsPaid", IsPaid);
           

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

        public static DataTable GetAllInvoicesData()
        {

            DataTable dtInvoicesList = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"
                            SELECT        Invoices.InvoiceID, Invoices.HistoryID, People.FirstName+' '+ People.SecondName+' '+ People.ThirdName+' '+ People.LastName as FullName,
                            (case when Invoices.InvoiceReason=1 then 'Direct Treatment' when Invoices.InvoiceReason=2 then 'Medicine Prescription' when Invoices.InvoiceReason=3 then 'Test Prescription' when Invoices.InvoiceReason=4 then 'Consultation' end) as InvoiceReason
                            , Invoices.TotalAmount, Invoices.IsPaid
                            FROM            Histories INNER JOIN
                            Invoices ON Histories.HistoryID = Invoices.HistoryID INNER JOIN
                            Patients ON Histories.PatientID = Patients.PatientID INNER JOIN
                            People ON Patients.PersonID = People.PersonID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    dtInvoicesList.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dtInvoicesList;
        }

    }
}
