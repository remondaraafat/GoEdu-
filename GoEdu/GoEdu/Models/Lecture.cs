using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;
using System.ComponentModel.DataAnnotations;



namespace GoEdu.Models
{

    public class Lecture : IDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

<<<<<<< HEAD

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Title must be between 4-200 characters")]
        [Display(Name = "Lecture Title")]

        public string Title { get; set; }
        public string VideoURL { get; set; }
        public DateTime LectureTime { get; set; }
        public string? Description { get; set; }
        public bool isDeleted { get; set; } = false;
=======
        [Required(ErrorMessage = "عنوان المحاضرة مطلوب")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "يجب أن يكون العنوان بين 4 و 200 حرف")]
        [Display(Name = "عنوان المحاضرة")]
        public string Title { get; set; }

        [Required(ErrorMessage = "رابط الفيديو مطلوب")]
        [Url(ErrorMessage = "صيغة الرابط غير صحيحة")]
        [StringLength(500, ErrorMessage = "لا يمكن أن يتجاوز الرابط 500 حرف")]
        [Display(Name = "رابط الفيديو")]
        public string VideoURL { get; set; }

        [Required(ErrorMessage = "وقت المحاضرة مطلوب")]
        [DataType(DataType.DateTime)]
        [Display(Name = "وقت المحاضرة")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LectureTime { get; set; }

        [StringLength(2000, ErrorMessage = "لا يمكن أن يتجاوز الوصف 2000 حرف")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "الوصف")]
        public string? Description { get; set; }

        [Display(Name = "تم الحذف")]
        public bool isDeleted { get; set; } = false;

        [Required(ErrorMessage = "رقم المعرف الخاص بالمقرر مطلوب")]
        [Display(Name = "معرف المقرر")]
>>>>>>> origin/main
        public int CourseID { get; set; }

        //  تم حذفه لاننا هنخلى الطالب يحل كل الاساله اللى على الحصه ك واجب
        public int ExamID { get; set; }

        // خصائص التنقل
        [Display(Name = "سجلات الحضور")]
        public virtual List<Attend>? Attend { get; set; }

        [Display(Name = "التعليقات")]
        public virtual List<Comment>? Comment { get; set; }

        [Display(Name = "الأسئلة")]
        public virtual List<Question>? Question { get; set; }

        [Display(Name = "اختبارات المحاضرة")]
        public virtual List<ExamLecture>? ExamLecture { get; set; }

        [ForeignKey("CourseID")]
        [Display(Name = "المقرر المرتبط")]
        public virtual Course? Course { get; set; }

        [NotMapped] // لو بتستخدم Entity Framework
        public IFormFile? VideoFile { get; set; }
    }

}
