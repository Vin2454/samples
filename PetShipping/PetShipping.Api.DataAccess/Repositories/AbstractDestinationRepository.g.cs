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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDestinationRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDestinationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Destination>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Destination> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Destination> Create(Destination item)
		{
			this.Context.Set<Destination>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Destination item)
		{
			var entity = this.Context.Set<Destination>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Destination>().Attach(item);
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
			Destination record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Destination>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Country> CountryByCountryId(int countryId)
		{
			return await this.Context.Set<Country>().SingleOrDefaultAsync(x => x.Id == countryId);
		}

		public async virtual Task<List<Destination>> ByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.PipelineStepDestinations
			              join destinations in this.Context.Destinations on
			              refTable.DestinationId equals destinations.Id
			              where refTable.DestinationId == destinationId
			              select destinations).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Destination>> Where(
			Expression<Func<Destination, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Destination, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Destination>();
			}
			else
			{
				return await this.Context.Set<Destination>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Destination>();
			}
		}

		private async Task<Destination> GetById(int id)
		{
			List<Destination> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2503ecebc7ae3db52d575b80528c2b5b</Hash>
</Codenesium>*/