namespace Dtos;

public class KafkaEventDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NameOperation { get; set; } = null!;
}
