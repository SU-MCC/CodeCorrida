namespace CodeCorrida.Application.DTOs.MyTestEntity.Response;

public class CreateMyTestEntityResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int PropertyA { get; set; }
    public int PropertyB { get; set; }
}