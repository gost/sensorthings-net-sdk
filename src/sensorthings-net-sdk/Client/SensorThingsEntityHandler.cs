using System;
using System.Linq;
using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    public class SensorThingsEntityHandler : AbstractEntityHandler, ISensorThingsEntityHandler {

        public SensorThingsEntityHandler(string baseUrl) : base(baseUrl) {
        }

        public async Task<T> CreateEntity<T>(T entity)
            where T : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T>(null);
            return await CreateEntity<T>(url, entity).ConfigureAwait(false);
        }

        public async Task<T> CreateEntity<T, T2>(T2 by, T entity)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T, T2>(by, null);
            return await CreateEntity<T>(url, entity).ConfigureAwait(false);
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
    }
}
