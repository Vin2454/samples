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
	[Trait("Table", "PaymentType")]
	[Trait("Area", "Integration")]
	public class PaymentTypeIntegrationTests
	{
		public PaymentTypeIntegrationTests()
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

			await client.PaymentTypeDeleteAsync(1);

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

			ApiPaymentTypeResponseModel model = await client.PaymentTypeGetAsync(1);

			ApiPaymentTypeModelMapper mapper = new ApiPaymentTypeModelMapper();

			UpdateResponse<ApiPaymentTypeResponseModel> updateResponse = await client.PaymentTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPaymentTypeRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPaymentTypeResponseModel> createResult = await client.PaymentTypeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPaymentTypeResponseModel getResponse = await client.PaymentTypeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PaymentTypeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPaymentTypeResponseModel verifyResponse = await client.PaymentTypeGetAsync(2);

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
			ApiPaymentTypeResponseModel response = await client.PaymentTypeGetAsync(1);

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

			List<ApiPaymentTypeResponseModel> response = await client.PaymentTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPaymentTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPaymentTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPaymentTypeResponseModel> result = await client.PaymentTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>bfc181bdb67fa2d9c92d791b4537911e</Hash>
</Codenesium>*/