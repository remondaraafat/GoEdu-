using GoEdu.Models;

namespace GoEdu.Repositories
{
    public interface IStudentPerformanceRepository:ICRUD<StudentPerformance>
    {
        public StudentPerformance GetBy2IDs(int studentID, int LectureID)
    }
}
