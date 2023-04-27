using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using Database;
using Mobiles;

namespace Server
{
    public class Server
    {
        #region Private Fields

        /// <summary>
        /// Database connecter
        /// </summary>
        private DatabaseConnecter _connecter = null;

        /// <summary>
        /// TCP listener
        /// </summary>
        private TcpListener _listener = null;

        /// <summary>
        /// Remote endpoint
        /// </summary>
        private IPEndPoint _endPoint = null;

        /// <summary>
        /// Remote ip address
        /// </summary>
        private IPAddress _ip = null;

        /// <summary>
        /// Remote port number
        /// </summary>
        private int _port = -1;

        /// <summary>
        /// Vehicle data structure
        /// </summary>
        private Dictionary<string, Vehicle> _vehicles = null;

        /// <summary>
        /// volatile flag for running server
        /// </summary>
        private volatile bool _done = false;

        #endregion

        #region Constructor

        public Server()
        {
            try
            {
                this._connecter = new DatabaseConnecter();

                this._ip = IPAddress.Parse(ConfigurationManager.AppSettings["Ip"]);
                if (Int32.TryParse(ConfigurationManager.AppSettings["Port"], out this._port))
                    throw new InvalidOperationException("port number is not a number");
                this._endPoint = new IPEndPoint(this._ip, this._port);
                this._listener = new TcpListener(this._endPoint);

                this._vehicles = new Dictionary<string, Vehicle>();

                this._done = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Private Methods

        private void Start()
        {
            while (!this._done)
            {
                if (this._listener.Pending())
                {
                    TcpClient client = this._listener.AcceptTcpClient();
                    this.Acceptclient(client);
                }
            }
        }

        private void Acceptclient(object tcpClient)
        {
            TcpClient client = tcpClient as TcpClient;
            Vehicle vehicle = new Vehicle();
            vehicle.Stream = client.GetStream();


        }

        #endregion
    }
}
