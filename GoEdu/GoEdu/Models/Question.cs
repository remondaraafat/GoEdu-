using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public enum QuestionType
    {
        TrueFalse,
        MCQ
    }
    public class Question: IDeleted
    {
        [Key]
        public int Id { get; set; }

        public QuestionType typeQuestion { get; set; }

        public string Content { get; set; }

        public int ModelAnswer {  get; set; }
        public bool isDeleted { get; set; }

        [ForeignKey("Lecture")]
        public int LectureId {  get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual List<ExamQuestion>? ExamQuestions { get; set; }
        public virtual List<Answer>? Answer { get; set; }

        public virtual List<Option>? Options { get; set; }

    }
}
