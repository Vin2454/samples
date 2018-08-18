using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALSpaceMapper
	{
		Space MapBOToEF(
			BOSpace bo);

		BOSpace MapEFToBO(
			Space efSpace);

		List<BOSpace> MapEFToBO(
			List<Space> records);
	}
}

/*<Codenesium>
    <Hash>47cf3c9ff8b5ef18118bfc5693932520</Hash>
</Codenesium>*/