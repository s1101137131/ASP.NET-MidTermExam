using MvcApplication1.Dao.Impl;
using MvcApplication1.Dao;
using MvcApplication1.Models;
using System.Collections.Generic;

namespace MvcApplication1.Services.Impl
{
    public class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddCourse(Course course)
        {
            CourseDao.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            CourseDao.UpdateCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            course = CourseDao.GetCourseById(course.Course_ID);

            if (course != null)
            {
                CourseDao.DeleteCourse(course);
            }
        }

        public IList<Course> GetAllCourses()
        {
            return CourseDao.GetAllCourse();
        }

        public Course GetCourseById(string id)
        {
            return CourseDao.GetCourseById(id);
        }

    }

}
