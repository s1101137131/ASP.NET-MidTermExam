using AopAlliance.Intercept;
using MvcApplication1.Models;
using System;
using System.Diagnostics;

namespace MvcApplication1.Interceptors 
{
    class UpdateCourseNameInterceptor : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {

            Console.WriteLine("UpdateCourseNameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);
            Debug.Print("UpdateCourseNameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            object result = invocation.Proceed();

            if (result is Course)
            {
                Course course = (Course)result;
                course.Course_Name = course.Course_Name + " 上面偷偷加東西";
                result = course;
            }

            return result;
        }
    }
}
