﻿using GoEdu.Models;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Data
{
    public class GoEduContext : DbContext
    {
        public GoEduContext(DbContextOptions<GoEduContext> opt) : base(opt) { }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> lectures { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamLecture> ExamLectures { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<StudentPerformeExam> StudentPerformeExams { get; set; }

        public DbSet<Option> Options { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }


    }
}
