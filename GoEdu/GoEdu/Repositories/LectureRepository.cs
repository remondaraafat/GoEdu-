using GoEdu.Data;

namespace GoEdu.Repositories
{
    internal class LectureRepository
    {
        private GoEduContext context;

        public LectureRepository(GoEduContext context)
        {
            this.context = context;
        }
    }
}