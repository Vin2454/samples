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

namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractDeviceRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDeviceRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Device>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Device> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Device> Create(Device item)
		{
			this.Context.Set<Device>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Device item)
		{
			var entity = this.Context.Set<Device>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Device>().Attach(item);
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
			Device record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Device>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<Device> ByPublicId(Guid publicId)
		{
			return await this.Context.Set<Device>().SingleOrDefaultAsync(x => x.PublicId == publicId);
		}

		public async virtual Task<List<DeviceAction>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<DeviceAction>().Where(x => x.DeviceId == deviceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<DeviceAction>();
		}

		protected async Task<List<Device>> Where(
			Expression<Func<Device, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Device, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Device>();
			}
			else
			{
				return await this.Context.Set<Device>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Device>();
			}
		}

		private async Task<Device> GetById(int id)
		{
			List<Device> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2db6b3f2463c51d67d7d1d0052476250</Hash>
</Codenesium>*/