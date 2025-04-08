using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoEdu.Interface;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Models
{
    [PrimaryKey(nameof(StudentId), nameof(LectureId))]
    public class StudentPerformance: IDeleted
    {
        [Range(0,100)]
        public int Grade { get; set; }
        public bool Status {  get; set; }
        public bool isDeleted { get; set; } = false;

        [ForeignKey("Student")]
        public int StudentId {  get; set; }

        [ForeignKey("Lecture")]
        public int LectureId {  get; set; }

        public virtual Student? Student { get; set; }
<<<<<<< HEAD:GoEdu/GoEdu/Models/StudentPerformance.cs
        public virtual Lecture? Lecture { get; set; }
=======
>>>>>>> origin/Tena:GoEdu/GoEdu/Models/StudentPerformeExam.cs
        public virtual Exams? Exam { get; set; }
    }
}
