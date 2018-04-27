using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class VersionInfoRepository: AbstractVersionInfoRepository, IVersionInfoRepository
	{
		public VersionInfoRepository(
			IObjectMapper mapper,
			ILogger<VersionInfoRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFVersionInfo> SearchLinqEF(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy("Version ASC").Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
			else
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
		}

		protected override List<EFVersionInfo> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy("Version ASC").Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
			else
			{
				return this.Context.Set<EFVersionInfo>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFVersionInfo>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>be820f70b314bdaab7bb5698852a726e</Hash>
</Codenesium>*/