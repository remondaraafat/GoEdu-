using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
        UnitOfWork unitOfWork;
        public CourseController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        #region Mark
        //need to Edit
        public IActionResult GetInsCourses(int id)
        {
            var courses = unitOfWork.CourseRepo.GetIstructorCourses(id);

            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        public IActionResult DeleteCourse(int id)
        {
            unitOfWork.CourseRepo.Delete(id);
            return RedirectToAction("GetInsCourses");
        }

        public IActionResult CourseInsDetails(int id)
        {
            return View();
        }

        public IActionResult NewCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveCourses(AddCourseWithInstructorVM newCrs)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    unitOfWork.CourseRepo.SaveNew(newCrs);
                    TempData["CourseCreated"] = "تم الإضافة بنجاح!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }
            return View("New", newCrs);
        }

        public IActionResult Edit(int id)
        {
            AddCourseWithInstructorVM course = unitOfWork.CourseRepo.EditCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult SaveEdit(AddCourseWithInstructorVM crsFromReq)
        {
            //if (!ModelState.IsValid)
            //{
            //    TempData["Error"] = "ModelState غير صالح";
            //}
            if (ModelState.IsValid == true)
            {
                try
                {
                    unitOfWork.CourseRepo.SaveEdit(crsFromReq);
                    TempData["CoursEdited"] = "تم التعديل بنجاح!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }
            return View("Edit", crsFromReq);
        }

        [HttpGet]
        public IActionResult CheckPrice(double CrsPrice)
        {
            if (CrsPrice >= 50)
            {
                return Json(true);
            }
            return Json(false);
        }
        #endregion


        public IActionResult Index(string searchQuery, string? filterBy, string? NameOfCourse)
        {
            var courses = unitOfWork.CourseRepo.GetAll();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = unitOfWork.CourseRepo.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(filterBy)&&!string.IsNullOrEmpty(NameOfCourse))
            {
                courses = unitOfWork.CourseRepo.FilterCourses(filterBy, NameOfCourse);
            }
            //if (!string.IsNullOrEmpty(NameOfCourse))
            //{
            //    courses = courses.Where(c => c.Name.Contains(NameOfCourse, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
            return View("Index", courses);
        }





        #region Edit


        #endregion


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
        //    var filteredCourses = courseRepository.FilterCourses(instructorName);
        //    return View("filtered", filteredCourses);
        //}

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
    }
}
