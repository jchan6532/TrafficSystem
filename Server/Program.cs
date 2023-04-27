using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mobiles;
using Constants.VehicleConstants;
using Database;
using Services;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlService xmlService = new XmlService();
            Console.WriteLine(xmlService.Serialize<RequestObj>(new RequestObj()));
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
