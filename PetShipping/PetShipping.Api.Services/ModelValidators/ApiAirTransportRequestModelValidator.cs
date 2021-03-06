using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiAirTransportRequestModelValidator : AbstractApiAirTransportRequestModelValidator, IApiAirTransportRequestModelValidator
	{
		public ApiAirTransportRequestModelValidator(IAirTransportRepository airTransportRepository)
			: base(airTransportRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model)
		{
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.IdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model)
		{
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.IdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ff86ff5c10b84a166435fa6383032deb</Hash>
</Codenesium>*/