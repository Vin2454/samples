using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial class SpaceXSpaceFeatureRepository : AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
	{
		public SpaceXSpaceFeatureRepository(
			ILogger<SpaceXSpaceFeatureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>809d54687f45af816a35587f93aba02d</Hash>
</Codenesium>*/