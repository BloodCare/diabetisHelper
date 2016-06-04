using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double amount { get; set; }

        public double BreadUnits { get; set; }
        public double EnergyAmount { get; set; }
    }
}
