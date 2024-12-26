namespace DAEHA.GraphQL1st.Models;

public sealed record SpeakerCreateRequest(
    string Name,
    string? Bio,
    string? WebSite);
