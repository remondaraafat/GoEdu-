using GoEdu.Data;

namespace GoEdu.Repositories
{
    public class InstructorRepository
    {
        private GoEduContext context;

        public InstructorRepository(GoEduContext context)
        {
            this.context = context;
        }
    }
}
