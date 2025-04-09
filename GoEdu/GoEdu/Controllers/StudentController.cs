using GoEdu.Data;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoEdu.Models;

namespace GoEdu.Controllers
{
    public class StudentController : Controller
    {
        private UnitOfWork unitOfWork;
        public StudentController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }  
        
        public IActionResult StudentDashBoard(int StudentId)
        {
                VMStudentDashBoard Dashboard = new VMStudentDashBoard
                {
                    TodayLectures = unitOfWork.LectureRepository.GetTodayLectureByStudentId(StudentId),
                    LateLectures = unitOfWork.LectureRepository.GetLateLectures(StudentId),
                };
            //nessecary need to send error from action "LectureDetails" in lecture controller
            if (ModelState.IsValid) { }
            return View(Dashboard);
        }


        //public IActionResult Index(int insID = 3)
        //{
        //    List<StudentWithInstructorVM> student = context.Registers.Where(r=>r.InstructorID ==insID&& r.isDeleted==false).Select(s=>new StudentWithInstructorVM()
        //    {
        //        StdID = s.Student.ID,
        //        StdName = s.Student.Name,
        //        stdEmail = s.Student.Email,
        //        StdPhone = s.Student.StudentPhone,
        //        PrtPhone = s.Student.ParentPhone,
        //    }).AsNoTracking().ToList();
        //    return View(student);
        //}
        public IActionResult AllStudentsByInstructor(int instructorId)
        {
            StudentsCoursesVM StdVM = new();

            //all Students by instructor
            StdVM.Students = unitOfWork.StudentRepo.GetStudentsByInstructor(instructorId);

            // get courses by instructor
            StdVM.Courses = unitOfWork.CourseRepo.CoursesByInstructor(instructorId);            

            return View(StdVM);
        }

        [HttpPost]
        public IActionResult FilterStudentsByCourse(int id, StudentsCoursesVM StudentsfromView)
        {
            if (StudentsfromView.CourseId != 0)
            {
                // get students with a specific course
                StudentsfromView.Students = unitOfWork.StudentRepo.
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
            Student std = unitOfWork.StudentRepo.GetByID(id);
            return View(std);
        }       
    }
}
