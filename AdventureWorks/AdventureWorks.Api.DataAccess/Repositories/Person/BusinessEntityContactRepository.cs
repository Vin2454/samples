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
	public class BusinessEntityContactRepository: AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
	{
		public BusinessEntityContactRepository(
			IObjectMapper mapper,
			ILogger<BusinessEntityContactRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFBusinessEntityContact> SearchLinqEF(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
			else
			{
				return this.Context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
		}

		protected override List<EFBusinessEntityContact> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
			else
			{
				return this.Context.Set<EFBusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBusinessEntityContact>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2c8eae6490e35ecc4701512f1f4391d7</Hash>
</Codenesium>*/