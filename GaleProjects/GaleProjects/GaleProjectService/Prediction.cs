using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaleProjectService
{
    public class Prediction
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string stationcode;

        public string Stationcode
        {
            get { return stationcode; }
            set { stationcode = value; }
        }
        private int cityid;

        public int Cityid
        {
            get { return cityid; }
            set { cityid = value; }
        }
        public Prediction(int id, string stationcod, int city)
        {
            Id = id;
            Stationcode = stationcod;
            Cityid = city;
        }
    }
}