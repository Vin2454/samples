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
	public class ContactTypeRepository: AbstractContactTypeRepository, IContactTypeRepository
	{
		public ContactTypeRepository(ILogger<ContactTypeRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFContactType> SearchLinqEF(Expression<Func<EFContactType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy("contactTypeID ASC").Skip(skip).Take(take).ToList<EFContactType>();
			}
			else
			{
				return this._context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFContactType>();
			}
		}

		protected override List<EFContactType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy("contactTypeID ASC").Skip(skip).Take(take).ToList<EFContactType>();
			}
			else
			{
				return this._context.Set<EFContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFContactType>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>72007e56549e18a00cb1378c121e1d66</Hash>
</Codenesium>*/