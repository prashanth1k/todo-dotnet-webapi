# Todo CRUD Demo using ASP.NET Web API 

A simple Todo CRUD app using ASP.NET Web API, Entity Framework Core & SQLite.


## Run Project

```cmd
cd dat.api
dotnet run
```
Use `dotnet watch` to hot reload changes to the project.

## Migrate DB

Apply migrations to DB -
```cmd
dotnet ef database update
```

The database file is in `Db` folder.


Remember to track your own changes and create migrations -
```cmd
dotnet ef migrations add Provide_Migration_Name
```

