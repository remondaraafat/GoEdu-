using System.ComponentModel.DataAnnotations;

namespace GoEdu.Models
{
    public class Exam:IsDeleted
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

        public virtual List<Answer>? Answers { get; set; }
        public virtual List<Question>? Question { get; set; }
        public virtual List<StudentPerformeExam>? Students { get; set; }

        public virtual List<ExamPerLecture>? ExamPerLectures { get; set; }
    }
}
