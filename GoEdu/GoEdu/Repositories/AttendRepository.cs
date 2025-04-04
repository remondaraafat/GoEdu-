using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    public class AttendRepository:IAttendRepository
    {
        private GoEduContext context;

        public AttendRepository(GoEduContext context)
        {
            this.context = context;
        }

        public void Delete(Attend Entity)
        {
            throw new NotImplementedException();
        }

        public List<Attend> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Attend> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Attend Entity)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Attend Entity)
        {
            throw new NotImplementedException();
        }
    }
}
