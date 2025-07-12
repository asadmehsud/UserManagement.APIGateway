using UserManagement.APIGateway.MiddleWares;

namespace UserManagement.APIGateway.Extensions
{
    public static class MiddlewaresExtension
    {
        public static WebApplication AddMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/vvv/swagger.json", "User Management Api v1");
                    options.RoutePrefix = string.Empty;
                });
                app.MapOpenApi();
            }
            //app.UseMiddleware<GlobalExceptionHandling>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
