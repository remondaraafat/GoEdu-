using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    public class ExamRepository : IExamRepository
    {
        public GoEduContext Context { get; }
        public ExamRepository(GoEduContext goEduContext)
        {
            Context = goEduContext;
        }

     

        public void Delete(Exams Entity)
        {
            throw new NotImplementedException();
        }

        public Exams GenerateExamForCourse(int id)
        {
            var examQues = Context.ExamQuestions.Where(eq => eq.Exam.CourseId == id)
                .Select(eq =>eq.Question).ToList();
            if (!examQues.Any())
                return null;

            var newExam= new Exams
            {
                CourseId = id,
                ExamDate=DateTime.Now,
                
            };
            Context.Add(newExam);
            Context.SaveChanges();

            foreach (var question in examQues)
            {
                Context.ExamQuestions.Add(new ExamQuestion
                {
                    ExamId=newExam.ID,
                    QuestionId=question.Id
                });
            }
            Context.SaveChanges();
            return newExam;
        }

        public List<Exams> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exams GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Exams Entity)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            Context.SaveChanges();
        }

        public void Update(int id, Exams Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
