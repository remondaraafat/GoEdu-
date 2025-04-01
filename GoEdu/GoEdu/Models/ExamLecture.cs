using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class ExamLecture
    {
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Lecture")]

        public int LectureId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
