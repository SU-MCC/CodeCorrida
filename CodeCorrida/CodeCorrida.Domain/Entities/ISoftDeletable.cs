namespace CodeCorrida.Domain.Entities;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
