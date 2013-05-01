﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using TheNoiseHLC;
using TheNoiseHLC.CommunicationObjects;
using TheNoiseHLC.CommunicationObjects.GlobalEnumerations;

namespace TheNoise_DatabaseControl
{
    public class DataAccessLayer : IDisposable
    {
        const string TABLE = "userFiles";

        private SqlConnectionStringBuilder sqlStrBldr = new SqlConnectionStringBuilder();

        public DataAccessLayer(string databaseAddress, string databaseName, bool useIntegratedSecurity)
        {
            sqlStrBldr.DataSource = databaseAddress;
            sqlStrBldr.InitialCatalog = databaseName;
            sqlStrBldr.IntegratedSecurity = useIntegratedSecurity;
            sqlStrBldr.InitialCatalog = "userFiles";
        }
        public DataAccessLayer(string databaseAddress, string databaseName) : this(databaseAddress, databaseName, true) { }
        public DataAccessLayer(string databaseAddress, string databaseName, string username, string password)
            : this(databaseAddress, databaseName, false)
        {
            sqlStrBldr.UserID = username;
            sqlStrBldr.Password = password;
            sqlStrBldr.IntegratedSecurity = false;
        }

        public void readUsers(ObservableCollection<LoginData> userList)
        {
            // Create database objects.
            using (DataSet dSetUsers = new DataSet())
            using (SqlConnection dataConnection = new SqlConnection())
            using (SqlCommand dataCommand = new SqlCommand())
            using (SqlDataAdapter dataAdaptor = new SqlDataAdapter("Select * FROM musicUsers", sqlStrBldr.ConnectionString))
            {

                dataAdaptor.Fill(dSetUsers, TABLE);

                dataAdaptor.FillSchema(dSetUsers, SchemaType.Source);

                DataTable dtUsers = dSetUsers.Tables[TABLE]; // Retreive the users table.

                foreach (DataRow row in dtUsers.Rows)
                {
                    // Cycle through and get every user
                    userList.Add(new LoginData(row[0].ToString(), row[1].ToString()));
                }
            }
        }

        public UserAddResult addUser(LoginData sentUser)
        {
            //GlobalEnumerations.UserValidationResult result;
            UserAuthenticationResult result;
            result = validateUser(sentUser);

            //If validateUser returns 1, user is not in database
            if (result == UserAuthenticationResult.InvalidUser)
            {
                string SQLstring = "EXEC addMusicUser @uname = " + sentUser.username + ", @passw = " + sentUser.password;

                executeNonQuery(SQLstring);

                //succeeded. User was added.
                return UserAddResult.Success;
            }
            else
            {
                return UserAddResult.AlreadyExists;
            }
        }

        public UserAuthenticationResult validateUser(LoginData sentUser)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlStrBldr.ConnectionString))
                {
                    SqlCommand command = new SqlCommand("checkMusicUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter userName = new SqlParameter("@uname", SqlDbType.VarChar);
                    userName.Direction = ParameterDirection.Input;
                    userName.Value = sentUser.username;
                    userName.Size = 50;
                    command.Parameters.Add(userName);

                    SqlParameter password = new SqlParameter("@passw", SqlDbType.VarChar);
                    password.Direction = ParameterDirection.Input;
                    password.Value = sentUser.password;
                    password.Size = 50;
                    command.Parameters.Add(password);

                    SqlParameter returnValue = new SqlParameter("@retval", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.Output;
                    command.Parameters.Add(returnValue);

                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    return (UserAuthenticationResult)(int)command.Parameters["@retval"].Value;
                }
            }
            catch
            {
                return UserAuthenticationResult.UnknownResult;
            }
        }

        private bool executeNonQuery(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlStrBldr.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Connection.Open();
                    if (command.ExecuteNonQuery() < 1)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.Net.Sockets.SocketException">An exception was generated while closing the TcpListener.</exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose all managed resources.
                
            }

            // Dispose of unmanaged resources here if any.
        }
    }
}
