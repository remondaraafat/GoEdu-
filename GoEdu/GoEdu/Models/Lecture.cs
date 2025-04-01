using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Lecture
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string VideoURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MaxViews { get; set; }
        public string? Description { get; set; }
        public int CourseID { get; set; }

        public virtual List<Attend>? Attend { get; set; }
        public virtual List<Comment>? Comment { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course? Course { get; set; }

    }
}
