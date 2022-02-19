namespace Web.DatingApp.API.Web.DatingApp.Middlewares
{
    public static class MiddlewareInjector
    {
        public static void AddMiddleWares(WebApplicationBuilder builder)
        {
            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "datingapp");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://datingappng.azurewebsites.net", "http://localhost:4200", "https://datingapp-mgmt-service.azure-api.net"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
