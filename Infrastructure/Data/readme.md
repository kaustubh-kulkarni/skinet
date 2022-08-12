# All about database #

-> This folder contains everything related to database and ORM

-> We use DbContext from the EFCore to derive the classes.

-> *DbContext sets up a session with the Database for quering.*
 - DbContext requires options as a parameter and here we provide it with the connection string for DB
 - We also provide the Type of context we need to send to option specified by <>
 - We also add some properties to the DbContext with the entities we have
 - The convention is **public DbSet<Entity> Its Pluralized name { get; set; }**
 - The pluralized name will be the name of the product that will be generated as a table in DB
 - **Data Context needs to be added as a service in startup class**
 - To use it we can do something like this
    - services.AddDbContext<StoreContext>(x => 
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

-> Connection string
 - Connection string is used to connect to a particular DB
 - It is in appsettings.development.json

-> Migrations using EF-Core
 - We can create the database using EF core but make sure you have
 ```
 Microsoft.EntityFrameworkCore.Design
 ```
 - Perform this command for migrations
 ```
 dotnet ef migrations add InitialMigration -o Data/Migrations
 ```
 - We can specify the output directory and the name for our migrations with this command
 - Once its is migrated we can do a database update and it will create the DB
 ```
 dotnet ef database update
 ```
 




-> **Packages used from NuGet**
```
Microsoft.EntityFrameworkCore.Sqlite