using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MobileFramework.ReminderPlugin;

namespace MobileFrameWork.Tests.Models
{
    public class RemindersTest
    {
        [Fact]
        public void MustBeTrue()
        {
            Assert.Equal(1, 1);
        }
        [Fact]
        public void AddReminder()
        {
            ReminderListPageModel rList = new ReminderListPageModel();
            Reminder r = new Reminder { Name = "test", isActive = false };
            int x = rList.ReminderList.Count;
            rList.ReminderList.Add(r);
            Assert.True(x+1 == rList.ReminderList.Count);
            var index = rList.ReminderList.IndexOf(r);   
            Assert.Equal(r,rList.ReminderList.ElementAt<Reminder>(index));
        }

        [Fact]
        public void DeleteReminder()
        {
            ReminderListPageModel rList = new ReminderListPageModel();
            Reminder r = new Reminder { Name = "test", isActive = false };
            int x = rList.ReminderList.Count;
            rList.ReminderList.Add(r);
            Assert.Equal(true, rList.ReminderList.Remove(r));
        }
        [Fact]
        public void EnableDisableReminder()
        {
            ReminderListPageModel rList = new ReminderListPageModel();
            Reminder r = new Reminder { Name = "test", isActive = false };
            Reminder r2 = new Reminder { Name = "test", isActive = false };
            rList.ReminderList.Add(r2);
            rList.ReminderList.Insert(0, r);
            Assert.True(rList.ReminderList.ElementAt<Reminder>(0).isActive == false);
            rList.ReminderList.ElementAt<Reminder>(0).isActive = true;
            Assert.True(rList.ReminderList.ElementAt<Reminder>(0).isActive == true);

           
        }
    }
}
