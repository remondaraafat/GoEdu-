<<<<<<< HEAD
﻿using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

=======
﻿using GoEdu.Repositories;
using Microsoft.AspNetCore.Mvc;
using GoEdu.ViewModel;
>>>>>>> origin/main
namespace GoEdu.Controllers
{
    public class CourseController : Controller
    {
<<<<<<< HEAD
        GoEduContext context;
        public CourseController(GoEduContext context)
        {
            this.context = context;
        }

        #region GetAll
        //need to Edit
        public IActionResult Index(int insID = 5)
        {
            List<CourseWithInstructorVM> crsVm = context.Courses.Where(c => c.InstructorID == insID && c.isDeleted == false)
                .Select(c => new CourseWithInstructorVM()
                {
                    CrsID = c.ID,
                    CrsName = c.Name,
                    CrsPrice = c.Price,
                    CrsHours = c.Hours,
                    CrsSemester = c.Semester,
                    CrsStage = c.StudentStage,
                    CrsLevel = c.CourseLevel,
                    NumOfLecture = context.lectures.Where(l => l.CourseID == c.ID).Count(),
                    NumOfStudent = context.Registers.Where(r => r.CourseID == c.ID).Count()
                }).AsNoTracking().ToList();
            return View(crsVm);
        }
        #endregion

        public IActionResult Delete(int id)
        {
            Course? course = context.Courses.FirstOrDefault(c => c.ID == id && c.isDeleted == false);
            if (course != null)
            {
                course.isDeleted = true;
                context.SaveChanges();
                TempData["CourseDeleted"] = "تم الحذف بنجاح !";

            }
            return RedirectToAction("Index");
=======
        ICourseRepository courseRepository;
        public CourseController(ICourseRepository crseRepo)
        {
            courseRepository = crseRepo;
        }

        public IActionResult Index(string searchQuery, string? filterBy, string? NameOfCourse)
        {
            var courses = courseRepository.GetAll();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courseRepository.search(searchQuery);// courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            if (!string.IsNullOrEmpty(filterBy)&&!string.IsNullOrEmpty(NameOfCourse))
            {
                courses = courseRepository.FilterCourses(filterBy, NameOfCourse);
            }
            //if (!string.IsNullOrEmpty(NameOfCourse))
            //{
            //    courses = courses.Where(c => c.Name.Contains(NameOfCourse, StringComparison.OrdinalIgnoreCase)).ToList();
            //}
            return View("Index", courses);
>>>>>>> origin/main
        }

        public IActionResult Details(int id)
        {
<<<<<<< HEAD
            return View();
        }

        #region New
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SeveNew(AddCourseWithInstructorVM newCrs)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    Course crs = new Course()
                    {
                        Name = newCrs.CrsName,
                        Price = newCrs.CrsPrice,
                        Hours = newCrs.CrsHours,
                        Degree = 100,
                        MinDegree = newCrs.CrsMinDegree,
                        Semester = newCrs.CrsSemester,
                        StudentStage = newCrs.CrsStage,
                        CourseLevel = newCrs.CrsLevel,
                        isDeleted = false,
                        InstructorID = newCrs.InsID
                    };

                    context.Courses.Add(crs);
                    context.SaveChanges();
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

        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            Course? crsFromDB= context.Courses.FirstOrDefault(c=>c.ID == id);

            if (crsFromDB == null)
            {
                return NoContent();
            }

            AddCourseWithInstructorVM crsVM = new AddCourseWithInstructorVM()
            {
                CrsID = crsFromDB.ID,
                CrsName = crsFromDB.Name,
                CrsPrice = crsFromDB.Price,
                CrsHours = crsFromDB.Hours,
                CrsMinDegree = crsFromDB.MinDegree,
                CrsSemester = crsFromDB.Semester,
                CrsStage = crsFromDB.StudentStage,
                CrsLevel = crsFromDB.CourseLevel,

            };

            return View(crsVM);
        }

        [HttpPost]
        public IActionResult SaveEdit(AddCourseWithInstructorVM crsFromReq)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "ModelState غير صالح";
            }
            if (ModelState.IsValid == true)
            {
                try
                {
                    Course? crsFromDB = context.Courses.FirstOrDefault(c => c.ID == crsFromReq.CrsID);

                    crsFromDB.Name = crsFromReq.CrsName;
                    crsFromDB.Price = crsFromReq.CrsPrice;
                    crsFromDB.Hours = crsFromReq.CrsHours;
                    crsFromDB.MinDegree = crsFromReq.CrsMinDegree;

                    context.SaveChanges();
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

        #endregion
            [HttpGet]
        public IActionResult CheckPrice(double CrsPrice)
        {
            if(CrsPrice >= 50)
            {
                return Json(true);
            }
            return Json(false);
        }
=======
            var Course = courseRepository.GetByID(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View("Details", Course);
        }
        public IActionResult GetAllWithIns()
        {
            var courses = courseRepository.GetAllcourses();
            return View("GetAllWithIns", courses);

        }
        //public IActionResult filtered(string? instructorName,)
        //{
        //    var filteredCourses = courseRepository.FilterCourses(instructorName);
        //    return View("filtered", filteredCourses);
        //}

        public IActionResult CourseDetails(int id)
        {
            var courseDetails= courseRepository.GetCourseWithLectures(id);
            if (courseDetails == null)
            {
                return NotFound("Course not found");
            }
            Console.WriteLine("✅ Course Found: " + courseDetails.CourseName);
           // return Content("Course ID is: " + id);
           return View("CourseDetails", courseDetails);
        }

>>>>>>> origin/main
    }
}
