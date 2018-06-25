using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventRelatedDocumentResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string eventId,
                        int id,
                        string relatedDocumentId)
                {
                        this.EventId = eventId;
                        this.Id = id;
                        this.RelatedDocumentId = relatedDocumentId;

                        this.EventIdEntity = nameof(ApiResponse.Events);
                }

                public string EventId { get; private set; }

                public string EventIdEntity { get; set; }

                public int Id { get; private set; }

                public string RelatedDocumentId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEventIdValue { get; set; } = true;

                public bool ShouldSerializeEventId()
                {
                        return this.ShouldSerializeEventIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentId()
                {
                        return this.ShouldSerializeRelatedDocumentIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEventIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeRelatedDocumentIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ea90350e81f6669bb032b2b30aec4189</Hash>
</Codenesium>*/