using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Database.ModelQueryOperations
{
    public class VehicleQueryOperations : IQueries
    {
        /// <summary>
        /// The connecter
        /// </summary>
        private DatabaseConnecter _connecter = null;

        /// <summary>
        /// The table name
        /// </summary>
        private readonly string _tableName = null;

        /// <summary>
        /// The column names
        /// </summary>
        private List<string> _columnNames = null;

        public VehicleQueryOperations()
        {
            
        }

        public VehicleQueryOperations(DatabaseConnecter connecter)
        {
            this._connecter = connecter;
            this._tableName = ConfigurationManager.AppSettings["VehicleTable"];
            if (this._tableName == null)
                throw new NullReferenceException($"{nameof(this._tableName)} is null.");

            this._columnNames = new List<string>();
            string[] columnNames = ConfigurationManager.AppSettings["VehicleColumnNames"].Split();
            if (this._columnNames == null)
                throw new NullReferenceException($"{nameof(columnNames)} is null.");

            foreach (var columnName in columnNames)
            {
                this._columnNames.Add(columnName);
            }
        }




        public void Create(List<object> data)
        {
            if (this._connecter == null)
                throw new NullReferenceException($"{nameof(DatabaseConnecter)} is null.");

            if (data.Count != this._columnNames.Count)
                throw new InvalidOperationException("columns and values don't match the correct count for INSERT"); //change exception type later;

            string columnNamesQuery = string.Empty;
            foreach (var columnName in this._columnNames)
            {
                columnNamesQuery += $"{columnName},";
            }
            columnNamesQuery = columnNamesQuery.TrimEnd(',');
            columnNamesQuery = $"({columnNamesQuery})";

            string valuesQuery = string.Empty;
            foreach (var argument in data)
            {
                valuesQuery += $"{argument},";
            }
            valuesQuery = valuesQuery.TrimEnd(',');
            valuesQuery = $"({valuesQuery})";



            string query = $"INSERT INTO {this._tableName} ({columnNamesQuery}) VALUES ({valuesQuery});";
            this._connecter.RunQuery(query);

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
