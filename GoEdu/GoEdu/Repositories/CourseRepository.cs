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

        public List<Course> CoursesByInstructor(int instructorId)
        {
            return Context.Courses.Where(c=>c.InstructorID == instructorId).ToList();
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
                    //Semester = c.Semester,
                    CourseLevel = c.CourseLevel,

                    InstructorName = c.Instructor.Name,
                    //InstructorName = c.Instructor.Name,


                }).ToList();
            return courses;
        }
        public Course GetByID(int id)
        {
            Course course = Context.Courses.Include(c=>c.Instructor).FirstOrDefault(c => c.ID == id);
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

       public List<Course> FilterCourses(string filterBy, string nameAccourdFilter)
          {
                
                IQueryable<Course> coursesQuery = Context.Courses;
            if (!string.IsNullOrEmpty(filterBy)&& !string.IsNullOrEmpty(nameAccourdFilter))
            {
                if (filterBy == "instructorName")
                {
                    coursesQuery = coursesQuery.Where(c => c.Instructor.Name.ToLower().Contains(nameAccourdFilter.ToLower()));
                    //.Select(i => i.ID)
                   
                    //coursesQuery = coursesQuery.Where(c => instructorIds.Contains(c.InstructorID));
                }
                else if (filterBy == "courseName")
                {

                    coursesQuery = coursesQuery.Where(c => c.Name.Contains(nameAccourdFilter.ToLower()));
                }

            }
           
            
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
        public CourseDetailsViewModel GetCourseWithLectures(int courseId)
        {
            var Result=Context.Courses.Where(c=>c.ID==courseId)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseName = c.Name,
                    Lectures = c.Lecture.Select(l => new VMLectureDetails
                    {
                        Title = l.Title,
                         ID=l.ID,
                        VideoURL = l.VideoURL,
                        //ReleaseDate = l.LectureTime,
                        Description = l.Description,
                        Comments = l.Comment,
                        //Question=l.Question,
                      
                    }).ToList()
                }).FirstOrDefault();


            return Result;
        }
    }
}
