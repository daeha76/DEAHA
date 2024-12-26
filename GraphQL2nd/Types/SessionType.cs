namespace DAEHA.GraphQL2nd.Types;

[ObjectType<Session>]
public static partial class SessionType
{
    public static TimeSpan Duration([Parent("StartTime EndTime")] Session session)
        => session.Duration;
}
