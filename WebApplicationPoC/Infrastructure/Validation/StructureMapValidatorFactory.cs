using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationPoC.DependencyResolution;

namespace WebApplicationPoC.Infrastructure.Validation
{
	using System;
	using FluentValidation;

	public class StructureMapValidatorFactory : ValidatorFactoryBase
	{
		public override IValidator CreateInstance(Type validatorType)
		{
			return IoC.Container.TryGetInstance(validatorType) as IValidator;
		}
	}
}