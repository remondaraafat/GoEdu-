using GoEdu.Data;
using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace GoEdu.Repositories
{
    public class CourseRepository:ICourseRepository
    {
        GoEduContext Context;
        public CourseRepository(GoEduContext contxt)
        {
            Context = contxt;
        }

        public void Delete(Course obj)
        {
            //Course course = GetByID(id);
            //Context.Remove(course);
            Context.Courses.Remove(obj);
        }

      
        public List<Course> GetAll()
        {
            List<Course> list = Context.Courses.Include(c => c.Instructor).ToList();
            return list;
        }

        public List<CourseViewModel> GetAllcourses()
        {
            var courses = Context.Courses
                .Select(c => new CourseViewModel
                {
                    ID = c.ID,
                    Name = c.Name,
                    Price = c.Price,
                    Hours = c.Hours,
                    MaxViews = c.MaxViews,

                    CourseLevel = c.CourseLevel,

                    InstructorName = c.Instructor.Name,
                    //InstructorName = c.Instructor.Name,


                }).ToList();
            return courses;
        }
        public Course GetByID(int id)
        {
            Course course = Context.Courses.FirstOrDefault(c => c.ID == id);
            return course;
        }

        public void Insert(Course Obj)
        {
            Context.Courses.Add(Obj);
        }

        public void SaveData()
        {
            Context.SaveChanges();
        }

        public void Update(int id, Course obj)
        {
            var existingCourse = Context.Courses.FirstOrDefault(c => c.ID == id);
            if (existingCourse != null)
            {
                existingCourse.Name = obj.Name;
                existingCourse.Semester = obj.Semester;
                existingCourse.StudentLevel = obj.StudentLevel;
                existingCourse.CourseLevel = obj.CourseLevel;
                existingCourse.Hours = obj.Hours;
                existingCourse.Price = obj.Price;
                Context.SaveChanges();
            }
        }

       public List<Course> FilterCourses(string? instructorName, string? NameOfCourse)
            //string? instructorName, string? specialization, string? sortBy)
            {
                // var Query=Context.Courses.Include(c => c.Instructor).AsQueryable();
                IQueryable<Course> coursesQuery = Context.Courses;
            if (!string.IsNullOrEmpty(instructorName))
            {
                coursesQuery = coursesQuery.Where(c=>c.Instructor.Name.Contains(instructorName));
            }
            if (!string.IsNullOrEmpty(NameOfCourse))
            {
                coursesQuery = coursesQuery.Where(c => c.Name.Contains(NameOfCourse));
            }
            //if (!string.IsNullOrEmpty(specialization))
            //{
            //  coursesQuery = coursesQuery.Where(c => c.Specialization.Contains(specialization));
            //}
            //if (sortBy == "name")
            //{
            //    coursesQuery = coursesQuery.OrderBy(c => c.Name);
            //}
            //else if (sortBy == "price")
            //{
            //    coursesQuery = coursesQuery.OrderBy(c => c.Price);
            //}
            //else if (sortBy == "date")
            //{
            //    coursesQuery = coursesQuery.OrderBy(c => c.CreatedDate);
            //}
            return coursesQuery.ToList();

        }
        public List<Course> search(string searchQuery)
        {
            List<Course> courses = Context.Courses.ToList(); ;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courses.Where(c => c.Name.Contains(searchQuery)).ToList();
            }
            return courses;
        }
    }
}
