using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Comment:IsDeleted
    {
        public int ID { get; set; }
        public int LectureID { get; set; }
        public int StudentID { get; set; }
        public string? Content { get; set; }    
        public DateTime Date { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("LectureID")]
        public virtual Lecture? Lecture { get; set; }

    }
}
