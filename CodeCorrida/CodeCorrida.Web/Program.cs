using CodeCorrida.Infrastructure.DataAccess.DI;
using CodeCorrida.Infrastructure.Mapster;
using CodeCorrida.Web.Infrastructure;
using CodeCorrida.Web.Infrastructure.Extensions;
using CodeCorrida.Web.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.RegisterMapsterConfiguration();
builder.Services.AddClientOptions(builder.Configuration);
builder.Services.AddClientCors(builder.Configuration);

// Dependencies
builder.Services.AddDataAccessDependencies(builder.Configuration, builder.Environment);
MapsterConfig.RegisterMappingConfig();

builder.Services.ConfigureSwagger();
builder.Services.AddControllers();
                //.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.ConfigureMediator();

builder.ConfigureLogger();
builder.ConfigureKestrel();

var app = builder.Build();

app.UseMiddleware<LoggerMiddleware>();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
});

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.MigrateAndSeedDatabase();
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.DocExpansion(DocExpansion.None);
    });
}

app.ConfigureRequestLocalization();

app.Run();

public sealed partial class Program { }
