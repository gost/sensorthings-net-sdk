using System.Collections.Generic;
using System.Linq;

namespace sensorthings.ODATA
{
    public class OdataQuery
    {
        public QueryExpand QueryExpand { get; set; }
        public QueryFilter QueryFilter { get; set; }
        public QueryTop QueryTop { get; set; }
        public QuerySkip QuerySkip { get; set; }
        public QuerySelect QuerySelect { get; set; }
        public QueryOrderBy QueryOrderBy { get; set; }
        public QueryCount QueryCount { get; set; }

        /// <summary>
        /// GetOdataQueryStrings returns all available and constructed ODATA
        /// query strings for example:
        /// string[]{"$expand=Datastreams($select=name),Datastreams/Observations($select=result,phenomenonTime;$top=1)", "$top=10", "$skip=0"}
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetOdataQueryStrings()
        {
            return (from query in GetAllQueries() where query != null select $"${query.GetQueryParam()}={query.GetQueryValueString()}").ToList();
        }

        /// <summary>
        /// Get a list of all queries from OdataQuery
        /// queries can be null if not set
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IQuery> GetAllQueries()
        {
            return new List<IQuery> { QueryExpand, QuerySelect, QueryFilter, QueryOrderBy, QueryTop, QuerySkip, QueryCount };
        }

        /// <summary>
        /// AppendOdataQueryToUrl takes the base url and adds the 
        /// available ODATA queries to the url
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public string AppendOdataQueryToUrl(string baseUrl)
        {
            var queryStrings = GetOdataQueryStrings();
            var url = baseUrl;

            foreach (var query in queryStrings)
            {
                var prefix = !url.Contains("?") ? "?" : "&";
                url = $"{url}{prefix}{query}";
            }

            return url;
        }
    }
}
