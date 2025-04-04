using GoEdu.Data;
using GoEdu.Models;

namespace GoEdu.Repositories
{
    internal class LectureRepository:ILectureRepository
    {
        private GoEduContext context;

        public LectureRepository(GoEduContext context)
        {
            this.context = context;
        }

        public void Delete(Lecture Entity)
        {
            throw new NotImplementedException();
        }

        public List<Lecture> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Lecture> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Lecture Entity)
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Lecture Entity)
        {
            throw new NotImplementedException();
        }
    }
}