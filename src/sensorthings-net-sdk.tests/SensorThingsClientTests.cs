using NUnit.Framework;
using SensorThings.Client;
using System;

namespace sensorthings_net_sdk.tests
{
    public class SensorThingsClientTests
    {
        private string server;
        private SensorThingsClient client;

        [SetUp]
        public void Initialize()
        {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            client = new SensorThingsClient(server);
        }

        [Test]
        public void GetFeatureOfInterestTest()
        {
            // act
            var foi = client.GetFeatureOfInterest();

            // assert
            Assert.IsTrue(foi.Id == 760921);
            Assert.IsTrue(foi.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)");
            Assert.IsTrue(foi.Description == "Generated using location details: Nanyang Polytechnic Block S");
            Assert.IsTrue(foi.Name == "Nanyang Polytechnic");
            // todo: How to parse the GeoJSON returned?
            // Assert.IsTrue(foi.Feature.ToString() == @"{{"coordinates": [103.84844899177551,1.3790908801131481],"type": "Point"}}");
            Assert.IsTrue(foi.ObservationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)/Observations");
        }

        [Test]
        public void GetFeatureOfInterestCollectionTest()
        {
            // act
            var fois = client.GetFeatureOfInterestCollection();

            // assert
            Assert.IsTrue(fois.Count == 367);
            Assert.IsTrue(fois.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest?$top=100&$skip=100");
            Assert.IsTrue(fois.Items.Count == 100);
        }

        [Test]
        public void GetObservedPropertyTest()
        {
            // act
            var observedProperty = client.GetObservedProperty();

            // assert
            Assert.IsTrue(observedProperty.Id == 760803);
            Assert.IsTrue(observedProperty.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)");
            Assert.IsTrue(observedProperty.Description == "acceleration of sensor");
            Assert.IsTrue(observedProperty.Name == "acceleration");
            Assert.IsTrue(observedProperty.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)/Datastreams");
        }

        [Test]
        public void GetObservedPropertyCollectionTest()
        {
            // act
            var observedProperties = client.GetObservedPropertyCollection();

            // assert
            Assert.IsTrue(observedProperties.Count == 1162);
            Assert.IsTrue(observedProperties.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties?$top=100&$skip=100");
            Assert.IsTrue(observedProperties.Items.Count == 100);
            Assert.IsTrue(observedProperties.Items[0].Id == 760803);
        }

        [Test]
        public void GetLocationTest()
        {
            // act
            var location = client.GetLocation(760795);

            // assert
            Assert.IsTrue(location.Id == 760795);
            Assert.IsTrue(location.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)");
            Assert.IsTrue(location.Description == "The NYP location");
            Assert.IsTrue(location.Name == "NYP_LOCATION_4321");
            Assert.IsTrue(location.EncodingType == "application/vnd.get+json");
            Assert.IsTrue(location.Feature != null);
            Assert.IsTrue(location.ThingsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)/Things");
            Assert.IsTrue(location.HistoricalLocationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)/HistoricalLocations");
        }

        [Test]
        public void GetLocationCollectionTest()
        {
            // act
            var locations = client.GetLocationCollection();

            // assert
            Assert.IsTrue(locations.Count == 1166);
            Assert.IsTrue(locations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations?$top=100&$skip=100");
            Assert.IsTrue(locations.Items.Count == 100);
            Assert.IsTrue(locations.Items[0].Id == 760795);
        }

        [Test]
        public void GetObservationTest()
        {
            // act
            var observation = client.GetObservation(760789);

            // assert
            Assert.IsTrue(observation.Id == 760789);
            Assert.IsTrue(observation.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)");
            // Phenomenon time should be 2020-01-25T19:00:00.000Z in Iso8601
            Assert.IsTrue(observation.PhenomenonTime == new DateTime(2020, 1, 25, 19, 0, 0));
            Assert.IsTrue((string)observation.Result == "99");
            Assert.IsTrue(observation.ResultTime == null);
            Assert.IsTrue(observation.DatastreamNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)/Datastream");
            Assert.IsTrue(observation.FeatureOfInterestNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)/FeatureOfInterest");
        }

        [Test]
        public void GetObservationCollectionTest()
        {
            // act
            var observations = client.GetObservationCollection();

            // assert
            // If new observations are added this next test will fail....
            Assert.IsTrue(observations.Count == 735595);
            Assert.IsTrue(observations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations?$top=100&$skip=100");
            Assert.IsTrue(observations.Items.Count == 100);
            Assert.IsTrue(observations.Items[0].Id == 760789);
        }
    }
}
