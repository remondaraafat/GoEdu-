using GoEdu.Data;

namespace GoEdu.Repositories
{
    public class ExamRepository
    {
        private GoEduContext context;

        public ExamRepository(GoEduContext context)
        {
            this.context = context;
        }
    }
}
