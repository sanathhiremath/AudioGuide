using System;
using System.Data;
using System.Data.SqlClient;
using AudioGuide.Helper;
using static AudioGuide.Models.Info;

namespace AudioGuide.DataLayer
{
    public class DataAccess
    {
        public static bool IsUserExists(string userName, string password, string userType)
        {
            bool response = false;
            SqlCommand command = null;
            SqlConnection connection = null;
            try
            {
                MSSQLAccess.CreateConnection(ref connection);
                MSSQLAccess.InitializeSqlCommandComponent(ref connection, ref command, "IsUserExists");
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@UserType", userType);
                command.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                command.ExecuteReader();
                response = Convert.ToBoolean(command.Parameters["@retValue"].Value);
            }
            catch (Exception)
            {

            }
            return response;
        }

        public static bool RegisterDoctor(Doctor doctorDetails)
        {
            bool response = false;
            SqlCommand command = null;
            SqlConnection connection = null;
            try
            {
                MSSQLAccess.CreateConnection(ref connection);
                MSSQLAccess.InitializeSqlCommandComponent(ref connection, ref command, "RegisterDoctor");
                command.Parameters.AddWithValue("@Name", doctorDetails.name);
                command.Parameters.AddWithValue("@PhoneNumber", doctorDetails.phoneNumber);
                command.Parameters.AddWithValue("@Email", doctorDetails.email);
                command.Parameters.AddWithValue("@Password", doctorDetails.password);
                command.Parameters.AddWithValue("@Specialization", doctorDetails.specialization);
                command.Parameters.AddWithValue("@Dob", doctorDetails.dob);
                command.ExecuteNonQuery();
                response = true;
            }
            catch ()
            {

            }
            return response;
        }

        public static bool RegisterPatient(Patient patientDetails)
        {
            bool response = false;
            SqlCommand command = null;
            SqlConnection connection = null;
            try
            {
                MSSQLAccess.CreateConnection(ref connection);
                MSSQLAccess.InitializeSqlCommandComponent(ref connection, ref command, "RegisterPatient");
                command.Parameters.AddWithValue("@Name", patientDetails.name);
                command.Parameters.AddWithValue("@PhoneNumber", patientDetails.phoneNumber);
                command.Parameters.AddWithValue("@Email", patientDetails.email);
                command.Parameters.AddWithValue("@Password", patientDetails.password);
                command.Parameters.AddWithValue("@FatherName", patientDetails.fatherName);
                command.Parameters.AddWithValue("@Dob", patientDetails.dob);
                command.Parameters.AddWithValue("@Address", patientDetails.address);
                command.ExecuteNonQuery();
                response = true;
            }
            catch (Exception)
            {

            }
            return response;
        }

        public static DataSet VerifyUserCredentials(string email, string password)
        {
            DataSet dataSet = new DataSet();
            SqlCommand command = null;
            SqlConnection connection = null;
            try
            {
                MSSQLAccess.CreateConnection(ref connection);
                MSSQLAccess.InitializeSqlCommandComponent(ref connection, ref command, "VerifyUserCredentials");
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                new SqlDataAdapter(command).Fill(dataSet);
            }
            catch (Exception)
            {

            }
            finally
            {
                MSSQLAccess.ClearSqlObjects(ref connection, ref command);
            }
            return dataSet;
        }

        public static bool InsertAuthenticationTokenId(string tokenId, DateTime expirationDate, string usedId)
        {
            bool response = false;
            SqlCommand command = null;
            SqlConnection connection = null;
            try
            {
                MSSQLAccess.CreateConnection(ref connection);
                MSSQLAccess.InitializeSqlCommandComponent(ref connection, ref command, "InsertAuthenticationTokenId");
                command.Parameters.AddWithValue("@tokenId", tokenId);
                command.Parameters.AddWithValue("@expirationDate", expirationDate);
                command.Parameters.AddWithValue("@userId", usedId);
                command.ExecuteNonQuery();
                response = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                MSSQLAccess.ClearSqlObjects(ref connection, ref command);
            }
            return response;
        }

    }
}