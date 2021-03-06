using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TestsNS.Api.DataAccess
{
	public partial class VPersonRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<VPersonRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<VPersonRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "Repositories")]
	public partial class VPersonRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<VPersonRepository>> loggerMoc = VPersonRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = VPersonRepositoryMoc.GetContext();
			var repository = new VPersonRepository(loggerMoc.Object, context);

			VPerson entity = new VPerson();
			context.Set<VPerson>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PersonId);

			record.Should().NotBeNull();
		}
	}
}

/*<Codenesium>
    <Hash>a5e6deaa34349601c8d9b4f177a2e9cb</Hash>
</Codenesium>*/