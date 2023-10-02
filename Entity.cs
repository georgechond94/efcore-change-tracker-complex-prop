namespace ChangeDetectorComplexEntityCosmos;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Value { get; set; }
    public Complex Complex { get; set; }
}

public class Complex
{
    public string Value { get; set; }
}