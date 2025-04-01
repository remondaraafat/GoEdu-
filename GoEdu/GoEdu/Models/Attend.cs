using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Attend
    {
        public int StdID { get; set; }
        public int LectID { get; set; }
        public string? ViewsCount { get; set; }

        [ForeignKey("StdID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("LectID")]
        public virtual Lecture? Lecture { get; set; }



    }
}
