using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    public class SensorThingsEntityHandler : ISensorThingsEntityHandler {
        private readonly string _baseUrl;

        public SensorThingsEntityHandler(string baseUrl) {
            _ = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl), "Variable must not be null");
            _ = new Uri(baseUrl); // check if URL is valid
            _baseUrl = baseUrl;
        }

        public async Task<T> CreateEntity<T>(T entity)
            where T : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T>(null);
            return await CreateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task<T> CreateEntity<T, T2>(T2 by, T entity)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T, T2>(by, null);
            return await CreateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task<T> GetEntity<T>(string id, OdataQuery odata = null)
            where T : AbstractEntity {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var url = GetEntityUrl<T>(id, odata);
            return await GetEntity<T>(url).ConfigureAwait(false);
        }

        public async Task<T> SearchEntity<T>(OdataQuery odata)
            where T : AbstractEntity {
            _ = odata ?? throw new ArgumentNullException(nameof(odata));

            var collection = await SearchEntities<T>(odata.TopN(1)).ConfigureAwait(false);
            return collection.Items?.FirstOrDefault();
        }

        public async Task<T> SearchEntity<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var query = odata ?? QueryHelper.Empty();
            var collection = await SearchEntities<T, T2>(by, query.TopN(1)).ConfigureAwait(false);
            return collection.Items?.FirstOrDefault();
        }

        public async Task<SensorThingsCollection<T>> SearchEntities<T>(OdataQuery odata = null)
            where T : AbstractEntity {
            var url = GetEntityUrl<T>(odata);
            return await GetEntities<T>(url).ConfigureAwait(false);
        }

        public async Task<SensorThingsCollection<T>> SearchEntities<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, odata);
            return await GetEntities<T>(url).ConfigureAwait(false);
        }

        public async Task UpdateEntity<T>(T entity)
            where T : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            _ = entity.Id ?? throw new ArgumentException("No valid entity - Id must NOT be null!", nameof(entity));

            var url = GetEntityUrl<T>(entity.Id, null);
            await UpdateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task DeleteEntity<T>(string id)
            where T : AbstractEntity {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var url = GetEntityUrl<T>(id, null);
            await DeleteEntity<T>(url).ConfigureAwait(false);
        }

        [Obsolete("Use GetEntity(id, query).")]
        internal async Task<Response<T>> GetEntityResponse<T>(string id, OdataQuery odata)
            where T : AbstractEntity {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var url = GetEntityUrl<T>(id, odata);
            return await Http.GetJson<T>(url).ConfigureAwait(false);
        }

        [Obsolete("Use SearchEntity(by, query).")]
        internal async Task<Response<T>> GetEntityResponse<T, T2>(T2 by, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            Response<SensorThingsCollection<T>> collectionResponse =
                await GetEntitiesResponse<T, T2>(by, odata).ConfigureAwait(false);

            return collectionResponse.Success
                ? Response<T>.CreateSuccessful(collectionResponse.Location,
                    collectionResponse.Result?.Items?.FirstOrDefault(), collectionResponse.HttpStatusCode)
                : Response<T>.CreateUnsuccessful(collectionResponse.Location, collectionResponse.ServiceError,
                    collectionResponse.HttpStatusCode);
        }

        [Obsolete("Use SearchEntities(query).")]
        internal async Task<Response<SensorThingsCollection<T>>> GetEntitiesResponse<T>(OdataQuery odata = null)
            where T : AbstractEntity {
            var url = GetEntityUrl<T>(odata);
            return await Http.GetJson<SensorThingsCollection<T>>(url).ConfigureAwait(false);
        }

        [Obsolete("Use SearchEntities(by, query).")]
        internal async Task<Response<SensorThingsCollection<T>>> GetEntitiesResponse<T, T2>(
            T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, odata);
            return await Http.GetJson<SensorThingsCollection<T>>(url).ConfigureAwait(false);
        }

        private async Task<T> CreateEntity<T>(Uri url, T entity)
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

        private async Task<T> GetEntity<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.GetJson<T>(url).ConfigureAwait(false);
            return respose.Result;
        }

        private async Task<SensorThingsCollection<T>> GetEntities<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.GetJson<SensorThingsCollection<T>>(url).ConfigureAwait(false);
            return respose.Result;
        }

        private async Task UpdateEntity<T>(Uri url, T entity)
            where T : AbstractEntity {
            var respose = await Http.PatchJson(url, entity).ConfigureAwait(false);
            
            if (!respose.Success) {
                throw new InvalidOperationException(
                    $"Cannot update entity for '{url}' because {respose.ServiceError}");
            }
        }

        private async Task DeleteEntity<T>(Uri url)
            where T : AbstractEntity {
            var respose = await Http.DeleteJson<T>(url).ConfigureAwait(false);
            
            if (!respose.Success) {
                throw new InvalidOperationException(
                    $"Cannot delete entity for '{url}' because {respose.ServiceError}");
            }
        }

        private Uri GetEntityUrl<T>(OdataQuery odata) 
            where T : AbstractEntity =>
            new Uri($"{_baseUrl}/{GetPlural<T>()}{OdataQuery(odata)}");

        private Uri GetEntityUrl<T>(string id, OdataQuery odata) 
            where T : AbstractEntity =>
            new Uri($"{_baseUrl}/{GetPlural<T>()}({id}){OdataQuery(odata)}");

        private Uri GetEntityUrl<T, T2>(T2 by, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity =>
            new Uri(
                $"{_baseUrl}/{GetPlural<T2>()}({by.Id})/{GetPlural<T>()}{OdataQuery(odata)}");

        private string GetPlural<T>() 
            where T : AbstractEntity {
            var name = typeof(T).Name;
            switch (name) {
                case nameof(ObservedProperty):
                    return "ObservedProperties";
                case nameof(FeatureOfInterest):
                    return "FeaturesOfInterest";
                default:
                    return $"{name}s";
            }
        }

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
