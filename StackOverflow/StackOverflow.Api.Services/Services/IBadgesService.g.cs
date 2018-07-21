using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IBadgesService
        {
                Task<CreateResponse<ApiBadgesResponseModel>> Create(
                        ApiBadgesRequestModel model);

                Task<UpdateResponse<ApiBadgesResponseModel>> Update(int id,
                                                                     ApiBadgesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiBadgesResponseModel> Get(int id);

                Task<List<ApiBadgesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>97ea93d0581afa76d56794f57a64c751</Hash>
</Codenesium>*/