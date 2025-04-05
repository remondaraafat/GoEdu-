using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class LectureController : Controller
    {
        UnitOfWork UnitOfWork;
        public LectureController(UnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LectureDetails(int id,int StudentID)
        {
            LectureDetailsVM lecture = UnitOfWork.LectureRepository.GetLectureVMByID(id,StudentID);
            return View(lecture);
        }
        public IActionResult EditLecture(int id, int InstructorID)
        {
            LectureWithInstructorCoursesVM lecture = UnitOfWork.LectureRepository.GetLectureWithCourseList(id, InstructorID);

            return View(lecture);
        }
    }
}
