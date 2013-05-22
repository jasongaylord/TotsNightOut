using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotsNightOut.Core.Model
{
    public class NearbyLocation
    {
        public int LocationId { get; set; }
        public string ChainName { get; set; }
        public float Distance { get; set; }

        public NearbyLocation() { }

        public NearbyLocation(int id, string name, float distance)
        {
            LocationId = id;
            ChainName = name;
            Distance = distance;
        }
    }

    public class NearbyLocations
    {
        public List<NearbyLocation> Listing { get; private set; }

        public NearbyLocations()
        {
            Listing = new List<NearbyLocation>();
            Listing.Add(new NearbyLocation(1, "Ruth Chris", 0.7f));
            Listing.Add(new NearbyLocation(2, "Costello's", 1.2f));
            Listing.Add(new NearbyLocation(3, "Pick Your Own Food", 3.2f));
        }
    }
}
