using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(ExamId), nameof(LectureId))]
    public class ExamPerLecture:IsDeleted
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }


        public virtual Exam? Exam { get; set; }
        public virtual Lecture? Lecture { get; set; }
    }
}
