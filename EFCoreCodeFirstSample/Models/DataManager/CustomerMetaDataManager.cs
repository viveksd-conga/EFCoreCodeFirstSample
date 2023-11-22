using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class CustomerMetaDataManager : IDataRepositoryCustomerMetaData<CustomerMetaData>
    {
        readonly EmployeeContext _employeeContext;

        public CustomerMetaDataManager(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Add(CustomerMetaData entity)
        {
            _employeeContext.CustomersMetaData.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(CustomerMetaData customerMetaData)
        {
            _employeeContext.CustomersMetaData.Remove(customerMetaData);
            _employeeContext.SaveChanges();
        }

        public CustomerMetaData Get(long id)
        {
            return _employeeContext.CustomersMetaData.FirstOrDefault(e => e.CustId == id);
        }

        public IEnumerable<CustomerMetaData> GetAll()
        {
            return _employeeContext.CustomersMetaData.AsQueryable();
        }

        public void Update(CustomerMetaData customerMetaData, CustomerMetaData entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
