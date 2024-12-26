using GreenDonut.Selectors;
using HotChocolate.Execution.Processing;

namespace DAEHA.GraphQL2nd.Types;

[ObjectType<Speaker>]
public static partial class SpeakerType
{
    [BindMember(nameof(Speaker.SessionSpeakers))]
    public static async Task<IEnumerable<Session>> GetSessionsAsync(
        [Parent] Speaker speaker,
        ISessionsBySpeakerIdDataLoader sessionsBySpeakerId,
        ISelection selection,
        CancellationToken cancellationToken)
    {
        return await sessionsBySpeakerId
            .Select(selection)
            .LoadRequiredAsync(speaker.Id, cancellationToken);
    }
}
