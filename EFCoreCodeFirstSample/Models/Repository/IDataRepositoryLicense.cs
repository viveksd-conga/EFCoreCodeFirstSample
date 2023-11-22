using static Amazon.S3.Util.S3EventNotification;
using System.Collections.Generic;
using System;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepositoryLicense<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
        void Add(License entity);
        void AddMany(List<TEntity> entities);
        void Update(License license, TEntity entity);
        void Delete(License employee);
    }
}
