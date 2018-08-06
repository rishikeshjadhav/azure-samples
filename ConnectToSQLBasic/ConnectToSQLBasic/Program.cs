using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectToSQLBasic
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("user id=adventureadmin;password=Pass1234;data source=adventureserver1234.database.windows.net;initial catalog=nitovate_config;connection timeout=30");

                sqlConnection.Open();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occurred: " + exception.Message);
            }
        }
    }
}
