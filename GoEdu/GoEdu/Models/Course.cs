﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GoEdu.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CrsLevel { get; set; }
        public string Semester { get; set; }
        public double Price { get; set; }
        public int Hours { get; set; }
        public int InstructorID { get; set; }

        public virtual List<Lecture>? Lecture { get; set; }
        public virtual List<Register>? Register { get; set; }
        [ForeignKey("InsID")]
        public virtual Instructor? Instructor { get; set; }

    }
}


