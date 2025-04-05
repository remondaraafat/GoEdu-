using GoEdu.Models;
using GoEdu.ViewModel;

namespace GoEdu.Repositories
{
    public interface ILectureRepository : ICRUD<Lecture>
    {
        public List<Lecture> GetAllCourseLectures(int CourseID);
        public LectureDetailsVM GetLectureVMByID(int id, int StudentID);


        public LectureWithInstructorCoursesVM  GetLectureWithCourseList(int LectureId, int InstructorID);
    }
}
