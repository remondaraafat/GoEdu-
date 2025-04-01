namespace GoEdu.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string StdPhone { get; set; }
        public string ParentPhone { get; set; }
        public int StdLevel { get; set; }

        public virtual List<Register>? Register { get; set; }
        public virtual List<Attend>? Attend { get; set; }    
        public virtual List<Comment>? Comment { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<StdPerformeExam>? Exams { get; set; }
    }
}
