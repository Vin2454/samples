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
	public partial class CultureService : AbstractCultureService, ICultureService
	{
		public CultureService(
			ILogger<ICultureRepository> logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolcultureMapper,
			IDALCultureMapper dalcultureMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base(logger,
			       cultureRepository,
			       cultureModelValidator,
			       bolcultureMapper,
			       dalcultureMapper,
			       bolProductModelProductDescriptionCultureMapper,
			       dalProductModelProductDescriptionCultureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2316c30fa44319cf8b1d2aa11ead5bc1</Hash>
</Codenesium>*/