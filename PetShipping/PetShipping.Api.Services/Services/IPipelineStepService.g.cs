using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepService
        {
                Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
                        ApiPipelineStepRequestModel model);

                Task<UpdateResponse<ApiPipelineStepResponseModel>> Update(int id,
                                                                           ApiPipelineStepRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepResponseModel> Get(int id);

                Task<List<ApiPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiOtherTransportResponseModel>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7c4c14ed9959ce638fa1a86dd46f9e27</Hash>
</Codenesium>*/