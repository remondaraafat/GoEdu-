using GoEdu.Data;
<<<<<<< HEAD
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
>>>>>>> origin/main

namespace GoEdu.Controllers
{
    public class StudentController : Controller
    {
<<<<<<< HEAD
        GoEduContext context;
        public StudentController(GoEduContext context)
=======
        private readonly UnitOfWork context;
        public StudentController(UnitOfWork context)
>>>>>>> origin/main
        {
            this.context = context;
        }

<<<<<<< HEAD
        public IActionResult Index(int insID = 3)
        {
            List<StudentWithInstructorVM> student = context.Registers.Where(r=>r.InstructorID ==insID&& r.isDeleted==false).Select(s=>new StudentWithInstructorVM()
            {
                StdID = s.Student.ID,
                StdName = s.Student.Name,
                stdEmail = s.Student.Email,
                StdPhone = s.Student.StudentPhone,
                PrtPhone = s.Student.ParentPhone,
            }).AsNoTracking().ToList();
            return View(student);
        }
=======
        public IActionResult AllStudentsByInstructor(int instructorId)
        {
            StudentsCoursesVM StdVM = new();

            //all Students by instructor
            StdVM.Students = context.StudentRepo.GetStudentsByInstructor(instructorId);

            // get courses by instructor
            StdVM.Courses = context.CourseRepo.CoursesByInstructor(instructorId);            

            return View(StdVM);
        }

        [HttpPost]
        public IActionResult FilterStudentsByCourse(int id, StudentsCoursesVM StudentsfromView)
        {
            if (StudentsfromView.CourseId != 0)
            {
                // get students with a specific course
                StudentsfromView.Students = context.StudentRepo.
                                            GetStudentsByCourse(StudentsfromView.CourseId);
            }
            // filter by status 
            //if(StudentsfromView.statusValue != 0)
            //{
            //    foreach (var std in StudentsfromView.Students)
            //    {
            //        if(StudentsfromView.statusValue == StudentsfromView.status[])
            //    }
            //}
            
            return View("AllStudentsByInstructor", StudentsfromView);
        }

        public IActionResult Details(int id)
        {
            Student std = context.StudentRepo.GetByID(id);
            return View(std);
        }       
>>>>>>> origin/main
    }
}
