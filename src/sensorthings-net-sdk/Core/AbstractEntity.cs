using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class AbstractEntity
    {

        public AbstractEntity()
        {
        }

        public AbstractEntity(int Id, string SelfLink)
        {
            this.Id = Id;
            this.SelfLink = SelfLink;
        }


        [JsonProperty("@iot.id")]
        public int Id { get; set; }
        [JsonProperty("@iot.selfLink")]
        public string SelfLink { get; set; }
    }
}
