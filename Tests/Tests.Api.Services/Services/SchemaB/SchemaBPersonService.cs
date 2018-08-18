using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class SchemaBPersonService : AbstractSchemaBPersonService, ISchemaBPersonService
	{
		public SchemaBPersonService(
			ILogger<ISchemaBPersonRepository> logger,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolschemaBPersonMapper,
			IDALSchemaBPersonMapper dalschemaBPersonMapper,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper
			)
			: base(logger,
			       schemaBPersonRepository,
			       schemaBPersonModelValidator,
			       bolschemaBPersonMapper,
			       dalschemaBPersonMapper,
			       bolPersonRefMapper,
			       dalPersonRefMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ea4171a9ae8fa5d4c15327b42fde495e</Hash>
</Codenesium>*/