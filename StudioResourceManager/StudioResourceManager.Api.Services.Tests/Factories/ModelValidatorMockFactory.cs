using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	public class ModelValidatorMockFactory
	{
		public Mock<IApiAdminRequestModelValidator> AdminModelValidatorMock { get; set; } = new Mock<IApiAdminRequestModelValidator>();

		public Mock<IApiEventRequestModelValidator> EventModelValidatorMock { get; set; } = new Mock<IApiEventRequestModelValidator>();

		public Mock<IApiEventStatusRequestModelValidator> EventStatusModelValidatorMock { get; set; } = new Mock<IApiEventStatusRequestModelValidator>();

		public Mock<IApiFamilyRequestModelValidator> FamilyModelValidatorMock { get; set; } = new Mock<IApiFamilyRequestModelValidator>();

		public Mock<IApiRateRequestModelValidator> RateModelValidatorMock { get; set; } = new Mock<IApiRateRequestModelValidator>();

		public Mock<IApiSpaceRequestModelValidator> SpaceModelValidatorMock { get; set; } = new Mock<IApiSpaceRequestModelValidator>();

		public Mock<IApiSpaceFeatureRequestModelValidator> SpaceFeatureModelValidatorMock { get; set; } = new Mock<IApiSpaceFeatureRequestModelValidator>();

		public Mock<IApiStudentRequestModelValidator> StudentModelValidatorMock { get; set; } = new Mock<IApiStudentRequestModelValidator>();

		public Mock<IApiStudioRequestModelValidator> StudioModelValidatorMock { get; set; } = new Mock<IApiStudioRequestModelValidator>();

		public Mock<IApiTeacherRequestModelValidator> TeacherModelValidatorMock { get; set; } = new Mock<IApiTeacherRequestModelValidator>();

		public Mock<IApiTeacherSkillRequestModelValidator> TeacherSkillModelValidatorMock { get; set; } = new Mock<IApiTeacherSkillRequestModelValidator>();

		public Mock<IApiTenantRequestModelValidator> TenantModelValidatorMock { get; set; } = new Mock<IApiTenantRequestModelValidator>();

		public Mock<IApiUserRequestModelValidator> UserModelValidatorMock { get; set; } = new Mock<IApiUserRequestModelValidator>();

		public Mock<IApiVEventRequestModelValidator> VEventModelValidatorMock { get; set; } = new Mock<IApiVEventRequestModelValidator>();

		public ModelValidatorMockFactory()
		{
			this.AdminModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiAdminRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.AdminModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.EventStatusModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiEventStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStatusModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiEventStatusRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.EventStatusModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.FamilyModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FamilyModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFamilyRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.FamilyModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.RateModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RateModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiRateRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.RateModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpaceModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSpaceFeatureRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.SpaceFeatureModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StudentModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudentModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudentRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudentModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.StudioModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiStudioRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudioModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiStudioRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.StudioModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeacherModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeacherSkillRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TeacherSkillModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.TenantModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTenantRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTenantRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.TenantModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.UserModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiUserRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.UserModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

			this.VEventModelValidatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiVEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VEventModelValidatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiVEventRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
			this.VEventModelValidatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));
		}
	}
}

/*<Codenesium>
    <Hash>6188aa87cb92f1d685bbb171158150ab</Hash>
</Codenesium>*/