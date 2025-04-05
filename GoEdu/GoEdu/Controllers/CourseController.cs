using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        public CourseController(ICourseRepository crseRepo)
        {
            courseRepository = crseRepo;
        }

        public IActionResult Index(string searchQuery, string? instructorName,string? NameOfCourse)
        {
            var courses = courseRepository.GetAll();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courseRepository.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(instructorName))
            {
                courses = courseRepository.FilterCourses(instructorName, NameOfCourse);
            }
            return View("Index", courses);
        }

        public IActionResult Details(int id)
        {
            var Course = courseRepository.GetByID(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View("Details", Course);
        }
        public IActionResult GetAllWithIns()
        {
            var courses = courseRepository.GetAllcourses();
            return View("GetAllWithIns", courses);

        }
        //public IActionResult filtered(string? instructorName,)
        //{
        //    var filteredCourses = courseRepository.FilterCourses(instructorName);
        //    return View("filtered", filteredCourses);
        //}

    }
}
