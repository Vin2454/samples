using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTicketRequestModelValidatorTest
	{
		public ApiTicketRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PublicId_Create_null()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
		}

		[Fact]
		public async void PublicId_Update_null()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
		}

		[Fact]
		public async void PublicId_Create_length()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
		}

		[Fact]
		public async void PublicId_Update_length()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
		}

		// table.Columns[i].GetReferenceTable().AppTableName= TicketStatu
		[Fact]
		public async void TicketStatusId_Create_Valid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(new TicketStatu()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Create_Invalid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

			await validator.ValidateCreateAsync(new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Update_Valid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(new TicketStatu()));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Update_Invalid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));

			var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>a491e435d159fa7b7a6b5bb9141630d4</Hash>
</Codenesium>*/