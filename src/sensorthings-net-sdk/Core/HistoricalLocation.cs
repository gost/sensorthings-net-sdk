using System;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class HistoricalLocation: AbstractEntity
    {
        public HistoricalLocation()
        {

        }

        public HistoricalLocation(string SelfLink)
        {
            this.SelfLink = SelfLink;
        }

        public DateTime Time { get; set; }
        public Thing Thing { get; set; }
        public List<Location> Locations { get; set; }
    }
}
