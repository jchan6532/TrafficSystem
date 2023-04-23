using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public enum QueryMode
    {
        /// <summary>
        /// The undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// The create
        /// </summary>
        Create,

        /// <summary>
        /// The read
        /// </summary>
        Read,

        /// <summary>
        /// The update
        /// </summary>
        Update,

        /// <summary>
        /// The delete
        /// </summary>
        Delete
    }
}
