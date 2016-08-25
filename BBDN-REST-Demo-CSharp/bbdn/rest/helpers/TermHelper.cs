using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDNRESTDemoCSharp;

namespace BBDNRESTDemoCSharp
{
    public class TermHelper
    {
        public static Term GenerateObject()
        {
            Term term = new Term();
            Availability availability = new Availability();
            Duration duration = new Duration();
            duration.type = "DateRange";
            duration.start = "2016-08-16T04:00:00.000Z";
            duration.end = "2017-02-17T04:59:59.000Z";
            availability.available = "Yes";
            availability.duration = duration;
            //term.id = "_25_2";
            term.externalId = "ar";
            term.name = "REST Python Demo Term Third";// Constants.TERM_NAME;
            term.description = "Term used for REST Python demo"; //Constants.TERM_DISPLAY;
            term.availability = availability;
            /*Term term = new Term();
            Availability availability = new Availability();
            Duration duration = new Duration();
            duration.type = "continuous";
           // duration.start = "2016-08-16T04:00:00.000Z";
           // duration.end = "2017-02-17T04:59:59.000Z";
            availability.available = "Yes";
            availability.duration = duration;
            //term.id = "_25_2";
            term.externalId = "ab";
            term.name = "REST Python Demo Term second";// Constants.TERM_NAME;
            term.description = "Term used for REST Python demo"; //Constants.TERM_DISPLAY;
            term.availability = availability;*/

            return term;
        }

    }
}
