namespace Web.DatingApp.API.Web.DatingApp.Middlewares
{
    public static class MiddlewareInjector
    {
        public static void AddMiddleWares(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline. 
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        } 
    }
}
