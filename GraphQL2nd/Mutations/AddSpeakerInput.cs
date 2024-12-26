namespace DAEHA.GraphQL2nd;

public sealed record AddSpeakerInput(
    string Name,
    string? Bio,
    string? Website
    );