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
	public partial class SelfReferenceService : AbstractSelfReferenceService, ISelfReferenceService
	{
		public SelfReferenceService(
			ILogger<ISelfReferenceRepository> logger,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolselfReferenceMapper,
			IDALSelfReferenceMapper dalselfReferenceMapper)
			: base(logger,
			       selfReferenceRepository,
			       selfReferenceModelValidator,
			       bolselfReferenceMapper,
			       dalselfReferenceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b35fa41df2683f34dcd96ec713c2b0a6</Hash>
</Codenesium>*/