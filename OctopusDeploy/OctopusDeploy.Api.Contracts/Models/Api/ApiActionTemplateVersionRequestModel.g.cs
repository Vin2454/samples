using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateVersionRequestModel : AbstractApiRequestModel
        {
                public ApiActionTemplateVersionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string actionType,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
                        this.Name = name;
                        this.Version = version;
                }

                private string actionType;

                [Required]
                public string ActionType
                {
                        get
                        {
                                return this.actionType;
                        }

                        set
                        {
                                this.actionType = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string latestActionTemplateId;

                [Required]
                public string LatestActionTemplateId
                {
                        get
                        {
                                return this.latestActionTemplateId;
                        }

                        set
                        {
                                this.latestActionTemplateId = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int version;

                [Required]
                public int Version
                {
                        get
                        {
                                return this.version;
                        }

                        set
                        {
                                this.version = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>42f7eac57140f25ee1b71c78146cf9c6</Hash>
</Codenesium>*/