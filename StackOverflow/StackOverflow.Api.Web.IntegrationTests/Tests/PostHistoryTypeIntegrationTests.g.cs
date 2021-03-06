using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "Integration")]
	public class PostHistoryTypeIntegrationTests
	{
		public PostHistoryTypeIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.PostHistoryTypeDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiPostHistoryTypeResponseModel model = await client.PostHistoryTypeGetAsync(1);

			ApiPostHistoryTypeModelMapper mapper = new ApiPostHistoryTypeModelMapper();

			UpdateResponse<ApiPostHistoryTypeResponseModel> updateResponse = await client.PostHistoryTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			var createModel = new ApiPostHistoryTypeRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPostHistoryTypeResponseModel> createResult = await client.PostHistoryTypeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPostHistoryTypeResponseModel getResponse = await client.PostHistoryTypeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PostHistoryTypeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPostHistoryTypeResponseModel verifyResponse = await client.PostHistoryTypeGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPostHistoryTypeResponseModel response = await client.PostHistoryTypeGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiPostHistoryTypeResponseModel> response = await client.PostHistoryTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostHistoryTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPostHistoryTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPostHistoryTypeResponseModel> result = await client.PostHistoryTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>079d786de836486b32287a293a6a01ae</Hash>
</Codenesium>*/