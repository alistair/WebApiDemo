using System.Collections.Generic;
using AutoMapper;
using StructureMap;

namespace WebApplicationPoC.Infrastructure.Mapping
{
	using System.Collections.Generic;
	using DependencyResolution;
	using AutoMapper;
	using StructureMap;

	public class AutoMapperBootstrapper
	{
		private static bool _initialized;
		private static readonly object Lock = new object();

		public static void Initialize(IContainer container)
		{
			lock (Lock)
			{
				if (_initialized) return;
				InitializeInternal(container);
				_initialized = true;
			}
		}

		private static void InitializeInternal(IContainer container)
		{
			Mapper.Initialize(cfg =>
			{
				var profileNames = new List<string>();
				foreach (var profile in container.GetAllInstances<Profile>())
				{
					profileNames.Add(profile.ProfileName);
					cfg.AddProfile(profile);
				}

				cfg.ConstructServicesUsing(container.GetInstance);
			});
		}
	}
}