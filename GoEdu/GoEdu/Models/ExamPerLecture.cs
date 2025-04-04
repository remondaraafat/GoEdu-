using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(ExamId), nameof(LectureId))]
    public class ExamPerLecture: IDeleted
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        public bool isDeleted { get; set; } = false;

        public virtual Exam? Exam { get; set; }
        public virtual Lecture? Lecture { get; set; }
    }
}
