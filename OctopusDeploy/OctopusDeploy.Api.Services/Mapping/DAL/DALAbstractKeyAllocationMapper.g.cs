using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractKeyAllocationMapper
        {
                public virtual KeyAllocation MapBOToEF(
                        BOKeyAllocation bo)
                {
                        KeyAllocation efKeyAllocation = new KeyAllocation();

                        efKeyAllocation.SetProperties(
                                bo.Allocated,
                                bo.CollectionName);
                        return efKeyAllocation;
                }

                public virtual BOKeyAllocation MapEFToBO(
                        KeyAllocation ef)
                {
                        var bo = new BOKeyAllocation();

                        bo.SetProperties(
                                ef.CollectionName,
                                ef.Allocated);
                        return bo;
                }

                public virtual List<BOKeyAllocation> MapEFToBO(
                        List<KeyAllocation> records)
                {
                        List<BOKeyAllocation> response = new List<BOKeyAllocation>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e5e77e368fb5ef07e3575c75a6501da4</Hash>
</Codenesium>*/