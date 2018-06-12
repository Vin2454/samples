using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentProcessResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public string Id { get; private set; }

                public bool IsFrozen { get; private set; }

                public string JSON { get; private set; }

                public string OwnerId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public int Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsFrozenValue { get; set; } = true;

                public bool ShouldSerializeIsFrozen()
                {
                        return this.ShouldSerializeIsFrozenValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOwnerIdValue { get; set; } = true;

                public bool ShouldSerializeOwnerId()
                {
                        return this.ShouldSerializeOwnerIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdsValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentIds()
                {
                        return this.ShouldSerializeRelatedDocumentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsFrozenValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeOwnerIdValue = false;
                        this.ShouldSerializeRelatedDocumentIdsValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e00e6ebe6a40f709c3610a70ed82603f</Hash>
</Codenesium>*/