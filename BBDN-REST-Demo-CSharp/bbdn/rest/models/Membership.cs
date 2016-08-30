using System;

namespace BBDNRESTDemoCSharp
{
	public class Membership
	{
		public string userId { get; set; }

		public string courseId { get; set; }

		public string dataSourceId { get; set; }

		public string created { get; set; }

        public MembershipAvailability availability { get; set; }

		public string courseRoleId { get; set; }
	}
    public class MembershipAvailability
	{
		public string available { get; set; }
    }
    
}

