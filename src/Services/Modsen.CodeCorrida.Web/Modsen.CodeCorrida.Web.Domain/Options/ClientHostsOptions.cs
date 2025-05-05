namespace Modsen.CodeCorrida.Web.Domain.Options;

public sealed class ClientHostsOptions
{
    public const string ConfigName = "Client:Hosts";
    
    public string Microsoft { get; set; } = null!;
    public string Front { get; set; } = null!;
    public string FrontDev { get; set; } = null!;
    public string FrontQa { get; set; } = null!;
    public string FrontStaging { get; set; } = null!;
    public string? LocalFrontHttps { get; set; }
    public string? LocalFrontHttp { get; set; }
    public string? SwaggerHttps { get; set; }
    public string? SwaggerHttp { get; set; }

    public IEnumerable<string> GetAllHosts()
    {
        yield return Microsoft;
        yield return Front;
        yield return FrontDev;
        yield return FrontQa;
        yield return FrontStaging;

        if (LocalFrontHttps is not null)
        {
            yield return LocalFrontHttps;
        }

        if (LocalFrontHttp is not null)
        {
            yield return LocalFrontHttp;
        }
        
        if (SwaggerHttps is not null)
        {
            yield return SwaggerHttps;
        }

        if (SwaggerHttp is not null)
        {
            yield return SwaggerHttp;
        }
    }
}
