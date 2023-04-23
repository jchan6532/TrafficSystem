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
        void Read();

        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update();

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();
    }
}
