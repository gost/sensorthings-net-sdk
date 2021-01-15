using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    public class AbstractEntityHandler {
        private readonly string _baseUrl;

        protected AbstractEntityHandler(string baseUrl) {
            _ = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl), "Variable must not be null");
            _ = new Uri(baseUrl); // check if URL is valid
            _baseUrl = baseUrl;
        }

        protected async Task<T> CreateEntity<T>(Uri url, T entity)
            where T : AbstractEntity {
            // workaround: creating the object the Id should be ignored at all
            entity.Id = null;
            var respose = await Http.PostJson(url, entity).ConfigureAwait(false);

            if (!respose.Success) {
                throw new InvalidOperationException(
                    $"Cannot create entity for '{url}' because {respose.ServiceError}");
            }
            return respose.Result ?? await GetEntity<T>(respose.Location).ConfigureAwait(false);
        }

        protected async Task<T> GetEntity<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.GetJson<T>(url).ConfigureAwait(false);
            return respose.Result;
        }

        protected async Task<SensorThingsCollection<T>> GetEntities<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.GetJson<SensorThingsCollection<T>>(url).ConfigureAwait(false);
            return respose.Result;
        }

        protected async Task UpdateEntity<T>(Uri url, T entity)
            where T : AbstractEntity {
            var respose = await Http.PatchJson(url, entity).ConfigureAwait(false);

            if (!respose.Success) {
                throw new InvalidOperationException(
                    $"Cannot update entity for '{url}' because {respose.ServiceError}");
            }
        }

        protected async Task DeleteEntity<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.DeleteJson<T>(url).ConfigureAwait(false);

            if (!respose.Success) {
                throw new InvalidOperationException(
                    $"Cannot delete entity for '{url}' because {respose.ServiceError}");
            }
        }

        protected Uri GetEntityUrl<T>(OdataQuery odata)
            where T : AbstractEntity =>
            new Uri($"{_baseUrl}/{GetPlural<T>()}{OdataQuery(odata)}");

        protected Uri GetEntityUrl<T>(string id, OdataQuery odata)
            where T : AbstractEntity =>
            new Uri($"{_baseUrl}/{GetPlural<T>()}({id}){OdataQuery(odata)}");

        protected Uri GetEntityUrl<T, T2>(T2 by, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity =>
            new Uri(
                $"{_baseUrl}/{GetPlural<T2>()}({by.Id})/{GetPlural<T>()}{OdataQuery(odata)}");

        private string GetPlural<T>()
            where T : AbstractEntity =>
            typeof(T).Name switch {
                "ObservedProperty" => "ObservedProperties",
                "FeatureOfInterest" => "FeaturesOfInterest",
                _ => $"{typeof(T).Name}s"
            };

        private string OdataQuery(OdataQuery odata = null) =>
            odata != null ? $"?{OdataQueryString(odata)}" : string.Empty;

        private string OdataQueryString(OdataQuery odata) =>
            string.Join(
                "&",
                odata.GetAllQueries()
                    .Where(query => query != null)
                    .Select(query => $"${query.GetQueryParam()}={PatchedValue(query)}")
                    .ToArray());

        // regarding to 'https://github.com/FraunhoferIOSB/FROST-Server/issues/299'
        private string PatchedValue(IQuery query) =>
            HttpUtility.UrlEncode(query.GetQueryValueString());
    }
}
