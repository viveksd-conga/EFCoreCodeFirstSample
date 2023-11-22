using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepositoryCustomerMetaData<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(CustomerMetaData employee, TEntity entity);
        void Delete(CustomerMetaData employee);
    }
}
