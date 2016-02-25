using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaleProjects.Models
{
    public class State
    {
       
        private int stateid;

        public int Stateid
        {
            get { return stateid; }
            set { stateid = value; }
        }
        private string states;

        public string States
        {
            get { return states; }
            set { states = value; }
        }
        
    }
}