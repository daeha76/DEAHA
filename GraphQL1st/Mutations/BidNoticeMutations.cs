namespace DAEHA.GraphQL1st.Mutations;

public static class BidNoticeMutations
{
    [Mutation]
    public static async Task<BidNoticeCreatePayload> CreateBidNoticeAsync(
        BidNoticeCreateRequest input,
        [Service] BmsDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var bidNotice = new BidNotice
        {
            BidId = input.BidId,
            BidName = input.BidName,
        };

        dbContext.BidNotices.Add(bidNotice);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new BidNoticeCreatePayload(bidNotice);
    }
}
