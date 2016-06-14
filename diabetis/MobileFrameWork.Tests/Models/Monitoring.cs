using MobileFramework.MonitoringPlugin;
using MobileFramework.MonitoringPlugin.Helpers;
using MobileFramework.MonitoringPlugin.SubPages;
using MobileFramework.PluginManager;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MobileFrameWork.Tests.Models
{
    public class MonitoringTests
    {
        [Fact]
        public void CheckCalcOfYValuesOfDataPoints()
        {
            PluginCollector coll = new PluginCollector();
            MonitoringPluginPageModel model = new MonitoringPluginPageModel(coll);

            model.BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 6, 12, 10, 0, 0), 50));
            model.BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 6, 12, 14, 0, 0), 150));
            //model.BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 6, 12, 10, 0, 0), 50));

            var result1 = model.calcDataPointsYValue(new ChartDataPoint(new DateTime(2016, 6, 12, 11, 0, 0), 0));
            var result2 = model.calcDataPointsYValue(new ChartDataPoint(new DateTime(2016, 6, 12, 12, 0, 0), 0));
            var result3 = model.calcDataPointsYValue(new ChartDataPoint(new DateTime(2016, 6, 12, 13, 0, 0), 0));

           
           Assert.True(result1 == 75 && result2 == 100 && result3 == 125);
           
        }

        [Fact]
        public void CheckAddBloodSugarDataPoint()
        {
            PluginCollector coll = new PluginCollector();
            MonitoringPluginPageModel model = new MonitoringPluginPageModel(coll);

            model.AddDatapoints(DataPoints.BloodSugar);

            AddBloodSugarPageModel bmodel = new AddBloodSugarPageModel(coll);
            bmodel.BloodSugarValue = 40;
            DateTime tmpDate = DateTime.Now;
            bmodel.Date = tmpDate;
            var x = bmodel.AddDataPoint;

            model.LoadData();
            ChartDataPoint bsPoint = (from ChartDataPoint poi in model.BloodSugarDataPoints where (DateTime)poi.XValue == tmpDate select poi).ToList().FirstOrDefault();
            Assert.True((DateTime)bsPoint.XValue == tmpDate);

        }

    }
}
