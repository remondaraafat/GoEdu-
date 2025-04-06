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
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Title must be between 4-200 characters")]
        [Display(Name = "Lecture Title")]

        public string Title { get; set; }
        public string VideoURL { get; set; }
        public DateTime LectureTime { get; set; }
        public string? Description { get; set; }
        public bool isDeleted { get; set; } = false;
        public int CourseID { get; set; }
        //not fk => to know the exam of the lecture 
        public int ExamID { get; set; }
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

        [NotMapped] // لو بتستخدم Entity Framework
        public IFormFile? VideoFile { get; set; }
    }
}
