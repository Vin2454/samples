using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiFileRequestModel : AbstractApiRequestModel
        {
                public ApiFileRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int? bucketId,
                        DateTime dateCreated,
                        string description,
                        DateTime expiration,
                        string extension,
                        Guid externalId,
                        decimal fileSizeInBytes,
                        int fileTypeId,
                        string location,
                        string privateKey,
                        string publicKey)
                {
                        this.BucketId = bucketId;
                        this.DateCreated = dateCreated;
                        this.Description = description;
                        this.Expiration = expiration;
                        this.Extension = extension;
                        this.ExternalId = externalId;
                        this.FileSizeInBytes = fileSizeInBytes;
                        this.FileTypeId = fileTypeId;
                        this.Location = location;
                        this.PrivateKey = privateKey;
                        this.PublicKey = publicKey;
                }

                private int? bucketId;

                public int? BucketId
                {
                        get
                        {
                                return this.bucketId;
                        }

                        set
                        {
                                this.bucketId = value;
                        }
                }

                private DateTime dateCreated;

                [Required]
                public DateTime DateCreated
                {
                        get
                        {
                                return this.dateCreated;
                        }

                        set
                        {
                                this.dateCreated = value;
                        }
                }

                private string description;

                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private DateTime expiration;

                [Required]
                public DateTime Expiration
                {
                        get
                        {
                                return this.expiration;
                        }

                        set
                        {
                                this.expiration = value;
                        }
                }

                private string extension;

                [Required]
                public string Extension
                {
                        get
                        {
                                return this.extension;
                        }

                        set
                        {
                                this.extension = value;
                        }
                }

                private Guid externalId;

                [Required]
                public Guid ExternalId
                {
                        get
                        {
                                return this.externalId;
                        }

                        set
                        {
                                this.externalId = value;
                        }
                }

                private decimal fileSizeInBytes;

                [Required]
                public decimal FileSizeInBytes
                {
                        get
                        {
                                return this.fileSizeInBytes;
                        }

                        set
                        {
                                this.fileSizeInBytes = value;
                        }
                }

                private int fileTypeId;

                [Required]
                public int FileTypeId
                {
                        get
                        {
                                return this.fileTypeId;
                        }

                        set
                        {
                                this.fileTypeId = value;
                        }
                }

                private string location;

                [Required]
                public string Location
                {
                        get
                        {
                                return this.location;
                        }

                        set
                        {
                                this.location = value;
                        }
                }

                private string privateKey;

                [Required]
                public string PrivateKey
                {
                        get
                        {
                                return this.privateKey;
                        }

                        set
                        {
                                this.privateKey = value;
                        }
                }

                private string publicKey;

                [Required]
                public string PublicKey
                {
                        get
                        {
                                return this.publicKey;
                        }

                        set
                        {
                                this.publicKey = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>12c887951654ab75a4a4ea2db79b37cf</Hash>
</Codenesium>*/