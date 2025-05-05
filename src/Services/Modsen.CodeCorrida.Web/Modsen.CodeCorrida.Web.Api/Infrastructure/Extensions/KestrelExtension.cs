namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class KestrelExtension
{
    //1536 * 1024 * 1024 = 1.5 gb in bytes
    public const long MaxRequestBodySize = 1536 * 1024 * 1024;

    public static void ConfigureKestrel(this WebApplicationBuilder builder)
    {
        builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = MaxRequestBodySize);
    }
}
