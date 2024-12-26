var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ApplicationDbContext>(option =>
    {
        option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    })
    .AddDbContext<BmsDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("BmsConnection"));
    })
    .AddGraphQLServer()
    .AddGraphQL1stTypes();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

app.Run();
