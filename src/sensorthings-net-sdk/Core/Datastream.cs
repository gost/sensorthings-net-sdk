using System;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Datastream:AbstractEntity
    {
        public Datastream(string SelfLink)
        {
            this.SelfLink = SelfLink;
        }

        public string Name  {get;set;}
        public string Description { get; set; }
        public string ObservationType { get; set; }
        public string UnitofMeasurement { get; set; }
        public double ObservedArea { get; set; }
        public List<Observation> Observations { get; set; }
        public DateTime PhenomenonTime { get; set; }
        public DateTime ResultTime { get; set; }
        public Thing Thing { get; set; }
        public Sensor Sensor { get; set; }
        public ObservedProperty ObservedProperty { get; set; }
    }
}
