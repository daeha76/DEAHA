namespace DAEHA.GraphQL2nd;

public sealed class AddSpeakerPayload(Speaker speaker)
{
    public Speaker Speaker { get; } = speaker;
}
