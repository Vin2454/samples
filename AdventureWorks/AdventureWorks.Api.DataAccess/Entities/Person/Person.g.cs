using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Person", Schema="Person")]
	public partial class Person : AbstractEntity
	{
		public Person()
		{
		}

		public virtual void SetProperties(
			string additionalContactInfo,
			int businessEntityID,
			string demographic,
			int emailPromotion,
			string firstName,
			string lastName,
			string middleName,
			DateTime modifiedDate,
			bool nameStyle,
			string personType,
			Guid rowguid,
			string suffix,
			string title)
		{
			this.AdditionalContactInfo = additionalContactInfo;
			this.BusinessEntityID = businessEntityID;
			this.Demographic = demographic;
			this.EmailPromotion = emailPromotion;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate;
			this.NameStyle = nameStyle;
			this.PersonType = personType;
			this.Rowguid = rowguid;
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("AdditionalContactInfo")]
		public string AdditionalContactInfo { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[Column("Demographics")]
		public string Demographic { get; private set; }

		[Column("EmailPromotion")]
		public int EmailPromotion { get; private set; }

		[MaxLength(50)]
		[Column("FirstName")]
		public string FirstName { get; private set; }

		[MaxLength(50)]
		[Column("LastName")]
		public string LastName { get; private set; }

		[MaxLength(50)]
		[Column("MiddleName")]
		public string MiddleName { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("NameStyle")]
		public bool NameStyle { get; private set; }

		[MaxLength(2)]
		[Column("PersonType")]
		public string PersonType { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[MaxLength(10)]
		[Column("Suffix")]
		public string Suffix { get; private set; }

		[MaxLength(8)]
		[Column("Title")]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f56db013076b4884b4c04a101b319b3c</Hash>
</Codenesium>*/