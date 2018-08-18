using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketRequestModelValidator : AbstractApiTicketRequestModelValidator, IApiTicketRequestModelValidator
	{
		public ApiTicketRequestModelValidator(ITicketRepository ticketRepository)
			: base(ticketRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b286bb246d969cef695bc033fea563dd</Hash>
</Codenesium>*/