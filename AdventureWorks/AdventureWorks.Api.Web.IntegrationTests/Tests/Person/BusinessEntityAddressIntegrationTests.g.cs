using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "BusinessEntityAddress")]
	[Trait("Area", "Integration")]
	public class BusinessEntityAddressIntegrationTests
	{
		public BusinessEntityAddressIntegrationTests()
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

			await client.BusinessEntityAddressDeleteAsync(1);

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

			ApiBusinessEntityAddressResponseModel model = await client.BusinessEntityAddressGetAsync(1);

			ApiBusinessEntityAddressModelMapper mapper = new ApiBusinessEntityAddressModelMapper();

			UpdateResponse<ApiBusinessEntityAddressResponseModel> updateResponse = await client.BusinessEntityAddressUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiBusinessEntityAddressResponseModel response = await client.BusinessEntityAddressGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.BusinessEntityAddressDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.BusinessEntityAddressGetAsync(1);

			response.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiBusinessEntityAddressResponseModel response = await client.BusinessEntityAddressGetAsync(1);

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

			List<ApiBusinessEntityAddressResponseModel> response = await client.BusinessEntityAddressAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBusinessEntityAddressResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBusinessEntityAddressRequestModel();
			model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiBusinessEntityAddressResponseModel> result = await client.BusinessEntityAddressCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>14f3854dd6b8e7041d2f47ed1b04148c</Hash>
</Codenesium>*/