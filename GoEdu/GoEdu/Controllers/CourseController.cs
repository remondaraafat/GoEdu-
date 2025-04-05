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

        public IActionResult Index(string searchQuery, string? filterBy, string? NameOfCourse)
        {
            var courses = courseRepository.GetAll();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courseRepository.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(filterBy)&&!string.IsNullOrEmpty(NameOfCourse))
            {
                courses = courseRepository.FilterCourses(filterBy, NameOfCourse);
            }
            //if (!string.IsNullOrEmpty(NameOfCourse))
            //{
            //    courses = courses.Where(c => c.Name.Contains(NameOfCourse, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
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

        public IActionResult CourseDetails(int id)
        {
            var courseDetails= courseRepository.GetCourseWithLectures(id);
            if (courseDetails == null)
            {
                return NotFound("Course not found");
            }
            Console.WriteLine("✅ Course Found: " + courseDetails.CourseName);
           // return Content("Course ID is: " + id);
           return View("CourseDetails", courseDetails);
        }

    }
}
