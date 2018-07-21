using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ILessonXTeacherService
        {
                Task<CreateResponse<ApiLessonXTeacherResponseModel>> Create(
                        ApiLessonXTeacherRequestModel model);

                Task<UpdateResponse<ApiLessonXTeacherResponseModel>> Update(int id,
                                                                             ApiLessonXTeacherRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonXTeacherResponseModel> Get(int id);

                Task<List<ApiLessonXTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>12acbc83a10b262a9238361a52bfb7e3</Hash>
</Codenesium>*/