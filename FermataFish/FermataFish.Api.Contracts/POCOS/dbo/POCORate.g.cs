using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCORate
	{
		public POCORate()
		{}

		public POCORate(
			decimal amountPerMinute,
			int id,
			int teacherId,
			int teacherSkillId)
		{
			this.AmountPerMinute = amountPerMinute.ToDecimal();
			this.Id = id.ToInt();

			this.TeacherId = new ReferenceEntity<int>(teacherId,
			                                          nameof(ApiResponse.Teachers));
			this.TeacherSkillId = new ReferenceEntity<int>(teacherSkillId,
			                                               nameof(ApiResponse.TeacherSkills));
		}

		public decimal AmountPerMinute { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> TeacherId { get; set; }
		public ReferenceEntity<int> TeacherSkillId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAmountPerMinuteValue { get; set; } = true;

		public bool ShouldSerializeAmountPerMinute()
		{
			return this.ShouldSerializeAmountPerMinuteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherId()
		{
			return this.ShouldSerializeTeacherIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillIdValue { get; set; } = true;

		public bool ShouldSerializeTeacherSkillId()
		{
			return this.ShouldSerializeTeacherSkillIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAmountPerMinuteValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeTeacherIdValue = false;
			this.ShouldSerializeTeacherSkillIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>074c33340e05dd95e7ef66c13c712ddb</Hash>
</Codenesium>*/