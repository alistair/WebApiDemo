using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationPoC.Features.Version
{
    public class VersionController : ApiController
    {
		[Route("version")]
		public dynamic GetVersion()
		{
			return new { Version = "1.0.0.0" };
		}
    }
}
