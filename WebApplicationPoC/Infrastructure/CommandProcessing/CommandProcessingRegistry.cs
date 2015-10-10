using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MediatR;
using StructureMap.Configuration.DSL;

namespace WebApplicationPoC.Infrastructure.CommandProcessing
{
	public class CommandProcessingRegistry : Registry
	{
		public CommandProcessingRegistry()
		{
			Scan(scan =>
			{
				scan.AssemblyContainingType<IMediator>();
				scan.AssemblyContainingType<CommandProcessingRegistry>();

				scan.AddAllTypesOf(typeof(IRequestHandler<,>));
				scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
				scan.AddAllTypesOf(typeof(IValidator<>));
				scan.WithDefaultConventions();
			});

			For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
			For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
		}
	}
}