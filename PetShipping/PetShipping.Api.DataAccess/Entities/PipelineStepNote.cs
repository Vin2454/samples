using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("PipelineStepNote", Schema="dbo")]
        public partial class PipelineStepNote: AbstractEntity
        {
                public PipelineStepNote()
                {
                }

                public void SetProperties(
                        int employeeId,
                        int id,
                        string note,
                        int pipelineStepId)
                {
                        this.EmployeeId = employeeId;
                        this.Id = id;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;
                }

                [Column("employeeId", TypeName="int")]
                public int EmployeeId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("note", TypeName="text(2147483647)")]
                public string Note { get; private set; }

                [Column("pipelineStepId", TypeName="int")]
                public int PipelineStepId { get; private set; }

                [ForeignKey("EmployeeId")]
                public virtual Employee Employee { get; set; }

                [ForeignKey("PipelineStepId")]
                public virtual PipelineStep PipelineStep { get; set; }
        }
}

/*<Codenesium>
    <Hash>f1f6a3d4fdf1a59b785fce008a3f468f</Hash>
</Codenesium>*/