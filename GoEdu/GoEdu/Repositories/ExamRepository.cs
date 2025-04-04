using GoEdu.Data;

namespace GoEdu.Repositories
{
<<<<<<<< HEAD:GoEdu/GoEdu/Repositories/AttendRepository.cs
    public class AttendRepository
========
    public class ExamRepository
    {
        private GoEduContext context;

        public ExamRepository(GoEduContext context)
    {
            this.context = context;
        }
    }
}
