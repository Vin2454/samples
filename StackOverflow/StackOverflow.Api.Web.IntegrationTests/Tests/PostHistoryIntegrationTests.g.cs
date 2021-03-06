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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Integration")]
	public class PostHistoryIntegrationTests
	{
		public PostHistoryIntegrationTests()
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

			await client.PostHistoryDeleteAsync(1);

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

			ApiPostHistoryResponseModel model = await client.PostHistoryGetAsync(1);

			ApiPostHistoryModelMapper mapper = new ApiPostHistoryModelMapper();

			UpdateResponse<ApiPostHistoryResponseModel> updateResponse = await client.PostHistoryUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPostHistoryRequestModel();
			createModel.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", "B", "B", 2);
			CreateResponse<ApiPostHistoryResponseModel> createResult = await client.PostHistoryCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPostHistoryResponseModel getResponse = await client.PostHistoryGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PostHistoryDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPostHistoryResponseModel verifyResponse = await client.PostHistoryGetAsync(2);

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
			ApiPostHistoryResponseModel response = await client.PostHistoryGetAsync(1);

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

			List<ApiPostHistoryResponseModel> response = await client.PostHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPostHistoryRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", "B", "B", 2);
			CreateResponse<ApiPostHistoryResponseModel> result = await client.PostHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>3df57826a5e802b2e817853add40ef83</Hash>
</Codenesium>*/