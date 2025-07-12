using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UserManagement.APIGateway.MiddleWares
{
    public class GlobalExceptionHandling(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
        }
		private async static Task HandleExceptionAsync(HttpContext context,Exception exception)
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			ProblemDetails problemDetails = new()
			{
				Status =(int)HttpStatusCode.InternalServerError,
				Title="Internal Server error",
				Detail="An internal server error has occured. Please try again later.",
				Type="https://httpstatuses.com/500",
				Instance=context.Request.Path,
			};
			await context.Response.WriteAsJsonAsync(problemDetails);
		}
    }
}
