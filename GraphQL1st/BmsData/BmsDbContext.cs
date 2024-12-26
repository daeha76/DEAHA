namespace DAEHA.GraphQL1st.BmsData;

public sealed class BmsDbContext(DbContextOptions<BmsDbContext> options)
    : DbContext(options)
{
    public DbSet<BidNotice> BidNotices { get; init; }
    public DbSet<ZMasterCode> ZMasterCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BidNotice>()
            .HasOne(b => b.DongilCategory)
            .WithMany()
            .HasForeignKey(b => b.DongilCategoryCode)
            .HasPrincipalKey(z => z.MCode);
    }
}
