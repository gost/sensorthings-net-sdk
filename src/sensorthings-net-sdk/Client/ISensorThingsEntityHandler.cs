using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    // ReSharper disable UnusedMember.Global
    public interface ISensorThingsEntityHandler {
        Task<Response<T>> CreateEntity<T>(T entity)
            where T : AbstractEntity;

        Task<Response<T>> CreateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<Response<T>> GetEntity<T>(string id, OdataQuery odata = null)
            where T : AbstractEntity;

        Task<Response<T>> GetEntity<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<Response<SensorThingsCollection<T>>> GetEntities<T>(OdataQuery odata = null)
            where T : AbstractEntity;

        Task<Response<SensorThingsCollection<T>>> GetEntities<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<Response<T>> UpdateEntity<T>(T entity)
            where T : AbstractEntity;

        Task<Response<T>> UpdateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<Response<T>> DeleteEntity<T>(string id)
            where T : AbstractEntity;

        Task<Response<T>> DeleteEntity<T, T2>(string id, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;
    }
}
