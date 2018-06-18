using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IRateRepository
        {
                Task<Rate> Create(Rate item);

                Task Update(Rate item);

                Task Delete(int id);

                Task<Rate> Get(int id);

                Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0);

                Task<Teacher> GetTeacher(int teacherId);
                Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
        }
}

/*<Codenesium>
    <Hash>9186e0c174ff9e1229684d4a0c3d2d00</Hash>
</Codenesium>*/