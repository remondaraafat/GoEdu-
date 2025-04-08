using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
<<<<<<< HEAD
using GoEdu.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using GoEdu.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
=======
using GoEdu.Models;
>>>>>>> origin/main
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

        public IActionResult Index(string searchQuery, string? filterBy, string? nameAccourdFilter)
        {
<<<<<<< HEAD
            var courses = unitOfWork.CourseRepo.GetAll();
=======
            var courses = courseRepository.GetAll();
            List<Course> courslist;
>>>>>>> origin/main
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = unitOfWork.CourseRepo.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
           else if (!string.IsNullOrEmpty(filterBy)&& !string.IsNullOrEmpty(nameAccourdFilter))
            {
<<<<<<< HEAD
                courses = unitOfWork.CourseRepo.FilterCourses(filterBy, NameOfCourse);
=======
                courses = courseRepository.FilterCourses(filterBy,nameAccourdFilter);
>>>>>>> origin/main
            }
           
            return View("Index", courses);
        }
<<<<<<< HEAD
        //not working
=======



>>>>>>> origin/main
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
