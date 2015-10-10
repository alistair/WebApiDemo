using System;
using StructureMap;

namespace WebApplicationPoC.DependencyResolution
{
	public static class IoC
	{
		private static Lazy<IContainer> Initialize = new Lazy<IContainer>(() =>
		{
			return new Container(x => x.AddRegistry<DefaultRegistry>());
		});

		public static IContainer Container { get { return Initialize.Value; } }
	}
}