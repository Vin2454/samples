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
	public class LinkLogRepository: AbstractLinkLogRepository, ILinkLogRepository
	{
		public LinkLogRepository(ILogger<LinkLogRepository> logger,
		                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFLinkLog> SearchLinqEF(Expression<Func<EFLinkLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLinkLog>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLinkLog>();
			}
			else
			{
				return this._context.Set<EFLinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLinkLog>();
			}
		}

		protected override List<EFLinkLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLinkLog>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLinkLog>();
			}
			else
			{
				return this._context.Set<EFLinkLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLinkLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4d84edb779ac5f2fee65e6aafd1e0341</Hash>
</Codenesium>*/