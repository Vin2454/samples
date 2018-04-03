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
	public class SalesTaxRateRepository: AbstractSalesTaxRateRepository, ISalesTaxRateRepository
	{
		public SalesTaxRateRepository(ILogger<SalesTaxRateRepository> logger,
		                              ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesTaxRate> SearchLinqEF(Expression<Func<EFSalesTaxRate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy("salesTaxRateID ASC").Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
			else
			{
				return this._context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
		}

		protected override List<EFSalesTaxRate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy("salesTaxRateID ASC").Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
			else
			{
				return this._context.Set<EFSalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTaxRate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>139a842914a1b62a4a7360e29293c21e</Hash>
</Codenesium>*/