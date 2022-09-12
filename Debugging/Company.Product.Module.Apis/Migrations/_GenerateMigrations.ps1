dotnet tool restore
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.8

dotnet ef migrations add CoreMigration_001 --context CoreDbContext
dotnet ef database update --context CoreDbContext

dotnet ef migrations add SecurityMigration_001 --context SecurityDbContext
dotnet ef database update --context SecurityDbContext
