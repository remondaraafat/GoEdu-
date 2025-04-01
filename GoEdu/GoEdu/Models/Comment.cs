using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int LectID { get; set; }
        public int StdID { get; set; }
        public string? Content { get; set; }    
        public DateTime Date { get; set; }

        [ForeignKey("StdID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("LectID")]
        public virtual Lecture? Lecture { get; set; }

    }
}
