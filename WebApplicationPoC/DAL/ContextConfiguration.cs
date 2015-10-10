using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WebApplicationPoC.DAL
{
	public class ContextConfiguration : DbConfiguration
	{
		public ContextConfiguration()
		{
			// https://msdn.microsoft.com/en-us/data/dn456835.aspx
			// DefaultExecutionStrategy:		this execution strategy does not retry any operations, 
			//									it is the default for databases other than sql server.

			// DefaultSqlExecutionStrategy:		this is an internal execution strategy that is used by default. 
			//									This strategy does not retry at all, however, it will wrap any exceptions that could be transient to inform 
			//									users that they might want to enable connection resiliency.

			// DbExecutionStrategy:				this class is suitable as a base class for other execution strategies, including your own custom ones. 
			//									It implements an exponential retry policy, where the initial retry happens with zero delay and the delay 
			//									increases exponentially until the maximum retry count is hit. This class has an abstract ShouldRetryOn method that 
			//									can be implemented in derived execution strategies to control which exceptions should be retried.

			// SqlAzureExecutionStrategy:		this execution strategy inherits from DbExecutionStrategy and will retry on exceptions that are known 
			//									to be possibly transient when working with SqlAzure.

			//Limitations: https://msdn.microsoft.com/en-us/data/dn307226
			SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
		}
	}
}