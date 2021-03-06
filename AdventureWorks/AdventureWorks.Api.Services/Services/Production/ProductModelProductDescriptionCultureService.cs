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
	public partial class ProductModelProductDescriptionCultureService : AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
	{
		public ProductModelProductDescriptionCultureService(
			ILogger<IProductModelProductDescriptionCultureRepository> logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper)
			: base(logger,
			       productModelProductDescriptionCultureRepository,
			       productModelProductDescriptionCultureModelValidator,
			       bolproductModelProductDescriptionCultureMapper,
			       dalproductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f07f5ad0a9ce922bbd7ce462c9509d01</Hash>
</Codenesium>*/