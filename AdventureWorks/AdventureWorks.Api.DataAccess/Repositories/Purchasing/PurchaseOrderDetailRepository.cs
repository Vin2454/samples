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
	public class PurchaseOrderDetailRepository: AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
	{
		public PurchaseOrderDetailRepository(ILogger<PurchaseOrderDetailRepository> logger,
		                                     ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy("purchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
			else
			{
				return this._context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
		}

		protected override List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy("purchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
			else
			{
				return this._context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6f630ff4eaffa59d60a6553ce7d7cbdd</Hash>
</Codenesium>*/