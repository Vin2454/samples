using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper boluserMapper,
			IDALUserMapper daluserMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       boluserMapper,
			       daluserMapper,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolTeacherMapper,
			       dalTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>be7010d0307f9f22c3d08a630df6f2c9</Hash>
</Codenesium>*/