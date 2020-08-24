using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace DbOperationLibrary
{
    public class DatabaseOperation
    {
        string connectionString;
        SqlConnection connection;
        public DatabaseOperation()
        {

            connectionString = @"Server=DESKTOP-ROBHQ7Q;Database=School Database;Trusted_Connection=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void AddData(String EmpId, String Name, String Phone, String Email, object Dob, int StaffType, String Value)
        {

            try
            {

                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "";
                //sql = "addData " + "'admin1','ramo','+91-78945612','asd@asd.com'," + 22 / 02 / 1999 + "," + 0 + "," + "'Chemistry'";
                sql = "addData @EmpId,@Name,@Phone,@Email,@Dob,@StaffType,@Value";
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@EmpId", EmpId);
                sqlCommand.Parameters.AddWithValue("@Name", Name);
                sqlCommand.Parameters.AddWithValue("@Phone", Phone);
                sqlCommand.Parameters.AddWithValue("@Email", Email);
                sqlCommand.Parameters.AddWithValue("@Dob", Dob);
                sqlCommand.Parameters.AddWithValue("@StaffType", StaffType);
                sqlCommand.Parameters.AddWithValue("@Value", Value);


                // adapter.InsertCommand = new SqlCommand(sql, connection);
                // adapter.InsertCommand.ExecuteScalar();
                sqlCommand.CommandText = sql;
                sqlCommand.ExecuteScalar();
                sqlCommand.Dispose();
                connection.Close();
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
                string sql, output = " ";

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;

                sql = "retireveAll @StaffType";
                Console.WriteLine("Connection ready");

                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@StaffType", StaffType);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    output = "EmpId : " + sqlDataReader.GetValue(1) + " Name : " + sqlDataReader.GetValue(2) + " Phone : " + sqlDataReader.GetValue(3) +
                             " Email :" + sqlDataReader.GetValue(4) + " Subject :" + sqlDataReader.GetValue(11) + "\n";
                    Console.WriteLine(output);
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
                String sql;
                SqlCommand sqlCommand;
                SqlDataAdapter adapter = new SqlDataAdapter();
                sql = "deleteStaff @StaffType,@EmpId";
                sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.AddWithValue("@StaffType", StaffType);
                sqlCommand.Parameters.AddWithValue("@EmpId", EmpId);
                sqlCommand.CommandText = sql;
                sqlCommand.ExecuteScalar();
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
        public string GetSingleStaff()
        {
            string output = " ";
            try
            {
                string sql;

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;

                sql = "select * from Staff as S inner join AdministrativeStaff as Ad on S.Id = Ad.StaffId";
                Console.WriteLine("Connection ready");

                sqlCommand = new SqlCommand(sql, connection);
                // sqlCommand.Parameters.AddWithValue("@StaffType", StaffType);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    output = "EmpId : " + sqlDataReader.GetValue(1) + " Name : " + sqlDataReader.GetValue(2) + " Phone : " + sqlDataReader.GetValue(3) +
                             " Email :" + sqlDataReader.GetValue(4) + " Subject :" + sqlDataReader.GetValue(11) + "\n";
                    Console.WriteLine(output);
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            return output;
        }
    }
}
