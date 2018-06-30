using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Transaction")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTransactionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTransactionMapper();
                        ApiTransactionRequestModel model = new ApiTransactionRequestModel();
                        model.SetProperties(1, "A", 1);
                        BOTransaction response = mapper.MapModelToBO(1, model);

                        response.Amount.Should().Be(1);
                        response.GatewayConfirmationNumber.Should().Be("A");
                        response.TransactionStatusId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTransactionMapper();
                        BOTransaction bo = new BOTransaction();
                        bo.SetProperties(1, 1, "A", 1);
                        ApiTransactionResponseModel response = mapper.MapBOToModel(bo);

                        response.Amount.Should().Be(1);
                        response.GatewayConfirmationNumber.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.TransactionStatusId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTransactionMapper();
                        BOTransaction bo = new BOTransaction();
                        bo.SetProperties(1, 1, "A", 1);
                        List<ApiTransactionResponseModel> response = mapper.MapBOToModel(new List<BOTransaction>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e93dea2120d37243aadcb6997f02e0f7</Hash>
</Codenesium>*/