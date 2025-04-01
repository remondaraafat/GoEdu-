namespace GoEdu.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public string? Address { get; set; }
        public string Phone { get; set; }

        public virtual List<Register>? Registers { get; set; }   
        public virtual List<Course>? Courses { get; set; }

    }
}
