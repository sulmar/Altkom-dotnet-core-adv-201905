using System.Collections.Generic;

namespace Altkom.DotnetCore.IServices
{
    public interface IEntitiesService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }




}
