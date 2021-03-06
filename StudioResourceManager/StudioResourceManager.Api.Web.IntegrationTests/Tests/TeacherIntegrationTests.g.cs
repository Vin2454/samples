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
	[Trait("Table", "Teacher")]
	[Trait("Area", "Integration")]
	public class TeacherIntegrationTests
	{
		public TeacherIntegrationTests()
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

			await client.TeacherDeleteAsync(1);

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

			ApiTeacherResponseModel model = await client.TeacherGetAsync(1);

			ApiTeacherModelMapper mapper = new ApiTeacherModelMapper();

			UpdateResponse<ApiTeacherResponseModel> updateResponse = await client.TeacherUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTeacherRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			CreateResponse<ApiTeacherResponseModel> createResult = await client.TeacherCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTeacherResponseModel getResponse = await client.TeacherGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TeacherDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTeacherResponseModel verifyResponse = await client.TeacherGetAsync(2);

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
			ApiTeacherResponseModel response = await client.TeacherGetAsync(1);

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

			List<ApiTeacherResponseModel> response = await client.TeacherAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeacherResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTeacherRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", 1);
			CreateResponse<ApiTeacherResponseModel> result = await client.TeacherCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a00dfdf6ba6164104bc9badc748c00b1</Hash>
</Codenesium>*/