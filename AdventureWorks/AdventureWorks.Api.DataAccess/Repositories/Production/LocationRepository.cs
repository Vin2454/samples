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
	public class LocationRepository: AbstractLocationRepository, ILocationRepository
	{
		public LocationRepository(ILogger<LocationRepository> logger,
		                          ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("locationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this._context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}

		protected override List<EFLocation> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("locationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this._context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ed7a13da73d63e226f0beceb7ef69294</Hash>
</Codenesium>*/