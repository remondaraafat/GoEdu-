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
        // all methods need to be tested
        public void Delete(Lecture Entity)
        {
            context.lectures.Remove(Entity);
        }

        public List<Lecture> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<Lecture> GetAllCourseLectures(int CourseID) {
            return context.lectures.Where(l=>l.CourseID==CourseID).ToList(); 
        }

        public Lecture GetByID(int id)
        {
            return context.lectures.FirstOrDefault(d => d.ID == id);
        }

        public void Insert(Lecture Entity)
        {
            context.lectures.Add(Entity);
        }

        public void SaveData()
        {
            context.SaveChanges();
        }
        
        public void Update(int id, Lecture Entity)
        {
            context.Update(Entity);
        }
    }
}