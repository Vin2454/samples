using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepNoteResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int employeeId,
                        string note,
                        int pipelineStepId)
                {
                        this.Id = id;
                        this.EmployeeId = employeeId;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;

                        this.EmployeeIdEntity = nameof(ApiResponse.Employees);
                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

                public int EmployeeId { get; private set; }

                public string EmployeeIdEntity { get; set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeEmployeeIdValue { get; set; } = true;

                public bool ShouldSerializeEmployeeId()
                {
                        return this.ShouldSerializeEmployeeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNoteValue { get; set; } = true;

                public bool ShouldSerializeNote()
                {
                        return this.ShouldSerializeNoteValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

                public bool ShouldSerializePipelineStepId()
                {
                        return this.ShouldSerializePipelineStepIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEmployeeIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNoteValue = false;
                        this.ShouldSerializePipelineStepIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>6b3ec147ec3d3940219978efb02fc76a</Hash>
</Codenesium>*/