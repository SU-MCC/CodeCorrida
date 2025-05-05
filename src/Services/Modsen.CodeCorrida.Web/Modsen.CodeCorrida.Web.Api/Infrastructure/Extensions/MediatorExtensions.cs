namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static void ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediator(o =>
        {
            o.Namespace = "Modsen.CodeCorrida.Web.Api";
            o.ServiceLifetime = ServiceLifetime.Scoped;
        });
    }
}
