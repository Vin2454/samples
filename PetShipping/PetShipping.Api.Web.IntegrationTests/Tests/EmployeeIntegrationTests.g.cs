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
	[Trait("Table", "Employee")]
	[Trait("Area", "Integration")]
	public class EmployeeIntegrationTests
	{
		public EmployeeIntegrationTests()
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

			await client.EmployeeDeleteAsync(1);

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

			ApiEmployeeResponseModel model = await client.EmployeeGetAsync(1);

			ApiEmployeeModelMapper mapper = new ApiEmployeeModelMapper();

			UpdateResponse<ApiEmployeeResponseModel> updateResponse = await client.EmployeeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiEmployeeRequestModel();
			createModel.SetProperties("B", true, true, "B");
			CreateResponse<ApiEmployeeResponseModel> createResult = await client.EmployeeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiEmployeeResponseModel getResponse = await client.EmployeeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.EmployeeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiEmployeeResponseModel verifyResponse = await client.EmployeeGetAsync(2);

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
			ApiEmployeeResponseModel response = await client.EmployeeGetAsync(1);

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

			List<ApiEmployeeResponseModel> response = await client.EmployeeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEmployeeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEmployeeRequestModel();
			model.SetProperties("B", true, true, "B");
			CreateResponse<ApiEmployeeResponseModel> result = await client.EmployeeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d22d080590623a83dda9dca11f0ac8b5</Hash>
</Codenesium>*/