using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDNRESTDemoCSharp.bbdn.rest.helpers
{
    class CourseHelper
    {
        public static Course GenerateObject()
        {
            Course course = new Course();

           // course.externalId = Constants.COURSE_ID;
            course.courseId = Constants.COURSE_ID;
            course.name = Constants.COURSE_NAME;
            course.description = Constants.COURSE_DESCRIPTION;
            course.allowGuests = true;
            course.readOnly = false;
           //course.termId = Constants.TERM_ID;
    
            return (course);
        }
    }
}
