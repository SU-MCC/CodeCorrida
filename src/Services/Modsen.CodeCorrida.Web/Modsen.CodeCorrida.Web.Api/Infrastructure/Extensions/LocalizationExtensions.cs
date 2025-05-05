using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class LocalizationExtensions
{
    public static void ConfigureRequestLocalization(this IApplicationBuilder app)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU")
        };

        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };

        app.UseRequestLocalization(localizationOptions);
    }
}
