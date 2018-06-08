using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class TeacherService: AbstractTeacherService, ITeacherService
        {
                public TeacherService(
                        ILogger<TeacherRepository> logger,
                        ITeacherRepository teacherRepository,
                        IApiTeacherRequestModelValidator teacherModelValidator,
                        IBOLTeacherMapper bolteacherMapper,
                        IDALTeacherMapper dalteacherMapper)
                        : base(logger,
                               teacherRepository,
                               teacherModelValidator,
                               bolteacherMapper,
                               dalteacherMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8d42a34976adb0c59646e4daa9590f05</Hash>
</Codenesium>*/