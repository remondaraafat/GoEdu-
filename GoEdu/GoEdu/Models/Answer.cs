using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Answer
    {
        [Key]  
        public int Id { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
      
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public string? StudentAnswer { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
      
        [Required]
        public virtual Exam? Exam { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Question? Question { get; set; }
    }
}
