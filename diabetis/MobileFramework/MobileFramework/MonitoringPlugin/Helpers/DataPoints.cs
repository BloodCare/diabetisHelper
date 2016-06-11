using MobileFramework.Model;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.MonitoringPlugin.Helpers
{
    public class BloodSugarDataPoint
    {
        public BloodSugarDataPoint()
        {
            Id= Guid.NewGuid().ToString("N");
        }

        public double BloodSugarLevel { get; set; }
        public DateTime Date { get; set; }

        public string Id { get; set; }
    }

    public class MealDataPoint
    {
        public MealDataPoint()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public double BreadUnits { get; set; }

        public double EnergyAmount { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public DateTime Date { get; set; }

        public string Id { get; set; }

        public double YValue { get; set; }
    }

    public class MedicineDataPoint
    {
        public DateTime Date { get; set; }

        public MedicineDataPoint()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        public string Name { get; set; }

        public double Amount { get; set; }

        public string Unit { get; set; }

        public string Id { get; set; }

        public double YValue { get; set; }
    }

    public class CustomDataPoint: ChartDataPoint
    { 
        public CustomDataPoint(IComparable xValue, double yValue) : base(xValue, yValue)
        {

        }
        public String Id { get; set; }
    }
}
