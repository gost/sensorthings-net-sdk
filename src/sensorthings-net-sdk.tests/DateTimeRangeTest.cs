using System;
using Newtonsoft.Json;
using NUnit.Framework;

using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class DateTimeRangeTest
    {
        private string _jsonStringTimeRangeStart;
        private string _jsonStringTimeRangeFull;
        private DateTimeRange _dateTimeRangeStart;
        private DateTimeRange _dateTimeRangeFull;
        private DateTime _now;
        private string _nowUtc;
        private DateTime _then;
        private string _thenUtc;

        [SetUp]
        public void Initialize()
        {
            _jsonStringTimeRangeStart = "{ \"@iot.id\": 1, \"result\": 10, \"phenomenonTime\": \"2015-04-13T00:00:00.123Z\" }";
            _jsonStringTimeRangeFull = "{ \"@iot.id\": 1, \"result\": 10, \"phenomenonTime\": \"2015-04-13T00:00:00.123Z/2015-04-13T12:20:15.321Z\" }";
            _now = DateTime.Now;
            _nowUtc = _now.ToUniversalTime().ToString(DateTimeRange.TimeFormat);
            _then = _now.AddHours(2).AddMinutes(12).AddMinutes(44);
            _thenUtc = _then.ToUniversalTime().ToString(DateTimeRange.TimeFormat);
            _dateTimeRangeStart = new DateTimeRange(_now);
            _dateTimeRangeFull = new DateTimeRange(_now, _then);
        }

        [Test]
        public void DateTimeRangeFromString()
        {
            // prepare
            var dt = new DateTimeRange("2015-04-13T00:00:00.123Z");
            var dt2 = new DateTimeRange("2015-04-13T00:00:00.123Z/2015-04-13T12:20:15.321Z");
            var dt3 = new DateTimeRange("2015-04-13T00:00:00.100+02:00");

            // assert
            Assert.NotNull(dt.Start);
            Assert.Null(dt.End);

            Assert.NotNull(dt2.Start);
            Assert.NotNull(dt2.End);

            Assert.AreEqual("2015-04-13T00:00:00.123Z", dt.ToString());
            Assert.AreEqual("2015-04-13T00:00:00.123Z/2015-04-13T12:20:15.321Z", dt2.ToString());
            Assert.AreEqual("2015-04-12T22:00:00.100Z", dt3.ToString());
        }

        [Test]
        public void DateTimeRangeFromDateTime()
        {
            // assert
            Assert.NotNull(_dateTimeRangeStart.Start);
            Assert.Null(_dateTimeRangeStart.End);

            Assert.NotNull(_dateTimeRangeFull.Start);
            Assert.NotNull(_dateTimeRangeFull.End);

            Assert.AreEqual(_nowUtc, _dateTimeRangeStart.ToString());
            Assert.AreEqual($"{_nowUtc}/{_thenUtc}", _dateTimeRangeFull.ToString());
        }

        [Test]
        public void DateTimeRangeSerialize()
        {
            // prepare
            var obs = new Observation {PhenomenonTime = _dateTimeRangeStart };
            var obs2 = new Observation {PhenomenonTime = _dateTimeRangeFull };

            // act
            var serialized1 = JsonConvert.SerializeObject(obs, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });

            var serialized2 = JsonConvert.SerializeObject(obs2, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });

            // assert
            Assert.AreEqual($"{{\"phenomenonTime\":\"{_nowUtc}\"}}", serialized1);
            Assert.AreEqual($"{{\"phenomenonTime\":\"{_nowUtc}/{_thenUtc}\"}}", serialized2);
        }

        [Test]
        public void DateTimeRangeDeserialize()
        {
            // act
            var deserialized = JsonConvert.DeserializeObject<Observation>(_jsonStringTimeRangeStart);
            var deserialized2 = JsonConvert.DeserializeObject<Observation>(_jsonStringTimeRangeFull);

            // assert
            Assert.AreEqual(DateTime.Parse("2015-04-13T00:00:00.123Z"), deserialized.PhenomenonTime.Start.Value);
            Assert.AreEqual(DateTime.Parse("2015-04-13T00:00:00.123Z"), deserialized2.PhenomenonTime.Start.Value);
            Assert.AreEqual(DateTime.Parse("2015-04-13T12:20:15.321Z"), deserialized2.PhenomenonTime.End.Value);
        }
    }
}
