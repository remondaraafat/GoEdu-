using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;

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
        public VMLectureDetails GetLectureVMByID(int id,int StudentID)
        {
           return context.lectures.Select(l => new VMLectureDetails { ID = l.ID,
               Comments=l.Comment,
               CourseName=l.Course.Name,
               Description=l.Description,
               ExamId=l.ExamID,
               LectureTime=l.LectureTime,
               Title=l.Title,
               VideoURL=l.VideoURL,
               ViewsCount=l.Attend.FirstOrDefault(a => a.StudentID==StudentID && a.LectureID==id).ViewsCount
           }).FirstOrDefault(LVM => LVM.ID == id);
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
           // Lecture l = GetByID(id);
            context.Update(Entity);
        }
        //need edit
        public VMLectureWithInstructorCourses GetLectureWithCourseList(int LectureId, int InstructorID)
        {
            List<VMCourseList> InstCourseList = context.Courses.Select(c=>new VMCourseList {
            ID=c.ID,
            Name=c.Name,
            }).ToList();

            return context.lectures.Select(l => new VMLectureWithInstructorCourses
            {
                ID = l.ID,
                Comments = l.Comment,
                CourseID = l.Course.ID,
                Description = l.Description,
                ExamId = l.ExamID,
                LectureTime = l.LectureTime,
                Title = l.Title,
                VideoURL = l.VideoURL,
                InstructorCourses = InstCourseList
            }).FirstOrDefault(LVM => LVM.ID == LectureId);

        }
    }
}