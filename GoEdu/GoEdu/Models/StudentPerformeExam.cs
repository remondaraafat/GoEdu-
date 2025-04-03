using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(StudentId), nameof(ExamId))]
    public class StudentPerformeExam: IDeleted
    {
        [Range(0,100)]
        public int Grade { get; set; }
        public bool Status {  get; set; }
        public bool isDeleted { get; set; }

        [ForeignKey("Student")]
        public int StudentId {  get; set; }

        [ForeignKey("Exam")]
        public int ExamId {  get; set; }

        public virtual Student? Student { get; set; }
        public virtual Exam? Exam { get; set; }
    }
}
