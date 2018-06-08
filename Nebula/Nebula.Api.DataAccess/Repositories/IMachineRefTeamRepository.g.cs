using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IMachineRefTeamRepository
        {
                Task<MachineRefTeam> Create(MachineRefTeam item);

                Task Update(MachineRefTeam item);

                Task Delete(int id);

                Task<MachineRefTeam> Get(int id);

                Task<List<MachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>cdc469d007ec836c01486638d39be26a</Hash>
</Codenesium>*/