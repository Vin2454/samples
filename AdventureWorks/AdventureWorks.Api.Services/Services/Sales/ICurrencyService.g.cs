using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICurrencyService
        {
                Task<CreateResponse<ApiCurrencyResponseModel>> Create(
                        ApiCurrencyRequestModel model);

                Task<UpdateResponse<ApiCurrencyResponseModel>> Update(string currencyCode,
                                                                       ApiCurrencyRequestModel model);

                Task<ActionResponse> Delete(string currencyCode);

                Task<ApiCurrencyResponseModel> Get(string currencyCode);

                Task<List<ApiCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCurrencyResponseModel> ByName(string name);

                Task<List<ApiCountryRegionCurrencyResponseModel>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCurrencyRateResponseModel>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d6c344db9ed1637515d92920df341b20</Hash>
</Codenesium>*/