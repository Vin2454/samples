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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractScrapReasonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractScrapReasonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ScrapReason>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ScrapReason> Get(short scrapReasonID)
		{
			return await this.GetById(scrapReasonID);
		}

		public async virtual Task<ScrapReason> Create(ScrapReason item)
		{
			this.Context.Set<ScrapReason>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ScrapReason item)
		{
			var entity = this.Context.Set<ScrapReason>().Local.FirstOrDefault(x => x.ScrapReasonID == item.ScrapReasonID);
			if (entity == null)
			{
				this.Context.Set<ScrapReason>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			short scrapReasonID)
		{
			ScrapReason record = await this.GetById(scrapReasonID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ScrapReason>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ScrapReason> ByName(string name)
		{
			return await this.Context.Set<ScrapReason>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<List<WorkOrder>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<WorkOrder>().Where(x => x.ScrapReasonID == scrapReasonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
		}

		protected async Task<List<ScrapReason>> Where(
			Expression<Func<ScrapReason, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ScrapReason, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ScrapReasonID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ScrapReason>();
			}
			else
			{
				return await this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ScrapReason>();
			}
		}

		private async Task<ScrapReason> GetById(short scrapReasonID)
		{
			List<ScrapReason> records = await this.Where(x => x.ScrapReasonID == scrapReasonID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c85e1af191c7ad5bac85cdea2bb8761e</Hash>
</Codenesium>*/