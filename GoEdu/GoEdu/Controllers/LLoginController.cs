using GoEdu.Data;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class LLoginController : Controller
    {
        UnitOfWork unitOfWork;
        public LLoginController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult LLogin()
        {
            return View();
        }
        public IActionResult RRegister()
        {
            return View();
        }
    }
}
