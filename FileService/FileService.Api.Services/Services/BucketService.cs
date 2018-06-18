using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class BucketService: AbstractBucketService, IBucketService
        {
                public BucketService(
                        ILogger<IBucketRepository> logger,
                        IBucketRepository bucketRepository,
                        IApiBucketRequestModelValidator bucketModelValidator,
                        IBOLBucketMapper bolbucketMapper,
                        IDALBucketMapper dalbucketMapper
                        ,
                        IBOLFileMapper bolFileMapper,
                        IDALFileMapper dalFileMapper

                        )
                        : base(logger,
                               bucketRepository,
                               bucketModelValidator,
                               bolbucketMapper,
                               dalbucketMapper
                               ,
                               bolFileMapper,
                               dalFileMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>76c86bd7845e1e7d4eaec7f80bbd1fce</Hash>
</Codenesium>*/