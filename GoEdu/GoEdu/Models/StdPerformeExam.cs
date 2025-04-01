using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class StdPerformeExam
    {
        [ForeignKey("Student")]
        public int StudentId {  get; set; }
        [ForeignKey("Exam")]
        public int ExamId {  get; set; }
        public virtual Student? Student { get; set; }
        public virtual Exam? Exam { get; set; }
    }
}
