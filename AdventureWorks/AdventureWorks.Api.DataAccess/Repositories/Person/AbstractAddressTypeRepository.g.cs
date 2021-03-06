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
	public abstract class AbstractAddressTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractAddressTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<AddressType>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<AddressType> Get(int addressTypeID)
		{
			return await this.GetById(addressTypeID);
		}

		public async virtual Task<AddressType> Create(AddressType item)
		{
			this.Context.Set<AddressType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(AddressType item)
		{
			var entity = this.Context.Set<AddressType>().Local.FirstOrDefault(x => x.AddressTypeID == item.AddressTypeID);
			if (entity == null)
			{
				this.Context.Set<AddressType>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int addressTypeID)
		{
			AddressType record = await this.GetById(addressTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AddressType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<AddressType> ByName(string name)
		{
			return await this.Context.Set<AddressType>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<List<BusinessEntityAddress>> BusinessEntityAddressesByAddressTypeID(int addressTypeID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BusinessEntityAddress>().Where(x => x.AddressTypeID == addressTypeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BusinessEntityAddress>();
		}

		protected async Task<List<AddressType>> Where(
			Expression<Func<AddressType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<AddressType, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.AddressTypeID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<AddressType>();
			}
			else
			{
				return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<AddressType>();
			}
		}

		private async Task<AddressType> GetById(int addressTypeID)
		{
			List<AddressType> records = await this.Where(x => x.AddressTypeID == addressTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>56b0b140d39a032a82b4a476ae4dfa89</Hash>
</Codenesium>*/