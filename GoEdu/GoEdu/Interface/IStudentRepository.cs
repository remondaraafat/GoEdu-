using GoEdu.Models;

namespace GoEdu.Repositories
{
    public interface IStudentRepository : ICRUD<Student>
    {
        public List<Student> GetStudentsByInstructor(int instructorId);
        public List<Student> GetStudentsByCourse(int instructorId);
    }
}
