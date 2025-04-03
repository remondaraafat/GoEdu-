using System.ComponentModel.DataAnnotations;

namespace GoEdu.Models
{
    public class Student: IDeleted
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Name Must be less than 50 char")]
        [MinLength(2, ErrorMessage = "Name Must be More than 2 char")]
        public string Name { get; set; }

        [RegularExpression(@"\w+\.(com)")]
        public string Email { get; set; }

        [Range(1, 100, ErrorMessage = "Invalid Age, must be positive Number or less than 100!")]
        public int Age { get; set; }
        public string? Address { get; set; }

        [RegularExpression(@"^\\+?[0-9][0-9]{7,14}$",ErrorMessage ="Invalid Phone Number")]
        public string StudentPhone { get; set; }

        [RegularExpression(@"^\\+?[0-9][0-9]{7,14}$", ErrorMessage = "Invalid Phone Number")]
        [Compare("StudentPhone")]
        public string ParentPhone { get; set; }
        public bool isDeleted { get; set; } = false;

        public virtual List<Register>? Register { get; set; }
        public virtual List<Attend>? Attend { get; set; }    
        public virtual List<Comment>? Comment { get; set; }
        public virtual List<Answer>? Answers { get; set; }
        public virtual List<StudentPerformeExam>? Exams { get; set; }
    }
   

}
