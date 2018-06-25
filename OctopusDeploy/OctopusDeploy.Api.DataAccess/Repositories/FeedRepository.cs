using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class FeedRepository : AbstractFeedRepository, IFeedRepository
        {
                public FeedRepository(
                        ILogger<FeedRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e645a77ef1e02e2db69eb4ff30ab6518</Hash>
</Codenesium>*/