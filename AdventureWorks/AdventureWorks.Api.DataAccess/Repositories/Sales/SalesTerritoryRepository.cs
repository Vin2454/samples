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
	public class SalesTerritoryRepository: AbstractSalesTerritoryRepository, ISalesTerritoryRepository
	{
		public SalesTerritoryRepository(
			IObjectMapper mapper,
			ILogger<SalesTerritoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSalesTerritory> SearchLinqEF(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy("TerritoryID ASC").Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
			else
			{
				return this.Context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
		}

		protected override List<EFSalesTerritory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy("TerritoryID ASC").Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
			else
			{
				return this.Context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b59e3588bd876a226a4578490367d197</Hash>
</Codenesium>*/