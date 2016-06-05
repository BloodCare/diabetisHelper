using MobileFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.MonitoringPlugin.Helpers
{
    public class BloodSugarDataPoint
    {
        public double BloodSugarLevel { get; set; }
        public DateTime Date { get; set; }
    }

    public class MealDataPoint
    {
        public double BreadUnits { get; set; }

        public double EnergyAmount { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public DateTime Date { get; set; }
    }

    public class MedicineDataPoint
    {
        public string Name { get; set; }

        public double Amount { get; set; }

        public string Unit { get; set; }

    }
}
