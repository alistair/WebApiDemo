using System;
using System.Data.Entity;
using System.Net.Http.Formatting;
using Owin;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplicationPoC.DAL;
using WebApplicationPoC.DependencyResolution;
using WebApplicationPoC.Infrastructure;
using WebApplicationPoC.Infrastructure.Mapping;
using WebApplicationPoC.Infrastructure.Validation;

namespace WebApplicationPoC
{
	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			var container = IoC.Container;

			var config = new HttpConfiguration();
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.MapHttpAttributeRoutes();
			config.Filters.Add(new ValidateAttribute());
			config.DependencyResolver = new StructureMapResolver(container);
			FluentValidation.WebApi.FluentValidationModelValidatorProvider.Configure(config, cfx =>
			{
				cfx.ValidatorFactory = new StructureMapValidatorFactory();
			});

			appBuilder.UseWebApi(config);
			AutoMapperBootstrapper.Initialize(container);

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExampleContext, Configuration>("default"));
		}
	}
}