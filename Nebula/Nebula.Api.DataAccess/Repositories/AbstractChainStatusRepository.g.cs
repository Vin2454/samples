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

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractChainStatusRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractChainStatusRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ChainStatus>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ChainStatus> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ChainStatus> Create(ChainStatus item)
		{
			this.Context.Set<ChainStatus>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ChainStatus item)
		{
			var entity = this.Context.Set<ChainStatus>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ChainStatus>().Attach(item);
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
			ChainStatus record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ChainStatus>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ChainStatus> ByName(string name)
		{
			return await this.Context.Set<ChainStatus>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<List<Chain>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Chain>().Where(x => x.ChainStatusId == chainStatusId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Chain>();
		}

		protected async Task<List<ChainStatus>> Where(
			Expression<Func<ChainStatus, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ChainStatus, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ChainStatus>();
			}
			else
			{
				return await this.Context.Set<ChainStatus>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ChainStatus>();
			}
		}

		private async Task<ChainStatus> GetById(int id)
		{
			List<ChainStatus> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>02c2befd9fdeecaeb3920628e0328e96</Hash>
</Codenesium>*/