using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotsNightOut.Controls
{
    class LocationTemplateSelector
    {
        public DataTemplate WithBackgroundImage { get; set; }
        public DataTemplate WithoutBackgroundImage { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var location = item as LocCityLocation;

            if (location != null)
            {
                int imageCount = 0;
                if (int.TryParse(location.imagecount, out imageCount))
                {
                    if (imageCount > 0)
                        return WithBackgroundImage;
                }
                return WithoutBackgroundImage;
            }

            return base.SelectTemplate(item, container);
        }
    }
}