using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiWorkerTaskLeaseRequestModelValidatorTest
        {
                public ApiWorkerTaskLeaseRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void TaskId_Create_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Update_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, null as string);
                }

                [Fact]
                public async void TaskId_Create_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void TaskId_Update_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TaskId, new string('A', 51));
                }

                [Fact]
                public async void WorkerId_Create_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WorkerId, null as string);
                }

                [Fact]
                public async void WorkerId_Update_null()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WorkerId, null as string);
                }

                [Fact]
                public async void WorkerId_Create_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateCreateAsync(new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WorkerId, new string('A', 51));
                }

                [Fact]
                public async void WorkerId_Update_length()
                {
                        Mock<IWorkerTaskLeaseRepository> workerTaskLeaseRepository = new Mock<IWorkerTaskLeaseRepository>();
                        workerTaskLeaseRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new WorkerTaskLease()));

                        var validator = new ApiWorkerTaskLeaseRequestModelValidator(workerTaskLeaseRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiWorkerTaskLeaseRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WorkerId, new string('A', 51));
                }
        }
}

/*<Codenesium>
    <Hash>43efc66b1240e472ec87a2001c8cf681</Hash>
</Codenesium>*/