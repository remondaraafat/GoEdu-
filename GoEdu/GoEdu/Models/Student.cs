using System.ComponentModel.DataAnnotations;

namespace GoEdu.Models
{
    public class Student
    {
        public int ID { get; set; }

        [MaxLength(50, ErrorMessage = "Name Must be less than 50 char")]
        [MinLength(2, ErrorMessage = "Name Must be More than 1 char")]
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
        public Stage StudentStage { get; set; }
        public Level StudentLevel { get; set; }

        public virtual List<Register>? Register { get; set; }
        public virtual List<Attend>? Attend { get; set; }    
        public virtual List<Comment>? Comment { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<StdPerformeExam>? Exams { get; set; }
    }
    public enum Stage
    {
        Preparatory,
        Secondary,
    }

    public enum Level
    {
        First,
        Second,
        Third
    }


}
