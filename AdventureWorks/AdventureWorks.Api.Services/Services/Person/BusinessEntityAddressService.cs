using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class BusinessEntityAddressService : AbstractBusinessEntityAddressService, IBusinessEntityAddressService
	{
		public BusinessEntityAddressService(
			ILogger<IBusinessEntityAddressRepository> logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper bolbusinessEntityAddressMapper,
			IDALBusinessEntityAddressMapper dalbusinessEntityAddressMapper)
			: base(logger,
			       businessEntityAddressRepository,
			       businessEntityAddressModelValidator,
			       bolbusinessEntityAddressMapper,
			       dalbusinessEntityAddressMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bd2a81c421f0841ddbf87d95a2d1fb5f</Hash>
</Codenesium>*/