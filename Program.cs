var builder = WebApplication.CreateBuilder(args);
// Database for opgaver
builder.Services.AddDbContext<Db>(options => {options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));});
var app = builder.Build();

// develop env
if (app.Environment.IsDevelopment()) {

    // opgaver db creating
    using var scopeOpgaverDb = app.Services.CreateScope();

    // create provider and generate db without migrations
    var opgaverDb = scopeOpgaverDb.ServiceProvider.GetRequiredService<Db>();
    opgaverDb.Database.EnsureCreated();

}

app.MapGet("/", (Db db) => {

    // new city
    var someCity = new City();
    someCity.Name = "Herning";

    // new region
    var someRegion = new Region();
    someRegion.Name = "Midt";
    someRegion.Cities = new List<City>(){someCity};

    // new country
    var someCountry = new Country();
    someCountry.Name = "Danmark";
    someCountry.Regions = new List<Region>(){someRegion};

    // add to db and save
    db.Countries.Add(someCountry);
    db.SaveChanges();

    // return json sresult
    return Results.Ok(db.Countries.Include(country => country.Regions).ThenInclude(region => region.Cities));

});

app.Run();
