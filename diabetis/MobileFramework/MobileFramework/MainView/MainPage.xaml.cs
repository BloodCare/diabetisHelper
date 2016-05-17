using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileFramework.PluginManager;
using Xamarin.Forms;

namespace MobileFramework.MainView
{
    public partial class MainPage : ContentPage
    {
        public String Name { get; set; }
        public MainPage()
        {
            Name = "MainPlugin";
            InitializeComponent();           
        }
    }
}
