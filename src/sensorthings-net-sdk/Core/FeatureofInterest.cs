using System.Collections.Generic;

namespace SensorThings.Core.Core
{
    public class FeatureofInterest : AbstractEntity
    {
        public FeatureofInterest()
        {
        }

        public FeatureofInterest(string SelfLink, string NavigationLink)
        {
            this.SelfLink = SelfLink;
            this.NavigationLink = NavigationLink;
        }

        public string Name { get; set; }
        public string Descrption { get; set; }
        public object Feature { get; set; }
        public List<Observation> Observations { get; set; }
        public string EncodingType { get; set; }
    }
}
