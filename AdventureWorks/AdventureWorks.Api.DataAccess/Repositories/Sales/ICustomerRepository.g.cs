using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICustomerRepository
        {
                Task<Customer> Create(Customer item);

                Task Update(Customer item);

                Task Delete(int customerID);

                Task<Customer> Get(int customerID);

                Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0);

                Task<Customer> ByAccountNumber(string accountNumber);
                Task<List<Customer>> ByTerritoryID(Nullable<int> territoryID);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);

                Task<Store> GetStore(int storeID);
                Task<SalesTerritory> GetSalesTerritory(int territoryID);
        }
}

/*<Codenesium>
    <Hash>b9d4a92aad6bb596b406649cb8c3b829</Hash>
</Codenesium>*/