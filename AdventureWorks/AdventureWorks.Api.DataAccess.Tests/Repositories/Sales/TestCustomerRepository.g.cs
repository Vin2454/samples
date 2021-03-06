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
	public partial class CustomerRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<CustomerRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<CustomerRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "Repositories")]
	public partial class CustomerRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CustomerID);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);

			var entity = new Customer();
			await repository.Create(entity);

			var record = await context.Set<Customer>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.CustomerID);

			await repository.Update(record);

			var modifiedRecord = context.Set<Customer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Customer());

			var modifiedRecord = context.Set<Customer>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<CustomerRepository>> loggerMoc = CustomerRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = CustomerRepositoryMoc.GetContext();
			var repository = new CustomerRepository(loggerMoc.Object, context);
			Customer entity = new Customer();
			context.Set<Customer>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.CustomerID);

			Customer modifiedRecord = await context.Set<Customer>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>b78a4336591b96c6e41ac512461725c1</Hash>
</Codenesium>*/