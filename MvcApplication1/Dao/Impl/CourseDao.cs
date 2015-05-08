
using MvcApplication1.Dao.Base;
using MvcApplication1.Dao.Mapper;
using MvcApplication1.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace MvcApplication1.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (Course_ID, Course_Name, Course_Description) VALUES (@Course_ID, @Course_Name, @Course_Description);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = course.Course_ID;
            parameters.Add("Course_Name", DbType.String).Value = course.Course_Name;
            parameters.Add("Course_Description", DbType.Int32).Value = course.Course_Description;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET Course_Description = @Course_Description, Course_Name = @Course_Name WHERE Course_ID = @Course_ID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = course.Course_ID;
            parameters.Add("Course_Name", DbType.String).Value = course.Course_Name;
            parameters.Add("Course_Description", DbType.Int32).Value = course.Course_Description;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE Course_ID = @Course_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = course.Course_ID;
           
            ExecuteNonQuery(command, parameters);
        }
        
        public IList<Course> GetAllCourse()
        {
            string command = @"SELECT * FROM Course ORDER BY Course_ID ASC";
            IList<Course> courses = ExecuteQueryWithRowMapper(command);
            return courses;
        }

        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Course WHERE Course_ID = @Course_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Course_ID", DbType.String).Value = id;

            IList<Course> courses = ExecuteQueryWithRowMapper(command, parameters);
            if (courses.Count > 0)
            {
                return courses[0];
            }

            return null;
        }

    }
}
