using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface ICountryRepository
        {
                Task<Country> Create(Country item);

                Task Update(Country item);

                Task Delete(int id);

                Task<Country> Get(int id);

                Task<List<Country>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Province>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>144d7a76e98de43be467aa3fdb6019f1</Hash>
</Codenesium>*/