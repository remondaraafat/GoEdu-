using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private GoEduContext context;

        public AnswerRepository(GoEduContext context)
        {
            this.context = context;
        }

        public void Delete(Answer Entity)
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Answer> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Answer Entity)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Answer Entity)
        {
            throw new NotImplementedException();
        }
    }
}
