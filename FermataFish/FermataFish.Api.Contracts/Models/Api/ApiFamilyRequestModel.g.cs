using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiFamilyRequestModel : AbstractApiRequestModel
        {
                public ApiFamilyRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string notes,
                        string pcEmail,
                        string pcFirstName,
                        string pcLastName,
                        string pcPhone,
                        int studioId)
                {
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;
                }

                private string notes;

                [Required]
                public string Notes
                {
                        get
                        {
                                return this.notes;
                        }

                        set
                        {
                                this.notes = value;
                        }
                }

                private string pcEmail;

                [Required]
                public string PcEmail
                {
                        get
                        {
                                return this.pcEmail;
                        }

                        set
                        {
                                this.pcEmail = value;
                        }
                }

                private string pcFirstName;

                [Required]
                public string PcFirstName
                {
                        get
                        {
                                return this.pcFirstName;
                        }

                        set
                        {
                                this.pcFirstName = value;
                        }
                }

                private string pcLastName;

                [Required]
                public string PcLastName
                {
                        get
                        {
                                return this.pcLastName;
                        }

                        set
                        {
                                this.pcLastName = value;
                        }
                }

                private string pcPhone;

                [Required]
                public string PcPhone
                {
                        get
                        {
                                return this.pcPhone;
                        }

                        set
                        {
                                this.pcPhone = value;
                        }
                }

                private int studioId;

                [Required]
                public int StudioId
                {
                        get
                        {
                                return this.studioId;
                        }

                        set
                        {
                                this.studioId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a130811efe8c92675e94a87f55a6698d</Hash>
</Codenesium>*/