using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class StudentController : Controller
    {
        private readonly UnitOfWork context;
        public StudentController(UnitOfWork context)
        {
            this.context = context;
        }

        public IActionResult AllStudentsByInstructor(int instructorId)
        {
            StudentsCoursesVM StdVM = new();

            //all Students by instructor
            StdVM.Students = context.StudentRepo.GetStudentsByInstructor(instructorId);

            // get courses by instructor
            StdVM.Courses = context.CourseRepo.CoursesByInstructor(instructorId);            

            return View(StdVM);
        }

        [HttpPost]
        public IActionResult FilterStudentsByCourse(int id, StudentsCoursesVM StudentsfromView)
        {
            if (StudentsfromView.CourseId != 0)
            {
                // get students with a specific course
                StudentsfromView.Students = context.StudentRepo.
                                            GetStudentsByCourse(StudentsfromView.CourseId);
            }
            // filter by status 
            //if(StudentsfromView.statusValue != 0)
            //{
            //    foreach (var std in StudentsfromView.Students)
            //    {
            //        if(StudentsfromView.statusValue == StudentsfromView.status[])
            //    }
            //}
            
            return View("AllStudentsByInstructor", StudentsfromView);
        }

        public IActionResult Details(int id)
        {
            Student std = context.StudentRepo.GetByID(id);
            return View(std);
        }       
    }
}
