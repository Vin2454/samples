using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolspeciesMapper,
			IDALSpeciesMapper dalspeciesMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       speciesRepository,
			       speciesModelValidator,
			       bolspeciesMapper,
			       dalspeciesMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40383ffd77918d425b3987c1b6e67bce</Hash>
</Codenesium>*/