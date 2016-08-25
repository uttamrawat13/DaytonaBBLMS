using BBDNRESTDemoCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDN_REST_Demo_CSharp
{
    public class doCourse
    {
        public async Task<Course> CreateCourse(Course newcourses)
        {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            CourseService termService = new CourseService(token);
            Course course = await termService.CreateObject(newcourses);
            return course;
        }
        public async Task<Course> UpdateCourse(Course newcourses)
        {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            CourseService termService = new CourseService(token);
            Course course = await termService.UpdateObject(newcourses);
            return course;

        }
    }
}
