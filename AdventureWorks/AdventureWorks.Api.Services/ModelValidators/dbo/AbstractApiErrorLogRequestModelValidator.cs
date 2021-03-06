using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiErrorLogRequestModelValidator : AbstractValidator<ApiErrorLogRequestModel>
	{
		private int existingRecordId;

		private IErrorLogRepository errorLogRepository;

		public AbstractApiErrorLogRequestModelValidator(IErrorLogRepository errorLogRepository)
		{
			this.errorLogRepository = errorLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiErrorLogRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ErrorLineRules()
		{
		}

		public virtual void ErrorMessageRules()
		{
			this.RuleFor(x => x.ErrorMessage).NotNull();
			this.RuleFor(x => x.ErrorMessage).Length(0, 4000);
		}

		public virtual void ErrorNumberRules()
		{
		}

		public virtual void ErrorProcedureRules()
		{
			this.RuleFor(x => x.ErrorProcedure).Length(0, 126);
		}

		public virtual void ErrorSeverityRules()
		{
		}

		public virtual void ErrorStateRules()
		{
		}

		public virtual void ErrorTimeRules()
		{
		}

		public virtual void UserNameRules()
		{
			this.RuleFor(x => x.UserName).NotNull();
			this.RuleFor(x => x.UserName).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>ac5f77cd42880047aadba7664bfb7dc4</Hash>
</Codenesium>*/