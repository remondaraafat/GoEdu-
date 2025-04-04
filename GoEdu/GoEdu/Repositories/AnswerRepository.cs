using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly GoEduContext ctx;

        public AnswerRepository(GoEduContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(Answer Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetByID(int id)
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
