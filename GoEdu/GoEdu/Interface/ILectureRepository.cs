using GoEdu.Models;

namespace GoEdu.Repositories
{
    public interface ILectureRepository : ICRUD<Lecture>
    {
        public List<Lecture> GetAllCourseLectures(int CourseID);
    }
}
