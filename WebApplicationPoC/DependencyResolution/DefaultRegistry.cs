using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;
using WebApplicationPoC.DAL;

namespace WebApplicationPoC.DependencyResolution
{
	public class DefaultRegistry : Registry
	{
		public DefaultRegistry()
		{
			Scan(_ =>
			{
				_.TheCallingAssembly();
				_.WithDefaultConventions();
				_.LookForRegistries();
				_.AssemblyContainingType<DefaultRegistry>();
				_.With(new ControllerConvention());

			});
			For<ExampleContext>().Use(() => new ExampleContext("default"))
				//.OnCreation("trace sql", x => x.Database.Log = TraceSql)
				.LifecycleIs<TransientLifecycle>();
		}

		static void TraceSql(string sql)
		{
			Trace.TraceInformation(sql);
		}
	}
}