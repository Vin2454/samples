using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonXTeacherResponseModel: AbstractApiResponseModel
        {
                public ApiLessonXTeacherResponseModel() : base()
                {
                }

                public void SetProperties(
                        int id,
                        int lessonId,
                        int studentId)
                {
                        this.Id = id;
                        this.LessonId = lessonId;
                        this.StudentId = studentId;

                        this.LessonIdEntity = nameof(ApiResponse.Lessons);
                        this.StudentIdEntity = nameof(ApiResponse.Students);
                }

                public int Id { get; private set; }

                public int LessonId { get; private set; }

                public string LessonIdEntity { get; set; }

                public int StudentId { get; private set; }

                public string StudentIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLessonIdValue { get; set; } = true;

                public bool ShouldSerializeLessonId()
                {
                        return this.ShouldSerializeLessonIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudentIdValue { get; set; } = true;

                public bool ShouldSerializeStudentId()
                {
                        return this.ShouldSerializeStudentIdValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLessonIdValue = false;
                        this.ShouldSerializeStudentIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c54d5357574bf9588fb9d79bcd151586</Hash>
</Codenesium>*/