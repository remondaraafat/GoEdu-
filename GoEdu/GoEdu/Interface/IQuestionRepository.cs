using GoEdu.Models;
using GoEdu.ViewModel;

namespace GoEdu.Repositories
{
    public interface IQuestionRepository:ICRUD<Question>
    {
        public VMQuestionWithQuestions GetAndAddQustionListByLectureId(int LectureId);

        public Question GetQuestionByContent(string content);
    }
}
