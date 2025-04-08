using GoEdu.Models;

namespace GoEdu.Repositories
{
    public interface IExamRepository:ICRUD<Exams>
    {
        public Exams GenerateExamForCourse(int id);
    }
}
