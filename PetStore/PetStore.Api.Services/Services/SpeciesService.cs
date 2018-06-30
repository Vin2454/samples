using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
                        IDALPetMapper dalPetMapper
                        )
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
    <Hash>ae400b53bf25e5ba884ebc294cb81857</Hash>
</Codenesium>*/