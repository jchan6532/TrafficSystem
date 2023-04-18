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
        /// SQL connection
        /// </summary>
        public MySqlConnection Connection { get; set; } = null;

        /// <summary>
        /// Connection String
        /// </summary>
        public string ConnectionString { get; set; } = null;

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
        public MySqlCommand Command { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DatabaseConnecter()
        {
            try
            {
                string user = ConfigurationSettings.AppSettings.Get("");
                string password = ConfigurationSettings.AppSettings.Get("");
                string ip = ConfigurationSettings.AppSettings.Get("");
                string port = ConfigurationSettings.AppSettings.Get("");

                this.Connection = new MySqlConnection(this.ConnectionString);
                this.Connection.Open();

                this.Adapter = new MySqlDataAdapter(this.Command);
                this.Adapter.Fill(this.Table);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
