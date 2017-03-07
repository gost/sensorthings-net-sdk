using NUnit.Framework;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class LocationTests
    {
        [Test]
        public void FirstLocationTest()
        {
            var location = new Location();
            Assert.IsTrue(location!=null);
        }
    }
}
