using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public abstract class DALAbstractVersionInfoMapper
        {
                public virtual VersionInfo MapBOToEF(
                        BOVersionInfo bo)
                {
                        VersionInfo efVersionInfo = new VersionInfo();

                        efVersionInfo.SetProperties(
                                bo.AppliedOn,
                                bo.Description,
                                bo.Version);
                        return efVersionInfo;
                }

                public virtual BOVersionInfo MapEFToBO(
                        VersionInfo ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOVersionInfo();

                        bo.SetProperties(
                                ef.Version,
                                ef.AppliedOn,
                                ef.Description);
                        return bo;
                }

                public virtual List<BOVersionInfo> MapEFToBO(
                        List<VersionInfo> records)
                {
                        List<BOVersionInfo> response = new List<BOVersionInfo>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>065f2319f63af783cc6c13620cf5b1a2</Hash>
</Codenesium>*/