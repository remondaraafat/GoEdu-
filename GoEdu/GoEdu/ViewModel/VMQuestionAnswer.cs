using GoEdu.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Extensions.Options;

    public class VMQuestionAnswer
    {
        [Required(ErrorMessage = "معرّف السؤال مطلوب")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "معرّف الطالب مطلوب")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "معرّف المحاضرة مطلوب")]
        public int LectureId { get; set; }

        [Display(Name = "محتوى السؤال")]
        public string? Content { get; set; }

        [Display(Name = "الإجابة النموذجية")]
        public string? ModelAnswer { get; set; }

        [Display(Name = "إجابة الطالب")]
        public string? StudentAnswer { get; set; }
        public List<Option>? options { get; set; }
    }

}
