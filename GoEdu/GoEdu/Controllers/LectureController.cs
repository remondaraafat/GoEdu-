using System.Collections.Generic;
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

        #region Mark Section
        #region All Lecture Course
        public IActionResult GetLectures(int id)
        {
            List<LectureWithInstructorVM> lectures = UnitOfWork.LectureRepository.GetLectureCourses(id);

            if (lectures == null)
            {
                return NoContent();
            }
            ViewData["LectureCount"] = UnitOfWork.LectureRepository.LectureCount(id);
            return View(lectures);
        }
        #endregion

        #region Add Lecture
        public IActionResult NewLecture(int CrsID)
        {
            AddOrEditLectureVM CrsId = new AddOrEditLectureVM() { CourseID = CrsID };
            return View(CrsId);
        }


        [HttpPost]
        public IActionResult SaveNew(AddOrEditLectureVM lctFromReq)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    Lecture lecture = new Lecture
                    {
                        Title = lctFromReq.Title,
                        VideoURL = "videoUrl",
                        LectureTime = lctFromReq.LectureTime,
                        Description = lctFromReq.Description,
                        isDeleted = false,
                        CourseID = lctFromReq.CourseID,
                    };
                    UnitOfWork.LectureRepository.Insert(lecture);
                    TempData["SuccessMessage"] = "تم إضافة المحاضرة بنجاح!";
                    return RedirectToAction("GetLectures", new { id = lctFromReq.CourseID });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }
            return View("NewLecture", lctFromReq);
        }
        #endregion

        #region Delete Lecture
        public IActionResult DeleteLecture(int id, int CrsID)
        {
            UnitOfWork.LectureRepository.Delete(id);
            TempData["Deleted"] = "تم الحذف بنجاح !";

            return RedirectToAction("GetLectures", new { id = CrsID });
        }
        #endregion
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
            Attend attend = UnitOfWork.AttendRepo.GetBy2Ids(StudentID, id);
            if (attend == null)
            {
                attend = new Attend();
                attend.StudentID = StudentID;
                attend.LectureID = id;
                attend.ViewsCount += 1;
                UnitOfWork.AttendRepo.Insert(attend);
            }
            else
            {
                if (UnitOfWork.CourseRepo.GetByID(UnitOfWork.LectureRepository.GetByID(id).CourseID).MaxViews > attend.ViewsCount)
                    attend.ViewsCount += 1;
                else
                {
                    ModelState.AddModelError("", "You Have reached maximum Views");
                    return RedirectToAction("StudentDashBoard", "Student");
                }
            }

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

        [HttpGet]
        public IActionResult LectureSchedule( int StudentID)
        {
            List<VMLectureSchedule> lectures = UnitOfWork.LectureRepository.GetStudentLectureSchedual(StudentID);

            return View(lectures);
        }
    }
}

