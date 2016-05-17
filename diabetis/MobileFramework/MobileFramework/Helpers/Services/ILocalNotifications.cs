using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Helpers.Services
{
    /// <summary>
    /// Notification Interface to acces native implementations from PCL
    /// </summary>
    public interface ILocalNotifications
	{
        void SendLocalNotification(string title, string description, int iconID, List<string> entrys, string name);
	}
   
}
