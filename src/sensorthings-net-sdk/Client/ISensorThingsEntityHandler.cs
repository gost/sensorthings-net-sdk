using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    // ReSharper disable UnusedMember.Global
    public interface ISensorThingsEntityHandler {
        Task<T> CreateEntity<T>(T entity)
            where T : AbstractEntity;

        Task<T> CreateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<T> GetEntity<T>(string id, OdataQuery odata = null)
            where T : AbstractEntity;
        
        Task<T> SearchEntity<T>(OdataQuery odata)
            where T : AbstractEntity;

        Task<T> SearchEntity<T, T2>(T2 by, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<SensorThingsCollection<T>> SearchEntities<T>(OdataQuery odata = null)
            where T : AbstractEntity;

        Task<SensorThingsCollection<T>> SearchEntities<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<bool> UpdateEntity<T>(T entity)
            where T : AbstractEntity;

        Task<bool> UpdateEntity<T, T2>(T entity, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<bool> DeleteEntity<T>(string id)
            where T : AbstractEntity;

        Task<bool> DeleteEntity<T, T2>(string id, T2 by)
            where T : AbstractEntity
            where T2 : AbstractEntity;
    }
}
