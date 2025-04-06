using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
using GoEdu.Models;
namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        public CourseController(ICourseRepository crseRepo)
        {
            courseRepository = crseRepo;
        }

        public IActionResult Index(string searchQuery, string? filterBy, string? nameAccourdFilter)
        {
            var courses = courseRepository.GetAll();
            List<Course> courslist;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courseRepository.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
           else if (!string.IsNullOrEmpty(filterBy)&& !string.IsNullOrEmpty(nameAccourdFilter))
            {
                courses = courseRepository.FilterCourses(filterBy,nameAccourdFilter);
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
