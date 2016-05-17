using FreshMvvm;
using MobileFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.PluginManager
{
    public interface IPluginCollector
    {
        /// <summary>
        /// not yet implemented
        /// </summary>
        Dictionary<String, Image> GetViewModels();

        /// <summary>
        /// not yet implemented
        /// </summary>
        Dictionary<String, Image> ViewModels{ get; set; }

        /// <summary>
        /// not yet implemented
        /// </summary>
        Dictionary<String, Type> Pages{ get; set; }

        /// <summary>
        /// returns the SettingsModels of all plugins
        /// </summary>
        Dictionary<string, SettingsModel> SettingsModels { get; set; }

    }
}
