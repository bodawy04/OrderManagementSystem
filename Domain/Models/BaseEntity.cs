namespace Domain.Models;

public class BaseEntity<Tkey>
{
    public Tkey Id { get; set; }
}
