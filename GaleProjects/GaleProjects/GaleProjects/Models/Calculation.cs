using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace GaleProjects.Models
{
    public class Calculation
    {
        public Calculation(){}
        Color color;
        public Color txtcolors(int sVariance)
        {
            
            if (sVariance == -1 || sVariance == 1)
            {
                color = Color.Black;
            }
            else if (sVariance == -3 || sVariance == 3)
            {
                color = Color.Purple;
            }
            else if (sVariance < -5 || sVariance > 5)
            {
                color = Color.Red;
            }
            return color;
        }
    }
}