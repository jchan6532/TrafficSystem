using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Constants.VehicleConstants;

namespace Mobiles
{
    /// <summary>
    /// Vehicle base class
    /// </summary>
    public class Vehicle
    {
        #region Private Fields

        /// <summary>
        /// VIN number
        /// </summary>
        private string vin;

        #endregion

        #region Public Properties

        /// <summary>
        /// VIN number
        /// </summary>
        public string Vin 
        {
            get
            {
                return this.vin;
            }
            private set
            {
                this.vin = Vehicle.CheckForValidVin(value) == true ? value : VinConstants.Undefined.ToString();
            }
        }

        /// <summary>
        /// Vehicle Type
        /// </summary>
        public VehicleType VehicleType
        {
            get;
        } = VehicleType.Undefined;

        /// <summary>
        /// Coordinates
        /// </summary>
        public Dictionary<string, int> Coordinates
        {
            get;
            set;
        } = new Dictionary<string, int>() {
            { "X", 0},
            { "Y", 0} 
        };

        /// <summary>
        /// Vehicle colour
        /// </summary>
        public string VehicleColour
        {
            get;
            set;
        } = null;

        /// <summary>
        /// Current vehicle speed
        /// </summary>
        public int CurrentSpeed
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Current vehicle acceleration
        /// </summary>
        public int CurrentAcceleration
        {
            get;
            set;
        } = 0;

        #endregion

        #region Contructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vehicle()
        {
            this.vin = VinConstants.Undefined.ToString();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vin">VIN</param>
        /// <param name="vehicleType">Vehicle Type</param>
        public Vehicle(string vin, VehicleType vehicleType)
        {
            this.vin = vin;
            this.VehicleType = vehicleType;

        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Checking for valid VIN
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public static bool CheckForValidVin(string vin)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
