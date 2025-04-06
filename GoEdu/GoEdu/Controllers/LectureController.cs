using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Controllers
{
    public class LectureController : Controller
    {

        UnitOfWork UnitOfWork;
        public LectureController(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        //public IActionResult Index()


        #region Getll
        //public IActionResult GetAll(int id)
        //{
        //    List<LectureWithInstructorVM> lectures = context.lectures.Where(l => l.CourseID == id && l.isDeleted == false)
        //        .Select(l => new LectureWithInstructorVM()
        //        {
        //            LctID = l.ID,
        //            Title = l.Title,
        //            LctTime = l.LectureTime,
        //            Description = l.Description,
        //            CrsID = l.CourseID
        //        }).AsNoTracking().ToList();
        //    return View(lectures);
        //}
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

        [HttpGet]
        public IActionResult LectureDetails(int id, int StudentID)
        {
            VMLectureDetails lecture = UnitOfWork.LectureRepository.GetLectureVMByID(id, StudentID);
            return View(lecture);
        }
        [HttpGet]
        public IActionResult EditLecture(int id, int InstructorID)
        {
            VMLectureWithInstructorCourses lecture = UnitOfWork.LectureRepository.GetLectureWithCourseList(id, InstructorID);

            return View(lecture);
        }
        [HttpPost]
        public IActionResult EditLecture(VMLectureWithInstructorCourses lectureVM)
        {

            if (ModelState.IsValid)
            {
                Lecture lecture = UnitOfWork.LectureRepository.GetByID(lectureVM.ID);
                if (lecture != null)
                {
                    lecture.Description = lectureVM.Description;
                    lecture.ExamID = lectureVM.ExamId;
                    lecture.ID = lectureVM.ID;
                    lecture.Title = lectureVM.Title;
                    lecture.LectureTime = lectureVM.LectureTime;
                    lecture.VideoURL = lectureVM.VideoURL;

                    try
                    {

                        UnitOfWork.LectureRepository.Update(lecture.ID, lecture);
                        UnitOfWork.save();
                        //need edit student id 
                        return RedirectToAction("LectureDetails", new { id = lecture.ID, StudentID = 1 });
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Lecture not found.");
                    lectureVM.InstructorCourses = UnitOfWork.LectureRepository.GetLectureWithCourseList(lectureVM.ID, 1).InstructorCourses;
                    return View(lectureVM);
                }
            }
            //need edit instructor id
            lectureVM.InstructorCourses = UnitOfWork.LectureRepository.GetLectureWithCourseList(lectureVM.ID, 1).InstructorCourses;
            return View(lectureVM);
        }
    }
}

