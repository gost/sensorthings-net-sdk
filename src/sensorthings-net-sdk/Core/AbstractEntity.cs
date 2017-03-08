using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class AbstractEntity
    {

        public AbstractEntity()
        {
        }

        public AbstractEntity(int Id, string NavigationLink, string SelfLink)
        {
            this.Id = Id;
            this.NavigationLink = NavigationLink;
            this.SelfLink = SelfLink;
        }


        [JsonProperty("@iot.id")]
        public int Id { get; set; }
        public string NavigationLink { get; set; }
        [JsonProperty("@iot.selfLink")]
        public string SelfLink { get; set; }
    }
}
