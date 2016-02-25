using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GaleProjects.Models
{
    public class City
    {
        public City(int id, string cname, int statid)
        {
            Cityid = id;
            Cityname = cname;
            Citystateid = statid;
            
        }
        private int cityid;

        public int Cityid
        {
            get { return cityid; }
            set { cityid = value; }
        }
        private int citystateid;

        public int Citystateid
        {
            get { return citystateid; }
            set { citystateid = value; }
        }
        private string cityname;

        public string Cityname
        {
            get { return cityname; }
            set { cityname = value; }
        }
       
    }
}