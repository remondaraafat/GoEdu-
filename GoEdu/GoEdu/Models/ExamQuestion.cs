using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(ExamId), nameof(QuestionId))]
    public class ExamQuestion:IsDeleted
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }



        public virtual Exam? Exam{ get; set; }
        public virtual Question? Question{ get; set; }
    }
}
