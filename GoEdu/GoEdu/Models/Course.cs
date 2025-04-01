using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Course:IsDeleted
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Course Name Must be less than 50 char")]
        [MinLength(2, ErrorMessage = "Course Name Must be More than 1 char")]
        public string Name { get; set; }

        public int CrsLevel { get; set; }
        public Semester Semester { get; set; }

        [Range(50, 10000, ErrorMessage = "Invalid Price")]
        public double Price { get; set; }

        [Range(1, 1000, ErrorMessage = "Invalid Hours, must be positive")]
        public int Hours { get; set; }

        public int InstructorID { get; set; }

        public virtual List<Lecture>? Lecture { get; set; }
        public virtual List<Register>? Register { get; set; }
      
        public virtual Instructor? Instructor { get; set; }

    }
    public enum Semester
    {
        First,
        Second,
    }
}


