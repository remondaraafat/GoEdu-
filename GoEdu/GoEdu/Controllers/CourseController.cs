using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
using GoEdu.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using GoEdu.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
        UnitOfWork unitOfWork;
        //IunitOfWork.CourseRepo unitOfWork.CourseRepo;
        public CourseController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork; 
        }

        public IActionResult Index(string searchQuery, string? filterBy, string? NameOfCourse)
        {
            var courses = unitOfWork.CourseRepo.GetAll();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = unitOfWork.CourseRepo.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(filterBy)&&!string.IsNullOrEmpty(NameOfCourse))
            {
                courses = unitOfWork.CourseRepo.FilterCourses(filterBy, NameOfCourse);
            }
            //if (!string.IsNullOrEmpty(NameOfCourse))
            //{
            //    courses = courses.Where(c => c.Name.Contains(NameOfCourse, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
            return View("Index", courses);
        }
        //not working
        public IActionResult Details(int id)
        {
            var Course = unitOfWork.CourseRepo.GetByID(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View("Details", Course);
        }
        public IActionResult GetAllWithIns()
        {
            var courses = unitOfWork.CourseRepo.GetAllcourses();
            return View("GetAllWithIns", courses);

        }
        //public IActionResult filtered(string? instructorName,)
        //{
        //    var filteredCourses = unitOfWork.CourseRepo.FilterCourses(instructorName);
        //    return View("filtered", filteredCourses);
        //}
        //course id
        public IActionResult CourseDetails(int id)
        {
            var courseDetails= unitOfWork.CourseRepo.GetCourseWithLectures(id);
            if (courseDetails == null)
            {
                return NotFound("Course not found");
            }
            Console.WriteLine("✅ Course Found: " + courseDetails.CourseName);
           // return Content("Course ID is: " + id);
           return View("CourseDetails", courseDetails);
        }
        //when student register in a course
        public IActionResult EnrollInCourse(int courseID,int StudentID)
        {
            //get instructor id
            //get record if found =>you are already registerd

            int InstructorID = unitOfWork.CourseRepo.GetByID(courseID).InstructorID;
            Enroll enrolled = unitOfWork.EnrollRepo.GetBy3IDs(courseID,InstructorID,StudentID);
            if (enrolled != null)
            {
                // Student already enrolled
                ViewBag.Message = "You are already enrolled in this course.";
                return RedirectToAction("Index");
            }
           
            Enroll enroll = new Enroll
            {
                CourseID = courseID,
                InstructorID = InstructorID,
                StudentID = StudentID,
                Data = DateTime.Now
            };
            unitOfWork.EnrollRepo.Insert(enroll);
            unitOfWork.save();

            return RedirectToAction("Index");

        }

    }
}
