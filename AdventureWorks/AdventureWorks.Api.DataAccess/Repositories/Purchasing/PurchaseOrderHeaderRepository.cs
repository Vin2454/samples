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
	public class PurchaseOrderHeaderRepository: AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
	{
		public PurchaseOrderHeaderRepository(ILogger<PurchaseOrderHeaderRepository> logger,
		                                     ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPurchaseOrderHeader> SearchLinqEF(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy("purchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
			else
			{
				return this._context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
		}

		protected override List<EFPurchaseOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy("purchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
			else
			{
				return this._context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>0b79f8772237d614b8f8805d69d585b3</Hash>
</Codenesium>*/