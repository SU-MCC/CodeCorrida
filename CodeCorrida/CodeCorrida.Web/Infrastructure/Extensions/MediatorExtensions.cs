namespace CodeCorrida.Web.Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static void ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediator(o =>
        {
            o.Namespace = "CodeCorrida.Web";
            o.ServiceLifetime = ServiceLifetime.Scoped;
        });
    }
}
