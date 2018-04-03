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
	public class ShoppingCartItemRepository: AbstractShoppingCartItemRepository, IShoppingCartItemRepository
	{
		public ShoppingCartItemRepository(ILogger<ShoppingCartItemRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("shoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}

		protected override List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("shoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>cd1a0d3f87860c8a5c27273aad5eec91</Hash>
</Codenesium>*/