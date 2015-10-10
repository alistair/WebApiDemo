using System.Web.Http;

namespace WebApplicationPoC.DependencyResolution
{
	using System;

	using StructureMap.Configuration.DSL;
	using StructureMap.Graph;
	using StructureMap.Pipeline;
	using StructureMap.TypeRules;

	public class ControllerConvention : IRegistrationConvention
	{
		#region Public Methods and Operators

		public void Process(Type type, Registry registry)
		{
			if (type.CanBeCastTo<ApiController>() && !type.IsAbstract)
			{
				registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
			}
		}

		#endregion
	}
}