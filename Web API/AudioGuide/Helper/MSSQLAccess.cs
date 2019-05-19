using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AudioGuide.Helper
{
    public class MSSQLAccess
    {
        public static void ClearSqlObjects(ref SqlConnection connection, ref SqlCommand command)
        {
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public static void ClearSqlObjects(ref SqlConnection connection, ref SqlCommand command, ref SqlDataAdapter adaptor)
        {
            if (adaptor != null)
            {
                adaptor.Dispose();
                adaptor = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        public static void CreateConnection(ref SqlConnection connection)
        {
            if (connection != null)
            {
                try
                {
                    connection.Close();
                    connection.Dispose();
                }
                finally
                {
                    connection = null;
                }
            }
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
        }

        public static void InitializeSqlCommandComponent(ref SqlConnection connection, ref SqlCommand command, string storedProcedureName)
        {
            if ((storedProcedureName == "") || (storedProcedureName == null))
            {
                throw new Exception("Please provide a valide name for the storedprocedure.");
            }
            if ((connection.State == ConnectionState.Closed) || (connection.State == ConnectionState.Closed))
            {
                connection.Open();
            }
            if (command == null)
            {
                command = new SqlCommand();
            }
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
        }
    }
}