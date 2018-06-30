using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "DALMapper")]
        public class TestDALSaleMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSaleMapper();
                        var bo = new BOSale();
                        bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        Sale response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.IpAddress.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.TransactionId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSaleMapper();
                        Sale entity = new Sale();
                        entity.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        BOSale response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.IpAddress.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.TransactionId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSaleMapper();
                        Sale entity = new Sale();
                        entity.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        List<BOSale> response = mapper.MapEFToBO(new List<Sale>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>22d6f79f6ec7a1fc136f6ba2ed244b35</Hash>
</Codenesium>*/