using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ChangeDetectorComplexEntityCosmos;

public class Interceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetAuditableProperties(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        SetAuditableProperties(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    
    private void SetAuditableProperties(DbContextEventData eventData)
    {
        var context = eventData.Context;

        if (context is not null)
        {
            var entries = context.ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                Console.WriteLine($"State {entry.State}");
            }
        }
    }
}