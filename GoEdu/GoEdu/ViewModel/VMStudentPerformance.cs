using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class VMStudentPerformance
    {
        [Display(Name = "معرّف الطالب")]
        public int StudentId { get; set; }

        [MaxLength(50, ErrorMessage = "يجب ألا يزيد الاسم عن 50 حرفًا")]
        [MinLength(2, ErrorMessage = "يجب ألا يقل الاسم عن حرفين")]
        [Display(Name = "اسم الطالب")]
        public string StudentName { get; set; }

        [Display(Name = "معرّف المحاضرة")]
        public int LectureID { get; set; }

        [StringLength(200, MinimumLength = 4, ErrorMessage = "يجب أن يكون العنوان بين 4 و 200 حرف")]
        [Display(Name = "عنوان المحاضرة")]
        public string LectureTitle { get; set; }
        public string CourseName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "وقت المحاضرة")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LectureTime { get; set; }

        [Range(0, 100, ErrorMessage = "يجب أن تكون الدرجة بين 0 و 100")]
        [Display(Name = "درجة الطالب")]
        public int Grade { get; set; }
    }

}
