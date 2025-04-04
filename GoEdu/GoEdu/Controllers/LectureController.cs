using GoEdu.Data;
using GoEdu.Models;
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
        public IActionResult LectureDetails(int id)
        {
            Lecture lecture = UnitOfWork.LectureRepository.GetByID(id);
            return View(lecture);
        }
    }
}
