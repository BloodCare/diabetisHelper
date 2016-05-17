using FreshMvvm;
using MobileFramework.Helpers;
using MobileFramework.MainView;
using MobileFramework.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.Diagnostics;

namespace MobileFramework.PluginManager
{
    /// <summary>
    /// collects infos of all avaiable plugins and is singleton
    /// </summary>
    public class PluginCollector : IPluginCollector
    {
       
        /// <summary>
        /// create list with instances of all SettingsModels over Reflection.
        /// The global defined Name will be the Key for the dictionaries.
        /// </summary>
       public PluginCollector() 
        {
            //Searches in the whole Assembly for the classes, that inherit from SettingsModel
            var settingModels = typeof(SettingsModel).Assembly().DefinedTypes.Where(x => x.IsSubclassOf(typeof(SettingsModel))).Select(x => x.AsType());
            SettingsModels = new Dictionary<string, SettingsModel>();
            foreach(Type type in settingModels)
            {
                try {
                   // var Source = ImageSource.FromResource("MobileFramework.Resources.Images.msm.jpg");
                    SettingsModel instance = (SettingsModel)Activator.CreateInstance(type);
                    if (!(SettingsModels.ContainsKey(instance.Name)))
                        SettingsModels.Add(instance.Name, instance);
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }           
            }
        }

       /// <summary>
       /// returns the SettingsModels of all plugins
       /// </summary>
       public Dictionary<string, SettingsModel> SettingsModels { get; set; }

        /// <summary>
        /// not yet implemented
        /// </summary>
       public Dictionary<String, Type> Pages
       {
           get;
           set;
       }

        /// <summary>
        /// not yet implemented
        /// </summary>
       public Dictionary<String,Image> ViewModels
       {
           get;
           set;
       }
        /// <summary>
        /// not yet implemented
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, Image> GetViewModels()
       {
            return ViewModels;
       }

    }
}
