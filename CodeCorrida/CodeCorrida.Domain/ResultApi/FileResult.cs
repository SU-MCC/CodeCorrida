namespace CodeCorrida.Domain.ResultApi;

public sealed class FileResult : OperationResult
{
    public byte[] FileBytes { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string FileName { get; set; } = default!;

    public FileResult()
    {

    }

    public OperationResult ToOperationResult()
    {
        return this;
    }
}
