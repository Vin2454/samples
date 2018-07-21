using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface IRowVersionCheckRepository
        {
                Task<RowVersionCheck> Create(RowVersionCheck item);

                Task Update(RowVersionCheck item);

                Task Delete(int id);

                Task<RowVersionCheck> Get(int id);

                Task<List<RowVersionCheck>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>28a8b440f0a5928509c63dcb7f9457c5</Hash>
</Codenesium>*/