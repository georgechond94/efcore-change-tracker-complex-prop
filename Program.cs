// See https://aka.ms/new-console-template for more information

using ChangeDetectorComplexEntityCosmos;

await using var dbContext = new EntityContext();
await dbContext.Database.EnsureCreatedAsync();

var entity = new Entity
{
    Complex = new Complex()
};

Console.WriteLine("Adding");
dbContext.Add(entity);
await dbContext.SaveChangesAsync();

Console.WriteLine("Updating primitive property");
entity.Value = "Updated";
await dbContext.SaveChangesAsync();

Console.WriteLine("Updating complex property");
entity.Complex = new Complex
{
    Value = "Updated"
};
await dbContext.SaveChangesAsync();