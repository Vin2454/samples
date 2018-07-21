using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
        [Table("Bucket", Schema="dbo")]
        public partial class Bucket : AbstractEntity
        {
                public Bucket()
                {
                }

                public virtual void SetProperties(
                        Guid externalId,
                        int id,
                        string name)
                {
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                }

                [Column("externalId")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9759598ade845215bfbe8031d856afa6</Hash>
</Codenesium>*/