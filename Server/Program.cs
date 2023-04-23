using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mobiles;
using Constants.VehicleConstants;
using Database;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseConnecter db = new DatabaseConnecter();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
