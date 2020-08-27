using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Collections.Generic;


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
            connectionString = ConfigurationManager.AppSettings["connectionstring"];
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
        public void AddData(String EmpId, String Name, String Phone, String Email, object Dob, int StaffType, String item)
        {
            object[] result = new object[6];
            try
            {
                DatabaseOperation db = new DatabaseOperation();
                result = db.GetSingleStaff(EmpId, StaffType);
                if (result[0] == null)
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
        public List<object[]> RetriveAll(int StaffType)
        {


            List<object[]> finalResult = new List<object[]>();
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
                    while (sqlDataReader.Read())
                    {
                        object[] result = new object[7];
                        result[0] = sqlDataReader.GetValue(0);
                        result[1] = sqlDataReader.GetValue(1);
                        result[2] = sqlDataReader.GetValue(2);
                        result[3] = sqlDataReader.GetValue(3);
                        result[4] = sqlDataReader.GetValue(5);
                        result[5] = sqlDataReader.GetValue(8);

                        if (StaffType == 0)
                        {
                            result[6] = sqlDataReader.GetValue(5);

                        }
                        else if (StaffType == 1)
                        {
                            result[6] = sqlDataReader.GetValue(6);

                        }
                        else if (StaffType == 2)
                        {
                            result[6] = sqlDataReader.GetValue(7);

                        }
                        finalResult.Add(result);

                    }
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

        public void DeleteFromDb(int StaffType, String EmpId)
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
        public void UpdateStaff(String EmpId, String Name, String Phone, String Email, object Dob, int StaffType, String item)
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
        public List<object[]> SearchStaff(string Name, int StaffType)
        {
            List<object[]> finalResult = new List<object[]>();
            try
            {

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_searchStaff", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        object[] result = new object[7];
                        result[0] = sqlDataReader.GetValue(0);
                        result[1] = sqlDataReader.GetValue(1);
                        result[2] = sqlDataReader.GetValue(2);
                        result[3] = sqlDataReader.GetValue(3);
                        result[4] = sqlDataReader.GetValue(5);
                        result[5] = sqlDataReader.GetValue(8);

                        if (StaffType == 0)
                        {
                            result[6] = sqlDataReader.GetValue(5);

                        }
                        else if (StaffType == 1)
                        {
                            result[6] = sqlDataReader.GetValue(6);

                        }
                        else if (StaffType == 2)
                        {
                            result[6] = sqlDataReader.GetValue(7);

                        }
                        finalResult.Add(result);

                    }
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
        public object[] GetSingleStaff(string EmpId, int StaffType)
        {
            object[] result = new Object[6];
            try
            {
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                sqlCommand = new SqlCommand("Proc_Staff_retireveSingleStaff", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    result[0] = sqlDataReader.GetValue(0);
                    result[1] = sqlDataReader.GetValue(1);
                    result[2] = sqlDataReader.GetValue(2);
                    result[3] = sqlDataReader.GetValue(3);
                    result[4] = sqlDataReader.GetValue(4);
                    if (StaffType == 0)
                    {
                        result[5] = sqlDataReader.GetValue(5);
                    }
                    else if (StaffType == 1)
                    {
                        result[5] = sqlDataReader.GetValue(6);
                    }
                    else
                    {
                        result[5] = sqlDataReader.GetValue(7);
                    }

                }
                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            return result;

        }
    }
}
