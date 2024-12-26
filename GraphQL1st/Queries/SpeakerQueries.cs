namespace DAEHA.GraphQL1st.Queries;

public static class SpeakerQueries
{
    [Query]
    public static async Task<IEnumerable<Speaker>> GetSpeakersAsync(
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Speakers
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
