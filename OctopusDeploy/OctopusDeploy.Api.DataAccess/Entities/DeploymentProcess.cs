using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DeploymentProcess", Schema="dbo")]
        public partial class DeploymentProcess: AbstractEntity
        {
                public DeploymentProcess()
                {
                }

                public void SetProperties(
                        string id,
                        bool isFrozen,
                        string jSON,
                        string ownerId,
                        string relatedDocumentIds,
                        int version)
                {
                        this.Id = id;
                        this.IsFrozen = isFrozen;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Version = version;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(150)")]
                public string Id { get; private set; }

                [Column("IsFrozen", TypeName="bit")]
                public bool IsFrozen { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("OwnerId", TypeName="nvarchar(150)")]
                public string OwnerId { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("Version", TypeName="int")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a3655b5079741523a90d14c54b78a22f</Hash>
</Codenesium>*/