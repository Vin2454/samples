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
	public class ProductModelProductDescriptionCultureRepository: AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
	{
		public ProductModelProductDescriptionCultureRepository(ILogger<ProductModelProductDescriptionCultureRepository> logger,
		                                                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
			else
			{
				return this._context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
		}

		protected override List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy("ProductModelID ASC").Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
			else
			{
				return this._context.Set<EFProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductModelProductDescriptionCulture>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a6d6e4009704692d0f2f8eda8c9a2bd0</Hash>
</Codenesium>*/