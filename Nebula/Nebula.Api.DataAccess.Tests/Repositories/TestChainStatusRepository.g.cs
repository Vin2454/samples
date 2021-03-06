using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace NebulaNS.Api.DataAccess
{
	public partial class ChainStatusRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<ChainStatusRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<ChainStatusRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Repositories")]
	public partial class ChainStatusRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);

			var entity = new ChainStatus();
			await repository.Create(entity);

			var record = await context.Set<ChainStatus>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<ChainStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new ChainStatus());

			var modifiedRecord = context.Set<ChainStatus>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<ChainStatusRepository>> loggerMoc = ChainStatusRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = ChainStatusRepositoryMoc.GetContext();
			var repository = new ChainStatusRepository(loggerMoc.Object, context);
			ChainStatus entity = new ChainStatus();
			context.Set<ChainStatus>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			ChainStatus modifiedRecord = await context.Set<ChainStatus>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f1d15aa0e4360a777d1b4b93eaa2e8d4</Hash>
</Codenesium>*/