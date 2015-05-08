using MvcApplication1.Models;
using Spring.Data.Generic;
using System.Data;

namespace MvcApplication1.Dao.Mapper
{
    class CourseRowMapper : IRowMapper<Course>
    {
        public Course MapRow(IDataReader dataReader, int rowNum)
        {
            Course target = new Course();

            target.Course_ID = dataReader.GetString(dataReader.GetOrdinal("Course_ID"));
            target.Course_Name = dataReader.GetString(dataReader.GetOrdinal("Course_Name"));
            target.Course_Description = dataReader.GetString(dataReader.GetOrdinal("Course_Description"));

            return target;
        }

    }
}
