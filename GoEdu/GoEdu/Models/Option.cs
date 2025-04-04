using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;

namespace GoEdu.Models
{
    public class Option: IDeleted
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool isDeleted { get; set; } = false;
        [ForeignKey("Question")]
        public int QuestionId {  get; set; }
        [InverseProperty("Options")]
        public Question? Question { get; set; }    
    }
}
