using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(ExamId), nameof(QuestionId))]
    public class ExamQuestion: IDeleted
    {
        public bool isDeleted { get; set; } 
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        
        [ForeignKey("Question")]
        public int QuestionId { get; set; }



        public virtual Exam? Exam{ get; set; }
        public virtual Question? Question{ get; set; }
    }
}
