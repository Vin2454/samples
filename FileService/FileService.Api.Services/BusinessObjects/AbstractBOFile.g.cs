using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractBOFile: AbstractBusinessObject
        {
                public AbstractBOFile() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  Nullable<int> bucketId,
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
                        this.Id = id;
                        this.Location = location;
                        this.PrivateKey = privateKey;
                        this.PublicKey = publicKey;
                }

                public Nullable<int> BucketId { get; private set; }

                public DateTime DateCreated { get; private set; }

                public string Description { get; private set; }

                public DateTime Expiration { get; private set; }

                public string Extension { get; private set; }

                public Guid ExternalId { get; private set; }

                public decimal FileSizeInBytes { get; private set; }

                public int FileTypeId { get; private set; }

                public int Id { get; private set; }

                public string Location { get; private set; }

                public string PrivateKey { get; private set; }

                public string PublicKey { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5c4f9eaa1696faaf9c56115df30b03aa</Hash>
</Codenesium>*/