using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Constants.VehicleConstants;

namespace Mobiles
{
    /// <summary>
    /// Car class
    /// </summary>
    public class Car : Vehicle
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Car() : base()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Car(string vin, VehicleType vehicleType) : base(vin, vehicleType)
        {
            this.Vin = "Sfd";
        }

        #endregion
    }
}
