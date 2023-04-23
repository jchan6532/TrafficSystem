using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseQueryArgs
    {
        /// <summary>
        /// Gets or sets the query mode.
        /// </summary>
        public QueryMode Mode { get; set; } = QueryMode.Undefined;

        /// <summary>
        /// Gets or sets the name of the table name.
        /// </summary>
        public string TableName { get; set; } = null;

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        public string[] ColumnNames { get; set; } = null;

        /// <summary>
        /// Gets or sets the where clause statement.
        /// </summary>
        public string WhereClause { get; set; } = null;

        /// <summary>
        /// Default constructor for initializing a new instance of the <see cref="DatabaseQueryArgs"/> class.
        /// </summary>
        public DatabaseQueryArgs()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseQueryArgs"/> class.
        /// </summary>
        public DatabaseQueryArgs(QueryMode mode, string[] columnNames, string tableName, string whereClause)
        {
            this.Mode = mode;
            this.ColumnNames = columnNames;
            this.TableName = tableName;
            this.WhereClause = whereClause;
        }
    }
}
