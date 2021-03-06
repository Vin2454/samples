using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "Services")]
	public partial class CommentServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var records = new List<Comment>();
			records.Add(new Comment());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			List<ApiCommentResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var record = new Comment();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ApiCommentResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Comment>(null));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ApiCommentResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).Returns(Task.FromResult(new Comment()));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			CreateResponse<ApiCommentResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Comment>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).Returns(Task.FromResult(new Comment()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			UpdateResponse<ApiCommentResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCommentRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Comment>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICommentRepository>();
			var model = new ApiCommentRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CommentService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.CommentModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLCommentMapperMock,
			                                 mock.DALMapperMockFactory.DALCommentMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CommentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>78141e7c59eeb9845f7fd40635cb0b38</Hash>
</Codenesium>*/