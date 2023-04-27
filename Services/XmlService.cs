using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Services
{
    public class XmlService
    {
        public XmlService()
        {

        }

        public object Deserialize(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode root = doc.DocumentElement;
            object obj = null;
            switch (root.Name.ToLower())
            {
                case "request":
                    obj = new RequestObj();
                    break;

                case "response":
                    obj = new ResponseObj();
                    break;

                default:
                    break;
            }

            if (obj.GetType().Name == typeof(RequestObj).Name)
            {

            }
            foreach (XmlNode child in root.ChildNodes)
            {

            }

            return obj;
        }

        public string Serialize<T>(object obj)
            where T : class, new()
        {
            if (typeof(T).Name != obj.GetType().Name)
                throw new InvalidOperationException("object type and generic class type do not match");

            T serializedObj = (T)obj;
            string objType = typeof(T).Name;

            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement(objType);
            doc.AppendChild(root);

            switch (objType)
            {
                case nameof(RequestObj):
                    RequestObj requestObj = serializedObj as RequestObj;

                    XmlNode vehicleIdNode = doc.CreateElement(nameof(requestObj.vehicleID));
                    vehicleIdNode.InnerText = requestObj.vehicleID.ToString();
                    root.AppendChild(vehicleIdNode);

                    break;
                case nameof(ResponseObj):

                    break;
                default:
                    break;
            }



            return this.GetFormattedXml(doc);
        }

        private string GetFormattedXml(XmlDocument doc)
        {
            return XElement.Parse(doc.OuterXml).ToString();
        }
    }
}
