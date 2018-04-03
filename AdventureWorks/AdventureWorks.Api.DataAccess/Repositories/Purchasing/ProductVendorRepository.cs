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
	public class ProductVendorRepository: AbstractProductVendorRepository, IProductVendorRepository
	{
		public ProductVendorRepository(ILogger<ProductVendorRepository> logger,
		                               ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductVendor> SearchLinqEF(Expression<Func<EFProductVendor, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy("productID ASC").Skip(skip).Take(take).ToList<EFProductVendor>();
			}
			else
			{
				return this._context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductVendor>();
			}
		}

		protected override List<EFProductVendor> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy("productID ASC").Skip(skip).Take(take).ToList<EFProductVendor>();
			}
			else
			{
				return this._context.Set<EFProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductVendor>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b25b83da7178c1d50937802dad8f857f</Hash>
</Codenesium>*/