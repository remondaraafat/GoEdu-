using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Controllers
{
    public class LectureController : Controller
    {
        GoEduContext context;

        public LectureController(GoEduContext context)
        {
            this.context = context;
        }
        //UnitOfWork UnitOfWork;
        //public LectureController(UnitOfWork unitOfWork) {
        //    this.UnitOfWork = unitOfWork;
        //}
        #region Getll
        public IActionResult GetAll(int id)
        {
            List<LectureWithInstructorVM> lectures = context.lectures.Where(l => l.CourseID == id && l.isDeleted == false)
                .Select(l => new LectureWithInstructorVM()
                {
                    LctID = l.ID,
                    Title = l.Title,
                    LctTime = l.LectureTime,
                    Description = l.Description,
                    CrsID = l.CourseID
                }).AsNoTracking().ToList();
            return View(lectures);
        }
        #endregion

        #region New
        public IActionResult New(int CrsID)
        {
            AddOrEditLectureVM crs = new AddOrEditLectureVM() { CourseID = CrsID };
            return View(crs);
        }


        [HttpPost]
        public IActionResult  SaveNew(AddOrEditLectureVM lctFromReq)
        {
            if (ModelState.IsValid == true)
            {
                try
                {

                    Lecture lecture = new Lecture
                    {
                        Title = lctFromReq.Title,
                        VideoURL = "videoUrl",
                        LectureTime = DateTime.Now,
                        Description = lctFromReq.Description,
                        isDeleted = false,
                        CourseID = lctFromReq.CourseID,
                    };

                    context.lectures.Add(lecture);
                    context.SaveChanges();
                    TempData["SuccessMessage"] = "تم إضافة المحاضرة بنجاح!";
                    return RedirectToAction("GetAll", new {id = lctFromReq.CourseID});
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }

            return View("New", lctFromReq);
        }

        #endregion
        //[HttpGet]


        //public IActionResult LectureDetails(int id)
        //{
        //    Lecture lecture = UnitOfWork.LectureRepository.GetByID(id);
        //    return View(lecture);
        //}
    }
}

