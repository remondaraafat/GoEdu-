using GoEdu.Data;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class StudentPerformanceController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public StudentPerformanceController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowStudentPerformanceByStudentId(int studentId)
        {
            List<VMStudentPerformance> studentPerfomances= unitOfWork.StudentPerformanceRepo.GetStudentPerformanceByStudentId(studentId);
            return View(studentPerfomances);
        }

        public IActionResult ShowStudentPerformanceByInstructorId(int instructorId)
        {
            List<VMStudentPerformance> studentPerfomancesByInstructor = unitOfWork.StudentPerformanceRepo.GetStudentPerformanceByInstructorId(instructorId);
            return View(studentPerfomancesByInstructor);
        }
    }
}
