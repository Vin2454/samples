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
	public abstract class AbstractSpecialOfferProductRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSpecialOfferProductRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpecialOfferProduct>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SpecialOfferProduct> Get(int specialOfferID)
		{
			return await this.GetById(specialOfferID);
		}

		public async virtual Task<SpecialOfferProduct> Create(SpecialOfferProduct item)
		{
			this.Context.Set<SpecialOfferProduct>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpecialOfferProduct item)
		{
			var entity = this.Context.Set<SpecialOfferProduct>().Local.FirstOrDefault(x => x.SpecialOfferID == item.SpecialOfferID);
			if (entity == null)
			{
				this.Context.Set<SpecialOfferProduct>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOfferProduct>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<SpecialOfferProduct>> Where(
			Expression<Func<SpecialOfferProduct, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SpecialOfferProduct, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SpecialOfferID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SpecialOfferProduct>();
			}
			else
			{
				return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SpecialOfferProduct>();
			}
		}

		private async Task<SpecialOfferProduct> GetById(int specialOfferID)
		{
			List<SpecialOfferProduct> records = await this.Where(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9f8c8a12efe877ebf773c2ba5f0247a9</Hash>
</Codenesium>*/