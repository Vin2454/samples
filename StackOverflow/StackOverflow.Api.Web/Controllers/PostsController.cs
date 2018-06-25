using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Web
{
        [Route("api/posts")]
        [ApiVersion("1.0")]
        public class PostsController : AbstractPostsController
        {
                public PostsController(
                        ApiSettings settings,
                        ILogger<PostsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostsService postsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0b66272f13308dfe9b42d8850fd7ec57</Hash>
</Codenesium>*/