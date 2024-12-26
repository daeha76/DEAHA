namespace DAEHA.GraphQL1st.Mutations;

public static class SpeakerMutations
{
    [Mutation]
    public static async Task<SpeakerCreatePayload> CreateSpeakerAsync(
        SpeakerCreateRequest input,
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        dbContext.Speakers.Add(speaker);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new SpeakerCreatePayload(speaker);
    }
}
