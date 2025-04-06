using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoEdu.Controllers
{
    public class QuestionController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public QuestionController(UnitOfWork ctx)
        {
            this.unitOfWork = ctx;
        }

        [HttpGet]
        public IActionResult AddAndShowQuestions(int id)
        {
            VMQuestionWithQuestions questions = unitOfWork.QuestionRepo.GetAndAddQustionListByLectureId(id);

            return View(questions);
        }
        [HttpPost]
        public IActionResult AddAndShowQuestions(VMQuestionWithQuestions QuestionFromView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Question question = new();
                    question.Content = QuestionFromView.Content;
                    question.LectureId = QuestionFromView.LectureId;
                    question.ModelAnswer = QuestionFromView.ModelAnswer;
                    unitOfWork.QuestionRepo.Insert(question);
                    unitOfWork.save();
                    
                    int questionId = unitOfWork.QuestionRepo.GetQuestionByContent(question.Content).Id;
                        
                    unitOfWork.OptionRepo.Insert(new Option
                    {
                        Content = QuestionFromView.Option1,
                        QuestionId = questionId,
                    });
                    unitOfWork.OptionRepo.Insert(new Option
                    {
                        Content = QuestionFromView.Option2,
                        QuestionId = questionId,
                    });
                    unitOfWork.OptionRepo.Insert(new Option
                    {
                        Content = QuestionFromView.Option3,
                        QuestionId = questionId,
                    });
                    unitOfWork.OptionRepo.Insert(new Option
                    {
                        Content = QuestionFromView.Option4,
                        QuestionId = questionId,
                    });
                    unitOfWork.save();

                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }

            }
            

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

       
    }
}
