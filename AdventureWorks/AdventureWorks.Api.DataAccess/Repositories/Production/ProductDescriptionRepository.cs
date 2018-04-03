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
	public class ProductDescriptionRepository: AbstractProductDescriptionRepository, IProductDescriptionRepository
	{
		public ProductDescriptionRepository(ILogger<ProductDescriptionRepository> logger,
		                                    ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductDescription> SearchLinqEF(Expression<Func<EFProductDescription, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy("productDescriptionID ASC").Skip(skip).Take(take).ToList<EFProductDescription>();
			}
			else
			{
				return this._context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDescription>();
			}
		}

		protected override List<EFProductDescription> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy("productDescriptionID ASC").Skip(skip).Take(take).ToList<EFProductDescription>();
			}
			else
			{
				return this._context.Set<EFProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductDescription>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>11118c5512a1187a0ce5a839ed49603d</Hash>
</Codenesium>*/