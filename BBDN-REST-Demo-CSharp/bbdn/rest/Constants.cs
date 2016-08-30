using System;

namespace BBDNRESTDemoCSharp
{
	public class Constants
	{
		public static string HOSTNAME = "https://daytonacollege-test.blackboard.com";
        public static string KEY = "fba6227b-65e7-4c0d-b2e3-ea82d994a15e";
        public static string SECRET = "J7hR7kFcbcwDyNnSeuDwYy6apaU5l4tj";

		public static string AUTH_PATH = "/learn/api/public/v1/oauth2/token";

		public static string DATASOURCE_PATH = "/learn/api/public/v1/dataSources";
        public static string DATASOURCE_ID = "DIAMOND-DSK";
		public static string DATASOURCE_DESCRIPTION = "Demo Data Source";

		public static string TERM_PATH = "/learn/api/public/v1/terms";
		public static string TERM_ID = "1999";
		public static string TERM_NAME = "Test";
        public static string TERM_RAW = "AugTODec";
        public static string TERM_DISPLAY = "AugTODec";

		public static string COURSE_PATH = "/learn/api/public/v1/courses";
		public static string COURSE_ID = "11002";
        public static string COURSE_NAME = "microsoft_office";
		public static string COURSE_DESCRIPTION = "microsoft office all";

        
        /*public static string USER_PATH = "/learn/api/public/v1/users";
        public static string USER_ID = "guest";
        public static string USER_NAME = "JimQueen";
        public static string USER_PASS = "Bl@ckb0ard!";
        public static string USER_FIRST = "Jim";
        public static string USER_LAST = "Queen";
        public static string USER_EMAIL = "j.queen@diamondsis.com";	*/

        public static string USER_PATH = "/learn/api/public/v1/users";
        public static string USER_ID = "guest";
        public static string USER_NAME = "nareshkumar";
        public static string USER_PASS = "12";
        public static string USER_FIRST = "Naresh";
        public static string USER_LAST = "Kumar";
        public static string USER_EMAIL = "naresh.kumarbirdo@gmail.com";


        public static string RESPONSERESULT = "FAIL";
        public static string BBTermId = string.Empty;
        public static string BBCourseId = string.Empty;
        public static string BBUserId = string.Empty;
         
    }
}

