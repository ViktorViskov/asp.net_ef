Example of usage MySql /MariaDB with EF

```
var connectionString = "Server=192.168.91.80;Database=esport_dev;User Id=root;Password=Password1!;";
var serverVersion = new MariaDbServerVersion(new Version(11, 0, 3));

builder.Services.AddDbContext<eSportPortalDbContext>(options =>
{
    options.UseMySql(connectionString, serverVersion).UseMySql(connectionString, serverVersion);                
});
```
