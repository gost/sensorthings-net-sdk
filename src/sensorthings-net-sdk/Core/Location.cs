using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Location:AbstractEntity
    {
        public Location() { }

        public Location(string SelfLink,
            string Name,
            string Description,
            string EncodingType)
        {
            this.SelfLink = SelfLink;
            this.Name = Name;
            this.Description = Description;
            this.EncodingType = EncodingType;
        }

        public List<Thing> Things { get; set; }
        public string EncodingType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
