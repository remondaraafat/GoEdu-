using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
using GoEdu.Models;
using GoEdu.Data;
namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
        
       // ICourseRepository courseRepository;
        UnitOfWork UnitOfWork;
        public CourseController(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
           //this.courseRepository = courseRepository;
        }

        public IActionResult Index(string searchQuery, string? filterBy, string? nameAccourdFilter)
        {
            var courses = UnitOfWork.CourseRepo.GetAll();
           
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = UnitOfWork.CourseRepo.search(searchQuery);
            }
            else if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(nameAccourdFilter))
            {
                courses = UnitOfWork.CourseRepo.FilterCourses(filterBy, nameAccourdFilter);
            }
            return View("Index", courses);
        }



        public IActionResult Details(int id)
        {
            var Course = UnitOfWork.CourseRepo.GetByID(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View("Details", Course);
        }
        public IActionResult GetAllWithIns()
        {
            var courses = UnitOfWork.CourseRepo.GetAllcourses();
            return View("GetAllWithIns", courses);

        }
       

        public IActionResult CourseDetails(int id)
        {
            var courseDetails= UnitOfWork.CourseRepo.GetCourseWithLectures(id); 
            {
                return NotFound("Course not found");
            }
            Console.WriteLine("✅ Course Found: " + courseDetails.CourseName);
           // return Content("Course ID is: " + id);
           return View("CourseDetails", courseDetails);
        }

    }
}
