dotnet tool restore
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.8

dotnet ef migrations add CoreMigration_InitialMigration --context CoreDbContext
dotnet ef database update --context CoreDbContext -- --environment {{environment}}
