using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private GoEduContext context;

        public RegisterRepository(GoEduContext context)
        {
            this.context = context;
        }

        public void Delete(Register Entity)
        {
            throw new NotImplementedException();
        }

        public List<Register> GetAll()
        {
            throw new NotImplementedException();
        }

        public Register GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Register Entity)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Register Entity)
        {
            throw new NotImplementedException();
        }
    }
}
