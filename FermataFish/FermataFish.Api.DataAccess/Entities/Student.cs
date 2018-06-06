using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class Student: AbstractEntity
	{
		public Student()
		{}

		public void SetProperties(
			DateTime birthday,
			string email,
			bool emailRemindersEnabled,
			int familyId,
			string firstName,
			int id,
			bool isAdult,
			string lastName,
			string phone,
			bool smsRemindersEnabled,
			int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
			this.FamilyId = familyId.ToInt();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.StudioId = studioId.ToInt();
		}

		[Column("birthday", TypeName="date")]
		public DateTime Birthday { get; private set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; private set; }

		[Column("emailRemindersEnabled", TypeName="bit")]
		public bool EmailRemindersEnabled { get; private set; }

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; private set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("isAdult", TypeName="bit")]
		public bool IsAdult { get; private set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; private set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; private set; }

		[Column("smsRemindersEnabled", TypeName="bit")]
		public bool SmsRemindersEnabled { get; private set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; private set; }

		[ForeignKey("FamilyId")]
		public virtual Family Family { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>c6126a82d393b473aaca70a9e42d4737</Hash>
</Codenesium>*/