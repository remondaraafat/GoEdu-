using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;

namespace GoEdu.Models
{
    public class Exams: IDeleted
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        public string ExamType { get; set; }
        [Range(10, 150)]
        public int TrueFalseCount { get; set; }
        [Range(10, 150)]
        public int MCQCount {  get; set; }
        public bool isDeleted { get; set; } = false;
        [ForeignKey("Course")]
        public int CourseId {  get; set; }
        public virtual List<Answer>? Answers { get; set; }
        public virtual List<Question>? Question { get; set; }
        public virtual List<StudentPerformeExam>? Students { get; set; }

        public virtual List<ExamLecture>? ExamLectures { get; set; }
    }
}
