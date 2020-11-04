using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SensorThings.OData;

namespace sensorthings_net_sdk.tests
{
    public class OdataTest
    {
        [Test]
        public void OdataQueryTest()
        {
            // prepare
            var odataQuery1 = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] { "name" }),
                QueryFilter = new QueryFilter("name eq 'test'")
            };

            var odataQuery2 = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] { "id", "result" }),
                QueryTop = new QueryTop(5)
            };

            var odataQuery = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] {"id", "name"}),
                QueryTop = new QueryTop(5),
                QuerySkip = new QuerySkip(1),
                QueryCount = new QueryCount(true),
                QueryFilter = new QueryFilter("name eq 'test'"),
                QueryOrderBy = new QueryOrderBy(new Dictionary<string, OrderType> {{"name", OrderType.Descending}}),
                QueryExpand = new QueryExpand(new[]
                    {
                        new Expand(new[] {"Datastreams"}, odataQuery1),
                        new Expand(new[] {"Datastreams", "Observations"}, odataQuery2)
                    }
                )
            };

            Assert.AreEqual(7, odataQuery.GetOdataQueryStrings().Count());
            Assert.AreEqual("http://stserver/v1.0/Things?$expand=Datastreams($select=name;$filter=name eq 'test'),Datastreams/Observations($select=id,result;$top=5)&$select=id,name&$filter=name eq 'test'&$orderby=name desc&$top=5&$skip=1&$count=true", odataQuery.AppendOdataQueryToUrl("http://stserver/v1.0/Things"));
        }

        [Test]
        public void QueryTopTest()
        {
            // prepare
            var queryTop = new QueryTop(5);

            // assert
            Assert.IsTrue(queryTop.Value == 5);
            Assert.AreEqual("top", queryTop.GetQueryParam());
            Assert.AreEqual("5", queryTop.GetQueryValueString());
        }

        [Test]
        public void QuerySkipTest()
        {
            // prepare
            var query = new QuerySkip(1);

            // assert
            Assert.IsTrue(query.Value == 1);
            Assert.AreEqual("skip", query.GetQueryParam());
            Assert.AreEqual("1", query.GetQueryValueString());
        }

        [Test]
        public void QueryCountTest()
        {
            // prepare
            var query = new QueryCount(true);

            // assert
            Assert.AreEqual(true, query.Value);
            Assert.AreEqual("count", query.GetQueryParam());
            Assert.AreEqual("true", query.GetQueryValueString());
        }

        [Test]
        public void QueryExpandtTest()
        {
            // prepare
            var odataQuery1 = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] {"name"}),
                QueryFilter = new QueryFilter("name eq 'test'")
            };

            var odataQuery2 = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] { "id", "result" }),
                QueryTop = new QueryTop(5)
            };

            var query = new QueryExpand(new[]
                {
                    new Expand(new[] {"Datastreams"}, odataQuery1),
                    new Expand(new[] {"Datastreams", "Observations"}, odataQuery2)
                }
            );

            
            // assert
            Assert.AreEqual(2, query.Value.Length);
            Assert.AreEqual("expand", query.GetQueryParam());
            Assert.AreEqual("Datastreams($select=name;$filter=name eq 'test'),Datastreams/Observations($select=id,result;$top=5)", query.GetQueryValueString());
        }

        [Test]
        public void QueryFilterTest()
        {
            // prepare
            var query = new QueryFilter("name eq 'test'");

            // assert
            Assert.AreEqual("name eq 'test'", query.Value);
            Assert.AreEqual("filter", query.GetQueryParam());
            Assert.AreEqual("name eq 'test'", query.GetQueryValueString());
        }

        [Test]
        public void QueryOrderByTest()
        {
            // prepare
            var query = new QueryOrderBy(new Dictionary<string, OrderType>
            {
                { "phenomenonTime", OrderType.Descending },
                { "result", OrderType.Ascending }
            });

            // assert
            Assert.AreEqual(2, query.Value.Count);
            Assert.AreEqual("orderby", query.GetQueryParam());
            Assert.AreEqual("phenomenonTime desc,result asc", query.GetQueryValueString());
        }

        [Test]
        public void QuerySelectTest()
        {
            // prepare
            var query = new QuerySelect(new []
            {
                "id", "result"
            });

            // assert
            Assert.AreEqual(2, query.Value.Length);
            Assert.AreEqual("select", query.GetQueryParam());
            Assert.AreEqual("id,result", query.GetQueryValueString());
        }
    }
}
