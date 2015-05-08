using MvcApplication1.Models;
using MvcApplication1.Services;
using MvcApplication1.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }
        public MidExamEntities1 mid = new MidExamEntities1();
        
        
        [HttpGet]
        public IList<Course> GetAllCourse()
        {
            return CourseService.GetAllCourses();
        }

        [HttpGet]
        [ActionName("byId")]
        public Course GetCourseById(string id)
        {
            var course = CourseService.GetCourseById(id);

            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return course;
        }

        [HttpPost]
        public Course AddCourse(Course course)
        {
            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseById(course.Course_ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }

}
