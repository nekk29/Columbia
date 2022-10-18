dotnet tool restore
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.8

dotnet ef migrations add CoreMigration_InitialMigrate --context CoreDbContext
dotnet ef database update --context CoreDbContext

dotnet ef migrations add SecurityMigration_InitialMigrate --context SecurityDbContext
dotnet ef database update --context SecurityDbContext
