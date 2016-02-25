using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;


namespace GaleProjectService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {

        public int GetData(string value)
        {

            string filepath = System.Web.Hosting.HostingEnvironment.MapPath("~/Speed.xml");
            var myDocument = new XmlDocument();
            myDocument.Load(filepath);
            var nodes = myDocument.GetElementsByTagName("item");
            var resultNodes = new List<XmlNode>();
            List<Prediction> list = new List<Prediction>();

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes != null && node.Attributes["Stationcode"] != null && node.Attributes["Stationcode"].Value.Equals(value))
                {
                    list.Add(new Prediction(Convert.ToInt16(node.Attributes["cityid"].Value),
                    node.Attributes["Stationcode"].Value.ToString(), Convert.ToInt16(node.Attributes["cityid"].Value)));
                    return Convert.ToInt16(node.Attributes["cityid"].Value);
                }
            }

            return 0;
        }
    }


}
