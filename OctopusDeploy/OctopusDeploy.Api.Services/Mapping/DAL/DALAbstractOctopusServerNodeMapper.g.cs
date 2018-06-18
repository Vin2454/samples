using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractOctopusServerNodeMapper
        {
                public virtual OctopusServerNode MapBOToEF(
                        BOOctopusServerNode bo)
                {
                        OctopusServerNode efOctopusServerNode = new OctopusServerNode();

                        efOctopusServerNode.SetProperties(
                                bo.Id,
                                bo.IsInMaintenanceMode,
                                bo.JSON,
                                bo.LastSeen,
                                bo.MaxConcurrentTasks,
                                bo.Name,
                                bo.Rank);
                        return efOctopusServerNode;
                }

                public virtual BOOctopusServerNode MapEFToBO(
                        OctopusServerNode ef)
                {
                        var bo = new BOOctopusServerNode();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsInMaintenanceMode,
                                ef.JSON,
                                ef.LastSeen,
                                ef.MaxConcurrentTasks,
                                ef.Name,
                                ef.Rank);
                        return bo;
                }

                public virtual List<BOOctopusServerNode> MapEFToBO(
                        List<OctopusServerNode> records)
                {
                        List<BOOctopusServerNode> response = new List<BOOctopusServerNode>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b3cb9d052bed4e93e09bc3c3bc23bf46</Hash>
</Codenesium>*/