namespace DAEHA.GraphQL1st.Models;

public sealed class BidNoticeCreatePayload(BidNotice bidNotice)
{
    public BidNotice BidNotice { get; } = bidNotice;
}
