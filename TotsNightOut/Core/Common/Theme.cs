using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TotsNightOut.Core.Common
{
    public static class Theme
    {
        public static SolidColorBrush Foreground { get; private set; }
        public static ThemeColor CurrentTheme { get; private set; }
        public static bool IsLightTheme { get { return CurrentTheme == ThemeColor.Light; } }
        public static bool IsDarkTheme { get { return CurrentTheme == ThemeColor.Dark; } }
        public static Uri LogoUri { get; private set; }

        public enum ThemeColor
        {
            Light,
            Dark
        }

        public static void Detect()
        {
            // Determine what the theme background is
            Visibility isVisible = (Visibility)Application.Current.Resources["PhoneLightThemeVisibility"];
            CurrentTheme = isVisible == Visibility.Visible ? ThemeColor.Light : ThemeColor.Dark;

            // Determine the theme foreground
            Theme.Foreground = (SolidColorBrush)Application.Current.Resources["PhoneAccentBrush"];

            // Get the default logo
            LogoUri = new Uri(CurrentTheme == ThemeColor.Dark ? "/Assets/TotsNightOut-DarkBackground.png" : "/Assets/TotsNightOut-LightBackground.png", UriKind.Relative);
        }
    }
}