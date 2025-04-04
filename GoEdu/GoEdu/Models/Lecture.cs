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

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Title must be between 5-200 characters")]
        [Display(Name = "Lecture Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Video URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]
        [Display(Name = "Video URL")]
        public string VideoURL { get; set; }

        [Required(ErrorMessage = "Lecture time is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Lecture Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LectureTime { get; set; }

        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Is Deleted")]
        public bool isDeleted { get; set; } = false;

        [Required(ErrorMessage = "Course ID is required")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        // Navigation properties
        [Display(Name = "Attendance Records")]
        public virtual List<Attend>? Attend { get; set; }

        [Display(Name = "Comments")]
        public virtual List<Comment>? Comment { get; set; }

        [Display(Name = "Questions")]
        public virtual List<Question>? Question { get; set; }

        [Display(Name = "Lecture Exams")]
        public virtual List<ExamLecture>? ExamLecture { get; set; }

        [ForeignKey("CourseID")]
        [Display(Name = "Associated Course")]
        public virtual Course? Course { get; set; }
    }
}
