﻿using GoEdu.Data;
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

        //get by two ids
        public Attend GetBy2Ids(int StudentId, int LectureId)
        {
            return context.Attends.FirstOrDefault(a => a.StudentID == StudentId && a.LectureID == LectureId && a.isDeleted);
        }


        // Default CRUD
        public void Delete(Attend Entity)
        {
            throw new NotImplementedException();
        }

        public List<Attend> GetAll()
        {
            return context.Attends.ToList();
        }

        public Attend GetByID(int id)
        {
            return context.Attends.FirstOrDefault(a=>a.LectureID==id);
        }

        public void Insert(Attend Entity)
        {
            context.Attends.Add(Entity);
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Attend Entity)
        {
            context.Attends.Update(Entity);
        }
    }
}
