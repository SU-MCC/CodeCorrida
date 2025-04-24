namespace CodeCorrida.Domain.Exceptions.LoopDetected;

public sealed class LoopDetectedException : ApplicationException
{
    public LoopDetectedException()
        : base() { }

    public LoopDetectedException(string message)
        : base(message) { }
}
