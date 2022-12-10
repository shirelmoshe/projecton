using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace StudentProject.Dal
{
    public class SqlQurey
    {
     
      
        public delegate object SetResulrDataReader2(SqlDataReader reader);
        public static void RunComand(string sqlQuery)
        {
            string ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))

            {
                string queryString = sqlQuery;
                using (SqlCommand command3 = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    command3.ExecuteNonQuery();
                }
            }
        }
        public static object RunResultComand(string sqlQuery, SetResulrDataReader2 fun)
        {
            string ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = sqlQuery;
                using (SqlCommand command1 = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command1.ExecuteReader())
                    {
                        
                       return fun(reader);
                        
                    }
                }
            }
           
        }

    }
}
    


