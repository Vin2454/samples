using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonXStudent", Schema="dbo")]
	public partial class EFLessonXStudent: AbstractEntityFrameworkPOCO
	{
		public EFLessonXStudent()
		{}

		public void SetProperties(
			int id,
			int lessonId,
			int studentId)
		{
			this.Id = id.ToInt();
			this.LessonId = lessonId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lessonId", TypeName="int")]
		public int LessonId { get; set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; set; }

		[ForeignKey("LessonId")]
		public virtual EFLesson Lesson { get; set; }

		[ForeignKey("StudentId")]
		public virtual EFStudent Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>5843a6eca0fee8a9bb8fbd6aab7cb286</Hash>
</Codenesium>*/