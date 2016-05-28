using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderAddPage : ContentPage
	{
		public static String feature1 = "Monitoring";
		public static String feature2 = "Diet Planner";
		public static String s1 = "Apex";
		public static String s2 = "Beacon";
		public static String s3 = "Bulletin";
		public static String s4 = "By the Sea side";
		public static String s5 = "Chimes";


		// Dictionary to get feature from feature name.
		Dictionary<string, string> feature = new Dictionary<string, string>
		{
			{ "Monitoring", feature1 }, { "Diet Planner",feature2 },

		};

		// Dictionary to get sound from sound name.
		Dictionary<string, string> sound = new Dictionary<string, string>
		{
			{ "Apex", s1 }, { "Beacon", s2 },{ "Bulletin", s3}, 
			{ "By the Sea side", s4 }, { "Chimes", s5 },
		};

		public ReminderAddPage ()
		{
			InitializeComponent ();
			Padding = new Thickness (20);

			var name = new Entry{ 
				Placeholder="Name"
			};

			var description = new Entry{
				Placeholder = "Description",
				WidthRequest= 200,
				HeightRequest = 100
			};

			var saveButton = new Button {
				Text = "Save",
				TextColor = Color.White,
				BackgroundColor = Color.Green,
				WidthRequest=100
			};
			saveButton.SetBinding (Button.CommandProperty, new Binding ("onSave"));

			var cancelButton = new Button {
				Text = "Cancel",
				TextColor = Color.White,
				BackgroundColor = Color.Gray,
				WidthRequest=100
			};
			cancelButton.SetBinding(Button.CommandProperty, new Binding("onCancel"));

			//Picker for feature
			Picker picker1 = new Picker
			{
				Title = "Link to Feature",
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			foreach (string featureName in feature.Keys)
			{
				picker1.Items.Add(featureName);
			}

			//Picker for sound
			Picker picker2 = new Picker
			{
				Title = "Sound",
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			foreach (string soundName in sound.Keys)
			{
				picker2.Items.Add(soundName);
			} 

			TimePicker timePicker = new TimePicker
			{
				Format = "T",
				//VerticalOptions = LayoutOptions.Center,
				//HorizontalOptions = LayoutOptions.End
			};

			DatePicker datePicker = new DatePicker
			{
				Format = "D",
				//VerticalOptions = LayoutOptions.Center,
				//HorizontalOptions = LayoutOptions.Start
			};


			// Label to display feature text
			/* Label fName = new Label
      {
       Text = "Picker",
       FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
       HorizontalOptions = LayoutOptions.Center
      };
        
    // selected item for picker 1
     /* picker1.SelectedIndexChanged += (sender, args) =>
      {
       if (picker1.SelectedIndex == -1)
       {
        fName.Text = "";
       }
       else
       {
        string Name = picker1.Items[picker1.SelectedIndex];
        fName.Text= Name;
        
       }
      };*/

			// Label to display sound text
			/*  Label sName = new Label
      {
       Text = "Picker",
       FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
       HorizontalOptions = LayoutOptions.Center
      };  */

			// selected item for picker 2
			/*  picker2.SelectedIndexChanged += (sender, args) =>
      {
       if (picker2.SelectedIndex == -1)
       {
        sName.Text = "";
       }
       else
       {
        string Name = picker2.Items[picker2.SelectedIndex];
        sName.Text= Name;

       }
      }; */



			// Accomodate iPhone status bar.
			//this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			var dateTimeviewlayout = new StackLayout ();
			dateTimeviewlayout.Orientation= StackOrientation.Horizontal;
			dateTimeviewlayout.Padding = 30;
			//dateTimeviewlayout.Children.Add(datePicker);
			//dateTimeviewlayout.Children.Add(timePicker);
			dateTimeviewlayout.Children.Add(saveButton);
			dateTimeviewlayout.Children.Add(cancelButton);




			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					name,
					description,
					picker1,
					picker2,
					datePicker,
					timePicker,
					dateTimeviewlayout,

				}
				};
		}
	}
}

