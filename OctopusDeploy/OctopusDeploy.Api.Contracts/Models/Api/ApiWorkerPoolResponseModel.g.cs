using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiWorkerPoolResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isDefault,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                public string Id { get; private set; }

                public bool IsDefault { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int SortOrder { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsDefaultValue { get; set; } = true;

                public bool ShouldSerializeIsDefault()
                {
                        return this.ShouldSerializeIsDefaultValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSortOrderValue { get; set; } = true;

                public bool ShouldSerializeSortOrder()
                {
                        return this.ShouldSerializeSortOrderValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsDefaultValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeSortOrderValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e15e215c0858517317e6b4e732a4ce2a</Hash>
</Codenesium>*/