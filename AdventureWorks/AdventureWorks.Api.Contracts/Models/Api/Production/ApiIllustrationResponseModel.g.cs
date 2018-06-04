using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationResponseModel: AbstractApiResponseModel
	{
		public ApiIllustrationResponseModel() : base()
		{}

		public void SetProperties(
			string diagram,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string Diagram { get; private set; }
		public int IllustrationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeDiagramValue { get; set; } = true;

		public bool ShouldSerializeDiagram()
		{
			return this.ShouldSerializeDiagramValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIllustrationIDValue { get; set; } = true;

		public bool ShouldSerializeIllustrationID()
		{
			return this.ShouldSerializeIllustrationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDiagramValue = false;
			this.ShouldSerializeIllustrationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>eadad52a406c6feaeb628e680c7cf545</Hash>
</Codenesium>*/