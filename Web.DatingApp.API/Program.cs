using Web.DatingApp.API.Web.DatingApp.IocContainer;
using Web.DatingApp.API.Web.DatingApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectDependencies(builder);

MiddlewareInjector.AddMiddleWares(builder);
