﻿using System;

namespace BBDNRESTDemoCSharp
{
	public class RestException
	{
		public string status { get; set; }

		public string code { get; set; }

		public string message { get; set; }

		public string developerMessage { get; set; }

		public string extraInfo { get; set; }
	}
}

