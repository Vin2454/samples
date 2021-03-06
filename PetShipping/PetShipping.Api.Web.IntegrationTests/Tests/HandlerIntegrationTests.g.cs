using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Handler")]
	[Trait("Area", "Integration")]
	public class HandlerIntegrationTests
	{
		public HandlerIntegrationTests()
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

			await client.HandlerDeleteAsync(1);

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

			ApiHandlerResponseModel model = await client.HandlerGetAsync(1);

			ApiHandlerModelMapper mapper = new ApiHandlerModelMapper();

			UpdateResponse<ApiHandlerResponseModel> updateResponse = await client.HandlerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiHandlerRequestModel();
			createModel.SetProperties(2, "B", "B", "B", "B");
			CreateResponse<ApiHandlerResponseModel> createResult = await client.HandlerCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiHandlerResponseModel getResponse = await client.HandlerGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.HandlerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiHandlerResponseModel verifyResponse = await client.HandlerGetAsync(2);

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
			ApiHandlerResponseModel response = await client.HandlerGetAsync(1);

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

			List<ApiHandlerResponseModel> response = await client.HandlerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiHandlerResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiHandlerRequestModel();
			model.SetProperties(2, "B", "B", "B", "B");
			CreateResponse<ApiHandlerResponseModel> result = await client.HandlerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>159c21bae65a437b1c6f366e44044faf</Hash>
</Codenesium>*/