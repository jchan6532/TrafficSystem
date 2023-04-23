using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Constants.VehicleConstants;
using Database;

namespace Mobiles
{
    /// <summary>
    /// Vehicle base class
    /// </summary>
    public class Vehicle : QueriesBase
    {
        #region Private Fields

        /// <summary>
        /// VIN number
        /// </summary>
        private string vin;

        #endregion

        #region Public Properties

        public string VehicleID 
        { 
            get;
            private set;
        } = null;

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

        /// <summary>
        /// Lane vehicle is on
        /// </summary>
        public int Lane
        {
            get;
            protected set;
        } = (int)LaneTypes.Undefined;

        /// <summary>
        /// Number of doors on the vehicle
        /// </summary>
        public int NumberOfDoors
        {
            get;
        } = -1;

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
            this.Vin = vin;
            this.VehicleType = vehicleType;
            this.NumberOfDoors = Vehicle.FindDoorCount(vehicleType);
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Checking for valid VIN
        /// </summary>
        /// <param name="vin"></param>
        /// <returns>True if valid vin</returns>
        public static bool CheckForValidVin(string vin)
        {
            if (string.IsNullOrEmpty(vin))
            {
                return false;
            }

            //implement code to check database
            return true;
        }

        /// <summary>
        /// Finds the door count based on vehicle type
        /// </summary>
        /// <param name="vehicleType">Vehicle type</param>
        /// <returns>Number of doors</returns>
        public static int FindDoorCount(VehicleType vehicleType)
        {
            int result = -1;
            switch (vehicleType)
            {
                case VehicleType.Undefined:
                    result = -1;
                    break;

                case VehicleType.Sedan:
                case VehicleType.HatchBack:
                case VehicleType.SUV:
                case VehicleType.PickupTruck:
                case VehicleType.Truck:
                    result = 4;
                    break;

                case VehicleType.Coupe:
                    result = 2;
                    break;

                case VehicleType.Motorcycle:
                case VehicleType.MotorBike:
                    result = 0;
                    break;

                default:
                    break;
            }

            return result;
        }

        #endregion
    }
}
