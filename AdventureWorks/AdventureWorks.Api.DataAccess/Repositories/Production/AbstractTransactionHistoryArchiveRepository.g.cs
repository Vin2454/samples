using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractTransactionHistoryArchiveRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractTransactionHistoryArchiveRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<TransactionHistoryArchive> Get(int transactionID)
                {
                        return await this.GetById(transactionID);
                }

                public async virtual Task<TransactionHistoryArchive> Create(TransactionHistoryArchive item)
                {
                        this.Context.Set<TransactionHistoryArchive>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(TransactionHistoryArchive item)
                {
                        var entity = this.Context.Set<TransactionHistoryArchive>().Local.FirstOrDefault(x => x.TransactionID == item.TransactionID);
                        if (entity == null)
                        {
                                this.Context.Set<TransactionHistoryArchive>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int transactionID)
                {
                        TransactionHistoryArchive record = await this.GetById(transactionID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<TransactionHistoryArchive>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<TransactionHistoryArchive>> ByProductID(int productID)
                {
                        var records = await this.Where(x => x.ProductID == productID);

                        return records;
                }
                public async Task<List<TransactionHistoryArchive>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID)
                {
                        var records = await this.Where(x => x.ReferenceOrderID == referenceOrderID && x.ReferenceOrderLineID == referenceOrderLineID);

                        return records;
                }

                protected async Task<List<TransactionHistoryArchive>> Where(
                        Expression<Func<TransactionHistoryArchive, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<TransactionHistoryArchive, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.TransactionID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionHistoryArchive>();
                        }
                        else
                        {
                                return await this.Context.Set<TransactionHistoryArchive>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<TransactionHistoryArchive>();
                        }
                }

                private async Task<TransactionHistoryArchive> GetById(int transactionID)
                {
                        List<TransactionHistoryArchive> records = await this.Where(x => x.TransactionID == transactionID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>103d8021a69ce692b0f5f646d3d852f6</Hash>
</Codenesium>*/