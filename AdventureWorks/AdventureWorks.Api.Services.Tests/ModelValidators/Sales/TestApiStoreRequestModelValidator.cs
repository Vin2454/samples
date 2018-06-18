using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Store")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiStoreRequestModelValidatorTest
        {
                public ApiStoreRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Store()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void SalesPersonID_Create_Valid_Reference()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStoreRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Create_Invalid_Reference()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateCreateAsync(new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Update_Valid_Reference()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStoreRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Update_Invalid_Reference()
                {
                        Mock<IStoreRepository> storeRepository = new Mock<IStoreRepository>();
                        storeRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

                        var validator = new ApiStoreRequestModelValidator(storeRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiStoreRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>3b09f1901a68b5ab4a879c13d1920d2e</Hash>
</Codenesium>*/