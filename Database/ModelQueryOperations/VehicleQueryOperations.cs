using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Database.ModelQueryOperations
{
    public class VehicleQueryOperations : QueriesBase
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connecter"></param>
        public VehicleQueryOperations(DatabaseConnecter connecter) : base(connecter)
        {
            this._tableName = ConfigurationManager.AppSettings["VehicleTable"];
            this._primaryKey = ConfigurationManager.AppSettings["VehiclePrimaryKey"];

            if (this._tableName == null)
                throw new NullReferenceException($"{nameof(this._tableName)} is empty.");

            string[] columnNames = ConfigurationManager.AppSettings["VehicleColumnNames"].Split();
            if (columnNames == null)
                throw new NullReferenceException($"{nameof(columnNames)} is an empty list.");

            this._columnNames = columnNames.ToList();
        }

        #endregion
    }
}
