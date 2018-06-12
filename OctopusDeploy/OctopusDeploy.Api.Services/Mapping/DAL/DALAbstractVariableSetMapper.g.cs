using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractVariableSetMapper
        {
                public virtual VariableSet MapBOToEF(
                        BOVariableSet bo)
                {
                        VariableSet efVariableSet = new VariableSet();

                        efVariableSet.SetProperties(
                                bo.Id,
                                bo.IsFrozen,
                                bo.JSON,
                                bo.OwnerId,
                                bo.RelatedDocumentIds,
                                bo.Version);
                        return efVariableSet;
                }

                public virtual BOVariableSet MapEFToBO(
                        VariableSet ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOVariableSet();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsFrozen,
                                ef.JSON,
                                ef.OwnerId,
                                ef.RelatedDocumentIds,
                                ef.Version);
                        return bo;
                }

                public virtual List<BOVariableSet> MapEFToBO(
                        List<VariableSet> records)
                {
                        List<BOVariableSet> response = new List<BOVariableSet>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7e28adc7270e3d355527c27fc9ee4dca</Hash>
</Codenesium>*/