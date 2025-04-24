namespace CodeCorrida.Domain.Options;

public sealed class ClientOptions
{
    public const string ConfigName = "Client";
    
    public ClientHostsOptions Hosts { get; set; } = null!;
    public ClientPathsOptions Paths { get; set; } = null!;
}
