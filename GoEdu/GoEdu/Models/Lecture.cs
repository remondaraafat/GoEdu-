using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;

namespace GoEdu.Models
{
    public class Lecture: IDeleted
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string VideoURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
        public bool isDeleted { get; set; } = false;
        public int CourseID { get; set; }

        public virtual List<Attend>? Attend { get; set; }
        public virtual List<Comment>? Comment { get; set; }
        public virtual List<Question>? Question { get; set; }
        public virtual List<ExamLecture>? ExamLecture { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course? Course { get; set; }

    }
}
