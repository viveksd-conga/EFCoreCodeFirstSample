using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepositoryProductRule<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string productWorkFlow);
        void Add(ProductRule entity);
        void AddMany(List<TEntity> entities);
        void Update(ProductRule productRule, TEntity entity);
        void Delete(ProductRule productRule);
    }
}
