using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Studio")]
	[Trait("Area", "Integration")]
	public class StudioIntegrationTests
	{
		public StudioIntegrationTests()
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

			await client.StudioDeleteAsync(1);

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

			ApiStudioResponseModel model = await client.StudioGetAsync(1);

			ApiStudioModelMapper mapper = new ApiStudioModelMapper();

			UpdateResponse<ApiStudioResponseModel> updateResponse = await client.StudioUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiStudioRequestModel();
			createModel.SetProperties("B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiStudioResponseModel> createResult = await client.StudioCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiStudioResponseModel getResponse = await client.StudioGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.StudioDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiStudioResponseModel verifyResponse = await client.StudioGetAsync(2);

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
			ApiStudioResponseModel response = await client.StudioGetAsync(1);

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

			List<ApiStudioResponseModel> response = await client.StudioAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStudioResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiStudioRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiStudioResponseModel> result = await client.StudioCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>34db62951efaa62b42aed2f78ed9c8db</Hash>
</Codenesium>*/