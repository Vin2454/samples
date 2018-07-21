using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface IBreedService
        {
                Task<CreateResponse<ApiBreedResponseModel>> Create(
                        ApiBreedRequestModel model);

                Task<UpdateResponse<ApiBreedResponseModel>> Update(int id,
                                                                    ApiBreedRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiBreedResponseModel> Get(int id);

                Task<List<ApiBreedResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>01ac8c12140fef872452937375ef4a8f</Hash>
</Codenesium>*/