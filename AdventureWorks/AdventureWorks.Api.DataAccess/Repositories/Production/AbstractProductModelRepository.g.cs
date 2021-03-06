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
	public abstract class AbstractProductModelRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductModelRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductModel>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductModel> Get(int productModelID)
		{
			return await this.GetById(productModelID);
		}

		public async virtual Task<ProductModel> Create(ProductModel item)
		{
			this.Context.Set<ProductModel>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductModel item)
		{
			var entity = this.Context.Set<ProductModel>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
			if (entity == null)
			{
				this.Context.Set<ProductModel>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModel>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ProductModel> ByName(string name)
		{
			return await this.Context.Set<ProductModel>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async Task<List<ProductModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CatalogDescription == catalogDescription, limit, offset);
		}

		public async Task<List<ProductModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.Instruction == instruction, limit, offset);
		}

		public async virtual Task<List<Product>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		public async virtual Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCulturesByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(x => x.ProductModelID == productModelID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		public async virtual Task<List<ProductModel>> ByIllustrationID(int illustrationID, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.ProductModelIllustrations
			              join productModels in this.Context.ProductModels on
			              refTable.ProductModelID equals productModels.ProductModelID
			              where refTable.IllustrationID == illustrationID
			              select productModels).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<ProductModel>> Where(
			Expression<Func<ProductModel, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductModel, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductModelID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModel>();
			}
			else
			{
				return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModel>();
			}
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.Where(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>eaaf3f4ee47afda4eaf939db7306b108</Hash>
</Codenesium>*/