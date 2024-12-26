using GreenDonut.Selectors;
using HotChocolate.Execution.Processing;

namespace DAEHA.GraphQL2nd;

public class Queries
{
    [Query]
    public static async Task<IEnumerable<Speaker>> GetSpeakers(
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Speakers.AsNoTracking().ToListAsync(cancellationToken);
    }

    [Query]
    public static async Task<Speaker?> GetSpeakerAsync(
        int id,
        ISpeeakerByIdDataLoader speeakerById,
        ISelection selection,
        CancellationToken cancellationToken)
    {
        return await speeakerById.Select(selection).LoadAsync(id, cancellationToken);
    }
}
