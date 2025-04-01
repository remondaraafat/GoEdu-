using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class ExamQuestion
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual Exam? Exams { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question{ get; set; }
    }
}
