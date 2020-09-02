using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using StaffLibrary;
//change while in retrieve to function
//populate value to corresponding staff model objects
namespace DbOperationLibrary
{
    public class DatabaseOperation
    {
        string connectionString;
        SqlConnection connection;
        static DataTable dataTable = new DataTable("typ_Staff");
        DataRow dataRow;

        public DatabaseOperation()
        {
            connectionString = "Server=DESKTOP-ROBHQ7Q;Database=School Database;Trusted_Connection=True";
            //ConfigurationManager.AppSettings["connectionstring"];
            Console.WriteLine("Db operation " + connectionString);
            connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                dataTable.Columns.Add("EmpId", typeof(string));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Phone", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Dob", typeof(DateTime));
                dataTable.Columns.Add("StaffType", typeof(int));
                dataTable.Columns.Add("CreatedDate", typeof(DateTime));
                dataTable.Columns.Add("UpdatedDate", typeof(DateTime));
                dataTable.Columns.Add("Value", typeof(string));
            }
            catch (Exception)
            { }

        }
        public void ExecuteBulkProc()
        {
            try
            {
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("Proc_Staff_bulkInsertion", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@typetable", dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                connection.Close();
                dataTable.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBulk proc error : " + e);
            }
        }
        public void AddBulkData(String EmpId, String Name, String Phone, String Email, object Dob, int StaffType, String item)
        {
            dataRow = dataTable.NewRow();
            dataRow["EmpId"] = EmpId;
            dataRow["Name"] = Name;
            dataRow["Phone"] = Phone;
            dataRow["Email"] = Email;
            dataRow["Dob"] = Convert.ToDateTime(Dob);
            dataRow["StaffType"] = StaffType;
            dataRow["Value"] = item;
            dataRow["CreatedDate"] = Convert.ToDateTime(DateTime.Now);
            dataRow["UpdatedDate"] = Convert.ToDateTime(DateTime.Now);
            dataTable.Rows.Add(dataRow);
            Console.WriteLine("\nInsertion Successfull\n");

        }

        public void AddData(String EmpId, String Name, String Phone, String Email, DateTime Dob, int StaffType, String item)
        {
            Staff result = null;
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                result = db.GetSingleStaff(EmpId, StaffType);
                if (result == null)
                {
                    SqlCommand sqlCommand;

                    sqlCommand = new SqlCommand("Proc_Staff_addData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                    sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                    sqlCommand.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = Phone;
                    sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                    sqlCommand.Parameters.AddWithValue("@Dob", SqlDbType.DateTime).Value = Dob;
                    sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                    sqlCommand.Parameters.AddWithValue("@Value", SqlDbType.NVarChar).Value = item;

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("\nData Insertion Complete");
                    sqlCommand.Dispose();
                    connection.Close();

                }
                else
                {
                    Console.WriteLine("\nEmployee Id already exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sql Insertion :" + e);
            }

        }
        public List<Staff> RetriveAll(int StaffType)
        {
            List<Staff> finalResult = new List<Staff>();
            try
            {

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_retireveAll", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    finalResult = Populate(sqlDataReader, StaffType);

                    return finalResult;
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            return null;

        }
        public List<Staff> Retrive()
        {
            List<Staff> finalResult = new List<Staff>();
            try
            {

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_retireve", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    finalResult = Populate(sqlDataReader, 0);

                    return finalResult;
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            return null;

        }


        public void DeleteStaff(int StaffType, String EmpId)
        {
            try
            {
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();
                sqlCommand = new SqlCommand("Proc_Staff_deleteStaff", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                sqlCommand.ExecuteNonQuery();
                // adapter.DeleteCommand = new SqlCommand(sql, connection);
                // adapter.DeleteCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sql Deletion :" + e);
            }


        }
        public void UpdateStaff(String EmpId, String Name, String Phone, String Email, DateTime Dob, int StaffType, String item)
        {
            try
            {
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("Proc_Staff_updateData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = Phone;
                sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sqlCommand.Parameters.AddWithValue("@Dob", SqlDbType.DateTime).Value = Dob;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@Value", SqlDbType.NVarChar).Value = item;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sql Updation :" + e);
            }
        }
        public List<Staff> SearchStaff(string Name, int StaffType)
        {
            List<Staff> finalResult = new List<Staff>();
            try
            {
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_searchStaff", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                sqlDataReader = sqlCommand.ExecuteReader();

                finalResult = Populate(sqlDataReader, StaffType);

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();
                return finalResult;

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            return null;
        }
        public Staff GetSingleStaff(string EmpId, int StaffType)
        {
            Staff result = null; ;

            try
            {
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_retireveSingleStaff", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    result = Populate(sqlDataReader, StaffType)[0];
                }
                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql single staff :" + e);
            }
            return result;

        }
        public List<Staff> Populate(SqlDataReader sqlDataReader, int StaffType)
        {
            List<Staff> staffList = new List<Staff>();
            while (sqlDataReader.Read())
            {
                if ((int)sqlDataReader.GetValue(9) == 0)
                {
                    AdministrativeStaff administrative = new AdministrativeStaff();
                    administrative.EmpId = sqlDataReader.GetValue(0).ToString();
                    administrative.Name = sqlDataReader.GetValue(1).ToString();
                    administrative.Phone = sqlDataReader.GetValue(2).ToString();
                    administrative.Email = sqlDataReader.GetValue(3).ToString();
                    administrative.Dob = (DateTime)sqlDataReader.GetValue(4);
                    administrative.StaffType = (SType)sqlDataReader.GetValue(8);
                    administrative.Designation = sqlDataReader.GetValue(5).ToString();
                    staffList.Add(administrative);
                }
                else if ((int)sqlDataReader.GetValue(9) == 1)
                {
                    TeachingStaff teaching = new TeachingStaff();
                    teaching.EmpId = sqlDataReader.GetValue(0).ToString();
                    teaching.Name = sqlDataReader.GetValue(1).ToString();
                    teaching.Phone = sqlDataReader.GetValue(2).ToString();
                    teaching.Email = sqlDataReader.GetValue(3).ToString();
                    teaching.Dob = (DateTime)sqlDataReader.GetValue(4);
                    teaching.StaffType = (SType)sqlDataReader.GetValue(8);
                    teaching.Subject = sqlDataReader.GetValue(6).ToString();
                    staffList.Add(teaching);

                }
                else if ((int)sqlDataReader.GetValue(9) == 2)
                {
                    SupportStaff support = new SupportStaff();
                    support.EmpId = sqlDataReader.GetValue(0).ToString();
                    support.Name = sqlDataReader.GetValue(1).ToString();
                    support.Phone = sqlDataReader.GetValue(2).ToString();
                    support.Email = sqlDataReader.GetValue(3).ToString();
                    support.Dob = (DateTime)sqlDataReader.GetValue(4);
                    support.StaffType = (SType)sqlDataReader.GetValue(8);
                    support.Department = sqlDataReader.GetValue(7).ToString();
                    staffList.Add(support);
                }
            }
            return staffList;
        }
    }

}
