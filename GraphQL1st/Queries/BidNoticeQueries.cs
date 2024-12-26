namespace DAEHA.GraphQL1st.Queries;

public static class BidNoticeQueries
{
    [Query]
    public static async Task<IEnumerable<BidNotice>> GetBidNoticesAsync(
        [Service] BmsDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.BidNotices
            .Include(b => b.DongilCategory)
            .ToListAsync(cancellationToken);
    }
}
