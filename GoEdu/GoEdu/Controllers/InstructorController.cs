using GoEdu.Data;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class InstructorController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public InstructorController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DashBoard(int instructorId)
        {
            VMInstructorDashBoard dashBoard = new VMInstructorDashBoard
            {
                InstructorId = instructorId,
                TotalStudents = unitOfWork.StudentRepo.GetStudentsByInstructor(instructorId).Count(),
                TotalCourses = unitOfWork.CourseRepo.CoursesByInstructor(instructorId).Count(),
                TotalViews = unitOfWork.AttendRepo.LecturesTotalViewsByInstructorId(instructorId),
                TopTenPerformances = unitOfWork.StudentPerformanceRepo.TopTenByInstructorId(instructorId),
            };
            
            return View();
        }

    }
}
