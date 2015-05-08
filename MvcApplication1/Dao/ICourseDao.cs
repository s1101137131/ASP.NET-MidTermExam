using MvcApplication1.Models;
using System;
using System.Collections.Generic;

namespace MvcApplication1.Dao
{
    public interface ICourseDao
    {

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(Course course);

        IList<Course> GetAllCourse();

        Course GetCourseById(string id);

    }
}
