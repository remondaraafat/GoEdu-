using GoEdu.Models;
using GoEdu.Data;
namespace GoEdu.Repositories
{
    public class StudentPerformanceRepository : IStudentPerformanceRepository
    {
        private readonly GoEduContext context;

        public StudentPerformanceRepository(GoEduContext context)
        {
            this.context = context;
        }
        public StudentPerformance GetBy2IDs(int studentID,int LectureID)
        {
            return context.StudentPerformances.FirstOrDefault(s=>s.StudentId==studentID && s.LectureId==LectureID);
        }
        public void Delete(StudentPerformance Entity)
        {
            throw new NotImplementedException();
        }

        public List<StudentPerformance> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentPerformance GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(StudentPerformance Entity)
        {
            context.StudentPerformances.Add(Entity);
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, StudentPerformance Entity)
        {
            throw new NotImplementedException();
        }
    }
}
