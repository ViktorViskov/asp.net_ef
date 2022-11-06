// provider for working with sqlite db
public class Db : DbContext {
    public Db(DbContextOptions<Db> options) : base(options) {}
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cityes => Set<City>();
}