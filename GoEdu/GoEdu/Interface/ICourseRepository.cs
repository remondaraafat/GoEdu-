using GoEdu.Models;
using GoEdu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoEdu.Repositories
{
    public interface ICourseRepository : ICRUD<Course>
    {
        public List<CourseViewModel> GetAllcourses();
        public List<Course> FilterCourses(string? instructorName, string? NameOfCourse);
        // , string? specialization, string? sortBy

        public List<Course> search(string searchQuery);
        public CourseDetailsViewModel GetCourseWithLectures(int courseId);

        //david methods
        public List<Course> CoursesByInstructor(int instructorId);

        //Mark
        public List<CourseWithInstructorVM> GetIstructorCourses(int insID);

        public void SaveNew(AddCourseWithInstructorVM newCrs);

        public AddCourseWithInstructorVM EditCourse(int id);

        public void SaveEdit(AddCourseWithInstructorVM crsFromReq);

    }

    //        public List<CourseViewModel> GetAllcourses();

    //        public List<Course> FilterCourses(string? instructorName, string? NameOfCourse);


    //        public List<Course> search(string searchQuery);
    //<<<<<<< HEAD
    //        public CourseDetailsViewModel GetCourseWithLectures(int courseId);
    //=======

    //        //david methods
    //        public List<Course> CoursesByInstructor(int instructorId);
    //>>>>>>> origin/main
    //    }
}

