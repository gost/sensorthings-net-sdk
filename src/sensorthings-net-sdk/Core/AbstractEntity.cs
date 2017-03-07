namespace SensorThings.Core
{
    public class AbstractEntity
    {

        public AbstractEntity() {
        }

        public AbstractEntity(string NavigationLink, string SelfLink)
        {
            this.NavigationLink = NavigationLink;
           this.SelfLink = SelfLink;
        }

        public string NavigationLink { get; set; }
        public string SelfLink { get; set; }
    }
}
