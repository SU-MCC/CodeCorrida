namespace Modsen.CodeCorrida.Web.Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastModifiedAt { get; set; }
}
