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
        //show question for student by lecture
        [HttpGet]
        public IActionResult ShowLectureQuestions(int LectureID,int StudentId) 
        {
            StudentPerformance studentPerformance = unitOfWork.StudentPerformanceRepo.GetBy2IDs(StudentId,LectureID);
            if (studentPerformance == null) {
                ModelState.AddModelError("", "لقد امتحنت هذا الامتحان مسبقا!");
                return RedirectToAction("LectureDetails", "Lecture",new { id= LectureID,  StudentID=StudentId });
            }
            List<VMQuestionAnswer> questions= unitOfWork.QuestionRepo.GetQuestionsByLectureID(LectureID);
            return View(questions);
        }
        [HttpPost]
        public IActionResult ShowLectureQuestions(List<VMQuestionAnswer> questionAnswers)
        {
            int grad = 0;
            foreach (var ans in questionAnswers)
            {
                
                if (ans.StudentAnswer ==ans.ModelAnswer)
                {
                    grad++;
                }
                
                var answer = new Answer
                {
                    QuestionId = ans.QuestionId,
                    StudentId = ans.StudentId,
                    StudentAnswer = ans.StudentAnswer
                };
                

                unitOfWork.AnswerRepo.Insert(answer);
            }
            int percent=100*grad/ questionAnswers.Count();
            StudentPerformance studentPerformance=new StudentPerformance
            {
                LectureId= questionAnswers[0].LectureId,
                StudentId= questionAnswers[0].StudentId,
                Grade=percent
            };
            unitOfWork.StudentPerformanceRepo.Insert(studentPerformance);
            unitOfWork.save();
            return RedirectToAction("LectureDetails", "Lecture", new { id = questionAnswers[0].LectureId, StudentID = questionAnswers[0].StudentId });
        }

        public IActionResult Index()
        {
            
            return View();
        }

       
    }
}
