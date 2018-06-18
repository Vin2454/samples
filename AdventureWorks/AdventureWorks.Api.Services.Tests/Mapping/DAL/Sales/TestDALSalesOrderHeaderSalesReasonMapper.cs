using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderHeaderSalesReason")]
        [Trait("Area", "DALMapper")]
        public class TestDALSalesOrderHeaderSalesReasonActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();

                        var bo = new BOSalesOrderHeaderSalesReason();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        SalesOrderHeaderSalesReason response = mapper.MapBOToEF(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        BOSalesOrderHeaderSalesReason  response = mapper.MapEFToBO(entity);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();

                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        List<BOSalesOrderHeaderSalesReason> response = mapper.MapEFToBO(new List<SalesOrderHeaderSalesReason>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bb900047e45d63d7da1457cdc17f6ec3</Hash>
</Codenesium>*/