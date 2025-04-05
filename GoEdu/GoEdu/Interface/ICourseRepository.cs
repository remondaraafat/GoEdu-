using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace GoEdu.Repositories
{
    public interface ICourseRepository : ICRUD<Course>
    {
        public List<CourseViewModel> GetAllcourses();
        public List<Course> FilterCourses(string? instructorName, string? NameOfCourse);
        //, string? specialization, string? sortBy

        public List<Course> search(string searchQuery);

        //david methods
        public List<Course> CoursesByInstructor(int instructorId);
    }
}
