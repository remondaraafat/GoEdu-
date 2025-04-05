using GoEdu.Data;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Controllers
{
    public class StudentController : Controller
    {
        GoEduContext context;
        public StudentController(GoEduContext context)
        {
            this.context = context;
        }

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
    }
}
