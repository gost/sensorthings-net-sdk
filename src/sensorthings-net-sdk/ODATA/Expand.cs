using System.Linq;

namespace sensorthings.ODATA
{
    public class Expand
    {
        public string[] Path { get; }
        public OdataQuery OdataQuery { get; }

        public Expand(string[] path, OdataQuery query = null)
        {
            Path = path;
            OdataQuery = query;
        }

        public string GetPathString()
        {
            return Path.Aggregate((x, y) => $"{x}/{y}");
        }

        private string ConstructInnerQueryString()
        {
            var queryStrings = OdataQuery.GetOdataQueryStrings();
            return queryStrings.Aggregate((x, y) => $"{x};{y}");
        }

        public string GetExpandString()
        {
            var expandString = GetPathString();
            if (OdataQuery != null)
            {
                expandString = $"{expandString}({ConstructInnerQueryString()})";
            }

            return expandString;
        }
    }
}
