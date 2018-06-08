using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractLinkLogMapper
        {
                public virtual LinkLog MapBOToEF(
                        BOLinkLog bo)
                {
                        LinkLog efLinkLog = new LinkLog();

                        efLinkLog.SetProperties(
                                bo.DateEntered,
                                bo.Id,
                                bo.LinkId,
                                bo.Log);
                        return efLinkLog;
                }

                public virtual BOLinkLog MapEFToBO(
                        LinkLog ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOLinkLog();

                        bo.SetProperties(
                                ef.Id,
                                ef.DateEntered,
                                ef.LinkId,
                                ef.Log);
                        return bo;
                }

                public virtual List<BOLinkLog> MapEFToBO(
                        List<LinkLog> records)
                {
                        List<BOLinkLog> response = new List<BOLinkLog>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>062786c703c7f914aaf36c4203cca73b</Hash>
</Codenesium>*/