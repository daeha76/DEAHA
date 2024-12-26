namespace DAEHA.GraphQL1st.Models;

public sealed class SpeakerCreatePayload(Speaker speaker)
{
    public Speaker Speaker { get; } = speaker;
}
