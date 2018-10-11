using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace TwitterNS.Api.DataAccess
{
	public partial class LocationRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<LocationRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<LocationRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "Repositories")]
	public partial class LocationRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			Location entity = new Location();
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			Location entity = new Location();
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LocationId);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);

			var entity = new Location();
			await repository.Create(entity);

			var record = await context.Set<Location>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.LocationId);

			await repository.Update(record);

			var modifiedRecord = context.Set<Location>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Location());

			var modifiedRecord = context.Set<Location>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<LocationRepository>> loggerMoc = LocationRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = LocationRepositoryMoc.GetContext();
			var repository = new LocationRepository(loggerMoc.Object, context);
			Location entity = new Location();
			context.Set<Location>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.LocationId);

			Location modifiedRecord = await context.Set<Location>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>f7f1769cd6e1d6f6bfb20db792271b0a</Hash>
</Codenesium>*/