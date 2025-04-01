using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> lectures { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamPerLecture> ExamLectures {  get; set; }   
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }
        
        public DbSet<StudentPerformeExam> StudentPerformeExams { get; set; }
        
        public DbSet<Option> Options { get; set; }
        public DbSet<ExamQuestion> ExamQuestions {  get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Education_System;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

    }
}
