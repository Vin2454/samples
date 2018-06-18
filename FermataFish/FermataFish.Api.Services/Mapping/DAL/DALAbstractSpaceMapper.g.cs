using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractSpaceMapper
        {
                public virtual Space MapBOToEF(
                        BOSpace bo)
                {
                        Space efSpace = new Space();

                        efSpace.SetProperties(
                                bo.Description,
                                bo.Id,
                                bo.Name,
                                bo.StudioId);
                        return efSpace;
                }

                public virtual BOSpace MapEFToBO(
                        Space ef)
                {
                        var bo = new BOSpace();

                        bo.SetProperties(
                                ef.Id,
                                ef.Description,
                                ef.Name,
                                ef.StudioId);
                        return bo;
                }

                public virtual List<BOSpace> MapEFToBO(
                        List<Space> records)
                {
                        List<BOSpace> response = new List<BOSpace>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>cec22e91b4aa0e42da0ff5180b0c8e59</Hash>
</Codenesium>*/