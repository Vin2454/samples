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
	public class JobCandidateRepository: AbstractJobCandidateRepository, IJobCandidateRepository
	{
		public JobCandidateRepository(
			IObjectMapper mapper,
			ILogger<JobCandidateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}

		protected override List<EFJobCandidate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy("JobCandidateID ASC").Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
			else
			{
				return this.Context.Set<EFJobCandidate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFJobCandidate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d1234394ed78f8e0846c0b912ac756cb</Hash>
</Codenesium>*/