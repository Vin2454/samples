using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Admin")]
	[Trait("Area", "Integration")]
	public class AdminIntegrationTests
	{
		public AdminIntegrationTests()
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

			await client.AdminDeleteAsync(1);

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

			ApiAdminResponseModel model = await client.AdminGetAsync(1);

			ApiAdminModelMapper mapper = new ApiAdminModelMapper();

			UpdateResponse<ApiAdminResponseModel> updateResponse = await client.AdminUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiAdminRequestModel();
			createModel.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAdminResponseModel> createResult = await client.AdminCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiAdminResponseModel getResponse = await client.AdminGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.AdminDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiAdminResponseModel verifyResponse = await client.AdminGetAsync(2);

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
			ApiAdminResponseModel response = await client.AdminGetAsync(1);

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

			List<ApiAdminResponseModel> response = await client.AdminAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAdminResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiAdminRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAdminResponseModel> result = await client.AdminCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>2b067bce0486bcb8cdd7bd47292ef27e</Hash>
</Codenesium>*/