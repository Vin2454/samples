using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public abstract class AbstractIncludedColumnTestRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractIncludedColumnTestRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<IncludedColumnTest>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<IncludedColumnTest> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<IncludedColumnTest> Create(IncludedColumnTest item)
		{
			this.Context.Set<IncludedColumnTest>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(IncludedColumnTest item)
		{
			var entity = this.Context.Set<IncludedColumnTest>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<IncludedColumnTest>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			IncludedColumnTest record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<IncludedColumnTest>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<IncludedColumnTest>> Where(
			Expression<Func<IncludedColumnTest, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<IncludedColumnTest, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<IncludedColumnTest>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<IncludedColumnTest>();
			}
			else
			{
				return await this.Context.Set<IncludedColumnTest>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<IncludedColumnTest>();
			}
		}

		private async Task<IncludedColumnTest> GetById(int id)
		{
			List<IncludedColumnTest> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>60032e56870cbeb73eb9cbf4b843193e</Hash>
</Codenesium>*/