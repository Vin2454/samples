using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IActionTemplateRepository
        {
                Task<ActionTemplate> Create(ActionTemplate item);

                Task Update(ActionTemplate item);

                Task Delete(string id);

                Task<ActionTemplate> Get(string id);

                Task<List<ActionTemplate>> All(int limit = int.MaxValue, int offset = 0);

                Task<ActionTemplate> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>10095cb84604969228bbff61bc2ceadb</Hash>
</Codenesium>*/