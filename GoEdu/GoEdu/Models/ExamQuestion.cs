using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class ExamQuestion
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }



        public virtual Exam? Exam{ get; set; }
        public virtual Question? Question{ get; set; }
    }
}
