using CodeCorrida.Domain.Enums;

namespace CodeCorrida.Domain.ResultApi;

public class OperationResult
{
    private static readonly OperationResult _ok = new OperationResult(OperationStatus.Ok);
    private static readonly OperationResult _failed = new OperationResult(OperationStatus.Failed);
    private static readonly OperationResult _notExist = new OperationResult(OperationStatus.NotFound);
    private static readonly OperationResult _alreadyExist = new OperationResult(OperationStatus.AlreadyExist);

    public OperationResult()
    {

    }

    public OperationResult(OperationStatus status)
    {
        Status = status;
    }

    public static OperationResult Ok => _ok;
    public static OperationResult Failed => _failed;
    public static OperationResult NotExist => _notExist;
    public static OperationResult AlreadyExist => _alreadyExist;
    public OperationStatus Status { get; set; }
    public string? Error { get; set; }

    public bool IsSuccessful
    {
        get
        {
            return Status == OperationStatus.Ok;
        }
    }

    public FileResult ToErrorFileResult()
    {
        return (FileResult)this;
    }

    public OperationResult<K> ConvertErrorResultToAnotherType<K>()
    {
        return new OperationResult<K>
        {
            Error = Error,
            Status = Status
        };
    }
}

public sealed class OperationResult<T> : OperationResult
{
    public OperationResult()
    {
    }

    public OperationResult(T? result, OperationStatus status)
    {
        Result = result;
        Status = status;
    }
    public T? Result { get; set; }
}
