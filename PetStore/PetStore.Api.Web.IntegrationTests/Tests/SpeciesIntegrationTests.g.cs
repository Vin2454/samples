using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Species")]
	[Trait("Area", "Integration")]
	public class SpeciesIntegrationTests
	{
		public SpeciesIntegrationTests()
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

			await client.SpeciesDeleteAsync(1);

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

			ApiSpeciesResponseModel model = await client.SpeciesGetAsync(1);

			ApiSpeciesModelMapper mapper = new ApiSpeciesModelMapper();

			UpdateResponse<ApiSpeciesResponseModel> updateResponse = await client.SpeciesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiSpeciesRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiSpeciesResponseModel> createResult = await client.SpeciesCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiSpeciesResponseModel getResponse = await client.SpeciesGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.SpeciesDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiSpeciesResponseModel verifyResponse = await client.SpeciesGetAsync(2);

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
			ApiSpeciesResponseModel response = await client.SpeciesGetAsync(1);

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

			List<ApiSpeciesResponseModel> response = await client.SpeciesAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpeciesResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpeciesRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSpeciesResponseModel> result = await client.SpeciesCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>165a929406f420cf7abc6bcabf5fa476</Hash>
</Codenesium>*/