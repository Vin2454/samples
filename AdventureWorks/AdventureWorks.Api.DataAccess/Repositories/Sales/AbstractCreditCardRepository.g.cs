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
	public abstract class AbstractCreditCardRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCreditCardRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CreditCard>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<CreditCard> Get(int creditCardID)
		{
			return await this.GetById(creditCardID);
		}

		public async virtual Task<CreditCard> Create(CreditCard item)
		{
			this.Context.Set<CreditCard>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CreditCard item)
		{
			var entity = this.Context.Set<CreditCard>().Local.FirstOrDefault(x => x.CreditCardID == item.CreditCardID);
			if (entity == null)
			{
				this.Context.Set<CreditCard>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int creditCardID)
		{
			CreditCard record = await this.GetById(creditCardID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CreditCard>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<CreditCard> ByCardNumber(string cardNumber)
		{
			return await this.Context.Set<CreditCard>().SingleOrDefaultAsync(x => x.CardNumber == cardNumber);
		}

		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>().Where(x => x.CreditCardID == creditCardID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		public async virtual Task<List<CreditCard>> ByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.PersonCreditCards
			              join creditCards in this.Context.CreditCards on
			              refTable.CreditCardID equals creditCards.CreditCardID
			              where refTable.BusinessEntityID == businessEntityID
			              select creditCards).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<CreditCard>> Where(
			Expression<Func<CreditCard, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CreditCard, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CreditCardID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CreditCard>();
			}
			else
			{
				return await this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<CreditCard>();
			}
		}

		private async Task<CreditCard> GetById(int creditCardID)
		{
			List<CreditCard> records = await this.Where(x => x.CreditCardID == creditCardID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>699f45ab7135daf38b21875503a53435</Hash>
</Codenesium>*/