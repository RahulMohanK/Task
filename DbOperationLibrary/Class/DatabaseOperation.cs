using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


namespace DbOperationLibrary
{
    public class DatabaseOperation
    {
        string connectionString;
        SqlConnection connection;
        public DatabaseOperation()
        {
            connectionString = ConfigurationManager.AppSettings["connectionstring"];
            connection = new SqlConnection(connectionString);
            connection.Open();
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
                    // SqlDataAdapter adapter = new SqlDataAdapter();
                    sqlCommand = new SqlCommand("Proc_Staff_addData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                    sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                    sqlCommand.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = Phone;
                    sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                    sqlCommand.Parameters.AddWithValue("@Dob", SqlDbType.DateTime).Value = Dob;
                    sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                    sqlCommand.Parameters.AddWithValue("@Value", SqlDbType.NVarChar).Value = item;


                    // adapter.InsertCommand = new SqlCommand(sql, connection);
                    // adapter.InsertCommand.ExecuteScalar();

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
        public void RetriveAll(int StaffType)
        {
            try
            {
                string output = " ";
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
                        output = "EmpId : " + sqlDataReader.GetValue(0) + " Name : " + sqlDataReader.GetValue(1) + " Phone : " + sqlDataReader.GetValue(2) +
                                 " Email : " + sqlDataReader.GetValue(3) + " Dob : " + sqlDataReader.GetValue(4) + " Age : " + sqlDataReader.GetValue(8);
                        if (StaffType == 0)
                        {
                            output = output + " Designation : " + sqlDataReader.GetValue(5) + "\n";
                        }
                        else if (StaffType == 1)
                        {
                            output = output + " Subject : " + sqlDataReader.GetValue(6) + "\n";
                        }
                        else if (StaffType == 2)
                        {
                            output = output + " Department: " + sqlDataReader.GetValue(7) + "\n";
                        }
                        Console.WriteLine(output);
                    }
                }
                else
                {
                    Console.WriteLine("\n List is empty \n");
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }

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
                // SqlDataAdapter adapter = new SqlDataAdapter();
                sqlCommand = new SqlCommand("Proc_Staff_updateData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = EmpId;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                sqlCommand.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = Phone;
                sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sqlCommand.Parameters.AddWithValue("@Dob", SqlDbType.DateTime).Value = Dob;
                sqlCommand.Parameters.AddWithValue("@StaffType", SqlDbType.Int).Value = StaffType;
                sqlCommand.Parameters.AddWithValue("@Value", SqlDbType.NVarChar).Value = item;
                // adapter.InsertCommand = new SqlCommand(sql, connection);
                // adapter.InsertCommand.ExecuteScalar();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sql Updation :" + e);
            }
        }
        public void SearchStaff(string Name, int StaffType)
        {
            try
            {
                string output = " ";
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
                        output = "EmpId : " + sqlDataReader.GetValue(0) + " Name : " + sqlDataReader.GetValue(1) + " Phone : " + sqlDataReader.GetValue(2) +
                                 " Email : " + sqlDataReader.GetValue(3) + " Dob : " + sqlDataReader.GetValue(4) + " Age : " + sqlDataReader.GetValue(8);
                        if (StaffType == 0)
                        {
                            output = output + " Designation : " + sqlDataReader.GetValue(5) + "\n";
                        }
                        else if (StaffType == 1)
                        {
                            output = output + " Subject : " + sqlDataReader.GetValue(6) + "\n";
                        }
                        else if (StaffType == 2)
                        {
                            output = output + " Department: " + sqlDataReader.GetValue(7) + "\n";
                        }
                        Console.WriteLine(output);
                    }
                }
                else
                {
                    Console.WriteLine("\nStaff Not Found!!\n");
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
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
