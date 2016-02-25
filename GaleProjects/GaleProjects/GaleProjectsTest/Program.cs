using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GaleProjectsTest.ServiceReference1;



namespace GaleProjectsTest
{
     [TestFixture]
    public class Program
    {
        static void Main(string[] args)
        {
        }
       
        public void testpredicted()
        {
            string stationcode="BI-EA-70";
            int predicted =70;
            Service1Client service=new Service1Client ();
            int result = Convert.ToInt16(service.GetData(stationcode));
            Assert.AreEqual(predicted, result);
        }
      
    }
    
}
