using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class LessonStatusRepository: AbstractLessonStatusRepository, ILessonStatusRepository
	{
		public LessonStatusRepository(
			IObjectMapper mapper,
			ILogger<LessonStatusRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFLessonStatus> SearchLinqEF(Expression<Func<EFLessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
			else
			{
				return this.Context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
		}

		protected override List<EFLessonStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
			else
			{
				return this.Context.Set<EFLessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLessonStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7c15f9297e9f45d060a7a75ef83c9d77</Hash>
</Codenesium>*/