using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherSkillService
        {
                Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
                        ApiTeacherSkillRequestModel model);

                Task<UpdateResponse<ApiTeacherSkillResponseModel>> Update(int id,
                                                                           ApiTeacherSkillRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherSkillResponseModel> Get(int id);

                Task<List<ApiTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiRateResponseModel>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0fe79013af7611b2825405e457ad8570</Hash>
</Codenesium>*/