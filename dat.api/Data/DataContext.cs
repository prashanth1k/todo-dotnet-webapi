namespace dat.api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite("Filename=MyDatabase.db");
    // }

    public DbSet<Todo> Todos { get; set; }
}