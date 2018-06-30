using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
        public interface IProvinceRepository
        {
                Task<Province> Create(Province item);

                Task Update(Province item);

                Task Delete(int id);

                Task<Province> Get(int id);

                Task<List<Province>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Province>> ByCountryId(int countryId);

                Task<List<City>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);

                Task<List<Venue>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);

                Task<Country> GetCountry(int countryId);
        }
}

/*<Codenesium>
    <Hash>989de66eeb2250836914bc0e494f212d</Hash>
</Codenesium>*/