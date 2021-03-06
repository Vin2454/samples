using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostRepositoryMoc
	{
		public static ApplicationDbContext GetContext()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
			              .UseInMemoryDatabase(Guid.NewGuid().ToString())
			              .Options;
			return new ApplicationDbContext(options);
		}

		public static Mock<ILogger<PostRepository>> GetLoggerMoc()
		{
			return new Mock<ILogger<PostRepository>>();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Table", "Post")]
	[Trait("Area", "Repositories")]
	public partial class PostRepositoryTests
	{
		[Fact]
		public async void All()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			Post entity = new Post();
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.All();

			record.Should().NotBeEmpty();
		}

		[Fact]
		public async void Get()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			Post entity = new Post();
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Create()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);

			var entity = new Post();
			await repository.Create(entity);

			var record = await context.Set<Post>().FirstOrDefaultAsync();

			record.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Tracked()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			var record = await repository.Get(entity.Id);

			await repository.Update(record);

			var modifiedRecord = context.Set<Post>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Update_Entity_Is_Not_Tracked()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Update(new Post());

			var modifiedRecord = context.Set<Post>().FirstOrDefaultAsync();
			modifiedRecord.Should().NotBeNull();
		}

		[Fact]
		public async void Delete()
		{
			Mock<ILogger<PostRepository>> loggerMoc = PostRepositoryMoc.GetLoggerMoc();
			ApplicationDbContext context = PostRepositoryMoc.GetContext();
			var repository = new PostRepository(loggerMoc.Object, context);
			Post entity = new Post();
			context.Set<Post>().Add(entity);
			await context.SaveChangesAsync();

			await repository.Delete(entity.Id);

			Post modifiedRecord = await context.Set<Post>().FirstOrDefaultAsync();

			modifiedRecord.Should().BeNull();
		}
	}
}

/*<Codenesium>
    <Hash>5ba0b3c27c14441a6c0db2bfad82a596</Hash>
</Codenesium>*/