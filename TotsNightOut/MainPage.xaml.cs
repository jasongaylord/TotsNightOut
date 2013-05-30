using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TotsNightOut.Core.Common;
using TotsNightOut.Core.Model;
using TotsNightOut.Resources;
using System.Windows.Media;

namespace TotsNightOut
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Local variables
        GeoLocation location;
        public static SolidColorBrush Foreground { get { return Theme.Foreground; } }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the logo
            Logo.Source = new BitmapImage(Theme.LogoUri);

            //LocalListing.ItemsSource = new List<String> { "apples", "bananas" };
            //LocalListing.FindNam
            //LocalListingStackPanel.Background = App.CurrentAccentColor;
            

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            // Start the GeoLocation process
            if (!PhoneApplicationService.Current.State.ContainsKey("CurrentGeoCoordinate"))
            {
                // Set temporary location
                GeoCoordinate coordNewYorkCity = new GeoCoordinate();
                coordNewYorkCity.Latitude = 40.7142;
                coordNewYorkCity.Longitude = -74.0064;
                PhoneApplicationService.Current.State["CurrentGeoCoordinate"] = coordNewYorkCity;

                location = new GeoLocation();
                location.StartWatching(GeoPositionAccuracy.Default);
                location.CoordinateChanged += location_CoordinateChanged;
            }

            // Refresh locations
            LoadNearbyLocations();
        }

        // Delegate to handle the location change
        private void location_CoordinateChanged(object sender, EventArgs e)
        {
            var current = location.CurrentLocation;
            PhoneApplicationService.Current.State["CurrentGeoCoordinate"] = current;

            // Refresh locations
            LoadNearbyLocations();
        }

        private void LoadNearbyLocations()
        {
            var listings = new NearbyLocations();
            LocalListing.ItemsSource = listings.Listing;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}