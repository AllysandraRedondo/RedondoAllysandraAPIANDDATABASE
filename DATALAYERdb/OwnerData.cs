using System.Collections.Generic;
using System.Data.SqlClient;
using MODELSdb;

namespace DATALAYERdb
{
    public class OwnerData
    {
        string connectionString = "Data Source=LAPTOP-JGL8F6OD\\SQLEXPRESS;Initial Catalog=AccountManagement;Integrated Security=True;";
        SqlConnection sqlConnection;

        public OwnerData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<OwnerContent> GetUsers()
        {
            string getuser = "SELECT username, password FROM Account";
            SqlCommand select = new SqlCommand(getuser, sqlConnection);
            sqlConnection.Open();
            List<OwnerContent> userList = new List<OwnerContent>();

            SqlDataReader reader = select.ExecuteReader();
            
                    while (reader.Read())
                    {
                        OwnerContent user = new OwnerContent
                        {
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString()
                        };
                        userList.Add(user);
                    }
            sqlConnection.Close();
            return userList;
        }

        
        
    }
}
