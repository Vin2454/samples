using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class PhoneNumberTypeRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PhoneNumberTypeRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PhoneNumberTypeRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "Repositories")]
	public partial class PhoneNumberTypeRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			PhoneNumberType entity = new PhoneNumberType();
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			PhoneNumberType entity = new PhoneNumberType();
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PhoneNumberTypeID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);

			var entity = new PhoneNumberType();
			await repository.Create(entity);

			var record = await context.Set<PhoneNumberType>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.PhoneNumberTypeID);

			await repository.Update(record);

			var modifiedRecord = context.Set<PhoneNumberType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new PhoneNumberType());

			var modifiedRecord = context.Set<PhoneNumberType>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PhoneNumberTypeRepository>> loggerMoc = PhoneNumberTypeRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PhoneNumberTypeRepositoryMoc.GetContext();
			var repository = new PhoneNumberTypeRepository(loggerMoc.Object, context);
			PhoneNumberType entity = new PhoneNumberType();
			context.Set<PhoneNumberType>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.PhoneNumberTypeID);

			PhoneNumberType modifiedRecord = await context.Set<PhoneNumberType>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>0220e469f00bc7a5940b33ac6e7267f5</Hash>
</Codenesium>*/