using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using SensorThings.Core;
using SensorThings.Extensions;
using SensorThings.OData;

namespace SensorThings.Client {
    public class SensorThingsEntityHandler : ISensorThingsEntityHandler {
        private readonly string _baseUrl;

        public SensorThingsEntityHandler(string baseUrl) { this._baseUrl = baseUrl; }

        // TODO - return Id of new object (note: Response has the Header 'Location' by Spec)
        public async Task<Response<T>> CreateEntity<T>(T entity)
            where T : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T>(null);
            return await CreateEntity(url, entity).ConfigureAwait(false);
        }

        // TODO - return Id of new object (note: Response has the Header 'Location' by Spec)
        public async Task<Response<T>> CreateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, true, null);
            return await CreateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task<Response<T>> GetEntity<T>(string id, OdataQuery odata = null)
            where T : AbstractEntity {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var url = GetEntityUrl<T>(id, odata);
            return await GetEntity<T>(url).ConfigureAwait(false);
        }

        public async Task<Response<T>> GetEntity<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, false, odata);
            return await GetEntity<T>(url).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<T>>> GetEntities<T>(OdataQuery odata = null)
            where T : AbstractEntity {
            var url = GetEntityUrl<T>(odata);
            return await GetEntities<T>(url).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<T>>> GetEntities<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, true, odata);
            return await GetEntities<T>(url).ConfigureAwait(false);
        }

        public async Task<Response<T>> UpdateEntity<T>(T entity)
            where T : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var url = GetEntityUrl<T>(null);
            return await UpdateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task<Response<T>> UpdateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, true, null);
            return await UpdateEntity(url, entity).ConfigureAwait(false);
        }

        public async Task<Response<T>> DeleteEntity<T>(string id)
            where T : AbstractEntity {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            var url = GetEntityUrl<T>(id, null);
            return await DeleteEntity<T>(url).ConfigureAwait(false);
        }

        public async Task<Response<T>> DeleteEntity<T, T2>(string id, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity {
            _ = by ?? throw new ArgumentNullException(nameof(by));

            var url = GetEntityUrl<T, T2>(by, true, null);
            return await DeleteEntity<T>(url).ConfigureAwait(false);
        }

        private async Task<Response<T>> CreateEntity<T>(Uri url, T entity)
            where T : AbstractEntity {
            // workaround: creating the object the Id should be ignored at all
            entity.Id = null;
            return await Http.PostJson(url, entity).ConfigureAwait(false);
        }

        private async Task<Response<T>> GetEntity<T>(Uri url)
            where T : AbstractEntity => await Http.GetJson<T>(url).ConfigureAwait(false);

        internal async Task<Response<SensorThingsCollection<T>>> GetEntities<T>(Uri url)
            where T : AbstractEntity => await Http.GetJson<SensorThingsCollection<T>>(url).ConfigureAwait(false);

        private async Task<Response<T>> UpdateEntity<T>(Uri url, T entity)
            where T : AbstractEntity => await Http.PatchJson(url, entity).ConfigureAwait(false);

        private async Task<Response<T>> DeleteEntity<T>(Uri url)
            where T : AbstractEntity => await Http.DeleteJson<T>(url).ConfigureAwait(false);

        private Uri GetEntityUrl<T>(OdataQuery odata) =>
            new Uri($"{_baseUrl}/{typeof(T).GetString(true)}{OdataQuery(odata)}");

        private Uri GetEntityUrl<T>(string id, OdataQuery odata) =>
            new Uri($"{_baseUrl}/{typeof(T).GetString(true)}({id}){OdataQuery(odata)}");

        internal Uri GetEntityUrl<T, T2>(T2 by, bool isPlural, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity =>
            new Uri(
                $"{_baseUrl}/{typeof(T2).GetString(true)}({by.Id})/{typeof(T).GetString(isPlural)}{OdataQuery(odata)}");

        private static string OdataQuery(OdataQuery odata = null) =>
            odata != null ? $"?{OdataQueryString(odata)}" : string.Empty;

        private static string OdataQueryString(OdataQuery odata) =>
            string.Join(
                "&",
                odata.GetAllQueries()
                    .Where(query => query != null)
                    .Select(query => $"${query.GetQueryParam()}={PatchedValue(query)}")
                    .ToArray());

        // regarding to 'https://github.com/FraunhoferIOSB/FROST-Server/issues/299'
        private static string PatchedValue(IQuery query) =>
            HttpUtility.UrlEncode(query.GetQueryValueString());
    }
}
