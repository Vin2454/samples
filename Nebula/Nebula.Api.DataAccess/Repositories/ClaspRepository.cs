using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public class ClaspRepository: AbstractClaspRepository, IClaspRepository
	{
		public ClaspRepository(
			ILogger<ClaspRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>523aea2a9c95a29c405f1412839823cc</Hash>
</Codenesium>*/