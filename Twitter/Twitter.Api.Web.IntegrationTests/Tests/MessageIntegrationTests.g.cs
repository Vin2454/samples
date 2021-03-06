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
	[Trait("Table", "Message")]
	[Trait("Area", "Integration")]
	public class MessageIntegrationTests
	{
		public MessageIntegrationTests()
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

			await client.MessageDeleteAsync(1);

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

			ApiMessageResponseModel model = await client.MessageGetAsync(1);

			ApiMessageModelMapper mapper = new ApiMessageModelMapper();

			UpdateResponse<ApiMessageResponseModel> updateResponse = await client.MessageUpdateAsync(model.MessageId, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiMessageRequestModel();
			createModel.SetProperties("B", 1);
			CreateResponse<ApiMessageResponseModel> createResult = await client.MessageCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiMessageResponseModel getResponse = await client.MessageGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.MessageDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiMessageResponseModel verifyResponse = await client.MessageGetAsync(2);

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
			ApiMessageResponseModel response = await client.MessageGetAsync(1);

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

			List<ApiMessageResponseModel> response = await client.MessageAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMessageResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiMessageRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiMessageResponseModel> result = await client.MessageCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d6d530eca988b80cb9ccb3b6d2a37793</Hash>
</Codenesium>*/