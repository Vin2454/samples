using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VoteTypes")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiVoteTypesRequestModelValidatorTest
        {
                public ApiVoteTypesRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IVoteTypesRepository> voteTypesRepository = new Mock<IVoteTypesRepository>();
                        voteTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));

                        var validator = new ApiVoteTypesRequestModelValidator(voteTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiVoteTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IVoteTypesRepository> voteTypesRepository = new Mock<IVoteTypesRepository>();
                        voteTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));

                        var validator = new ApiVoteTypesRequestModelValidator(voteTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiVoteTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IVoteTypesRepository> voteTypesRepository = new Mock<IVoteTypesRepository>();
                        voteTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));

                        var validator = new ApiVoteTypesRequestModelValidator(voteTypesRepository.Object);
                        await validator.ValidateCreateAsync(new ApiVoteTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IVoteTypesRepository> voteTypesRepository = new Mock<IVoteTypesRepository>();
                        voteTypesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new VoteTypes()));

                        var validator = new ApiVoteTypesRequestModelValidator(voteTypesRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiVoteTypesRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }
        }
}

/*<Codenesium>
    <Hash>408b9a5cbf0f944297998e7ff7e6e371</Hash>
</Codenesium>*/