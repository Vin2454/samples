using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ErrorLogRepository: AbstractErrorLogRepository, IErrorLogRepository
	{
		public ErrorLogRepository(ILogger<ErrorLogRepository> logger,
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFErrorLog> SearchLinqEF(Expression<Func<EFErrorLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("errorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this._context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}

		protected override List<EFErrorLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("errorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this._context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c407d39b9612ecbadbddb07f133c1d15</Hash>
</Codenesium>*/