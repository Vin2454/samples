using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial interface ICityRepository
	{
		Task<City> Create(City item);

		Task Update(City item);

		Task Delete(int id);

		Task<City> Get(int id);

		Task<List<City>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<City>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<Event>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0);

		Task<Province> ProvinceByProvinceId(int provinceId);
	}
}

/*<Codenesium>
    <Hash>bc72f8212869bc1c43e7ca95cc6da15c</Hash>
</Codenesium>*/