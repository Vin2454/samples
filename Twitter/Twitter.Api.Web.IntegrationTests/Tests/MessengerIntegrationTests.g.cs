using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "Integration")]
	public class MessengerIntegrationTests
	{
		public MessengerIntegrationTests()
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

			await client.MessengerDeleteAsync(1);

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

			ApiMessengerResponseModel model = await client.MessengerGetAsync(1);

			ApiMessengerModelMapper mapper = new ApiMessengerModelMapper();

			UpdateResponse<ApiMessengerResponseModel> updateResponse = await client.MessengerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiMessengerRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("1"), 1, 1);
			CreateResponse<ApiMessengerResponseModel> createResult = await client.MessengerCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiMessengerResponseModel getResponse = await client.MessengerGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.MessengerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiMessengerResponseModel verifyResponse = await client.MessengerGetAsync(2);

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
			ApiMessengerResponseModel response = await client.MessengerGetAsync(1);

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

			List<ApiMessengerResponseModel> response = await client.MessengerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMessengerResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiMessengerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, TimeSpan.Parse("1"), 1, 1);
			CreateResponse<ApiMessengerResponseModel> result = await client.MessengerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d6a3d09a215d4f6e83e503761310b30f</Hash>
</Codenesium>*/