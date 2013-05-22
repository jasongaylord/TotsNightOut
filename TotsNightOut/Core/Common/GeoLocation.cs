using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotsNightOut.Core.Common
{
    public class GeoLocation
    {
        GeoCoordinateWatcher watcher;
        GeoCoordinate previous = new GeoCoordinate();
        GeoCoordinate current = new GeoCoordinate();
        public event EventHandler CoordinateChanged;

        public GeoCoordinate CurrentLocation
        {
            get
            {
                return this.current;
            }
            set
            {
                if (value != this.current)
                {
                    this.current = value;
                    if (this.CoordinateChanged != null)
                        this.CoordinateChanged(this, new EventArgs());
                }
            }
        }

        public void StartWatching(GeoPositionAccuracy accuracy)
        {
            if (watcher != null)
                StopWatching();

            watcher = new GeoCoordinateWatcher(accuracy);
            watcher.MovementThreshold = 1.0;
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.StatusChanged += watcher_StatusChanged;

            if (watcher.Permission == GeoPositionPermission.Granted)
                watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (watcher.Status == GeoPositionStatus.Ready)
            {
                GeoCoordinate location = e.Position.Location;
                // Update current coordinate now
                previous = CurrentLocation;
                CurrentLocation = location;
            }
        }

        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            // We'll leave this blank for now.
        }

        public void StopWatching()
        {
            if (watcher != null)
            {
                watcher.Stop();
                watcher.PositionChanged -= watcher_PositionChanged;
                watcher.StatusChanged -= watcher_StatusChanged;
                watcher.Dispose();
                watcher = null;
            }
        }

    }
}