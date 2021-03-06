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
	[Trait("Table", "Airline")]
	[Trait("Area", "Integration")]
	public class AirlineIntegrationTests
	{
		public AirlineIntegrationTests()
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

			await client.AirlineDeleteAsync(1);

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

			ApiAirlineResponseModel model = await client.AirlineGetAsync(1);

			ApiAirlineModelMapper mapper = new ApiAirlineModelMapper();

			UpdateResponse<ApiAirlineResponseModel> updateResponse = await client.AirlineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiAirlineRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiAirlineResponseModel> createResult = await client.AirlineCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiAirlineResponseModel getResponse = await client.AirlineGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.AirlineDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiAirlineResponseModel verifyResponse = await client.AirlineGetAsync(2);

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
			ApiAirlineResponseModel response = await client.AirlineGetAsync(1);

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

			List<ApiAirlineResponseModel> response = await client.AirlineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAirlineResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiAirlineRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiAirlineResponseModel> result = await client.AirlineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>1826b86a52ccfb389ad2d4b64a17b661</Hash>
</Codenesium>*/