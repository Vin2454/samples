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
	[Trait("Table", "Badge")]
	[Trait("Area", "Integration")]
	public class BadgeIntegrationTests
	{
		public BadgeIntegrationTests()
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

			await client.BadgeDeleteAsync(1);

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

			ApiBadgeResponseModel model = await client.BadgeGetAsync(1);

			ApiBadgeModelMapper mapper = new ApiBadgeModelMapper();

			UpdateResponse<ApiBadgeResponseModel> updateResponse = await client.BadgeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiBadgeRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiBadgeResponseModel> createResult = await client.BadgeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiBadgeResponseModel getResponse = await client.BadgeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.BadgeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiBadgeResponseModel verifyResponse = await client.BadgeGetAsync(2);

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
			ApiBadgeResponseModel response = await client.BadgeGetAsync(1);

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

			List<ApiBadgeResponseModel> response = await client.BadgeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBadgeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBadgeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2);
			CreateResponse<ApiBadgeResponseModel> result = await client.BadgeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>86a55cfc418ca088c9daa52dca1d8a67</Hash>
</Codenesium>*/