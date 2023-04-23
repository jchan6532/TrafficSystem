using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IQueries
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        void Create(List<object> data);

        /// <summary>
        /// Reads this instance.
        /// </summary>
        object Read(string columnName, int id, string whereClause = "");

        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update(int id, List<object> newUpdatedValues, List<string> updatingColumns, string whereClause = "");

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete(int id, string whereClause = "");
    }
}
