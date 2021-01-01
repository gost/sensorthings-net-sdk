using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    // ReSharper disable UnusedMember.Global
    // ReSharper disable UnusedMemberInSuper.Global
    public interface ISensorThingsEntityHandler {
        Task<T> CreateEntity<T>(T entity)
            where T : AbstractEntity;

        Task<T> CreateEntity<T, T2>(T2 by, T entity)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<T> GetEntity<T>(string id, OdataQuery odata = null)
            where T : AbstractEntity;
        
        Task<T> SearchEntity<T>(OdataQuery odata)
            where T : AbstractEntity;

        Task<T> SearchEntity<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        Task<SensorThingsCollection<T>> SearchEntities<T>(OdataQuery odata = null)
            where T : AbstractEntity;

        Task<SensorThingsCollection<T>> SearchEntities<T, T2>(T2 by, OdataQuery odata = null)
            where T : AbstractEntity
            where T2 : AbstractEntity;

        // note: UpdateBy is not allowed by standard (and framework)
        Task UpdateEntity<T>(T entity)
            where T : AbstractEntity;

        // note: DeleteBy is not allowed by standard (and framework)
        Task DeleteEntity<T>(string id)
            where T : AbstractEntity;
    }
}
