using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Database
{
    public class QueriesBase
    {
        #region Private Members

        /// <summary>
        /// The connecter
        /// </summary>
        private DatabaseConnecter _connecter = null;

        /// <summary>
        /// The table name
        /// </summary>
        protected string _tableName = null;

        /// <summary>
        /// The primary key
        /// </summary>
        protected string _primaryKey = null;

        /// <summary>
        /// The column names
        /// </summary>
        protected List<string> _columnNames = null;

        #endregion

        #region Constructor

        public QueriesBase(DatabaseConnecter connecter)
        {
            this._connecter = connecter;
        }

        #endregion

        #region Public CRUD Operations

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
            if (this._connecter.RunQuery(query) != 1)
                throw new InvalidOperationException("Insert operation failed");

        }

        public void Delete(int id, string whereClause = "")
        {
            if (this._connecter == null)
                throw new NullReferenceException($"{nameof(DatabaseConnecter)} is null.");

            string query = $"DELETE FROM {this._tableName} WHERE {this._primaryKey}={id};";
            if (whereClause != "")
                query = $"SELECT * FROM {this._tableName} {whereClause};";

            if (this._connecter.RunQuery(query) != 1)
                throw new InvalidOperationException("No entries in table to read");
        }

        public object Read(string columnName, int id, string whereClause = "")
        {
            if (this._connecter == null)
                throw new NullReferenceException($"{nameof(DatabaseConnecter)} is null.");

            string query = $"SELECT * FROM {this._tableName} WHERE {this._primaryKey}={id};";
            if (whereClause != "")
                query = $"SELECT * FROM {this._tableName} {whereClause};";

            if (this._connecter.RunQuery(query) != 1)
                throw new InvalidOperationException("No entries in table to read");

            object result = this._connecter.ReadTable(columnName);
            return result;
        }

        public void Update(int id, List<object> newUpdatedValues, List<string> updatingColumns, string whereClause = "")
        {
            if (this._connecter == null)
                throw new NullReferenceException($"{nameof(DatabaseConnecter)} is null.");

            if ((newUpdatedValues.Count >= this._columnNames.Count) || (updatingColumns.Count >= this._columnNames.Count))
                throw new InvalidOperationException("columns and values contain more columns for count for INSERT"); //change exception type later;

            if (newUpdatedValues.Count != updatingColumns.Count)
                throw new InvalidOperationException("columns and values don't match the correct count for INSERT"); //change exception type later;



            string newUpdatedValuesQuery = "";
            for (int i = 0; i < updatingColumns.Count; i++)
            {
                newUpdatedValuesQuery += $"{updatingColumns[i]} = {newUpdatedValues[i]},";
            }
            newUpdatedValuesQuery = newUpdatedValuesQuery.TrimEnd(',');
            newUpdatedValuesQuery = $"({newUpdatedValuesQuery})";

            string query = $"UPDATE {this._tableName} SET {newUpdatedValuesQuery} WHERE {this._primaryKey}={id};";
            if (whereClause != "")
                query = $"UPDATE {this._tableName} SET {newUpdatedValuesQuery} {whereClause};";
        }

        #endregion
    }
}
