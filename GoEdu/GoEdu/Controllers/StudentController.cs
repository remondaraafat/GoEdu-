using GoEdu.Data;
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

            // Enum of student status filter
            StdVM.status = new();
            // Alert: add courses by instructor here
            //StdVM.Courses = 

            return View(StdVM);
        }

        [HttpPost]
        public IActionResult FilterStudentsByCourse(StudentsCoursesVM StudentsfromView)
        {
            if (StudentsfromView.CourseId != 0)
            {
                // get students with a specific course

            }
            //all Students by instructor
            StdVM.Students = context.StudentRepo.GetStudentsByInstructor(instructorId);

            // Enum of student status filter
            StdVM.status = new();

            // Alert: add courses by instructor here
            //StdVM.Courses = 

            return View(StdVM);
        }
    }
}
