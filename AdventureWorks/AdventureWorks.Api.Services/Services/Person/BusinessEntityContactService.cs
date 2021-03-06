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
	public partial class BusinessEntityContactService : AbstractBusinessEntityContactService, IBusinessEntityContactService
	{
		public BusinessEntityContactService(
			ILogger<IBusinessEntityContactRepository> logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper bolbusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalbusinessEntityContactMapper)
			: base(logger,
			       businessEntityContactRepository,
			       businessEntityContactModelValidator,
			       bolbusinessEntityContactMapper,
			       dalbusinessEntityContactMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2245036f1b140f3fe9a2202c5791933d</Hash>
</Codenesium>*/