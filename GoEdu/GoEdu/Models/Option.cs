using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Question")]
        public int QuestionId {  get; set; }
        [InverseProperty("Options")]
        public Question? Question { get; set; }    
    }
}
