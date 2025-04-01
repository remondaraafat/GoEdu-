using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Register
    {
        public int StdID { get; set; }
        public int CrsID { get; set; }
        public int InsID {  get; set; }

        public DateTime Data { get; set; }
        public string? Status { get; set; }

        [ForeignKey("StdID")]
        public virtual Student? Student { get; set; }

        [ForeignKey("CrsID")]
        public virtual Course? Course { get; set; }

        [ForeignKey("InsID")]
        public virtual Instructor? Instructor { get; set; }


    }
}
