using GoEdu.Models;
using GoEdu.ViewModel;

namespace GoEdu.Repositories
{
    public interface ILectureRepository : ICRUD<Lecture>
    {
        public List<Lecture> GetAllCourseLectures(int CourseID);
        public VMLectureDetails GetLectureVMByID(int id, int StudentID);


        public VMLectureWithInstructorCourses  GetLectureWithCourseList(int LectureId, int InstructorID);
    }
}
