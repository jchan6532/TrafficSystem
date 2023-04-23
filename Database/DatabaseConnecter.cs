using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Database
{
    /// <summary>
    /// Database Connecter
    /// </summary>
    public class DatabaseConnecter
    {
        /// <summary>
        /// Connection String
        /// </summary>
        private string ConnectionString = null;

        /// <summary>
        /// SQL connection
        /// </summary>
        public MySqlConnection Connection { get; set; } = null;

        /// <summary>
        /// Data table
        /// </summary>
        public DataTable Table { get; set; } = null;

        /// <summary>
        /// SQL Adapter
        /// </summary>
        public MySqlDataAdapter Adapter { get; set; } = null;

        /// <summary>
        /// SQL Command
        /// </summary>
        public MySqlCommand Command { get; private set; } = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DatabaseConnecter()
        {
            try
            {
                string user = ConfigurationManager.AppSettings.Get("UserName");
                string password = ConfigurationManager.AppSettings["Password"];
                string databaseName = ConfigurationManager.AppSettings["Database"];
                string ip = ConfigurationManager.AppSettings["DatabaseIP"];
                string port = ConfigurationManager.AppSettings["DatabasePort"];

                this.ConnectionString = $"user={user}; password={password}; database={databaseName}; server={ip};";

                this.Connection = new MySqlConnection(this.ConnectionString);
                this.Connection.Open();

                //this.Adapter = new MySqlDataAdapter(this.Command);
                //this.Adapter.Fill(this.Table);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Runs the query.
        /// </summary>
        public int RunQuery(string query)
        {
            if (this.Command == null)
            {
                this.Command = new MySqlCommand(string.Empty, this.Connection);
            }

            this.Command.CommandText = query;

            int numRows = this.Command.ExecuteNonQuery();

            return numRows;
        }

        public object ReadTable(string columnName)
        {
            object result = null;
            try
            {
                this.Adapter = new MySqlDataAdapter(this.Command);
                this.Table.Clear();
                this.Adapter.Fill(this.Table);
                result = this.Table.Rows[0].Field<object>(columnName);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
