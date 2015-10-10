using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplicationPoC.Infrastructure
{
	public class ValidateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			HandleInvalidModelState(actionContext);
		}

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			HandleInvalidModelState(actionExecutedContext.ActionContext);
		}

		private static void HandleInvalidModelState(HttpActionContext actionContext)
		{
			if (!actionContext.ModelState.IsValid)
			{
				var response = new ErrorResponse
				{
					Code = HttpStatusCode.BadRequest.ToString(),
					Message = "Validation errors exist in the request.",
					Errors = actionContext.ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList()
				};

				actionContext.Response =
					actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, response, new JsonMediaTypeFormatter());
			}
		}
	}

	public class ErrorResponse
	{
		public string Code { get; set; }
		public string Message { get; set; }
		public List<string> Errors { get; set; }
	}
}