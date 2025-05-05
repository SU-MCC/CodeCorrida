namespace Modsen.CodeCorrida.Web.Domain.Entities;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
