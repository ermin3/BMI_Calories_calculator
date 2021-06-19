using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Food
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
